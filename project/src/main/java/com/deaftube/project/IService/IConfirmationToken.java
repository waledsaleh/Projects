package com.deaftube.project.IService;

import com.deaftube.project.entity.ConfirmationToken;

import java.util.Optional;

public interface IConfirmationToken {
    void saveConfirmationToken(ConfirmationToken confirmationToken);

    Optional<ConfirmationToken> findConfirmationTokenByToken(String token);

    void deleteConfirmationToken(Long id);
}
