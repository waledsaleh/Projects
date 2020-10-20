package com.usermanagement.demo.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.FOUND)
public class UserIsAlreadyExistException extends RuntimeException {
    public UserIsAlreadyExistException() {
        super();
    }

    public UserIsAlreadyExistException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserIsAlreadyExistException(String message) {
        super(message);
    }

    public UserIsAlreadyExistException(Throwable cause) {
        super(cause);
    }

}
