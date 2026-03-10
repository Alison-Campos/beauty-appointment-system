CREATE PROCEDURE sp_Servicio_Crear
	@Nombre NVARCHAR(100),
	@DuracionMin INT,
	@Precio DECIMAL(10,2),
	@ColorCalendario NVARCHAR(20)
AS
BEGIN

	IF EXISTS (
		SELECT 1 FROM Servicios
		WHERE Nombre = @Nombre
		AND Activo = 1
	)

	BEGIN
		RAISERROR('Ya existe un servicio con ese nombre',16,1)
		RETURN
	END

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