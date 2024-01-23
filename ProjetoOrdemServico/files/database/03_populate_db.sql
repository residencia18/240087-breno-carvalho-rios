-- Inserir dados na tabela 'endereco'
INSERT INTO osmanagerdb.endereco (rua, bairro, cidade, estado, pais, numero) 
VALUES 
  ('Rua São Paulo', 'Centro', 'São Paulo', 'SP', 'Brasil', 123),
  ('Avenida Rio de Janeiro', 'Copacabana', 'Rio de Janeiro', 'RJ', 'Brasil', 456),
  ('Rua Floriano Peixoto', 'Boa Vista', 'Recife', 'PE', 'Brasil', 789),
  ('Rua Buenos Aires', 'Palermo', 'Buenos Aires', 'BA', 'Argentina', 567),
  ('Main Street', 'Downtown', 'New York', 'NY', 'USA', 789),
  ('Rue de la Paix', 'Champs-Élysées', 'Paris', 'IDF', 'France', 101),
  ('Alexanderplatz', 'Mitte', 'Berlin', 'BE', 'Germany', 222),
  ('Shibuya Crossing', 'Shibuya', 'Tokyo', 'Tokyo', 'Japan', 333),
  ('Piazza San Marco', 'San Marco', 'Venice', 'VE', 'Italy', 444),
  ('Red Square', 'Tverskoy', 'Moscow', 'MOW', 'Russia', 555);

-- Inserir dados na tabela 'cliente'
INSERT INTO osmanagerdb.cliente (nome, email, telefone, endereco_id) 
VALUES 
  ('Maria Silva', 'maria@email.com', '123456789', 1),
  ('João Oliveira', 'joao@email.com', '987654321', 2),
  ('Ana Souza', 'ana@email.com', '111222333', 3),
  ('Carlos Santos', 'carlos@email.com', '555666777', 4),
  ('Patricia Lima', 'patricia@email.com', '888999000', 5),
  ('Rafael Pereira', 'rafael@email.com', '111222333', 6),
  ('Elena Rodriguez', 'elena@email.com', '777888999', 7),
  ('James Smith', 'james@email.com', '555444333', 8),
  ('Sophie Martin', 'sophie@email.com', '333222111', 9),
  ('Alexei Ivanov', 'alexei@email.com', '999888777', 10);

-- Inserir dados na tabela 'prestador_de_servico'
INSERT INTO osmanagerdb.prestador_de_servico (nome, especialidade, telefone, endereco_id) 
VALUES 
  ('Luiz Oliveira', 'Encanador', '555666777', 2),
  ('Camila Santos', 'Eletricista', '888999000', 3),
  ('Fernando Pereira', 'Pintor', '111222333', 1),
  ('Marta Gonzalez', 'Jardineiro', '777888999', 4),
  ('John Smith', 'Carpinteiro', '555444333', 5),
  ('Isabella Rossi', 'Limpeza', '333222111', 6),
  ('Hiroshi Tanaka', 'Encanador', '999888777', 7),
  ('Elena Petrova', 'Eletricista', '222111000', 8),
  ('Antonio Morelli', 'Pintor', '888777666', 9),
  ('Anastasia Ivanova', 'Jardineiro', '444333222', 10);

-- Inserir dados na tabela 'servico'
INSERT INTO osmanagerdb.servico (nome, descricao, preco) 
VALUES 
  ('Instalação Hidráulica', 'Instalação de encanamento', 100.00),
  ('Reparo Elétrico', 'Reparo em circuitos elétricos', 150.00),
  ('Pintura Interna', 'Pintura de paredes internas', 200.00),
  ('Manutenção de Jardim', 'Corte de grama e poda de plantas', 80.00),
  ('Construção de Móveis', 'Montagem e reparo de móveis', 120.00),
  ('Limpeza Residencial', 'Faxina geral em residências', 90.00),
  ('Instalação de Encanamento', 'Reparo e instalação de tubulações', 110.00),
  ('Reparo Elétrico Residencial', 'Conserto de problemas elétricos', 160.00),
  ('Pintura Externa', 'Pintura de fachadas e exteriores', 220.00),
  ('Projeto de Jardim', 'Desenho e planejamento de jardins', 200.00);

-- Inserir dados na tabela 'ordem_de_servico'
INSERT INTO osmanagerdb.ordem_de_servico (numero, descricao, data_emissao, status, cliente_id, prestador_de_servico_id) 
VALUES 
  (1, 'Reparo no Banheiro', '2024-01-21 10:00:00', 'Em Andamento', 1, 1),
  (2, 'Troca de Tomadas', '2024-01-22 12:30:00', 'Concluído', 2, 2),
  (3, 'Pintura na Sala', '2024-01-23 15:45:00', 'Pendente', 3, 3),
  (4, 'Manutenção de Jardim', '2024-01-24 18:00:00', 'Em Andamento', 4, 4),
  (5, 'Construção de Móveis', '2024-01-25 09:30:00', 'Concluído', 5, 5),
  (6, 'Limpeza Residencial', '2024-01-26 14:00:00', 'Pendente', 6, 6),
  (7, 'Instalação de Encanamento', '2024-01-27 11:15:00', 'Em Andamento', 7, 7),
  (8, 'Reparo Elétrico Residencial', '2024-01-28 16:45:00', 'Concluído', 8, 8),
  (9, 'Pintura Externa', '2024-01-29 13:20:00', 'Pendente', 9, 9),
  (10, 'Projeto de Jardim', '2024-01-30 10:30:00', 'Em Andamento', 10, 10);

-- Inserir dados na tabela 'pagamento'
INSERT INTO osmanagerdb.pagamento (valor, data_pagamento, metodo_pagamento, ordem_de_servico_id) 
VALUES 
  (120.00, '2024-01-22 11:30:00', 'Cartão de Crédito', 1),
  (180.00, '2024-01-23 16:30:00', 'Boleto Bancário', 2),
  (220.00, '2024-01-24 09:00:00', 'Transferência Bancária', 3),
  (90.00, '2024-01-25 15:45:00', 'Pix', 4),
  (150.00, '2024-01-26 20:00:00', 'Dinheiro', 5),
  (100.00, '2024-01-27 12:30:00', 'Cartão de Débito', 6),
  (110.00, '2024-01-28 14:00:00', 'Boleto Bancário', 7),
  (160.00, '2024-01-29 18:30:00', 'Transferência Bancária', 8),
  (200.00, '2024-01-30 10:45:00', 'Pix', 9),
  (180.00, '2024-01-31 09:15:00', 'Dinheiro', 10);

-- Inserir dados na tabela 'servico_ordem_de_servico'
INSERT INTO osmanagerdb.servico_ordem_de_servico (ordem_de_servico_id, servico_id, endereco_id) 
VALUES 
  (1, 1, 1),
  (1, 2, 2),
  (2, 3, 3),
  (3, 1, 1),
  (4, 4, 4),
  (5, 5, 5),
  (6, 6, 6),
  (7, 7, 7),
  (8, 8, 8),
  (9, 9, 9),
  (10, 10, 10);
