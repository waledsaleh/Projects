package com.deaftube.project.service;

import com.deaftube.project.IService.IConfirmationToken;
import com.deaftube.project.dao.ConfirmationTokenDao;
import com.deaftube.project.entity.ConfirmationToken;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
public class ConfirmationTokenService implements IConfirmationToken {

    @Autowired
    private ConfirmationTokenDao confirmationTokenDao;

    @Override
    public void saveConfirmationToken(ConfirmationToken confirmationToken) {
        confirmationTokenDao.save(confirmationToken);
    }

    @Override
    public Optional<ConfirmationToken> findConfirmationTokenByToken(String token) {
        return confirmationTokenDao.findByConfirmationToken(token);
    }

    @Override
    public void deleteConfirmationToken(Long id) {
        confirmationTokenDao.deleteById(id);
    }
}
