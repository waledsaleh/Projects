package com.usermanagement.demo.service;

import com.usermanagement.demo.dao.UserRepository;
import com.usermanagement.demo.dto.UserCreationDTO;
import com.usermanagement.demo.dto.UserPasswordDTO;
import com.usermanagement.demo.dto.UserResponseDTO;
import com.usermanagement.demo.entity.PasswordResetToken;
import com.usermanagement.demo.entity.UserEntity;
import com.usermanagement.demo.exception.*;
import com.usermanagement.demo.utility.JwtUtility;
import org.apache.commons.validator.routines.EmailValidator;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.DisabledException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.web.authentication.logout.SecurityContextLogoutHandler;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.util.ArrayList;
import java.util.UUID;

@Service
public class UserService implements UserDetailsService {
    final Logger LOGGER = LoggerFactory.getLogger(getClass());

    @Autowired
    private UserRepository userRepository;

    @Autowired
    private BCryptPasswordEncoder bCryptPasswordEncoder;

    private EmailValidator validator = EmailValidator.getInstance();

    @Autowired
    private PasswordTokenService passwordTokenService;

    @Autowired
    private AuthenticationManager authenticationManager;

    @Autowired
    private EmailService emailService;

    public UserResponseDTO loginUser(String username, String password) throws Exception {

        if (StringUtils.isEmpty(username))
            throw new UserEmailIsEmptyException("User email is empty/null");

        if (username.length() < 1 || username.length() > 100)
            throw new UserEmailLengthException("Email is not in range (1 - 100)");

//        if (validator.isValid(username))
//            throw new UserEmailIsNotValidException("User email is not valid");

        if (StringUtils.isEmpty(password))
            throw new UserPasswordIsEmptyException("User password is empty/null");

        if (password.length() < 10 || password.length() > 50)
            throw new UserPasswordLengthException("User password is not in range (10 - 50)");

        authenticate(username, password);

        UserDetails userDetails = loadUserByUsername(username);

        UserEntity userEntity = this.userRepository.findByUsername(userDetails.getUsername());

        UserResponseDTO userResponseDTO = new UserResponseDTO();
        userResponseDTO.setUsername(userDetails.getUsername());
        userResponseDTO.setToken(JwtUtility.getJWTToken(username));
        userResponseDTO.setAge(userEntity.getAge());
        userResponseDTO.setFirstName(userEntity.getFirstName());
        userResponseDTO.setLastName(userEntity.getLastName());
        userResponseDTO.setPassword(userEntity.getPassword());

        return userResponseDTO;
    }


    public void signUpUser(UserCreationDTO userCreationDTO) {

        if (userRepository.findByUsername(userCreationDTO.getUsername()) != null)
            throw new UserIsAlreadyExistException("There is already an account registered with that email");

        if (userCreationDTO.getAge() < 18)
            throw new AgeLimitException("Age must be greater than or equal 18");

        UserEntity user = new UserEntity();
        user.setUsername(userCreationDTO.getUsername());
        user.setPassword(bCryptPasswordEncoder.encode(userCreationDTO.getPassword()));
        user.setFirstName(userCreationDTO.getFirstName());
        user.setLastName(userCreationDTO.getLastName());
        user.setAge(userCreationDTO.getAge());

        userRepository.save(user);
    }


    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        UserEntity userDb = this.userRepository.findByUsername(username);

        if (userDb == null)
            throw new UserNotFoundException("User Not found in db");

        return new User(username, userDb.getPassword(), new ArrayList<>());
    }

    private void authenticate(String username, String password) throws Exception {
        try {
            authenticationManager.authenticate(new UsernamePasswordAuthenticationToken(username, password));
        } catch (DisabledException e) {
            throw new Exception("USER_DISABLED", e);
        } catch (BadCredentialsException e) {
            throw new Exception("INVALID_CREDENTIALS", e);
        }
    }

    public void handleLogOut(HttpServletRequest request, HttpServletResponse response, Long userId) {

        System.out.println(userId);

        UserEntity userEntity = this.userRepository.findUserEntityById(userId);
        if (userEntity == null)
            throw new UserNotFoundException("Current user is not found");

        Authentication auth = SecurityContextHolder.getContext().getAuthentication();
        if (auth != null) {
            new SecurityContextLogoutHandler().logout(request, response, auth);
        }

    }

    public ResponseEntity<String> resetPassword(String userEmail) {
        UserEntity user = this.userRepository.findByUsername(userEmail);
        if (user == null) {
            throw new UserNotFoundException();
        }
        String token = UUID.randomUUID().toString();
        createPasswordResetTokenForUser(user, token);
        //we need to configure username Email and password for SMTP to test this api
        // emailService.send("http://localhost:8080", token, user);
        return new ResponseEntity("reset password", HttpStatus.OK);
    }

    public void createPasswordResetTokenForUser(UserEntity user, String token) {
        passwordTokenService.saveToken(token, user);
    }


    public String viewPasswordPage(String token) {
        String result = passwordTokenService.validatePasswordResetToken(token);

        if (result != null) {
            return "redirect:/login";
        } else {

            return "redirect:/update-password";
        }

    }

    public ResponseEntity<String> changePassword(UserPasswordDTO userPasswordDTO) {
        String result = passwordTokenService.validatePasswordResetToken(userPasswordDTO.getToken());

        if (result != null) {
            return new ResponseEntity("auth.message." + result, HttpStatus.OK);
        }

        PasswordResetToken passwordResetToken = passwordTokenService.getUserByToken(userPasswordDTO.getToken());

        UserEntity userEntity = passwordResetToken.getUser();

        if (userEntity != null) {
            changeUserPassword(userEntity, userPasswordDTO.getNewPassword());
            return new ResponseEntity("reset password success", HttpStatus.OK);
        } else {
            return new ResponseEntity("auth.message.invalid", HttpStatus.CONFLICT);
        }
    }

    public void changeUserPassword(UserEntity user, String password) {
        user.setPassword(bCryptPasswordEncoder.encode(password));
        userRepository.save(user);
    }

    public UserEntity getByUserId(Long id) {
        return this.userRepository.findUserEntityById(id);
    }

    public UserEntity findByUsername(String username){
        return userRepository.findByUsername(username);
    }

}
