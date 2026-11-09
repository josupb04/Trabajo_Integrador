CREATE DATABASE Programacion3;
GO

USE Programacion3;
GO

CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL
);
GO

INSERT INTO Productos (Nombre, Precio, Stock) VALUES
('Teclado Mecánico', 85000.00, 10),
('Mouse Inalámbrico', 15000.00, 25),
('Monitor 24 pulgadas', 192000.00, 5),
('Auriculares Bluetooth', 110000.00, 8),
('Memoria RAM 16GB', 45000.00, 15);
GO

SELECT * FROM Productos;