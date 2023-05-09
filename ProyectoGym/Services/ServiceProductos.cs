using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym.Services
{
    public interface IProductoService
    {
        Task<List<Productos>> RetornarTodo(string TipoDato);
    }
    public class ServiceProductos : IProductoService
    {
        private readonly ApplicationDbContext context;

        public ServiceProductos(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Productos>> RetornarTodo(string TipoDato)
        {
            if (!string.IsNullOrEmpty(TipoDato))
            {
                return await context.Producto.Where(p => p.Tipo == TipoDato).ToListAsync();
            }

            return await context.Producto.ToListAsync();
        }
    }
}
