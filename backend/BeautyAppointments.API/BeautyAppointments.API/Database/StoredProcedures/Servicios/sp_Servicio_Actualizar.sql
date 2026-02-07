CREATE PROCEDURE sp_Servicios_Actualizar
	@IdServicio INT,
	@Nombre NVARCHAR(100),
	@DuracionMin INT,
	@Precio DECIMAL(10,2),
	@ColorCalendario NVARCHAR(20),
	@Activo BIT
AS
BEGIN
	UPDATE Servicios
	SET
		DuracionMin = @DuracionMin,
		Nombre = @Nombre,
		Precio = @Precio,
		ColorCalendario = @ColorCalendario,
		Activo = @Activo
	WHERE IdServicio = @IdServicio

	SELECT @@ROWCOUNT;
END
