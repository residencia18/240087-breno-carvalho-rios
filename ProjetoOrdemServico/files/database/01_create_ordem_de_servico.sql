CREATE TABLE `osmanagerdb`.`ordem_de_servico` (
  `ordem_de_servico_id` INT NOT NULL AUTO_INCREMENT,
  `numero` INT NOT NULL,
  `descricao` VARCHAR(100) NULL,
  `data_emissao` DATETIME NOT NULL,
  `status` VARCHAR(50) NOT NULL,
  `cliente_id` INT NOT NULL,
  `prestador_de_servico_id` INT NOT NULL,
  PRIMARY KEY (`ordem_de_servico_id`)
);