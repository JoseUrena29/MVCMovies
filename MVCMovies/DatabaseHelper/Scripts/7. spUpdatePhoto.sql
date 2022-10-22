USE [MVCMovies]
GO

CREATE PROCEDURE spUpdatePhoto
	@Photo VARCHAR(50),
	@IdMovie INT
AS
	BEGIN
		UPDATE Movies SET Photo = @Photo 
		WHERE IdMovie = @IdMovie
	END

Select * from Movies

exec spUpdatePhoto '/images/5.jpg',5