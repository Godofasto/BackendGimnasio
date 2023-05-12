using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/Ejercicios/PechoTriceps")]
    public class PechoTricepsController : ControllerBase
    {
        private readonly IPechoTricepsService PechoTricepsService;
        public readonly ApplicationDbContext context;

        public PechoTricepsController(ApplicationDbContext context, IPechoTricepsService PechoTricepsService)
        {
            this.context = context;
            this.PechoTricepsService = PechoTricepsService;
        }
        [HttpPost("RetornarPechoTriceps")]
        public async Task<ActionResult<List<EjerciciosPechoTriceps>>> RetornarPechoTriceps() //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            //if(!string.IsNullOrEmpty(dato.TipoDato))
            //{
            //    return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();
            //}
            //return await context.Producto.ToListAsync();
            var PechoTriceps = await PechoTricepsService.RetornarPechoTriceps(); //Viene del servicio que he creado para esto, acostumbrarme a hacerlo asi, y no olvidarme de meterlo en el startup.cs que si no no va
            return Ok(PechoTriceps);
        }
    }
}
