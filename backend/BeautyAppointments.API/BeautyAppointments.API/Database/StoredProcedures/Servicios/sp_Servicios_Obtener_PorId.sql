CREATE PROCEDURE sp_Servicios_Obtener_PorId
	@IdServicio INT
AS
BEGIN
	SELECT
		IdServicio,
		Nombre,
		DuracionMin,
		Precio,
		ColorCalendario,
		Activo
	FROM Servicios
	WHERE IdServicio =	@IdServicio;
END