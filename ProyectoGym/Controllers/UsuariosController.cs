
using System.Linq; // Para usar LINQ en consultas
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        public readonly ApplicationDbContext context;
        public UsuariosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost("añadir")]
        public async Task<ActionResult> Post(Usuarios usuario) //<-Ejemplo de Model Binding [FromBody]
        {
            var existeUsuarioConElMismoNombre = await context.Usuarios.AnyAsync(x => x.Nombre == usuario.Nombre); //<-Booleano

            if (existeUsuarioConElMismoNombre)
            {
                //return BadRequest($"Ya existe un usuario con el nombre {usuario.Nombre}");
                return new ObjectResult("Ya existe un usuario con ese nombre")
                {
                    StatusCode = StatusCodes.Status409Conflict
                };
            }
            else if (!string.IsNullOrEmpty(usuario.Email))
            {
                try
                {
                    var mailAddress = new MailAddress(usuario.Email);
                }
                catch (FormatException)
                {
                    return new ObjectResult("La dirección de correo electrónico no es válida")
                    {
                        StatusCode = StatusCodes.Status417ExpectationFailed
                    };
                }
            }

            context.Add(usuario);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("comprobar")]
        public async Task<ActionResult> Login(Usuarios usuario)
        {
            var user = await context.Usuarios.FirstOrDefaultAsync(u => u.Nombre == usuario.Nombre);

            if(user == null|| user.Contrasena != usuario.Contrasena)
            {
                return Unauthorized();
                Console.WriteLine("mal");
            }
            Console.WriteLine("bien");
            return Ok();
        }
    }
}
