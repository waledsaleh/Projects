package com.deaftube.project.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.NOT_FOUND)
public class UserEmailNotExistException extends RuntimeException {
    public UserEmailNotExistException() {
        super();
    }

    public UserEmailNotExistException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserEmailNotExistException(String message) {
        super(message);
    }

    public UserEmailNotExistException(Throwable cause) {
        super(cause);
    }
}
