using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.Models
{
    public class Pelicula
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public bool InCartelera { get; set; }

        public Pelicula(int _id,string _nombre, double _precio, bool _inCartelera)
        {
            this.Id = _id;
            this.Nombre = _nombre;
            this.Precio = _precio;
            this.InCartelera = _inCartelera;
                
        }


    }
}