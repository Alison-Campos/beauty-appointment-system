CREATE PROCEDURE sp_Clientes_Eliminar
    @IdCliente INT
AS
BEGIN
    UPDATE Clientes
    SET Activo = 0
    WHERE IdCliente = @IdCliente;

    SELECT @@ROWCOUNT;
END