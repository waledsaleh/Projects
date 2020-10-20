package com.usermanagement.demo.dao;


import com.usermanagement.demo.entity.UserEntity;
import org.springframework.data.repository.CrudRepository;
import org.springframework.security.core.userdetails.User;
import org.springframework.stereotype.Repository;

@Repository
public interface UserRepository extends CrudRepository<UserEntity,Long> {

    UserEntity findByUsername(String username);
    UserEntity findUserEntityById(Long id);
}
