
using Proyecto2.Models;
using Proyecto2.Service;
using System.Text.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Proyecto2.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class UsuarioController : ApiController
    {
        ServiceLogin servicelogin = new ServiceLogin();

        [Route("api/Usuario/List")]
        [HttpGet]
        // GET: api/Usuario
        public string GetAllUsuarios()
        {
            return JsonSerializer.Serialize(servicelogin.GetAllUsuarios());
        }

        [Route("api/Usuario/user")]
        [HttpGet]
        public Usuario GetUsuarioById(Usuario u)
        {
            return this.servicelogin.GetUsuarioById(u.Id);
        }




        //// POST: api/Usuario
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Usuario/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Usuario/5
        //public void Delete(int id)
        //{
        //}
    }
}
