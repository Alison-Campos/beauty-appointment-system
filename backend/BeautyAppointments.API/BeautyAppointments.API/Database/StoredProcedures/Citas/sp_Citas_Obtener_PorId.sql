CREATE PROCEDURE sp_Citas_Obtener_PorId
	@IdCita INT
AS
BEGIN 
	SELECT IdCita, ClienteId, ServicioId, UsuarioId, FechaInicio, FechaFin, Estado, Observaciones, FechaCreacionCita, Activo
	FROM Citas
	WHERE IdCita = @IdCita;
END