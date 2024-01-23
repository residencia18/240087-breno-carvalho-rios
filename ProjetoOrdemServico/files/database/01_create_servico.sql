CREATE TABLE `osmanagerdb`.`servico` (
`nome` VARCHAR(100) NOT NULL,
`descricao` TEXT,
`preco` DECIMAL(10, 2) NOT NULL,
`tipo_servico` VARCHAR(50)
PRIMARY KEY (`servico_id`)
);
