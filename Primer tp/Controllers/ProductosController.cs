using Microsoft.AspNetCore.Mvc;
using Primer_tp.Services;

namespace Primer_tp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        // Variable privada de solo lectura para guardar el servicio.
        private readonly IProductoService _productoService;
        //Se crea un espacio privado dentro del controlador para guardar el servicio a entregar. Readonly es para que nadie pueda modificar o reemplazar ese servicio mientras se procesa la petición


        // CONSTRUCTOR: Acá ocurre la Inyección de Dependencias
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        //Se usa constructor para que no tengamos que escribir "new Prod..." adentro del controlador. Al pedirlo x constructor, hacemos que el frmwrk sea quien fabrique el objeto y lo deje listo.


        // GET: api/productos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Delegamos la búsqueda al servicio
                var productos = _productoService.ObtenerTodos();

                // Devolvemos 200 OK con la lista de productos. El 200ok significa que todo salió bien.
                return Ok(productos);
            }
            catch (Exception ex)
            {
                // Si falla la BD, devolvemos error 500 con el mensaje controlado del repositorio
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        // GET: api/productos/5 (El {id} captura el número que venga en la URL)
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var producto = _productoService.ObtenerPorId(id);

                // Si el repositorio devolvió null, el ID no existe en SQL Server (404 Not Found)
                if (producto == null)
                {
                    return NotFound(new { mensaje = $"No se encontró ningún producto con el ID {id}." });
                }

                // Si existe, devolvemos 200 OK con los datos del producto
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }
    }
}