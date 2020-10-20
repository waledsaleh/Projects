package com.usermanagement.demo.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)

public class UserFirstNameIsEmptyException extends RuntimeException {
    public UserFirstNameIsEmptyException() {
        super();
    }

    public UserFirstNameIsEmptyException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserFirstNameIsEmptyException(String message) {
        super(message);
    }

    public UserFirstNameIsEmptyException(Throwable cause) {
        super(cause);
    }
}
