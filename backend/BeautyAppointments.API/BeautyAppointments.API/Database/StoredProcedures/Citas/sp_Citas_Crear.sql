CREATE PROCEDURE sp_Citas_Crear
	@ClienteId INT,
	@ServicioId INT,
	@UsuarioId INT,
	@FechaInicio DATETIME,
	@FechaFin DATETIME,
	@Observaciones NVARCHAR(255)

AS
BEGIN
	INSERT INTO Citas
	(
		ClienteId,
		ServicioId,
		UsuarioId,
		FechaInicio,
		FechaFin,
		Observaciones,
		FechaCreacionCita
	)
	VALUES
	(
		@ClienteId,
		@ServicioId,
		@UsuarioId,
		@FechaInicio,
		@FechaFin,
		@Observaciones,
		GETDATE()
	);

	SELECT SCOPE_IDENTITY();
END