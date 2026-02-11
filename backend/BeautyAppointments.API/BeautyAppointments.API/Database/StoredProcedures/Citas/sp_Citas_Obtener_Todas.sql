CREATE PROCEDURE sp_Citas_Obtener_Todas
AS
BEGIN 
	SELECT IdCita, ClienteId, ServicioId, UsuarioId, FechaInicio, FechaFin, Estado, Observaciones, FechaCreacionCita, Activo
	FROM Citas
	Where Activo = 1;
END