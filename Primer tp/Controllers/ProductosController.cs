using Microsoft.AspNetCore.Mvc;

namespace Primer_tp.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Esto define la ruta base como /api/productos
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Devuelve un mensaje de texto simple para verificar que el Controller funciona
            return Ok("¡La ruta GET /api/productos está funcionando correctamente!");
        }
    }
}