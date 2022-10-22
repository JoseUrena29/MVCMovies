
CREATE PROCEDURE spDeleteMovie
	@IdMovie INT
AS
BEGIN
	DELETE FROM Movies
	WHERE IdMovie = @IdMovie

END
GO

SELECT * FROM Movies

Exec spDeleteMovie 4
