CREATE UNIQUE INDEX UX_Servicios_Nombre
ON Servicios(Nombre)
WHERE Activo = 1;