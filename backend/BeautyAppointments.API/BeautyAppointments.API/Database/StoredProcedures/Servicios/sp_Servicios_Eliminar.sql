CREATE PROCEDURE sp_Servicios_Eliminar
    @IdServicio INT
AS
BEGIN
    DELETE FROM Servicios
    WHERE IdServicio = @IdServicio;

    SELECT @@ROWCOUNT;
END