--CREATE DATABASE Scuola

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
--CREATE UNIQUE INDEX [UQ_Aula] ON [Aula](
--	[Corpo],
--	[Piano],
--	[Numero]
--)

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
	[ANNO] [CHAR](1) NOT NULL,
	[SEZIONE] [CHAR](1) NOT NULL,
	[INDIRIZZO] [VARCHAR](20) NOT NULL,
	CONSTRAINT [PK_Studente] PRIMARY KEY CLUSTERED(
		[ID_Studente]
	), 
	CONSTRAINT [FK_Studente_Classe] FOREIGN KEY(
		[ANNO],
		[SEZIONE],
		[INDIRIZZO]
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


CREATE VIEW [DettagliClasseAulaStudenti] AS (
	SELECT s.Nome, s.Cognome, c.Anno, c.Sezione, c.Indirizzo, 
	a.Numero, a.Piano, a.Corpo
	FROM Studente as s
	JOIN Classe as c
	ON s.Anno = c.Anno AND s.Sezione = c.Sezione
	AND s.Indirizzo = c.Indirizzo
	JOIN Aula as a
	ON c.ID_AULA = a.ID_AULA
);

SELECT * 
FROM DettagliClasseAulaStudenti

-- VIEW DI SISTEMA
--select object_id, name
--FROM sys.all_columns
--where object_id = 3


-- STORED PROCEDURE
CREATE PROCEDURE [InserimentoAula] @Corpo nchar(1), @piano nchar(1), @numero nchar(2),
@mq numeric null
as
BEGIN 
INSERT INTO Aula (Corpo, Piano, Numero, MQ) VALUES (@Corpo, @Piano, @Numero, @mq)
END

EXECUTE [InserimentoAula] @corpo = 'a', @piano = '1', @numero = '1', @mq = null

CREATE PROCEDURE [InserimentoClasse]
@Sezione char(1),
@Indirizzo varchar(20),
@Anno char(1),
@Aula int
AS
BEGIN
INSERT INTO Classe (Anno, Sezione, Indirizzo, ID_AULA) 
VALUES (@Anno, @Sezione, @Indirizzo, @Aula)
END

EXECUTE [InserimentoClasse]
 @sezione = 'C', @Indirizzo = 'Chimica', @Anno = '1', @Aula = 1


CREATE PROCEDURE [InserimentoStudente] 
@ID_CLASSE INT,
@Nome varchar(50),
@Cognome varchar(50)
AS
BEGIN
-- ricerco la classe sulla base dell'id
-- DICHIARO LE VARIABILI CHE MI SERVONO (ANNO, SEZIONE E INDIRIZZO)
DECLARE @anno char(1)
DECLARE @sezione char(1)
DECLARE @indirizzo varchar(20)
SELECT @anno = c.Anno, @sezione = c.Sezione, @indirizzo = c.Indirizzo
FROM Classe as c
WHERE c.ID_Classe = @ID_CLASSE
INSERT INTO Studente (Nome, Cognome, Anno, Sezione, Indirizzo)
VALUES (@Nome, @Cognome, @Anno, @Sezione, @Indirizzo)
END

EXEC [InserimentoStudente] @ID_CLASSE = 1, @Nome = 'Mario', @Cognome = 'Rossi'

SELECT * FROM STUDENTE
SELECT * FROM DettagliClasseAulaStudenti

CREATE PROCEDURE [InserisciDisciplina] 
@Materia varchar(20),
@Docente varchar(50)
AS
BEGIN 
INSERT INTO Disciplina(Nome, Docente) VALUES (@Materia, @Docente)
END

EXEC [InserisciDisciplina] @materia = 'Italiano', @docente = 'Luca Bianchi'

CREATE PROCEDURE [InserisciVerifica]
@data date,
@nomeStudente varchar(50),
@cognomeStudente varchar(50),
@docente varchar(50),
@voto int
AS 
BEGIN
DECLARE @ID_STUDENTE INT
DECLARE @ID_MATERIA INT
SELECT @ID_STUDENTE = s.ID_Studente
FROM STUDENTE as S
WHERE S.Nome = @nomeStudente AND S.Cognome = @cognomeStudente
SELECT @ID_MATERIA = D.ID_DISCIPLINA
FROM DISCIPLINA AS D
WHERE D.Docente LIKE @docente
INSERT INTO Verifica VALUES (@data, @ID_MATERIA, @ID_STUDENTE, @voto)
END

EXECUTE InserisciVerifica @data = '28/07/2021', @nomeStudente = 'Mario',
@cognomeStudente = 'Rossi', @docente = 'Luca Bianchi', @voto = 8

SELECT * FROM Verifica

CREATE PROCEDURE [ModificaVerificheItaliano]
@votoDaModificare int,
@DOCENTE varchar(50)
AS
BEGIN 
DECLARE @ID_DISCIPLINA int
SELECT @ID_DISCIPLINA = ID_DISCIPLINA
FROM Disciplina
WHERE Docente = @DOCENTE and Nome = 'Italiano'
UPDATE VERIFICA set VOTO = @votoDaModificare 
END

EXEC ModificaVerificheItaliano @votoDaModificare = 6, @docente = 'Luca Bianchi'

-- FUNZIONI
CREATE FUNCTION Elenco_Studenti_Raggruppati(
	@anno char(1) = '0'
)
RETURNS TABLE
AS
RETURN 
SELECT C.sezione, c.Indirizzo, Count(*) as Num
FROM Studente as S
JOIN Classe as C
ON S.Anno = C.Anno and S.Indirizzo = C.Indirizzo and
S.Sezione = C.Sezione
WHERE s.Anno = @anno
GROUP BY C.Sezione, C.Indirizzo

SELECT *
FROM dbo.Elenco_Studenti_Raggruppati(null)

CREATE FUNCTION Numero_Studenti_Sezione(@sezione char(1))
RETURNS INT
AS
BEGIN
DECLARE @result int
SELECT @result = count(*)
FROM Studente as S
JOIN Classe as C
ON S.anno = c.anno and s.Sezione = c.Sezione and s.Indirizzo = c.Indirizzo
WHERE C.SEZIONE = @SEZIONE
RETURN @result
END


select dbo.Numero_Studenti_Sezione('c') as value


CREATE FUNCTION [GetClassiNumerose](@sezione char(1), @numeroStudenti int)
RETURNS TABLE
as 
return(
SELECT c.Anno, c.sezione, c.Indirizzo, a.Piano, a.Corpo
FROM CLASSE C
join aula a
on c.ID_AULA = a.ID_AULA
WHERE Sezione = @sezione AND dbo.Numero_Studenti_Sezione(@sezione) > @numeroStudenti)

SELECT * from dbo.GetClassiNumerose('b', 1) 


SELECT * FROM VERIFICA


CREATE PROCEDURE [InserisciVerificaConControllo]
@data date,
@nomeStudente varchar(50),
@cognomeStudente varchar(50),
@docente varchar(50),
@voto int
AS
BEGIN
	begin try
	-- OPERAZIONI CHE PROVOCANO LE ECCEZIONI
	DECLARE @ID_STUDENTE INT
	DECLARE @ID_MATERIA INT
	SELECT @ID_STUDENTE = s.ID_STUDENTE
	FROM STUDENTE s
	WHERE s.Nome = @nomeStudente AND s.Cognome = @cognomeStudente
	SELECT @ID_MATERIA = d.ID_DISCIPLINA
	from Disciplina d
	where d.Docente = @docente
	INSERT INTO Verifica values (@data, @id_materia, @id_studente, @voto)
	end try
	begin catch
	-- STAMPA DELLE ECCEZIONI
	SELECT ERROR_LINE(), ERROR_MESSAGE(), ERROR_SEVERITY()
	end catch
END

EXEC [InserisciVerificaConControllo] @data='31/07/2021', @nomeStudente='Mario',
@cognomeStudente = 'Rossi', @docente='Luca Bianchi', @voto=8

SELECT * FROM VERIFICA

CREATE PROCEDURE DeleteStudente @nomeStudente varchar(50),
@cognomeStudente varchar(50)
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	 --operazioni di cancellazione
	 -- recupero l'id dello studente
	 DECLARE @IDStudente int
	 SELECT @IDSTudente = s.ID_Studente
	 FROM Studente s
	 WHERE s.Nome = @nomeStudente and s.Cognome = @cognomeStudente
	 --cancello le verifiche di quello studente

	 DELETE FROM Verifica WHERE ID_STUDENTE = @IDStudente
	 
	 DELETE FROM Studente WHERE ID_Studente = @IDStudente
	 IF @@ERROR > 0
		ROLLBACK TRANSACTION

	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		SELECT ERROR_LINE(), ERROR_MESSAGE()
		ROLLBACK TRANSACTION 
	END CATCH
END

EXEC DeleteStudente @nomeStudente = 'Mario', @cognomeStudente = 'Rossi'

SELECT * FROM Studente

CREATE TRIGGER InserimentoConSuccesso
ON Studente AFTER INSERT
AS
PRINT 'Studente aggiunto con successo'

CREATE TRIGGER ControlloSuVerifica
ON Verifica AFTER INSERT
AS
IF EXISTS(SELECT * FROM VERIFICA WHERE Data > SYSDATETIME())
ROLLBACK