using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/citas")]
    public class CitasController : ControllerBase
    {
        private readonly ICitasService CitasService;
        public readonly ApplicationDbContext context;

        public CitasController(ApplicationDbContext context, ICitasService CitasService)
        {
            this.context = context;
            this.CitasService = CitasService;
        }
        [HttpPost("RetornarTodasCitas")]
        public async Task<ActionResult<List<Citas>>> RetornarTodasCitas() //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            //if(!string.IsNullOrEmpty(dato.TipoDato))
            //{
            //    return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();
            //}
            //return await context.Producto.ToListAsync();
            var citas = await CitasService.RetornarTodasCitas(); //Viene del servicio que he creado para esto, acostumbrarme a hacerlo asi, y no olvidarme de meterlo en el startup.cs que si no no va
            return Ok(citas);
        }

        //public Task<ActionResult> PostEntrenadores(Entrenadores entrenador)
        //{
        //    return PostEntrenadores(entrenador, EntrenadoresService);
        //}

        [HttpPost("SubirCitas")]
        public async Task<ActionResult> PostCitas(Citas citas) //<-Ejemplo de Model Binding [FromBody]
        {
            await CitasService.AgregarCitas(citas);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCita(int Id)
        {
            var citas = await context.Citas.FindAsync(Id);
            if (citas == null)
            {
                return NotFound();
            }
            context.Citas.Remove(citas);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}