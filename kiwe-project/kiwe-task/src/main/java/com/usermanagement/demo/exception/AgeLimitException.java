package com.usermanagement.demo.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.CONFLICT)

public class AgeLimitException extends RuntimeException {
    public AgeLimitException() {
        super();
    }

    public AgeLimitException(String message, Throwable cause) {
        super(message, cause);
    }

    public AgeLimitException(String message) {
        super(message);
    }

    public AgeLimitException(Throwable cause) {
        super(cause);
    }

}
