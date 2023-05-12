using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface IPiernaHombroService
    {
        Task<List<EjerciciosPiernaHombro>> RetornarPiernaHombro();
    }
    public class PiernaHombroService : IPiernaHombroService
    {
        private readonly ApplicationDbContext context;
        public PiernaHombroService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<EjerciciosPiernaHombro>> RetornarPiernaHombro()
        {
            return await context.EjerciciosPiernaHombro.ToListAsync();
        }
    }
}