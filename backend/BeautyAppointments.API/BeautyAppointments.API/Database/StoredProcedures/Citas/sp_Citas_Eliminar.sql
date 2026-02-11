CREATE PROCEDURE sp_Citas_Eliminar
    @IdCita INT
AS
BEGIN
    UPDATE Citas
    SET Activo = 0,
        Estado = 'Cancelada'
    WHERE IdCita = @IdCita;

    SELECT @@ROWCOUNT;
END