package com.usermanagement.demo.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)
public class UserPasswordLengthException extends RuntimeException {
    public UserPasswordLengthException() {
        super();
    }

    public UserPasswordLengthException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserPasswordLengthException(String message) {
        super(message);
    }

    public UserPasswordLengthException(Throwable cause) {
        super(cause);
    }
}
