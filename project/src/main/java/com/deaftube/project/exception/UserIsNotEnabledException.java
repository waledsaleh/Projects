package com.deaftube.project.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)
public class UserIsNotEnabledException extends RuntimeException {
    public UserIsNotEnabledException() {
        super();
    }

    public UserIsNotEnabledException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserIsNotEnabledException(String message) {
        super(message);
    }

    public UserIsNotEnabledException(Throwable cause) {
        super(cause);
    }
}
