package com.usermanagement.demo.service;

import com.usermanagement.demo.dao.PasswordTokenRepository;
import com.usermanagement.demo.entity.PasswordResetToken;
import com.usermanagement.demo.entity.UserEntity;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Calendar;

@Service
public class PasswordTokenService {

    @Autowired
    private PasswordTokenRepository passwordTokenRepository;

    public String validatePasswordResetToken(String token) {
        PasswordResetToken passToken = passwordTokenRepository.findByToken(token);

//        return !isTokenFound(passToken) ? "invalidToken"
////                : isTokenExpired(passToken) ? "expired"
////                : null;
        return !isTokenFound(passToken) ? "InvalidToken" : null;
    }

    private boolean isTokenFound(PasswordResetToken passToken) {
        return passToken != null;
    }

    private boolean isTokenExpired(PasswordResetToken passToken) {
        final Calendar cal = Calendar.getInstance();
        return passToken.getExpiryDate().before(cal.getTime());
    }

    public void saveToken(String token, UserEntity user) {

        PasswordResetToken myToken = new PasswordResetToken(token, user);
        this.passwordTokenRepository.save(myToken);
    }

    public PasswordResetToken getUserByToken(String token) {
        return this.passwordTokenRepository.findByToken(token);
    }

}
