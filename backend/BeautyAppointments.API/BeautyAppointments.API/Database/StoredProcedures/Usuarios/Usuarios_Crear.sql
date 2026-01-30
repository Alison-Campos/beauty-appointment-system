CREATE PROCEDURE sp_Usuarios_Crear
	@Servicio NVARCHAR(100),
	@Email NVARCHAR(150),
	@PasswordHash NVARCHAR(255),
	@Rol NVARCHAR(50)
AS 
BEGIN
	INSERT INTO Usuarios (Servicio, Email, PasswordHash, Rol)
	Values (@Servicio, @Email, @PasswordHash, @Rol)

	SELECT SCOPE_IDENTITY();


END
