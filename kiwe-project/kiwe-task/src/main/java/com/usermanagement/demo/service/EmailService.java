package com.usermanagement.demo.service;

import com.usermanagement.demo.entity.UserEntity;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Service;

@Service
public class EmailService {

    @Value("${email.user}")
    private String emailFromName;

    @Autowired
    private JavaMailSender javaMailSender;

    private SimpleMailMessage constructResetTokenEmail(
            String contextPath, String token, UserEntity user) {
        String url = contextPath + "/change-password?token=" + token;
        String message = "message.resetPassword";

        return constructEmail("Reset Password", message + " \r\n" + url, user);
    }

    public SimpleMailMessage constructEmail(String subject, String body,
                                            UserEntity user) {
        SimpleMailMessage email = new SimpleMailMessage();
        email.setSubject(subject);
        email.setText(body);
        email.setTo(user.getUsername());
        email.setFrom(emailFromName);
        return email;
    }

    public void send(String appUrl, String token, UserEntity userEntity) {
        javaMailSender.send(constructResetTokenEmail(appUrl, token, userEntity));
    }

}
