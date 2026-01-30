CREATE PROCEDURE sp_Usuarios_Eliminar
    @IdUsuario INT
AS
BEGIN
    UPDATE Usuarios
    SET Activo = 0
    WHERE IdUsuario = @IdUsuario;
END