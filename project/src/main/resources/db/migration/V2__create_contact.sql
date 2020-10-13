CREATE TABLE contact (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  name varchar(50) not null,
  email varchar(100) NOT NULL,
  message varchar(50) NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY UK_username (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE users
ADD COLUMN enabled bit(1) NOT NULL AFTER password;
