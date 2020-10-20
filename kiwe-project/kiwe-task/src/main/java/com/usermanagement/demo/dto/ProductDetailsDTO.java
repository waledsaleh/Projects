package com.usermanagement.demo.dto;

import com.usermanagement.demo.entity.Category;

import java.io.Serializable;
import java.util.List;
import java.util.Set;

public class ProductDetailsDTO implements Serializable {

    private String name;
    private Set<String> categories;
    private Integer quantity;
    private String username;

    public ProductDetailsDTO() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Set<String> getCategories() {
        return categories;
    }

    public void setCategories(Set<String> categories) {
        this.categories = categories;
    }

    public Integer getQuantity() {
        return quantity;
    }

    public void setQuantity(Integer quantity) {
        this.quantity = quantity;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
