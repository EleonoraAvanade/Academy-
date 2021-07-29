-- Il nome dell’artista ed il titolo delle opere conservate alla “Galleria degli Uffizi” o alla “National Gallery”.

SELECT O.NomeA, O.Titolo 
FROM Opere O 
WHERE O.NomeM = “Galleria degli Uffizi” OR O.NomeM =“National Gallery”

--Il nome dell’artista ed il titolo delle opere di artisti spagnoli conservate nei musei di Firenze
SELECT NomeA, Titolo 
FROM Artisti A, Opere O, Musei M 
WHERE A.Nazionalità = “Spagna” AND M.Città = “Firenze” 
AND A.NomeA = O.NomeA AND O.NomeM = M.NomeM

--  Il codice ed il titolo delle opere di artisti italiani conservate nei musei di Londra, in cui è rappresentata la Madonna
SELECT O.Codice, O.Titolo 
FROM Opere O, Artisti A, Musei M, Personaggi P 
WHERE M.Città = “Londra” AND P.Personaggio = “Madonna” AND A.Nazionalità = “Italia” 
 AND A.NomeA=O.NomeA AND M.NomeM = O.NomeM AND O.Codice = P.Codice 

 -- Per ciascun museo di Londra, il numero di opere di artisti italiani ivi conservate
 select count (*)
 from museo m
 join artista
 on artista.museo_id = artista.id
 where artista.nazionalita = italia and museo.citta = londra
 group by museo.citta
 
 --  Il nome dei musei di Londra che non conservano opere di Tiziano
SELECT M.NomeM 
FROM Musei M 
WHERE M.Città = Londra” AND Not Exists 
( SELECT * 
 FROM Opere O 
 WHERE O.NomeA = “Tiziano ” AND M.NomeM = O.NomeM)

 --  Il nome dei musei di Londra che conservano solo opere di Tiziano
 SELECT M.NomeM 
FROM Musei M 
WHERE M.Città = Londra” AND Not Exists 
( SELECT * 
 FROM Opere O 
 WHERE O.NomeA <> “Tiziano ” 
 AND M.NomeM = O.NomeM)

 SELECT  mus.nome
from museo mus
where mus.citta = 'Londra' and 'Tiziano' = ALL
(
select a.Nome
FROM Museo m
JOIN Opera o
on m.ID = o.ID_MUSEO
JOIN Artista a
ON A.ID = o.ID_Artista
where m.ID = mus.ID
)

 -- I musei che conservano almeno 20 opere di artisti italiani
 SELECT O.NomeM 
FROM Opere O, Artisti A 
WHERE A.Nazionalità = “Italia” AND O.NomeA = A.NomeA 
GROUP BY O.NomeM 
HAVING Count (*) >=20 

-- Per ogni museo, il numero di opere divise per la nazionalità dell’artista
SELECT O.NomeM, A.Nazionalità, Count(*) 
FROM Opere O, Artisti A 
WHERE O.NomeA = A.NomeA 
GROUP BY O.NomeM, A.Nazionalità

-- per ogni museo di londra il numero di artisti
select distinct m.nome, count(distinct a.nome) as 'Numero Artisti'
FROM Museo as m
join Opera as o
on m.id = o.id_museo
join artista as a
on o.id_artista = a.id
where m.citta = 'Londra'
group by m.Nome



CREATE VIEW DettagliOpereMusei As
SELECT o.Titolo, A.Nome AS Artista, A.Nazionalita, m.Nome AS Museo, m.Citta
FROM   dbo.Museo AS m INNER JOIN
             dbo.Opera AS o ON m.ID = o.ID_MUSEO INNER JOIN
             dbo.Artista AS A ON o.ID_Artista = A.ID


CREATE PROCEDURE CambiaMuseo
@titoloOpera varchar(50),
@nomeMuseo varchar(50)
AS
BEGIN
DECLARE @idOpera int
DECLARE @idMuseo int
SELECT @idOpera = ID 
FROM OPERA
WHERE Titolo = @titoloOpera
SELECT @idMuseo = ID 
FROM Museo
WHERE Nome = @nomeMuseo
update Opera set id_museo = @idMuseo where ID = @idOpera
END

CREATE PROCEDURE DeleteArtista @nomeArtista INT
AS
BEGIN
BEGIN TRAN
	BEGIN TRY
	-- ELIMINARE STUDENTE PRIMA DA VERIFICA E POI DALLA TABELLA STUDENTE
	DELETE FROM PERSONAGGIO WHERE ID IN (
	SELECT p.ID
	FROM Personaggio p
	JOIN Opera O
	ON P.ID_Opera =  o.ID
	JOIN Artista A 
	ON a.ID = o.ID_Artista
	WHERE a.Nome = @nomeArtista
	)

	DELETE FROM Opera WHERE ID IN (
	SELECT o.ID
	from Opera O
	JOIN Artista A 
	ON a.ID = o.ID_Artista
	WHERE a.Nome = @nomeArtista
	)

	delete from artista where nome = @nomeArtista
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	--SELECT ERROR_NUMBER(), ERROR_MESSAGE()
	print(error_message())
	ROLLBACK TRANSACTION
	END CATCH
END