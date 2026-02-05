CREATE PROCEDURE sp_Servicio_Crear
	@DuracionMin INT,
	@Precio DECIMAL(10,2),
	@ColorCalendario NVARCHAR(20)
AS
BEGIN
	INSERT INTO Servicios
	(
		DuracionMin,
		Precio,
		ColorCalendario
	)
	VALUES
	(
		@DuracionMin,
		@Precio,
		@ColorCalendario
	);

	SELECT SCOPE_IDENTITY();
END