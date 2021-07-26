using Proyecto2.DAOs;
using Proyecto2.Models;
using System.Collections.Generic;

namespace Proyecto2.Service
{
    public class ServiceSala
    {
        private SalaDAO saladao;
        public ServiceSala()
        {
            saladao = new SalaDAO();
        }

        public Sala getSalabyId(int id)
        {
            return this.saladao.GetSalaById(id);
        }

        public List<Sala> getAllSalas()
        {
            return this.saladao.GetAllSalas();
        }

    }
}