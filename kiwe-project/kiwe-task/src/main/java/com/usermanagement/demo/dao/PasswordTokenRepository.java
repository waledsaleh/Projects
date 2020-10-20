package com.usermanagement.demo.dao;

import com.usermanagement.demo.entity.PasswordResetToken;
import com.usermanagement.demo.entity.UserEntity;
import org.springframework.data.repository.CrudRepository;

public interface PasswordTokenRepository  extends CrudRepository<PasswordResetToken,Long>{

    PasswordResetToken findByToken(String token);

}
