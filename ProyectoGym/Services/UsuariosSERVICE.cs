using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface IUsuariosService
    {
        Task<List<Usuarios>> RetornarTodo();
    }
    public class UsuariosSERVICE : IUsuariosService
    {
        private readonly ApplicationDbContext context;

        public UsuariosSERVICE(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Usuarios>> RetornarTodo()
        {
            return await context.Usuarios.ToListAsync();
        }
    }
}