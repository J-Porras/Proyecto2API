using Proyecto2.Filters;
using Proyecto2.Models;
using Proyecto2.Service;
using System.Net;
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
        [JwtAuthentication]
        [Authorize(Roles = "0")]

        public Sala getSalabyId(int idsala)
        {
            
            return this.servicesala.getSalabyId(idsala);
        }


        [Route("api/Sala/salas")]
        [HttpGet]

        [JwtAuthentication]
        [Authorize(Roles = "0")]

        public string getAllSalas()
        {
          //  var rol = User.Identity.ToString();
            return JsonSerializer.Serialize(this.servicesala.getAllSalas());

        }

        [Route("api/Sala/add")]
        [HttpPost]
        [JwtAuthentication]
        [Authorize(Roles = "0")]

        public IHttpActionResult addNewSala(Sala salabody)
        {
            try
            {
                if (this.servicesala.addNewSala(salabody))
                    return Ok(true);
                return StatusCode(HttpStatusCode.InternalServerError);


            }
            catch (System.Exception)
            {

                return  StatusCode(HttpStatusCode.InternalServerError);
            }
        }


    }
}
