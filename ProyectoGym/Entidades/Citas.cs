namespace ProyectoGym.Entidades
{
    public class Citas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public int UsuariosId { get; set; }
        public int ActividadesId { get; set; }
    }
}
