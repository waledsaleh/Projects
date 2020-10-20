package com.usermanagement.demo.controller;


import com.usermanagement.demo.dto.CreateProductDTO;
import com.usermanagement.demo.dto.ProductDetailsDTO;
import com.usermanagement.demo.dto.UserProductDetailsDTO;
import com.usermanagement.demo.service.ProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ProductController {

    @Autowired
    private ProductService productService;

    @PostMapping("/create-product")
    @PreAuthorize("hasRole('ROLE_USER')")
    public ResponseEntity<String> createProduct(@RequestBody CreateProductDTO createProductDTO) {

        this.productService.saveProduct(createProductDTO);
        return new ResponseEntity<>("Created product", HttpStatus.CREATED);
    }

    @GetMapping("/get-product")
    @PreAuthorize("hasRole('ROLE_USER')")
    public ProductDetailsDTO getProductById(@RequestParam Long productId) {
        return this.productService.getProductById(productId);
    }

    @GetMapping("/view-product")
    @PreAuthorize("hasRole('ROLE_USER')")
    public List<UserProductDetailsDTO> getUserProducts() {

        return this.productService.getUserProducts();
    }

}
