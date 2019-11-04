CREATE DATABASE M_Roman

USE M_Roman

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL unique,
	Senha VARCHAR(100) NOT NULL
);

CREATE TABLE Status(
	IdStatus INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL
);
CREATE TABLE Temas (
	IdTema INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL,
	IdStatus INT FOREIGN KEY REFERENCES  Status (IdStatus)
);
CREATE TABLE Projetos(
	IdProjeto INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL,
	IdTema INT FOREIGN KEY REFERENCES  Temas (IdTema),
	IdUsuario INT FOREIGN KEY REFERENCES  Usuarios (IdUsuario)
);

INSERT INTO Usuarios(Nome,Email,Senha)
VALUES ('Helena Strada','h@gmail.com','123'),
	   ('Erick','h@gmail.com','123')

INSERT INTO Status(Nome)
VALUES ('Ativo'),('Inativo')

INSERT INTO Temas(Nome,IdStatus)
VALUES('Gestão',1),('Mobile',1),('FrontEnd',1)

INSERT INTO Projetos(Nome,IdTema,IdUsuario)
VALUES('Roman',2,1),('Opflix',3,2)


select * from Usuarios
select * from Projetos
select * from Temas
select * from Status




