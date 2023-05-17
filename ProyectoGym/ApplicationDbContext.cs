using Microsoft.EntityFrameworkCore;
using ProyectoGym.Entidades;

namespace ProyectoGym
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        //public DbSet<Autor> Autores { get; set; }
        //public DbSet<Libro> Libros { get; set; }
        public DbSet<Productos> Producto { get; set; }
        public DbSet<Entrenadores> Entrenador { get; set; }
        public DbSet<EjerciciosEspaldaBiceps> EjerciciosEspaldaBiceps { get; set; }
        public DbSet<EjerciciosPechoTriceps> EjerciciosPechoTriceps { get; set; }
        public DbSet<EjerciciosPiernaHombro> EjerciciosPiernaHombro { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}