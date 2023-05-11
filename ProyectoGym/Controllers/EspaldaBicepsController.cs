using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/Ejercicios/EspaldaBiceps")]
    public class EspaldaBicepsController:ControllerBase
    {
        private readonly IEspaldaBicepsService EspaldaBicepsService;
        public readonly ApplicationDbContext context;
    
    public EspaldaBicepsController(ApplicationDbContext context, IEspaldaBicepsService EspaldaBicepsService)
    {
        this.context = context;
        this.EspaldaBicepsService = EspaldaBicepsService;
    }
        [HttpPost("RetornarEspaldaBiceps")]
        public async Task<ActionResult<List<EjerciciosEspaldaBiceps>>> RetornarEspaldaBiceps() //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            //if(!string.IsNullOrEmpty(dato.TipoDato))
            //{
            //    return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();
            //}
            //return await context.Producto.ToListAsync();
            var EspaldaBiceps = await EspaldaBicepsService.RetornarEspaldaBiceps(); //Viene del servicio que he creado para esto, acostumbrarme a hacerlo asi, y no olvidarme de meterlo en el startup.cs que si no no va
            return Ok(EspaldaBiceps);
        }
    }
}
