CREATE DATABASE TallerMecanicoDB;
GO

USE TallerMecanicoDB;
GO

-- 1. Tabla TipoServicio (Pregunta 1 y 4)
CREATE TABLE TipoServicio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    PrecioBase DECIMAL(10,2) NOT NULL
);
GO

-- 2. Tabla Cliente (Pregunta 1)
CREATE TABLE Cliente (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Paterno VARCHAR(50) NOT NULL,
    Materno VARCHAR(50) NOT NULL,
    Nombres VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) NULL,
    Telefono VARCHAR(20) NULL
);
GO

-- 3. Tabla Vehiculo (Pregunta 1: Un cliente puede tener varios vehículos)
CREATE TABLE Vehiculo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Placa VARCHAR(10) NOT NULL UNIQUE,
    Marca VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    Anio INT NOT NULL,
    ClienteId INT NOT NULL,
    CONSTRAINT FK_Vehiculo_Cliente FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);
GO

-- 4. Tabla OrdenServicio (Pregunta 1 y 5)
CREATE TABLE OrdenServicio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaIngreso DATETIME DEFAULT GETDATE(),
    DescripcionProblema VARCHAR(MAX) NOT NULL,
    CostoEstimado DECIMAL(10,2) NOT NULL,
    Estado VARCHAR(30) NOT NULL,
    VehiculoId INT NOT NULL,
    TipoServicioId INT NOT NULL,
    CONSTRAINT FK_OrdenServicio_Vehiculo FOREIGN KEY (VehiculoId) REFERENCES Vehiculo(Id),
    CONSTRAINT FK_OrdenServicio_TipoServicio FOREIGN KEY (TipoServicioId) REFERENCES TipoServicio(Id)
);
GO

-- Datos iniciales base para pruebas inmediatas
INSERT INTO TipoServicio (Nombre, PrecioBase) VALUES 
('Mantenimiento Preventivo', 150.00),
('Alineacion y Balanceo', 80.00);

INSERT INTO Cliente (Paterno, Materno, Nombres, Correo, Telefono) VALUES 
('Perez', 'Gomez', 'Juan Carlos', 'juan.perez@test.com', '999888777');

INSERT INTO Vehiculo (Placa, Marca, Modelo, Anio, ClienteId) VALUES 
('ABC-123', 'Toyota', 'Corolla', 2022, 1);
GO