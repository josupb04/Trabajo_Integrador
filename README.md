# Web API de Productos - Programación 3

API REST desarrollada en **ASP.NET Core (.NET 8)** conectada a **SQL Server** mediante **ADO.NET**, implementando arquitectura en capas, Inyección de Dependencias y manejo controlado de excepciones y códigos de estado HTTP.

## Arquitectura del Proyecto

El código está organizado en capas para separar responsabilidades y desacoplar la lógica de negocio del acceso físico a los datos:

* **`Controllers/ProductosController.cs`**: Expone los endpoints HTTP, recibe las peticiones y devuelve los códigos de respuesta correspondientes (`200 OK`, `404 Not Found`, `500 Internal Server Error`).
* **`Services/IProductoService.cs` y `ProductoService.cs`**: Capa intermedia de lógica de negocio entre el controlador y el repositorio.
* **`Data/IProductoRepository.cs` y `ProductoRepository.cs`**: Capa de acceso a datos implementada con **ADO.NET** (`SqlConnection`, `SqlCommand`, `SqlDataReader`) utilizando consultas parametrizadas.
* **`Models/Producto.cs`**: Entidad que modela los registros de la tabla `Productos`.
* **`appsettings.json`**: Archivo de configuración que almacena la cadena de conexión (`DefaultConnection`).

## Tecnologías y Requisitos

* Visual Studio 2022
* .NET 8 SDK
* SQL Server LocalDB (`(localdb)\MSSQLLocalDB`)
* Paquete NuGet: `Microsoft.Data.SqlClient`

## Configuración de la Base de Datos

1. Conectarse a la instancia **`(localdb)\MSSQLLocalDB`** desde el Explorador de objetos de SQL Server en Visual Studio o desde SSMS.
2. Ejecutar el siguiente script SQL para crear la base de datos, la tabla y los datos iniciales:

```sql
CREATE DATABASE Programacion3;
GO

USE Programacion3;
GO

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
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
```

3. Verificar que `appsettings.json` contenga la siguiente cadena de conexión:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Programacion3;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## Ejecución y Endpoints

1. Abrir la solución `Primer tp.sln` en Visual Studio 2022.
2. Presionar **F5** para iniciar la aplicación y abrir **Swagger UI**.

| Método | Ruta | Descripción | Respuestas HTTP |
| :--- | :--- | :--- | :--- |
| `GET` | `/api/Productos` | Devuelve el listado completo de productos. | `200 OK`, `500 Internal Server Error` |
| `GET` | `/api/Productos/{id}` | Busca un producto por su identificador único. | `200 OK`, `404 Not Found`, `500 Internal Server Error` |
