CREATE PROCEDURE sp_ClienteS_Obtener_Todos
AS
BEGIN 
	SELECT IdCliente, Nombre, Telefono, Email, Notas, FechaCreacionCliente, Activo
	FROM Clientes
	Where Activo = 1;
END