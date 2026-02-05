CREATE PROCEDURE sp_Servicio_Actualizar
	@IdServicio INT,
	@DuracionMin INT,
	@Precio DECIMAL(10,2),
	@ColorCalendario NVARCHAR(20),
	@Activo BIT
AS
BEGIN
	UPDATE Servicios
	SET
		DuracionMin = @DuracionMin,
		Precio = @Precio,
		ColorCalendario = @ColorCalendario,
		Activo = @Activo
	WHERE IdServicio = @IdServicio

	SELECT @@ROWCOUNT;
END
