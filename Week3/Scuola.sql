-- CREATE DATABASE Scuola

CREATE TABLE Aula(
	[ID_AULA] [int] IDENTITY(1, 1) NOT NULL, --PRIMARY KEY,
	[Corpo] [nchar](1) NOT NULL, --UNIQUE, 
	[Piano] [nchar](1) NOT NULL,
	[Numero] [nchar](2) NOT NULL,
	[MQ] [numeric](4, 2) NULL
	CONSTRAINT [PK_Aule] PRIMARY KEY CLUSTERED (ID_AULA),
	--unicità su un singolo attributo
	--CONSTRAINT [UQ_Corpo] UNIQUE(Corpo),
	CONSTRAINT [UQ_Aula] UNIQUE (Corpo, Piano, Numero)
);

--vincolo unicità su tabella già esistente
CREATE UNIQUE INDEX [UQ_Aula] ON [Aula](
	[Corpo],
	[Piano],
	[Numero]
)

CREATE TABLE Classe(
	[ID_Classe] [INT] IDENTITY(1,1) NOT NULL,
	[Anno] [CHAR](1) NOT NULL,
	[Sezione] [CHAR](1) NOT NULL,
	[Indirizzo] [VARCHAR](20) NOT NULL,
	[ID_AULA] [INT] NOT NULL,
	CONSTRAINT [PK_Classe] PRIMARY KEY CLUSTERED(
		[ID_Classe] DESC 
	),
	CONSTRAINT [UQ_Classi_Diverse] UNIQUE NONCLUSTERED(
		[Anno],
		[Sezione],
		[Indirizzo]
	),
	CONSTRAINT [FK_Classe_Aule] FOREIGN KEY(
		[ID_AULA]
	) REFERENCES [Aula](ID_AULA)
);


CREATE TABLE Studente(
	[ID_Studente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [VARCHAR](50) NOT NULL,
	[Cognome] [VARCHAR](50) NOT NULL,
	[ID_ANNO] [CHAR](1) NOT NULL,
	[ID_SEZIONE] [CHAR](1) NOT NULL,
	[ID_INDIRIZZO] [VARCHAR](20) NOT NULL,
	CONSTRAINT [PK_Studente] PRIMARY KEY CLUSTERED(
		[ID_Studente]
	), 
	CONSTRAINT [FK_Studente_Classe] FOREIGN KEY(
		[ID_ANNO],
		[ID_SEZIONE],
		[ID_INDIRIZZO]
	) REFERENCES [Classe]([Anno], [Sezione], [Indirizzo])
);

CREATE TABLE Disciplina(
 [ID_DISCIPLINA] [INT] IDENTITY (1,1) NOT NULL,
 [Nome] [VARCHAR](20) NOT NULL,
 [Docente] [VARCHAR](50) NOT NULL,
 CONSTRAINT [PK_Disciplina] PRIMARY KEY (
	[ID_DISCIPLINA]
 )
);


CREATE TABLE Verifica(
	[ID_Verifica] [INT] IDENTITY(1, 1) NOT NULL,
	[Data] DATE NOT NULL,
	[ID_DISCIPLINA] [INT] DEFAULT 0 NOT NULL,
	[ID_STUDENTE] [INT] NOT NULL,
	CONSTRAINT [PK_Verifica] PRIMARY KEY(
		[ID_Verifica]
	),
	CONSTRAINT [FK_Studente] FOREIGN KEY (ID_STUDENTE) 
	REFERENCES Studente(ID_Studente)
	ON DELETE NO ACTION
	ON UPDATE CASCADE,
	CONSTRAINT [FK_Disciplina] FOREIGN KEY (ID_DISCIPLINA)
	REFERENCES [Disciplina](ID_DISCIPLINA)
	ON DELETE SET DEFAULT
	ON UPDATE SET DEFAULT
)

ALTER TABLE [Classe]
WITH CHECK ADD CONSTRAINT [Indirizzo]
CHECK ([Indirizzo] IN ('Chimica', 'Informatica', 'Ragioneria', 'Alberghiero'))


ALTER TABLE [Classe]
WITH CHECK ADD CONSTRAINT [Sezione]
CHECK ([Sezione] IN ('A', 'B', 'C', 'D', 'E', 'F'))

ALTER TABLE [Classe]
WITH CHECK ADD CONSTRAINT [Anno]
CHECK ([Anno] IN ('1', '2', '3', '4', '5'))


CREATE INDEX Studenti_NDX
ON Studente (Cognome ASC, Nome ASC);

CREATE UNIQUE INDEX Verifiche_NDX
ON Verifica (ID_STUDENTE, ID_DISCIPLINA, Data);

ALTER TABLE Verifica
ADD Voto INT

ALTER TABLE [Verifica]
WITH CHECK ADD CONSTRAINT [VotiValidi]
CHECK ([Voto] BETWEEN 0 AND 10)

--cancello vincolo
ALTER TABLE Verifica
DROP Constraint VotiValidi

ALTER TABLE Verifica
DROP COLUMN [Voto]









