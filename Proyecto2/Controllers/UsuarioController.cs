using Proyecto2.Filters;
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

        [JwtAuthentication]
        [Authorize(Roles = "0")]
        public string GetAllUsuarios()
        {
            return JsonSerializer.Serialize(servicelogin.GetAllUsuarios());
        }

        [Route("api/Usuario/user")]
        [JwtAuthentication]
        [Authorize(Roles = "0")]
        public Usuario GetUsuarioById(Usuario u)
        {
            return this.servicelogin.GetUsuarioById(u.Id);
        }

    }
}
