CREATE PROCEDURE sp_Servicios_Eliminar
    @IdServicio INT
AS
BEGIN
    UPDATE Servicios
    SET Activo = 0
    WHERE IdServicio = @IdServicio;

    SELECT @@ROWCOUNT;
END
