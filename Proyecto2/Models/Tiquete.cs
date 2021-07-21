namespace Proyecto2.Models
{
    public class Tiquete
    {
        //falta el ID de la pelicula
        public int Id { get; set; }
        public int IdProyeccion { get; set; }
        public string IdCliente { get; set; }
        public string Asiento { get; set; }

        public int IdPelicula { get; set; }
        public int IdSala { get; set; }
    


        public Tiquete(int id, int id_proyeccion, string id_cliente, string asiento,int id_pelicula,int id_sala)
        {
            this.Id = id;
            this.IdProyeccion = id_proyeccion;
            this.IdCliente = id_cliente;
            this.Asiento = asiento;
            this.IdPelicula = id_pelicula;
            this.IdSala = id_sala;  
        }


    }
}