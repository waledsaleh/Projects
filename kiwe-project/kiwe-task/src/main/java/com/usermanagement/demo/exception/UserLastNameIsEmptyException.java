package com.usermanagement.demo.exception;


import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)

public class UserLastNameIsEmptyException extends RuntimeException {
    public UserLastNameIsEmptyException() {
        super();
    }

    public UserLastNameIsEmptyException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserLastNameIsEmptyException(String message) {
        super(message);
    }

    public UserLastNameIsEmptyException(Throwable cause) {
        super(cause);
    }
}
