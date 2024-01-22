CREATE TABLE `osmanagerdb`.`pagamento` (
  `pagamento_id` INT NOT NULL AUTO_INCREMENT,
  `valor` FLOAT NOT NULL,
  `data_pagamento` DATETIME NOT NULL,
  `metodo_pagamento` VARCHAR(100) NOT NULL,
  `ordem_de_servico_id` INT NOT NULL,
  PRIMARY KEY (`pagamento_id`)
);
