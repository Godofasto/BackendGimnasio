using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/actividadesEntrenador")]
    public class ActividadesConEntrenadorController : ControllerBase
    {
        private readonly IActividadesService ActividadesService;
        public readonly ApplicationDbContext context;
        public ActividadesConEntrenadorController(ApplicationDbContext context, IActividadesService ActividadesService)
        {
            this.context = context;
            this.ActividadesService = ActividadesService;
        }
        [HttpPost("RetornarTodo")]
        public async Task<ActionResult<List<ActividadesConEntrenador>>> RetornarActividadesConEntrenadores() //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            //if(!string.IsNullOrEmpty(dato.TipoDato))
            //{
            //    return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();
            //}
            //return await context.Producto.ToListAsync();
            var actividadesEntrenadores = await ActividadesService.RetornarActividadesConEntrenadores(); //Viene del servicio que he creado para esto, acostumbrarme a hacerlo asi, y no olvidarme de meterlo en el startup.cs que si no no va
            return Ok(actividadesEntrenadores);
        }
    }
}
