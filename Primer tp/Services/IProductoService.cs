using Primer_tp.Models;

namespace Primer_tp.Services
{
    public interface IProductoService
    {
        //Define el contrato: Qué operaciones debe proporcionar el servicio
        IEnumerable<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
    }
}
