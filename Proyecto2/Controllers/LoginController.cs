using Proyecto2.Models;
using Proyecto2.Service;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Proyecto2.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class LoginController : ApiController
    {

        [HttpGet]
        [Route("api/echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("api/echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("api/userLogin")]
        public IHttpActionResult Authenticate(Usuario userhttp)
        {
            ServiceLogin serviceLogin = new ServiceLogin();
            if (userhttp == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            Usuario u = serviceLogin.GetUsuarioById(userhttp.Id);
            //bool isCredentialValid = (login.Password == "123456");
            if (u is object)
            {
                var token = TokenGenerator.GenerateTokenJwt(userhttp.Id);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
