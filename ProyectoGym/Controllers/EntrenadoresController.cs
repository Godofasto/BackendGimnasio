using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/entrenadores")]
    public class EntrenadoresController : ControllerBase
    {
        private readonly IEntrenadorService EntrenadoresService;
        public readonly ApplicationDbContext context;

        public EntrenadoresController(ApplicationDbContext context, IEntrenadorService EntrenadoresService)
        {
            this.context = context;
            this.EntrenadoresService = EntrenadoresService;
        }
        [HttpPost("RetornarTodosEntrenadores")]
        public async Task<ActionResult<List<Entrenadores>>> RetornarTodosEntrenadores() //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            //if(!string.IsNullOrEmpty(dato.TipoDato))
            //{
            //    return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();
            //}
            //return await context.Producto.ToListAsync();
            var entrenadores = await EntrenadoresService.RetornarTodosEntrenadores(); //Viene del servicio que he creado para esto, acostumbrarme a hacerlo asi, y no olvidarme de meterlo en el startup.cs que si no no va
            return Ok(entrenadores);
        }

        //public Task<ActionResult> PostEntrenadores(Entrenadores entrenador)
        //{
        //    return PostEntrenadores(entrenador, EntrenadoresService);
        //}

        [HttpPost("SubirEntrenadores")]
        public async Task<ActionResult> PostEntrenadores(Entrenadores entrenador) //<-Ejemplo de Model Binding [FromBody]
        {
            var existeEntrenadorConElMismoNombre = await EntrenadoresService.ExisteEntrenadorConElMismoNombre(entrenador.Nombre);

            if (existeEntrenadorConElMismoNombre)
            {
                return BadRequest($"Ya existe un entrenador con el nombre {entrenador.Nombre}");
            }

            await EntrenadoresService.AgregarEntrenador(entrenador);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteEntre(int Id)
        {
            var entrenador = await context.Entrenador.FindAsync(Id);
            if (entrenador == null)
            {
                return NotFound();
            }
            context.Entrenador.Remove(entrenador);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}