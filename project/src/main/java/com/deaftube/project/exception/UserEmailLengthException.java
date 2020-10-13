package com.deaftube.project.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)
public class UserEmailLengthException extends RuntimeException {
    public UserEmailLengthException() {
        super();
    }

    public UserEmailLengthException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserEmailLengthException(String message) {
        super(message);
    }

    public UserEmailLengthException(Throwable cause) {
        super(cause);
    }
}
