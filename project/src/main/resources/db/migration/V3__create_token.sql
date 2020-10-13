CREATE TABLE confirmation_token (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  confirmation_token varchar(100) NOT NULL,
  created_date DATE NOT NULL,
  user_id bigint,
  FOREIGN KEY(user_id) REFERENCES users(id),
  PRIMARY KEY (id),
  UNIQUE KEY UK_token (confirmation_token)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;