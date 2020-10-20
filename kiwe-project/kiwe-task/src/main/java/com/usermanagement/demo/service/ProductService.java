package com.usermanagement.demo.service;

import com.usermanagement.demo.dao.ProductRepository;
import com.usermanagement.demo.dto.CreateProductDTO;
import com.usermanagement.demo.dto.ProductDetailsDTO;
import com.usermanagement.demo.dto.UserProductDetailsDTO;
import com.usermanagement.demo.entity.Category;
import com.usermanagement.demo.entity.Image;
import com.usermanagement.demo.entity.Product;
import com.usermanagement.demo.entity.UserEntity;
import com.usermanagement.demo.exception.ProductNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@Service
public class ProductService {

    @Autowired
    private ProductRepository productRepository;

    @Autowired
    private UserService userService;

    @Autowired
    private CategoryService categoryService;

    public void saveProduct(CreateProductDTO createProductDTO) {

        Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();

        String username;
        if (principal instanceof UserDetails)
            username = ((UserDetails) principal).getUsername();
        else
            username = principal.toString();

        UserEntity userEntity = this.userService.findByUsername(username);

        Product product = new Product();
        product.setUser(userEntity);
        product.setName(createProductDTO.getName());
        product.setQuantity(createProductDTO.getQuantity());

        Set<Image> images = new HashSet<>();

        for (String str : createProductDTO.getImages()) {
            Image img = new Image();
            img.setPath(str);
            img.setProduct(product);

            images.add(img);
        }

        Category category = new Category();
        category.setName(createProductDTO.getCategory());
        Set<Category> categories = new HashSet<>();
        categories.add(category);

        this.categoryService.saveCategory(categories);
        product.setImages(images);
        product.setCategories(categories);
        this.productRepository.save(product);
    }

    public ProductDetailsDTO getProductById(Long productId) {

        Product product = this.productRepository.findProductById(productId);
        if (product == null)
            throw new ProductNotFoundException("Product not found");

        ProductDetailsDTO productDetailsDTO = new ProductDetailsDTO();
        productDetailsDTO.setName(product.getName());
        productDetailsDTO.setUsername(product.getUser().getUsername());
        productDetailsDTO.setQuantity(product.getQuantity());

        Set<Category> categories = product.getCategories();

        Set<String> productCategory = new HashSet<>();
        for (Category category : categories) {
            productCategory.add(category.getName());
        }

        productDetailsDTO.setCategories(productCategory);


        return productDetailsDTO;
    }

    public List<UserProductDetailsDTO> getUserProducts() {
        Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();

        String username;
        if (principal instanceof UserDetails)
            username = ((UserDetails) principal).getUsername();
        else
            username = principal.toString();

        UserEntity userEntity = this.userService.findByUsername(username);

        List<Product> productList = this.productRepository.findProductsByUserId(userEntity.getId());

        List<UserProductDetailsDTO> userProductDetailsDTOS = new ArrayList<>();


        for (Product product : productList) {
            UserProductDetailsDTO userProductDetailsDTO = new UserProductDetailsDTO();

            userProductDetailsDTO.setName(product.getName());

            List<String> categoryList = new ArrayList<>();
            Set<Category> categories = product.getCategories();

            for (Category category : categories) {
                categoryList.add(category.getName());
            }

            userProductDetailsDTO.setCategories(categoryList);
            userProductDetailsDTO.setQuantity(product.getQuantity());
            List<String> images = new ArrayList<>();
            for (Image image : product.getImages()) {
                images.add(image.getPath());
            }
            userProductDetailsDTO.setImages(images);
            userProductDetailsDTOS.add(userProductDetailsDTO);

        }

        return userProductDetailsDTOS;
    }

}
