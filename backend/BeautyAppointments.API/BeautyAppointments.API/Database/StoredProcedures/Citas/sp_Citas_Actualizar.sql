CREATE PROCEDURE sp_Citas_Actualizar
	@IdCita INT,
	@FechaInicio DATETIME,
	@FechaFin DATETIME,
	@Estado NVARCHAR(30),
	@Observaciones  NVARCHAR(255),
	@Activo BIT
AS
BEGIN
	UPDATE Citas
	SET 
		FechaInicio = @FechaInicio,
		FechaFin = @FechaFin,
		Estado = @Estado,
		Observaciones = @Observaciones,
		Activo = @Activo
	WHERE IdCita = @IdCita;
	
	SELECT @@ROWCOUNT;
END
