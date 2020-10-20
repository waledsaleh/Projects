package com.usermanagement.demo.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)

public class UserEmailIsNotValidException extends RuntimeException {
    public UserEmailIsNotValidException() {
        super();
    }

    public UserEmailIsNotValidException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserEmailIsNotValidException(String message) {
        super(message);
    }

    public UserEmailIsNotValidException(Throwable cause) {
        super(cause);
    }
}
