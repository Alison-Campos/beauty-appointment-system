CREATE PROCEDURE sp_Clientes_Obtener_PorId
	@IdCliente INT
AS
BEGIN
	SELECT IdCliente, Nombre, Telefono, Email, Notas, FechaCreacionCliente, Activo
	FROM Clientes
	WHERE IdCliente = @IdCliente;
END
