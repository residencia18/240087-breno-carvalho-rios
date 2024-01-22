CREATE TABLE servico (
servico_id INT PRIMARY KEY,
nome VARCHAR(255) NOT NULL,
descricao TEXT,
preco DECIMAL(10, 2) NOT NULL,
tipo_servico VARCHAR(50)
);
