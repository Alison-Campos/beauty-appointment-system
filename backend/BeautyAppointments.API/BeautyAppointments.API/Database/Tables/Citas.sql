CREATE TABLE Citas (
IdCita INT IDENTITY PRIMARY KEY,
ClienteId INT NOT NULL,
ServicioId INT NOT NULL,
UsuarioId INT NOT NULL,
FechaInicio DATETIME NOT NULL,
FechaFin DATETIME NOT NULL,
Estado NVARCHAR(50) DEFAULT 'Programada',
Observaciones NVARCHAR(255),
Activo BIT NOT NULL DEFAULT 1,
FechaCreacionCita DATETIME DEFAULT GETDATE(),
CONSTRAINT FK_Citas_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(IdCliente),
CONSTRAINT FK_Citas_Servicios FOREIGN KEY (ServicioId) REFERENCES Servicios(IdServicio),
CONSTRAINT FK_Citas_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(IdUsuario)

);