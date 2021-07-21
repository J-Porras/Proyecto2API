using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.Models
{
    public class Proyeccion
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int PeliculaId { get; set; }

        public Proyeccion(int id, int sala_id, String fecha, String hora, int pelicula_id)
        {
            this.Id = id;
            this.SalaId = sala_id;
            this.Fecha = fecha;
            this.Hora = hora;
            this.PeliculaId = pelicula_id;
        }

    }
}