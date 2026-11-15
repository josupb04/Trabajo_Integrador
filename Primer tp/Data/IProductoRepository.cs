using Primer_tp.Models;

namespace Primer_tp.Data //ubica la interfaz en el espacio de nombres de la capa de datos
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> ObtenerTodos(); //Obliga a traer toda la lista de registros de la tabla Productos
        Producto? ObtenerPorId(int id); //Obliga a usar un unico produccto por su identificador. El signo de pregunta habilita a que si buscamos un ID inexistente en la BDD, el método tiene permitido devolver un 
                                        // Null sin generar advertencias. 
    }
}