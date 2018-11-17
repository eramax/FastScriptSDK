using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppSDK.Managers.RouteManager
{
    class SdkRouteManager
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.js/{*pathInfo}");
            routes.IgnoreRoute("{resource}.css/{*pathInfo}");
            routes.IgnoreRoute("{resource}.svc/{*pathInfo}");
            routes.IgnoreRoute("{resource}.woff");
            routes.IgnoreRoute("{resource}.woff2");
            routes.IgnoreRoute("{resource}.ttf");

            var routeEntryList = new List<RouteEntry>
            {
                new RouteEntry("User/Login", "User", "Login"),
                //new RouteEntry("User/ELogin", "User", "ELogin"),

                //new RouteEntry("Home/ContactUs", "Home", "ContactUs"),
                //new RouteEntry("Schedule/{id}", "Schedule", "Index"),

                //new RouteEntry("User/ForgetPassword", "User", "ForgetPassword"),
                //new RouteEntry("User/ForgetPasswordChoice", "User", "ForgetPasswordChoice"),
                //new RouteEntry("User/ActivateAccount", "User", "ActivateAccount"),
                //new RouteEntry("User/ChangePassword", "User", "ChangePassword"),
                //new RouteEntry("User/AddUserRegisteration", "User", "AddUserRegisteration"),
                //new RouteEntry("DefaultCaptcha/Generate", "DefaultCaptcha", "Generate"),
                //new RouteEntry("DefaultCaptcha/refresh", "DefaultCaptcha", "refresh")
            };

            for (int i = 0; i < routeEntryList.Count; i++)
            {
                routes.MapRoute(
                  name: routeEntryList[i].Name,
                  url: routeEntryList[i].Url,
                  defaults: routeEntryList[i].Defaults
                  //, namespaces: new[] { "CamelApp.Portal.Controllers" }

                 );
            }
            routes.MapRoute(
                name: "Default",
                url: "{application}/{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
                //,namespaces: new[] { "CamelApp.Portal.Controllers" }
            );




        }
    }
}
