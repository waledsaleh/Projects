package com.usermanagement.demo.service;


import com.usermanagement.demo.dao.CategoryRepository;
import com.usermanagement.demo.entity.Category;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Set;

@Service
public class CategoryService {

    @Autowired
    private CategoryRepository categoryRepository;

    public void saveCategory(Set<Category> categories) {
        categoryRepository.saveAll(categories);
    }
}
