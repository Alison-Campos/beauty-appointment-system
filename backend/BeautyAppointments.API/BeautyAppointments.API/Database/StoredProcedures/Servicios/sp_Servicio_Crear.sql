CREATE PROCEDURE sp_Servicio_Crear
	@Nombre NVARCHAR(100),
	@DuracionMin INT,
	@Precio DECIMAL(10,2),
	@ColorCalendario NVARCHAR(20)
AS
BEGIN
	INSERT INTO Servicios
	(
		Nombre,
		DuracionMin,
		Precio,
		ColorCalendario
	)
	VALUES
	(
		@Nombre,
		@DuracionMin,
		@Precio,
		@ColorCalendario
	);

	SELECT SCOPE_IDENTITY();
END