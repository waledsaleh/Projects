CREATE TABLE users (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  email varchar(100) NOT NULL,
  password varchar(200) NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY UK_username (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
