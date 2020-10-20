package com.usermanagement.demo.controller;

import com.usermanagement.demo.dto.UserCreationDTO;
import com.usermanagement.demo.dto.UserLoginDTO;
import com.usermanagement.demo.dto.UserPasswordDTO;
import com.usermanagement.demo.dto.UserResponseDTO;
import com.usermanagement.demo.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@RestController
public class UserController {

    @Autowired
    private UserService userService;

    @PostMapping("/login")
    public UserResponseDTO login(@RequestBody UserLoginDTO userDTO) throws Exception {
        System.out.println("login");
        return userService.loginUser(userDTO.getUsername(), userDTO.getPassword());

    }

    @PostMapping("/sign-up")
    public String signUp(@RequestBody UserCreationDTO userCreationDTO) {
        userService.signUpUser(userCreationDTO);
        return "redirect:/login";
    }


    @PostMapping(value = "/logout-user")
    @PreAuthorize("hasRole('ROLE_USER')")
    public String logout(HttpServletRequest request, HttpServletResponse response, @RequestParam Long userId) {
        this.userService.handleLogOut(request, response, userId);
        return "redirect:/login";
    }


    @PostMapping("/user/resetPassword")
    public ResponseEntity<String> resetPassword(HttpServletRequest request,
                                        @RequestParam("username") String userEmail) {

        return this.userService.resetPassword(userEmail);

    }

    @GetMapping("/change-password")
    public String showChangePasswordPage(@RequestParam("token") String token) {

        return this.userService.viewPasswordPage(token);
    }

    @PostMapping("/update-password")
    public ResponseEntity<String> savePassword(@RequestBody UserPasswordDTO userPasswordDTO) {

        return this.userService.changePassword(userPasswordDTO);
    }
}
