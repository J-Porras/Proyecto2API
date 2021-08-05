using Proyecto2.Controllers;
using System.Web.Http;

namespace Proyecto2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //CORS
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.MessageHandlers.Add(new TokenValidationHandler());

            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
           // config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            //GlobalConfiguration.Configure(WebApiConfig.Register);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
