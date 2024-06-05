CREATE DATABASE TestDatabase;
GO

USE TestDatabase;
GO

CREATE TABLE Puestos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Estados (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Empleados (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fotografia NVARCHAR(MAX),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    PuestoId INT NULL,
    FechaNacimiento DATE NOT NULL,
    FechaContratacion DATE NOT NULL,
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(20),
    CorreoElectronico NVARCHAR(100),
    EstadoId INT NULL,
    FOREIGN KEY (PuestoId) REFERENCES Puestos(Id),
    FOREIGN KEY (EstadoId) REFERENCES Estados(Id)
);