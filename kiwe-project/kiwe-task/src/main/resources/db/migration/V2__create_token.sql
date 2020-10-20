CREATE TABLE confirmation_token (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  token varchar(100) NOT NULL,
  expiry_date DATE NOT NULL,
  user_id bigint,
  FOREIGN KEY(user_id) REFERENCES users(id),
  PRIMARY KEY (id),
  UNIQUE KEY UK_token (token)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;