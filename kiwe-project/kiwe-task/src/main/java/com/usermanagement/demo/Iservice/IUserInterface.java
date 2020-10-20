package com.usermanagement.demo.Iservice;

import com.usermanagement.demo.dto.UserCreationDTO;
import com.usermanagement.demo.dto.UserResponseDTO;

public interface IUserInterface {

    UserResponseDTO loginUser(String username, String password);

    void signUpUser(UserCreationDTO userCreationDTO);


}
