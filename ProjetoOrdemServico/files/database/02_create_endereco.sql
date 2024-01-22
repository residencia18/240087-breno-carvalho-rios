CREATE TABLE `osmanagerdb`.`endereco` (
  `endereco_id` INT NOT NULL AUTO_INCREMENT,
  `rua` VARCHAR(100) NOT NULL,
  `bairro` VARCHAR(100) NOT NULL,
  `cidade` VARCHAR(100) NOT NULL,
  `estado` VARCHAR(100) NOT NULL,
  `pais` VARCHAR(100) NOT NULL,
  `numero` INT NOT NULL,
  PRIMARY KEY (`endereco_id`)
);