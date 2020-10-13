package com.deaftube.project.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)
public class ContactMessageIsEmptyException extends RuntimeException {
    public ContactMessageIsEmptyException() {
        super();
    }

    public ContactMessageIsEmptyException(String message, Throwable cause) {
        super(message, cause);
    }

    public ContactMessageIsEmptyException(String message) {
        super(message);
    }

    public ContactMessageIsEmptyException(Throwable cause) {
        super(cause);
    }
}
