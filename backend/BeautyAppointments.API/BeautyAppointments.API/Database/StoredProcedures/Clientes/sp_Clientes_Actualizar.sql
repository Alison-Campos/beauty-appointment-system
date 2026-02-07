CREATE PROCEDURE sp_Clientes_Actualizar
	@IdCliente INT,
	@Nombre NVARCHAR(100),
	@Telefono NVARCHAR(20),
	@Email NVARCHAR(150),
	@Notas NVARCHAR(255),
	@Activo BIT
AS
BEGIN	
	UPDATE Clientes
	SET
		Nombre = @Nombre,
		Telefono = @Telefono,
		Email = @Email,
		Notas = @Notas,
		Activo = @Activo
	WHERE IdCliente = @IdCliente;

	SELECT @@ROWCOUNT;
END