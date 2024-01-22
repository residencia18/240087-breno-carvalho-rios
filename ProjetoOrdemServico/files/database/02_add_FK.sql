ALTER TABLE `osmanagerdb`.`cliente` ADD CONSTRAINT `fk_cliente_endereco` FOREIGN KEY (`endereco_id`) REFERENCES `osmanagerdb`.`endereco` (`endereco_id`);

ALTER TABLE `osmanagerdb`.`prestador_de_servico` ADD CONSTRAINT `fk_prestador_de_servico_endereco` FOREIGN KEY (`endereco_id`) REFERENCES `osmanagerdb`.`endereco` (`endereco_id`);

ALTER TABLE `osmanagerdb`.`ordem_de_servico` ADD CONSTRAINT `fk_ordem_de_servico_cliente` FOREIGN KEY (`cliente_id`) REFERENCES `osmanagerdb`.`cliente` (`cliente_id`);
ALTER TABLE `osmanagerdb`.`ordem_de_servico` ADD CONSTRAINT `fk_ordem_de_servico_prestador_de_servico` FOREIGN KEY (`prestador_de_servico_id`) REFERENCES `osmanagerdb`.`prestador_de_servico` (`prestador_de_servico_id`);

ALTER TABLE `osmanagerdb`.`pagamento` ADD CONSTRAINT `fk_pagamento_ordem_de_servico` FOREIGN KEY (`ordem_de_servico_id`) REFERENCES `osmanagerdb`.`ordem_de_servico` (`ordem_de_servico_id`);

ALTER TABLE `osmanagerdb`.`servico_ordem_de_servico` ADD CONSTRAINT `fk_servico_ordem_de_servico_ordem_de_servico` FOREIGN KEY (`ordem_de_servico_id`) REFERENCES `osmanagerdb`.`ordem_de_servico` (`ordem_de_servico_id`);
ALTER TABLE `osmanagerdb`.`servico_ordem_de_servico` ADD CONSTRAINT `fk_servico_ordem_de_servico_servico` FOREIGN KEY (`servico_id`) REFERENCES `osmanagerdb`.`servico` (`servico_id`);
ALTER TABLE `osmanagerdb`.`servico_ordem_de_servico` ADD CONSTRAINT `fk_servico_ordem_de_servico_endereco` FOREIGN KEY (`endereco_id`) REFERENCES `osmanagerdb`.`endereco` (`endereco_id`);