using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface IActividadesService
    {
        Task<List<Actividades>> RetornarTodasActividades();
        Task<bool> ExisteActividadConElMismoNombre(string nombre);
        Task AgregarActividad(Actividades actividad);
        Task<List<ActividadesConEntrenador>> RetornarActividadesConEntrenadores();

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
        public class ActividadConEntrenador
        {
            public Actividades Actividad { get; set; }
            public Entrenadores Entrenador { get; set; }
        }

        public async Task<List<ActividadesConEntrenador>> RetornarActividadesConEntrenadores()
        {
            var actividadesConEntrenador = await (from a in context.Actividades
                                                    join e in context.Entrenador on a.IdEntrenador equals e.Id
                                                    select new ActividadesConEntrenador
                                                    {
                                                        Actividad = a,
                                                        Entrenador = e
                                                    }).ToListAsync();

            return actividadesConEntrenador;
        }

    }
}