using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Dispatcher;
using AppSDK.Managers.RouteManager;
using System.Collections.Generic;

namespace AppSDK.Api
{
    public static class SDKWebApiConfig
    {
        public static List<RouteEntry> RouteEntryList = new List<RouteEntry>();
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.

            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //config.Services.Replace(typeof(IHttpControllerSelector), new ApiControllerSelector(config));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //for (int i = 0; i < RouteEntryList.Count; i++)
            //{
            //    config.Routes.MapHttpRoute(
            //      name: RouteEntryList[i].Name,
            //      routeTemplate: RouteEntryList[i].Url,
            //      defaults: RouteEntryList[i].Defaults
            //     );
            //}

        }
    }
}
