CREATE PROCEDURE sp_Citas_Crear
	@ClienteId INT,
	@ServicioId INT,
	@UsuarioId INT,
	@FechaInicio DATETIME,
	@FechaFin DATETIME,
	@Observaciones NVARCHAR(255),
	@FechaCreacionCita DATETIME

AS
BEGIN
	INSERT INTO Citas
	(
		ClienteId,
		ServicioId,
		UsuarioId,
		FechaInicio,
		FechaFin,
		Observaciones
	)
	VALUES
	(
		@ClienteId,
		@ServicioId,
		@UsuarioId,
		@FechaInicio,
		@FechaFin,
		@Observaciones
	);

	SELECT SCOPE_IDENTITY();
END