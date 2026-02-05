CREATE PROCEDURE sp_Usuario_Actualizar
    @IdUsuario INT,
    @Servicio NVARCHAR(100),
    @Email NVARCHAR(150),
    @Rol NVARCHAR(50),
    @Activo BIT
AS
BEGIN
    UPDATE dbo.Usuarios
    SET
        Servicio = @Servicio,
        Email = @Email,
        Rol = @Rol,
        Activo = @Activo
    WHERE IdUsuario = @IdUsuario;

    SELECT @@ROWCOUNT;
END