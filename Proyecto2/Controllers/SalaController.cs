using Proyecto2.Models;
using Proyecto2.Service;
using System.Text.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Proyecto2.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class SalaController : ApiController
    {
        ServiceSala servicesala = new ServiceSala();

        
        [Route("api/Sala/sala/{idsala}")]
        [HttpGet]
        public Sala getSalabyId(int idsala)
        {
            return this.servicesala.getSalabyId(idsala);
        }


        [Route("api/Sala/salas")]
        [HttpGet]
        public string getAllSalas()
        {
            return JsonSerializer.Serialize(this.servicesala.getAllSalas());
        }
         

    }
}
