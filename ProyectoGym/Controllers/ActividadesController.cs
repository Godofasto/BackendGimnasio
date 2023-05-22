using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/Actividades")]
    public class ActividadesController : ControllerBase
    {
        private readonly IActividadesService ActividadesService;
        public readonly ApplicationDbContext context;

        public ActividadesController(ApplicationDbContext context, IActividadesService ActividadesService)
        {
            this.context = context;
            this.ActividadesService = ActividadesService;
        }
        [HttpPost("RetornarTodasActividades")]
        public async Task<ActionResult<List<Actividades>>> RetornarTodasActividades() //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            //if(!string.IsNullOrEmpty(dato.TipoDato))
            //{
            //    return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();
            //}
            //return await context.Producto.ToListAsync();
            var actividades = await ActividadesService.RetornarTodasActividades(); //Viene del servicio que he creado para esto, acostumbrarme a hacerlo asi, y no olvidarme de meterlo en el startup.cs que si no no va
            return Ok(actividades);
        }

        //public Task<ActionResult> PostEntrenadores(Entrenadores entrenador)
        //{
        //    return PostEntrenadores(entrenador, EntrenadoresService);
        //}

        [HttpPost("SubirActividades")]
        public async Task<ActionResult> PostActividades(Actividades actividades) //<-Ejemplo de Model Binding [FromBody]
        {
            var existeActividadConElMismoNombre = await ActividadesService.ExisteActividadConElMismoNombre(actividades.Nombre);

            if (existeActividadConElMismoNombre)
            {
                return BadRequest($"Ya existe una actividad con el nombre {actividades.Nombre}");
            }

            await ActividadesService.AgregarActividad(actividades);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteActividad(int Id)
        {
            var actividad = await context.Actividades.FindAsync(Id);
            if (actividad == null)
            {
                return NotFound();
            }
            context.Actividades.Remove(actividad);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}