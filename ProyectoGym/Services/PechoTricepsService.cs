using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface IPechoTricepsService
    {
        Task<List<EjerciciosPechoTriceps>> RetornarPechoTriceps();
    }
    public class PechoTricepsService : IPechoTricepsService
    {
        private readonly ApplicationDbContext context;
        public PechoTricepsService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<EjerciciosPechoTriceps>> RetornarPechoTriceps()
        {
            return await context.EjerciciosPechoTriceps.ToListAsync();
        }
    }
}