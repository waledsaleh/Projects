package com.usermanagement.demo.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)
public class UserEmailIsEmptyException extends RuntimeException {
    public UserEmailIsEmptyException() {
        super();
    }

    public UserEmailIsEmptyException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserEmailIsEmptyException(String message) {
        super(message);
    }

    public UserEmailIsEmptyException(Throwable cause) {
        super(cause);
    }
}
