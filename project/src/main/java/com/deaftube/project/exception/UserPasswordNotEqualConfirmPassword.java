package com.deaftube.project.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)
public class UserPasswordNotEqualConfirmPassword extends RuntimeException {
    public UserPasswordNotEqualConfirmPassword() {
        super();
    }

    public UserPasswordNotEqualConfirmPassword(String message, Throwable cause) {
        super(message, cause);
    }

    public UserPasswordNotEqualConfirmPassword(String message) {
        super(message);
    }

    public UserPasswordNotEqualConfirmPassword(Throwable cause) {
        super(cause);
    }
}
