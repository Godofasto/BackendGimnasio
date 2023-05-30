
using System.Linq; // Para usar LINQ en consultas
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoGym.Controllers.Request;
using ProyectoGym.Entidades;
using ProyectoGym.Services;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ProyectoGym.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        public readonly ApplicationDbContext context;
        public readonly IUsuariosService UsuariosService;
        public UsuariosController(ApplicationDbContext context, IUsuariosService UsuariosService)
        {
            this.context = context;
            this.UsuariosService = UsuariosService;
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
                try
                {
                    string patron = @"^(?:(?:\+|00)34|0)?[6789]\d{8}$";
                    Regex regex = new Regex(patron);
                    string telefonoString = (usuario.Tlf).ToString();
                    bool esValido = regex.IsMatch(telefonoString);
                    
                }
                catch(FormatException)
                {
                    return new ObjectResult("El número de teléfono no es válido")
                    {
                        StatusCode = StatusCodes.Status406NotAcceptable
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
        [HttpPost("Recoger")]
        public async Task<ActionResult<List<Usuarios>>> RetornarTodo() //Meterlo como un objeto y arreglarlo, ver como acceder al atributo del objeto
        {
            //if(!string.IsNullOrEmpty(dato.TipoDato))
            //{
            //    return await context.Producto.Where(p => p.Tipo == dato.TipoDato).ToListAsync();
            //}
            //return await context.Producto.ToListAsync();
            var usuarios = await UsuariosService.RetornarTodo(); //Viene del servicio que he creado para esto, acostumbrarme a hacerlo asi, y no olvidarme de meterlo en el startup.cs que si no no va
            return Ok(usuarios);
        }

    }
}
