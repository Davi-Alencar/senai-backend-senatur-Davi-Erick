CREATE DATABASE Senatur_Tarde;
GO

USE Senatur_Tarde
GO

CREATE TABLE Pacotes (
IdPacote			INT PRIMARY KEY IDENTITY, 
NomePacote			VARCHAR (255) NOT NULL, 
Descricao			TEXT,
DataIda				DATE, 
DataVolta			DATE, 
Valor				MONEY, 
NomeCidade			VARCHAR (255) NOT NULL,
Ativo				BIT NOT NULL
);
GO

CREATE TABLE TipoUsuarios(
IdTipoUsuario		INT PRIMARY KEY IDENTITY,
Titulo				VARCHAR (255) NOT NULL UNIQUE
);
GO

CREATE TABLE Usuarios(
IdUsuario INT PRIMARY KEY IDENTITY,
Nome			VARCHAR (255) NOT NULL,
Email			VARCHAR (255) NOT NULL,
Senha			VARCHAR (255) NOT NULL,
IdTipoUsuario	INT FOREIGN KEY REFERENCES  TipoUsuarios (IdTipoUsuario)
);
GO

SELECT * FROM Pacotes
