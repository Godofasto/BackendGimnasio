using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface IActividadesService
    {
        Task<List<Actividades>> RetornarTodasActividades();
        Task<bool> ExisteActividadConElMismoNombre(string nombre);
        Task AgregarActividad(Actividades actividad);
    }
    public class ActividadesService : IActividadesService
    {
        private readonly ApplicationDbContext context;

        public ActividadesService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Actividades>> RetornarTodasActividades()
        {
            return await context.Actividades.ToListAsync();
        }
        public async Task<bool> ExisteActividadConElMismoNombre(string nombre)
        {
            return await context.Actividades.AnyAsync(x => x.Nombre == nombre);
        }

        public async Task AgregarActividad(Actividades actividad)
        {
            context.Add(actividad);
            await context.SaveChangesAsync();
        }
    }
}