CREATE TABLE `osmanagerdb`.`cliente` (
  `cliente_id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `telefone` VARCHAR(20) NOT NULL,
  `endereco_id` INT NOT NULL,
  PRIMARY KEY (`cliente_id`)
);
