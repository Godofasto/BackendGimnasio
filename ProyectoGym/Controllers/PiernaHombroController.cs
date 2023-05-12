using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/Ejercicios/PiernaHombro")]
    public class PiernaHombroController : ControllerBase
    {
        private readonly IPiernaHombroService PiernaHombroService;
        public readonly ApplicationDbContext context;

        public PiernaHombroController(ApplicationDbContext context, IPiernaHombroService PiernaHombroService)
        {
            this.context = context;
            this.PiernaHombroService = PiernaHombroService;
        }
        [HttpPost("RetornarPiernaHombro")]
        public async Task<ActionResult<List<EjerciciosPiernaHombro>>> RetornarPiernaHombro() //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            //if(!string.IsNullOrEmpty(dato.TipoDato))
            //{
            //    return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();
            //}
            //return await context.Producto.ToListAsync();
            var PiernaHombro = await PiernaHombroService.RetornarPiernaHombro(); //Viene del servicio que he creado para esto, acostumbrarme a hacerlo asi, y no olvidarme de meterlo en el startup.cs que si no no va
            return Ok(PiernaHombro);
        }
    }
}
