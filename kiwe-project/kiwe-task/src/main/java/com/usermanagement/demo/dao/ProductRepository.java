package com.usermanagement.demo.dao;

import com.usermanagement.demo.entity.Product;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ProductRepository  extends CrudRepository<Product,Long>{

    Product findProductById(Long id);
    List<Product> findProductsByUserId(Long userId);
}
