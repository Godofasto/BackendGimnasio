using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface IEjerciciosService
    {
        Task<List<Ejercicios>> RetornarTodo(string TipoEjercicio);
    }
    public class EjerciciosService : IEjerciciosService
    {
        private readonly ApplicationDbContext context;

        public EjerciciosService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Ejercicios>> RetornarTodo(string TipoEjercicio)
        {
            if (!string.IsNullOrEmpty(TipoEjercicio))
            {
                return await context.Ejercicios.Where(p => p.idTipos == TipoEjercicio).ToListAsync();
            }

            return await context.Ejercicios.ToListAsync();
        }
    }
}
