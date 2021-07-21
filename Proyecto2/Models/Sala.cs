using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto2.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Sala(int id,string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
    }
}