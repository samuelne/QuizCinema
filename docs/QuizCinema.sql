-- Criar banco de dados
CREATE DATABASE db_QuizCinema

-- O comando goto vai para o proximo comando e o executa
GOTO

-- Usar banco de dados
USE db_QuizCinema


-- Criar tabela tb_Jogador
CREATE TABLE tb_jogador(
	id_jogador		INT IDENTITY PRIMARY KEY,
	nome			VARCHAR(100) not null,
	sobrenome		VARCHAR (30),
	email			VARCHAR (50) not null
)

-- Criar tabela tb_Perguntas com as seguintes colunas, id, pergunta, resposta_correta, data
CREATE TABLE tb_perguntas(
	id_perguntas		INT IDENTITY PRIMARY KEY,
	pergunta			VARCHAR(MAX),
	resposta_correta	VARCHAR (MAX),
	nivel				VARCHAR (10),
	pontos				INT,
	id_jogador			INT,
	DATA DATETIME DEFAULT GETDATE()
)

-- Seleciona tudo da tabela tb_Jogador
SELECT * FROM tb_jogador

-- Seleciona tudo da tabela tb_Perguntas
SELECT * FROM tb_perguntas

-- Seleciona o id_jogador da tb_jogador e soma todos os pontos
SELECT SUM pontos FROM tb_jogador WHERE id_jogador = 1

--Insere valor dentro da tabela tb_Jogador na coluna nome
INSERT INTO tb_jogador(nome) VALUES('Amanda')
INSERT INTO tb_jogador(nome) VALUES('Fernanda')


-- Insere os valores dentro da tabela tb_Jogador nas colunas pergunta, reposta_correta
INSERT INTO tb_Perguntas (pergunta, resposta_correta) VALUES ('1) O software tem por objetivo em uma apresentação?','O software deve simplificar a apresentação em vez de complicá-la.' )

-- Deleta o id 17 da tabela tb_Jogador
DELETE FROM tb_Jogador WHERE id = 17

-- Insere dentro da tabela tb_Jogador o valor Ramón
INSERT INTO tb_Jogador (nome) VALUES ('Ramón')

-- Apaga todos registros da tabela tb_Jogador
DELETE FROM tb_Jogador

-- Zera toda tabela tb_Jogador e começa o id do 1
TRUNCATE TABLE tb_Jogador

-- Zera toda tabela tb_Perguntas e começa o id do 1
TRUNCATE TABLE tb_perguntas

-- Adicionar a columa id_jogador dentro da tabela depois que ela já foi criada
ALTER TABLE tb_Perguntas ADD id_jogador INT

-- Excluir a columa id_jogador adicionada por engano na tabela tb_Perguntas
ALTER TABLE tb_Jogador DROP COLUMN id_jogador


-- Fazer "junção" das tabelas tb_Jogador com a tb_Perguntas "onde" tb_Jogador.id = tb_Perguntas.id_jogador
SELECT * FROM tb_Jogador JOIN tb_Perguntas ON tb_Jogador.id = tb_Perguntas.id_jogador

-- Identifica o ultimo insert feito em qualquer tabela
SELECT  @@IDENTITY

-- Site para entender alguns conceitos
--http://www.devmedia.com.br/conhecendo-os-metodos-executenonquery-executereader-e-executescalar-da-ado-net/27579




