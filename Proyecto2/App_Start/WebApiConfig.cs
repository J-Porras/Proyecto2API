using Proyecto2.Controllers;
using Proyecto2.Filters;
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
           // config.Filters.Add(new AuthorizeAttribute());

            //GlobalConfiguration.Configure(WebApiConfig.Register);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
