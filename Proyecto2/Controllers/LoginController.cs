using Proyecto2.Models;
using Proyecto2.Service;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Jwt;

namespace Proyecto2.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class LoginController : ApiController
    {

        [HttpGet]
        [Route("api/echoping")]
        [AllowAnonymous]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("api/echouser")]
        [AllowAnonymous]

        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("api/userLogin")]
        [AllowAnonymous]

        public IHttpActionResult Authenticate(Usuario userhttp)
        {
            ServiceLogin serviceLogin = new ServiceLogin();
            if (userhttp == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Usuario u = serviceLogin.GetUsuarioById(userhttp.Id);
            if (u is object)
            {
                var token = JwtManager.GenerateToken(u.Id,u.Rol);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
