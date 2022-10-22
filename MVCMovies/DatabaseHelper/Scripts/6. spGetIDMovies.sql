CREATE PROCEDURE spGetIDMovie
	@IdMovie INT
AS
BEGIN
	SELECT * FROM Movies where IdMovie=@IdMovie
END
GO

exec spGetIDMovie 2
SELECT * FROM Movies