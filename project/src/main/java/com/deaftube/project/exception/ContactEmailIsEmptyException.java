package com.deaftube.project.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)
public class ContactEmailIsEmptyException extends RuntimeException {
    public ContactEmailIsEmptyException() {
        super();
    }

    public ContactEmailIsEmptyException(String message, Throwable cause) {
        super(message, cause);
    }

    public ContactEmailIsEmptyException(String message) {
        super(message);
    }

    public ContactEmailIsEmptyException(Throwable cause) {
        super(cause);
    }
}
