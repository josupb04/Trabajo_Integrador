using Primer_tp.Data;
using Primer_tp.Models;

namespace Primer_tp.Services
{
    public class ProductoService : IProductoService
    {
        // Guardamos la referencia al repositorio mediante su interfaz
        private readonly IProductoRepository _productoRepository;

        // CONSTRUCTOR: ASP.NET Core inyecta ProductoRepository automáticamente
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            // Delegamos la búsqueda al repositorio
            return _productoRepository.ObtenerTodos();
        }

        public Producto? ObtenerPorId(int id)
        {
            // Delegamos la búsqueda por ID al repositorio
            return _productoRepository.ObtenerPorId(id);
        }
    }
}