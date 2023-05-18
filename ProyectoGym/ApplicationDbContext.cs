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
        public DbSet<Perfiles> Perfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Perfil) // Propiedad de navegación en Usuarios
                .WithMany() // La relación no es uno-a-muchos, ya que solo hay un perfil por usuario
                .HasForeignKey(u => u.PerfilId); // Columna FK en Usuarios
        }
    }

}