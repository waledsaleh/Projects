package com.deaftube.project.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)
public class ContactNameIsEmptyException extends RuntimeException {
    public ContactNameIsEmptyException() {
        super();
    }

    public ContactNameIsEmptyException(String message, Throwable cause) {
        super(message, cause);
    }

    public ContactNameIsEmptyException(String message) {
        super(message);
    }

    public ContactNameIsEmptyException(Throwable cause) {
        super(cause);
    }
}
