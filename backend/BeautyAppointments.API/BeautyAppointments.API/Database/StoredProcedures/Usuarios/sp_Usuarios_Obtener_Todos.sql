CREATE PROCEDURE sp_Usuarios_Actualizar
    @IdUsuario INT,
    @Servicio NVARCHAR(100),
    @Rol NVARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE Usuarios
    SET Servicio = @Servicio,
        Rol = @Rol,
        Activo = @Activo
    WHERE IdUsuario = @IdUsuario;
END