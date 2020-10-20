package com.usermanagement.demo.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.NOT_FOUND)
public class UserPasswordIsNotMatchedException extends RuntimeException {
    public UserPasswordIsNotMatchedException() {
        super();
    }

    public UserPasswordIsNotMatchedException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserPasswordIsNotMatchedException(String message) {
        super(message);
    }

    public UserPasswordIsNotMatchedException(Throwable cause) {
        super(cause);
    }
}
