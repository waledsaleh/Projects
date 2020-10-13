package com.deaftube.project.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)
public class UserEmailNotEqualConfirmEmailException extends RuntimeException {
    public UserEmailNotEqualConfirmEmailException() {
        super();
    }

    public UserEmailNotEqualConfirmEmailException(String message, Throwable cause) {
        super(message, cause);
    }

    public UserEmailNotEqualConfirmEmailException(String message) {
        super(message);
    }

    public UserEmailNotEqualConfirmEmailException(Throwable cause) {
        super(cause);
    }
}
