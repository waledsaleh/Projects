CREATE TABLE if not exists users (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  first_name varchar(100) NOT NULL,
  last_name varchar(100) NOT NULL,
  username varchar(100) NOT NULL,
  password varchar(200) NOT NULL,
  age int NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY UK_username (username)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


create table if not exists category (
    id bigint(20) NOT NULL AUTO_INCREMENT,
    name varchar(100) not null,
    primary key (id)

);

create table if not exists product (
    id bigint(20) NOT NULL AUTO_INCREMENT,
    name varchar(300) not null,
    quantity double not null,
    user_id bigint not null,
    image varchar(50) null,
    primary key (id),
    foreign key (user_id) references users(id)
);

create table if not exists product_category (
    product_id bigint,
    category_id bigint,
    primary key (product_id, category_id),
    foreign key (product_id) references product(id),
    foreign key (category_id) references category(id)
);

create table if not exists image (
    id bigint(20) NOT NULL AUTO_INCREMENT,
    path varchar(50) not null,
    product_id bigint,
    primary key (id),
    foreign key (product_id) references product(id)
);
