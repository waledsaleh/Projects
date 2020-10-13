package com.deaftube.project.service;

import com.deaftube.project.IService.IContactUs;
import com.deaftube.project.dao.ContactUsDao;
import com.deaftube.project.dto.ContactUsDTO;
import com.deaftube.project.entity.Contact;
import com.deaftube.project.exception.ContactEmailIsEmptyException;
import com.deaftube.project.exception.ContactMessageIsEmptyException;
import com.deaftube.project.exception.ContactNameIsEmptyException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;

@Service
public class ContactUsService implements IContactUs {
    @Autowired
    private ContactUsDao contactUsDao;

    @Override
    public void saveContact(ContactUsDTO contactUsDTO) {

        if (StringUtils.isEmpty(contactUsDTO.getName()))
            throw new ContactNameIsEmptyException("Contact name is empty/null");

        if (StringUtils.isEmpty(contactUsDTO.getEmail()))
            throw new ContactEmailIsEmptyException("Contact email is empty/null");

        if (StringUtils.isEmpty(contactUsDTO.getMessage()))
            throw new ContactMessageIsEmptyException("Contact message is empty/null");

        Contact contact = new Contact();
        contact.setEmail(contactUsDTO.getEmail());
        contact.setMessage(contactUsDTO.getMessage());
        contact.setName(contactUsDTO.getName());

        contactUsDao.save(contact);
    }
}
