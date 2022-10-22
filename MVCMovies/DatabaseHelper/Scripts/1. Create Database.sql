CREATE DATABASE MVCMovies

USE MVCMovies

CREATE TABLE Movies(
IdMovie INT NOT NULL,
Name VARCHAR(100) NOT NULL,
Genere VARCHAR(100) NOT NULL,
Date VARCHAR(100) NOT NULL,
Photo VARCHAR(50)

--Primary key
CONSTRAINT PKMovies PRIMARY KEY(IdMovie)
)

USE MVCMovies
GO

INSERT INTO Movies(
			IdMovie,
			Name,
			Genere,
			Date,
			Photo)
VALUES
(1,'Un Viaje Salvaje','Comedia','2022','/images/1.jpg'),
(2,'Pinocho','Infaltil/Aventura','2022','/images/2.jpg'),
(3,'Terremoto','Acción','2014','/images/3.jpg'),
(4,'Lucy','Acción','2015','/images/4.jpg')

SELECT * FROM Movies

