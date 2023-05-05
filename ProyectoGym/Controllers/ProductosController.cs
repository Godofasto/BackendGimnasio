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

        [HttpGet("listadoSuplementacion")]
        public async Task<ActionResult<List<Productos>>> GetSup()
        {
            return await context.Producto.Where(p => p.Tipo == "Suplementos").ToListAsync();
        }

        [HttpGet("listadoModa")]
        public async Task<ActionResult<List<Productos>>> GetMod()
        {
            return await context.Producto.Where(q => q.Tipo == "Moda").ToListAsync();
        }

        [HttpGet("listadoEquipamiento")]
        public async Task<ActionResult<List<Productos>>> GetEquip()
        {
            return await context.Producto.Where(j => j.Tipo == "Equipamiento").ToListAsync();
        }

        [HttpPost("añadir")]
        public async Task<ActionResult> Post(Productos producto) //<-Ejemplo de Model Binding [FromBody]
        {
            var existeProductoConElMismoNombre = await context.Producto.AnyAsync(x => x.Nombre == producto.Nombre); //<-Booleano

            if (existeProductoConElMismoNombre)
            {
                return BadRequest($"Ya existe un producto con el nombre {producto.Nombre}");
            }

            context.Add(producto);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
