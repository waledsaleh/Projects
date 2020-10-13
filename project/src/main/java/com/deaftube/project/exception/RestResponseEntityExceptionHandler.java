package com.deaftube.project.exception;

import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.context.request.WebRequest;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

@ControllerAdvice
public class RestResponseEntityExceptionHandler extends ResponseEntityExceptionHandler {

    @ExceptionHandler(value
            = {UserNotFoundException.class, UserEmailNotExistException.class})
    protected ResponseEntity<Object> handleUserNotFound(
            RuntimeException ex, WebRequest request) {
        String bodyOfResponse = ex.getMessage();
        return handleExceptionInternal(ex, bodyOfResponse,
                new HttpHeaders(), HttpStatus.NOT_FOUND, request);
    }

    @ExceptionHandler(value
            = {UserEmailIsEmptyException.class, UserEmailLengthException.class, UserPasswordIsEmptyException.class,
            UserPasswordLengthException.class, ContactEmailIsEmptyException.class, ContactMessageIsEmptyException.class,
            ContactNameIsEmptyException.class, UserIsNotEnabledException.class, UserPasswordNotEqualConfirmPassword.class,
            UserEmailNotEqualConfirmEmailException.class, UserPasswordIsNotMatchedException.class})
    protected ResponseEntity<Object> handleUserEmailWithPassword(
            RuntimeException ex, WebRequest request) {
        String bodyOfResponse = ex.getMessage();
        return handleExceptionInternal(ex, bodyOfResponse,
                new HttpHeaders(), HttpStatus.CONFLICT, request);
    }

    @ExceptionHandler(value
            = {UserIsAlreadyExistException.class})
    protected ResponseEntity<Object> handleUserFound(
            RuntimeException ex, WebRequest request) {
        String bodyOfResponse = ex.getMessage();
        return handleExceptionInternal(ex, bodyOfResponse,
                new HttpHeaders(), HttpStatus.FOUND, request);
    }
}
