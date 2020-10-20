package com.usermanagement.demo.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)

public class UserPasswordIsEmptyException extends RuntimeException {
    public UserPasswordIsEmptyException() {
        super();
    }

    public UserPasswordIsEmptyException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserPasswordIsEmptyException(String message) {
        super(message);
    }

    public UserPasswordIsEmptyException(Throwable cause) {
        super(cause);
    }

}
