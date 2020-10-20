package com.deaftube.project.service;

import com.deaftube.project.IService.IConfirmationToken;
import com.deaftube.project.IService.IUser;
import com.deaftube.project.bean.AuthenticationBean;
import com.deaftube.project.dao.UserDao;
import com.deaftube.project.dto.UserRegistrationDTO;
import com.deaftube.project.entity.ConfirmationToken;
import com.deaftube.project.entity.User;
import com.deaftube.project.exception.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;

@Service
public class UserService implements IUser {

    @Autowired
    private UserDao userDao;

    @Autowired
    private BCryptPasswordEncoder bCryptPasswordEncoder;

    @Autowired
    private IConfirmationToken confirmationTokenInterface;

    @Override
    public AuthenticationBean userAuthentication(String email, String password) {

        User userDb = userDao.findByEmail(email);

        if (StringUtils.isEmpty(email))
            throw new UserEmailIsEmptyException("User email is empty/null");

        if (email.length() < 1 || email.length() > 100)
            throw new UserEmailLengthException("Email is not in range (1 - 100)");

        if (StringUtils.isEmpty(password))
            throw new UserPasswordIsEmptyException("User password is empty/null");

        if (password.length() < 10 || password.length() > 50)
            throw new UserPasswordLengthException("User password is not in range (10 - 50)");

        if (userDb == null)
            throw new UserEmailNotExistException("User Email is not exist");

        String encodedPassword = bCryptPasswordEncoder.encode(password);
//
//        if (userDao.findByPassword(encodedPassword) == null)
//            throw new UserPasswordIsNotExistException("Email is exist, but password is wrong");

        // User userDb = userDao.findByEmailAndPassword(email, encodedPassword);

//         if (!bCryptPasswordEncoder.matches(password, encodedPassword))
//             throw new UserPasswordIsNotMatchedException("Email is exist, but password is wrong");

//        if (userDb == null)
//            throw new UserNotFoundException("Invalid Credentials");

        if (!userDb.getEnabled())
            throw new UserIsNotEnabledException("User is not enabled");

        return new AuthenticationBean("You are authenticated");
    }

    @Override
    public void signUpUser(UserRegistrationDTO userRegistrationDTO) {
        if (userDao.findByEmail(userRegistrationDTO.getEmail()) != null)
            throw new UserIsAlreadyExistException("There is already an account registered with that email");

        if (!userRegistrationDTO.getEmail().equals(userRegistrationDTO.getConfirmEmail()))
            throw new UserEmailNotEqualConfirmEmailException("User email is not equal confirm email");

        if (!userRegistrationDTO.getPassword().equals(userRegistrationDTO.getConfirmPassword()))
            throw new UserPasswordNotEqualConfirmPassword("User password is not equal confirm password");

        User user = new User();
        user.setEmail(userRegistrationDTO.getEmail());
        user.setPassword(bCryptPasswordEncoder.encode(userRegistrationDTO.getPassword()));

        User createdUser = userDao.save(user);

        ConfirmationToken confirmationToken = new ConfirmationToken(createdUser);

        confirmationTokenInterface.saveConfirmationToken(confirmationToken);


    }

    @Override
    public void confirmUser(ConfirmationToken confirmationToken) {
        User user = confirmationToken.getUser();

        user.setEnabled(true);

        userDao.save(user);

        confirmationTokenInterface.deleteConfirmationToken(confirmationToken.getId());
    }

    //ToDo: Implement Send mail to user to confirm

}
