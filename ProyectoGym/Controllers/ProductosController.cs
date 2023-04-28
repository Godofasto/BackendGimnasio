using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        public readonly ApplicationDbContext context;
        public ProductosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("listado")]
        public async Task<ActionResult<List<Productos>>> Get()
        {
            return await context.Producto.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Productos producto) //<-Ejemplo de Model Binding [FromBody]
        {
            var existeAutorConElMismoNombre = await context.Producto.AnyAsync(x => x.Nombre == producto.Nombre); //<-Booleano

            if (existeAutorConElMismoNombre)
            {
                return BadRequest($"Ya existe un autor con el nombre {producto.Nombre}");
            }

            context.Add(producto);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
