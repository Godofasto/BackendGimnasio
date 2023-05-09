using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface IEntrenadorService
    {
        Task<List<Entrenadores>> RetornarTodosEntrenadores();
        Task<bool> ExisteEntrenadorConElMismoNombre(string nombre);
        Task AgregarEntrenador(Entrenadores entrenador);
    }
    public class EntrenadoresService : IEntrenadorService
    {
        private readonly ApplicationDbContext context;

        public EntrenadoresService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Entrenadores>> RetornarTodosEntrenadores()
        {
            return await context.Entrenador.ToListAsync();
        }
        public async Task<bool> ExisteEntrenadorConElMismoNombre(string nombre)
        {
            return await context.Entrenador.AnyAsync(x => x.Nombre == nombre);
        }

        public async Task AgregarEntrenador(Entrenadores entrenador)
        {
            context.Add(entrenador);
            await context.SaveChangesAsync();
        }
    }
}

