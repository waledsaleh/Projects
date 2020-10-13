package com.deaftube.project.dao;

import com.deaftube.project.entity.Contact;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ContactUsDao extends JpaRepository<Contact, Long> {
}
