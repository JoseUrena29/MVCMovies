CREATE PROCEDURE spUpdateMovie
	@IdMovie INT,
	@Name VARCHAR(100),
	@Genere VARCHAR(100),
	@Date VARCHAR(100)
AS
BEGIN
	UPDATE Movies
	   SET 
	   	IdMovie=@IdMovie,
		Name=@Name,
		Genere=@Genere,
		Date=@Date
	 WHERE IdMovie = @IdMovie
END
GO

SELECT * FROM Movies

exec spUpdateMovie 5,'Cocoo','Comedia','2017'
exec spUpdateMovie 3,'Terremoto','Acción','2015'
