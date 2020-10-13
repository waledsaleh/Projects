package com.deaftube.project.controller;

import com.deaftube.project.IService.IContactUs;
import com.deaftube.project.dto.ContactUsDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ContactUsController {
    @Autowired
    private IContactUs contactUs;

    @RequestMapping(method = RequestMethod.POST, value = "/contact-us")
    public void contactUs(@RequestBody ContactUsDTO contactUsDTO) {

        contactUs.saveContact(contactUsDTO);
    }
}
