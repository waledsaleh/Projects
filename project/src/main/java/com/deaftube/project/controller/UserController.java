package com.deaftube.project.controller;


import com.deaftube.project.IService.IConfirmationToken;
import com.deaftube.project.IService.IUser;
import com.deaftube.project.bean.AuthenticationBean;
import com.deaftube.project.dto.UserDTO;
import com.deaftube.project.dto.UserRegistrationDTO;
import com.deaftube.project.entity.ConfirmationToken;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping("/auth")
public class UserController {

    @Autowired
    private IUser userInterface;

    @Autowired
    private IConfirmationToken confirmationToken;

    @RequestMapping(method = RequestMethod.POST, value = "/sign-in")
    public AuthenticationBean basicAuth(@RequestBody UserDTO userDTO) {
        System.out.println(userDTO.toString());
        return userInterface.userAuthentication(userDTO.getUsername(), userDTO.getPassword());
    }

    @RequestMapping(method = RequestMethod.POST, value = "/sign-up")
    public String signUp(@RequestBody UserRegistrationDTO userRegistrationDTO) {
        userInterface.signUpUser(userRegistrationDTO);
        return "redirect:/sign-in";
    }

    @GetMapping("/confirm")
    String confirmMail(@RequestParam("token") String token) {

        Optional<ConfirmationToken> optionalConfirmationToken = confirmationToken.findConfirmationTokenByToken(token);
        optionalConfirmationToken.ifPresent(userInterface::confirmUser);

        return "/sign-in";
    }
}
