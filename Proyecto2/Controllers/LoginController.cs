using Proyecto2.Models;
using Proyecto2.Service;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Proyecto2.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class LoginController : ApiController
    {
        ServiceLogin servicelogin = new ServiceLogin();

        public LoginController()
        {
        }


        [Route("api/userLogin")]
        [HttpGet]
        public Usuario GetUsuarioById(Usuario u)
        {
            return this.servicelogin.login(u);
        }


    }
}
