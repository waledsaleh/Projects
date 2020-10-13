package com.deaftube.project.IService;

import com.deaftube.project.bean.AuthenticationBean;
import com.deaftube.project.dto.UserRegistrationDTO;
import com.deaftube.project.entity.ConfirmationToken;

public interface IUser {

    AuthenticationBean userAuthentication(String email, String password);

    void signUpUser(UserRegistrationDTO userRegistrationDTO);

    void confirmUser(ConfirmationToken confirmationToken);
}
