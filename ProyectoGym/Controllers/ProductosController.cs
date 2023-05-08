using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
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
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        [HttpPost("RetornarTodo")]
        public async Task<ActionResult<List<Productos>>> RetornarTodo(RetornarTodoRequest dato) //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            if(dato.TipoDato == "Todo")
            {
                return await context.Producto.ToListAsync();
            }
            
            return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();

        }
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

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
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteProd(int Id)
        {
            var producto = await context.Producto.FindAsync(Id);
            if(producto== null)
            {
                return NotFound();
            }
            context.Producto.Remove(producto);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
