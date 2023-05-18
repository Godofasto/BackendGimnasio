namespace ProyectoGym.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Tlf { get; set; }
        public string Contrasena { get; set; }
        public string Sexo { get; set; }
        public int PerfilId { get; set; } // Nueva propiedad FK
        public Perfiles Perfil { get; set; } // Propiedad de navegación
    }
}
