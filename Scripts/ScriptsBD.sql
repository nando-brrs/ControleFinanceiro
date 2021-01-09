CREATE DATABASE ControleFinanceiro

USE [ControleFinanceiro]

CREATE TABLE [USUARIOS]
(
	[ID] UNIQUEIDENTIFIER NOT NULL,
	[NOME] VARCHAR(150) NOT NULL,
	[EMAIL] VARCHAR(100) NOT NULL,
	[LOGIN] VARCHAR(50) NOT NULL,
	[SENHA] VARCHAR(100) NOT NULL,
	[ATIVO] BIT NOT NULL,
	CONSTRAINT PK_USUARIOS_ID
		PRIMARY KEY CLUSTERED (ID)
);


CREATE TABLE [TIPOLANCAMENTOS]
(
	[ID] INT NOT NULL,
	[DESCRICAO] VARCHAR(200)
	CONSTRAINT PK_TIPOLANCAMENTOS_ID
		PRIMARY KEY CLUSTERED (ID)
);


INSERT INTO [TIPOLANCAMENTOS](ID, DESCRICAO) VALUES(1, 'RECEITAS')
INSERT INTO [TIPOLANCAMENTOS](ID, DESCRICAO) VALUES(2, 'DESPESAS')

CREATE TABLE [CATEGORIAS]
(
	[ID] UNIQUEIDENTIFIER NOT NULL,
	[DESCRICAO] VARCHAR(200),
	[ATIVO] BIT NOT NULL,
	[ID_TIPOLANCAMENTO] INT NOT NULL,
	CONSTRAINT PK_CATEGORIAS_ID	
		PRIMARY KEY CLUSTERED (ID)
);

Alter Table [CATEGORIAS] WITH CHECK ADD CONSTRAINT [FK_CATEGORIA_TIPOLANCAMENTO]
FOREIGN KEY ([ID_TIPOLANCAMENTO]) REFERENCES [TIPOLANCAMENTOS]([ID])


INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Receitas', 1, 1)
INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Alimenta��o', 1, 2)
INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Habita��o', 1, 2)
INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Comunica��o', 1, 2)
INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Educa��o', 1, 2)
INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Transporte', 1, 2)
INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Lazer', 1, 2)
INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Pessoal', 1, 2)
INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Sa�de', 1, 2)
INSERT INTO [CATEGORIAS](ID, DESCRICAO, ATIVO, ID_TIPOLANCAMENTO) VALUES(NEWID(), 'Servi�os Financeiros', 1, 2)


CREATE TABLE [SUBCATEGORIAS]
(
	[ID] UNIQUEIDENTIFIER NOT NULL,
	[DESCRICAO] VARCHAR(200),
	[ATIVO] BIT NOT NULL,
	[ID_CATEGORIA] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_SUBCATEGORIAS_ID	
		PRIMARY KEY CLUSTERED (ID)
);

Alter Table [SUBCATEGORIAS] WITH CHECK ADD CONSTRAINT [FK_SUBCATEGORIA_CATEGORIA]
FOREIGN KEY ([ID_CATEGORIA]) REFERENCES [CATEGORIAS]([ID])



INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Sal�rio', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Receitas'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'F�rias', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Receitas'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), '13� Sal�rio', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Receitas'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Outras Receitas', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Receitas'))

INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Feira/hortifruti', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Alimenta��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Supermercado', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Alimenta��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'a�ougue', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Alimenta��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Padaria', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Alimenta��o'))

INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), '�gua/esgoto', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Habita��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Eletricidade', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Habita��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'G�s', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Habita��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Manuten��o da casa', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Habita��o'))

INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Telefone', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Comunica��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Internet', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Comunica��o'))

INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Curso idioma', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Educa��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Mensalidade', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Educa��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Material', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Educa��o'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Atividades extra-curriculares', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Educa��o'))

INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Combust�vel', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Transporte'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Estacionamento', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Transporte'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'IPVA', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Transporte'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Taxa Licenciamento', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Transporte'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'DPVAT', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Transporte'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Manuten��o', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Transporte'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Metr�/�nibus/trem', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Transporte'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Seguro carro', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Transporte'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Presta��o carro', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Transporte'))

INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'TV a cabo', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Lazer'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Cinema', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Lazer'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Barzinho/Pizzaria', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Lazer'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Teatro', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Lazer'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Viagens', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Lazer'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Leitura', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Lazer'))

INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Cabeleireiro', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Pessoal'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Manicure', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Pessoal'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Academia/esportes', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Pessoal'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Vestu�rio', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Pessoal'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Presentes', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Pessoal'))

INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Rem�dios', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Sa�de'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Dentista', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Sa�de'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Outros', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Sa�de'))

INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Tarifa banco', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Servi�os Financeiros'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Fatura Cart�o', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Servi�os Financeiros'))
INSERT INTO [SUBCATEGORIAS](ID, DESCRICAO, ATIVO, ID_CATEGORIA) VALUES(NEWID(), 'Investimentos', 1, (SELECT ID FROM CATEGORIAS WHERE DESCRICAO LIKE 'Servi�os Financeiros'))

CREATE TABLE [LANCAMENTOS]
(
	[ID] UNIQUEIDENTIFIER NOT NULL,
	[VALOR] DECIMAL NOT NULL,
	[DATA] DATETIME NOT NULL,
	[DATAVENCIMENTO] DATE NULL,
	[PAGO] BIT NULL,
	[RECORRENTE] BIT NULL,
	[DESCRICAO] VARCHAR(500) NULL,
	[ID_TIPOLANCAMENTO] INT NOT NULL,
	[ID_SUBCATEGORIA] UNIQUEIDENTIFIER NOT NULL,
	[ID_USUARIO] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_LANCAMENTOS_ID	
		PRIMARY KEY CLUSTERED (ID)
);

Alter Table [LANCAMENTOS] WITH CHECK ADD CONSTRAINT [FK_LANCAMENTOS_SUBCATEGORIA]
FOREIGN KEY ([ID_SUBCATEGORIA]) REFERENCES [SUBCATEGORIAS]([ID])

Alter Table [LANCAMENTOS] WITH CHECK ADD CONSTRAINT [FK_LANCAMENTOS_TIPOLANCAMENTO]
FOREIGN KEY ([ID_TIPOLANCAMENTO]) REFERENCES [TIPOLANCAMENTOS]([ID])

Alter Table [LANCAMENTOS] WITH CHECK ADD CONSTRAINT [FK_LANCAMENTOS_USUARIO]
FOREIGN KEY ([ID_USUARIO]) REFERENCES [USUARIOS]([ID])

