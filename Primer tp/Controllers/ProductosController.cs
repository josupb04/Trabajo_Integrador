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


        [HttpGet]
        public IActionResult Get()
        {
            // Delegamos la búsqueda al servicio
            var productos = _productoService.ObtenerTodos();

            // Devolvemos 200 OK con la lista de productos. El 200ok significa que todo salió bien.
            return Ok(productos);
        }
    }
}