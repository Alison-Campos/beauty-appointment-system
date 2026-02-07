CREATE PROCEDURE sp_Clientes_Crear
	@Nombre NVARCHAR(150),
	@Telefono NVARCHAR(20),
	@Email NVARCHAR(150),
	@Notas NVARCHAR(255)
AS
BEGIN
	INSERT INTO Clientes (Nombre, Telefono, Email, Notas)
	VALUES (@Nombre,@Telefono, @Email, @Notas);

	SELECT SCOPE_IDENTITY();
END