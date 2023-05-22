using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface ICitasService
    {
        Task<List<Citas>> RetornarTodasCitas();
        Task AgregarCitas(Citas citas);
    }
    public class CitasService : ICitasService
    {
        private readonly ApplicationDbContext context;

        public CitasService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Citas>> RetornarTodasCitas()
        {
            return await context.Citas.ToListAsync();
        }
        public async Task AgregarCitas(Citas citas)
        {
            context.Add(citas);
            await context.SaveChangesAsync();
        }
    }
}