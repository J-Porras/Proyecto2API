namespace Proyecto2.Models
{
    public class Usuario
    {
        public string Id { get; set; }//la autopropiedad genera un campo privadi y una propiedad publica
        public string Nombre { get; set; }
        public string Contrasenna { get; set; }
        public int Rol { get; set; }

        public Usuario(string id, string nombre, string contrasenna, int rol)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Contrasenna = contrasenna;
            this.Rol = rol;
        }

        public Usuario(string id, string nombre, int rol)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Rol = rol;
        }
    }
}