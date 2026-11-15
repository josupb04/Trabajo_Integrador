using Microsoft.Data.SqlClient;
using Primer_tp.Models;

namespace Primer_tp.Data
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        // Recibimos IConfiguration por Inyección de Dependencias para leer el appsettings.json
        public ProductoRepository(IConfiguration configuration) //Herramienta de ASP.NET Core que lee el archivo appsettings.json. Se usa para traer la DefaultConnection sin tener que escribir la dirección del server
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'.");
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            var productos = new List<Producto>();

            try
            {
                // 'using' asegura que la conexión se cierre y libere de la memoria al terminar
                using (var connection = new SqlConnection(_connectionString))  // Puente fisico entre el programa y SQL Server.
                {
                    string query = "SELECT Id, Nombre, Precio, Stock FROM Productos";

                    using (var command = new SqlCommand(query, connection)) //Mensajero que lleva la consulta SELECT a traves de ese "tunel" o "puente"
                    {
                        connection.Open(); //Con esto abrimos la "puerta"
                         
                        using (var reader = command.ExecuteReader()) //Lector rápido hacia adelante que recibe que recibe la tabla de resultados de SQL y permite leer fila x fila para convertir cada registro en objeto C#
                        {
                            // Recorremos fila por fila los resultados que devuelve SQL Server
                            while (reader.Read())
                            {
                                productos.Add(new Producto
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Precio = Convert.ToDecimal(reader["Precio"]),
                                    Stock = Convert.ToInt32(reader["Stock"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Relanzamos un mensaje genérico para ocultar detalles internos del servidor
                throw new Exception("Ocurrió un error al intentar obtener los productos desde la base de datos.");
            }

            return productos;
        }

        public Producto? ObtenerPorId(int id)
        {
            Producto? producto = null;

            try //Si SQL Server está apagado, 
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    // Usamos el parámetro @Id en lugar de concatenar texto
                    string query = "SELECT Id, Nombre, Precio, Stock FROM Productos WHERE Id = @Id";

                    using (var command = new SqlCommand(query, connection)) //se usa VAR porque el método devuelve un objeto tipo SqlDataReader
                    {
                        // Asignamos el valor al parámetro de forma segura
                        command.Parameters.AddWithValue("@Id", id); //Esto sirve para bloquear cualquier intento de ejecutar comandos extraños.

                        connection.Open();

                        using (var reader = command.ExecuteReader()) // Este bloque permite que en cuanto termine de usarse, C# destruye el objeto para que no siga consumiendo memoria. 
                        {
                            // Usamos 'if' en lugar de 'while' porque esperamos como máximo 1 solo resultado
                            if (reader.Read())
                            {
                                producto = new Producto
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Precio = Convert.ToDecimal(reader["Precio"]),
                                    Stock = Convert.ToInt32(reader["Stock"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un error al intentar buscar el producto en la base de datos.");
            }

            return producto;
        }
    }
}