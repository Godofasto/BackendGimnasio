using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/ejercicios")]
    public class EjerciciosController : ControllerBase
    {
        private readonly IEjerciciosService EjerciciosService;
        public readonly ApplicationDbContext context;
        public EjerciciosController(ApplicationDbContext context, IEjerciciosService EjerciciosService)
        {
            this.context = context;
            this.EjerciciosService = EjerciciosService;
        }
        [HttpPost("RetornarTodo")]
        public async Task<ActionResult<List<Ejercicios>>> RetornarTodo([FromBody] RetornarEjercicios dato) //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            //if(!string.IsNullOrEmpty(dato.TipoDato))
            //{
            //    return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();
            //}
            //return await context.Producto.ToListAsync();
            var ejercicios = await EjerciciosService.RetornarTodo(dato.datoEjercicio); //Viene del servicio que he creado para esto, acostumbrarme a hacerlo asi, y no olvidarme de meterlo en el startup.cs que si no no va
            return Ok(ejercicios);
        }
    }
}
