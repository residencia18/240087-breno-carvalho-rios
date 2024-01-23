CREATE TABLE `osmanagerdb`.`servico_ordem_de_servico` (
  `servico_ordem_de_servico_id` INT NOT NULL AUTO_INCREMENT,
  `ordem_de_servico_id` INT NOT NULL,
  `servico_id` INT NOT NULL,
  `endereco_id` INT NOT NULL,
  PRIMARY KEY (`servico_ordem_de_servico_id`)
);