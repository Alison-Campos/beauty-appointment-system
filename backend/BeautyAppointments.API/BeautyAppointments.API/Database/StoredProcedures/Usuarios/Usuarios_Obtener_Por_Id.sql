CREATE PROCEDURE sp_Usuarios_ObtenerPorId
	@IdUsuario INT

AS
BEGIN
	SELECT * FROM Usuarios
	WHERE IdUsuario = @IdUsuario;

END
