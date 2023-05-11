using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface IEspaldaBicepsService
    {
        Task<List<EjerciciosEspaldaBiceps>> RetornarEspaldaBiceps();
    }
    public class EspaldaBicepsService : IEspaldaBicepsService
    {
        private readonly ApplicationDbContext context;
        public EspaldaBicepsService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<EjerciciosEspaldaBiceps>> RetornarEspaldaBiceps()
        {
            return await context.EjerciciosEspaldaBiceps.ToListAsync();
        }
    }
}
