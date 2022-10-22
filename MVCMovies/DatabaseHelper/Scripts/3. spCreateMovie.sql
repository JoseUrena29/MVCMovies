CREATE PROCEDURE spCreateMovie
	@IdMovie INT,
	@Name VARCHAR(100),
	@Genere VARCHAR(100),
	@Date VARCHAR(100),
	@Photo VARCHAR(50)
AS
BEGIN

INSERT INTO Movies(
			IdMovie,
			Name,
			Genere,
			Date,
			Photo)

VALUES
	(@IdMovie,
	@Name,
	@Genere,
	@Date,
	@Photo)

END
GO
