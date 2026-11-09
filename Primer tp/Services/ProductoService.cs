using Primer_tp.Models;

namespace Primer_tp.Services
{
    // La clase recibe la interfaz IProductoService
    public class ProductoService : IProductoService
    {
        public IEnumerable<Producto> ObtenerTodos()
        {
            // Retorno temporal vacío. Más adelante se conecta la base de datos acá.
            return new List<Producto>();
        }

        public Producto ObtenerPorId(int id)
        {
            // Retorno temporal vacío.
            return new Producto();
        }
    }
}