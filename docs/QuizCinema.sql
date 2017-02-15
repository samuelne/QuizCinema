-- Criar banco de dados
create database db_QuizCinema

-- O comando goto vai para o proximo comando e o executa
goto

-- Usar banco de dados
use db_QuizCinema


-- Criar tabela tb_Jogador
create table tb_jogador(
	id_jogador		int identity primary key,
	nome			varchar(100) not null,
	sobrenome		varchar (30),
	email			varchar (50) not null
)

-- Criar tabela tb_Perguntas com as seguintes colunas, id, pergunta, resposta_correta, data
create table tb_perguntas(
	id_perguntas		int identity primary key,
	pergunta			varchar(max),
	resposta_correta	varchar (max),
	nivel				varchar (10),
	pontos				int,
	id_jogador			int,
	data datetime default getdate()
)

-- Seleciona tudo da tabela tb_Jogador
select nome from tb_jogador

-- Seleciona tudo da tabela tb_Perguntas
select * from tb_perguntas

--Insere valor dentro da tabela tb_Jogador na coluna nome
insert into tb_jogador(nome) values('Amanda')
insert into tb_jogador(nome) values('Fernanda')


-- Insere os valores dentro da tabela tb_Jogador nas colunas pergunta, reposta_correta
insert into tb_Perguntas (pergunta, resposta_correta) values ('1) O software tem por objetivo em uma apresentação?','O software deve simplificar a apresentação em vez de complicá-la.' )

-- Deleta o id 17 da tabela tb_Jogador
delete from tb_Jogador where id = 17

-- Insere dentro da tabela tb_Jogador o valor Ramón
insert into tb_Jogador (nome) values ('Ramón')

-- Apaga todos registros da tabela tb_Jogador
delete from tb_Jogador

-- Zera toda tabela tb_Jogador e começa o id do 1
truncate table tb_Jogador

-- Zera toda tabela tb_Perguntas e começa o id do 1
truncate table tb_perguntas

-- Adicionar a columa id_jogador dentro da tabela depois que ela já foi criada
alter table tb_Perguntas add id_jogador int

-- Excluir a columa id_jogador adicionada por engano na tabela tb_Perguntas
alter table tb_Jogador drop column id_jogador


-- Fazer "junção" das tabelas tb_Jogador com a tb_Perguntas "onde" tb_Jogador.id = tb_Perguntas.id_jogador
select * from tb_Jogador join tb_Perguntas on tb_Jogador.id = tb_Perguntas.id_jogador

-- Identifica o ultimo insert feito em qualquer tabela
select  @@IDENTITY

-- Site para entender alguns conceitos
--http://www.devmedia.com.br/conhecendo-os-metodos-executenonquery-executereader-e-executescalar-da-ado-net/27579




