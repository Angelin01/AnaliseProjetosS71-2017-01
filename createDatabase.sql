-- Só vai funfar em MySQL

CREATE TABLE IF NOT EXISTS Funcionario (
    cpf VARCHAR(14), -- Formato "123.456.789-00"
    nome VARCHAR(255) NOT NULL,
    nome_da_mae VARCHAR(255),
    nome_do_pai VARCHAR(255),
    rg VARCHAR(40) NOT NULL, -- Formato "1234567... Orgão UF"
    ctps INT NOT NULL,
    endereco VARCHAR(255),
    telefone VARCHAR(40), -- Formato internacional pra todos telefones "+554112345678"
    telefone_cel VARCHAR(40),
    email VARCHAR(255),
    email_alt VARCHAR(255),
    login VARCHAR(255) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    salario INT NOT NULL,
    cargo CHAR NOT NULL,
    
    PRIMARY KEY(cpf)
);

CREATE TABLE IF NOT EXISTS Recurso (
    id INT AUTO_INCREMENT, 
    nome VARCHAR(255) NOT NULL,
    quantidade FLOAT NOT NULL,
    nome_fornecedor VARCHAR(255),
    telefone_fornecedor VARCHAR(40),
    
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS Produto (
    id INT AUTO_INCREMENT,
    nome VARCHAR(255) NOT NULL,
    preco INT NOT NULL, -- Em centavos
    
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS ProdutoIngrediente (
    idProduto INT,
    idIngrediente INT,
    quantidade FLOAT NOT NULL,
    
    PRIMARY KEY(idProduto, idIngrediente),
    FOREIGN KEY (idProduto) REFERENCES Produto(id),
    FOREIGN KEY (idRecurso) REFERENCES Recurso(id)
);

CREATE TABLE IF NOT EXISTS Pedido (
    id INT AUTO_INCREMENT,
    estado CHAR NOT NULL,
    data_hora DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    observacao VARCHAR(255),
    
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS PedidoProduto (
    idProduto INT,
    idPedido INT,
    quantidade FLOAT NOT NULL,
    
    PRIMARY KEY(idProduto, idPedido),
    FOREIGN KEY (idProduto) REFERENCES Produto(id),
    FOREIGN KEY (idPedido) REFERENCES Pedido(id)
);

CREATE TABLE IF NOT EXISTS Transacao (
    id INT AUTO_INCREMENT,
    valor INT NOT NULL,
    data_hora DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    descricao VARCHAR(255),
    
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS TransacaoPedido (
    idPedido INT,
    idTransacao INT,
    
    FOREIGN KEY (idTransacao) REFERENCES Transacao(id),
    FOREIGN KEY (idPedido) REFERENCES Pedido(id)
);