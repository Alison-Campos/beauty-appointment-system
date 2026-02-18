CREATE PROCEDURE sp_Cita_ValidarDisponibilidad
    @UsuarioId INT,
    @FechaInicio DATETIME,
    @FechaFin DATETIME,
    @IdCita INT = NULL -- para cuando actualizas
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM Citas
        WHERE UsuarioId = @UsuarioId
        AND Activo = 1
        AND (@IdCita IS NULL OR IdCita <> @IdCita)
        AND @FechaInicio < FechaHoraFin -- Empiezas antes de que termine la otra
        AND @FechaFin > FechaHoraInicio -- Termina después del inicio de otra
    )
        SELECT 0 -- NO disponible
    ELSE
        SELECT 1 -- Disponible

END