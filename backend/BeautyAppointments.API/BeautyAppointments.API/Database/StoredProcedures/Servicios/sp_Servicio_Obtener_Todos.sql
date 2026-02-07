CREATE PROCEDURE sp_Servicios_Obtener_Todos
AS
BEGIN 
	SELECT
		IdServicio,
		Nombre,
		DuracionMin, 
		Precio,
		ColorCalendario,
		Activo
	FROM Servicios;
END