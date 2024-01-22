CREATE TABLE `osmanagerdb`.`prestador_de_servico` (
  `prestador_de_servico_id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `especialidade` VARCHAR(100) NOT NULL,
  `telefone` VARCHAR(20) NOT NULL,
  `endereco_id` INT NOT NULL,
  PRIMARY KEY (`prestador_de_servico_id`)
);
