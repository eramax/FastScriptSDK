using AppSDK;
using AppSDK.mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            PluginManager.LoadLocalControllers();
            //PluginManager.LoadPlugin("/plugins/plugin1/plugin1.dll");
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

            GlobalConfiguration.Configure(SDKWebApiConfig.Register);

            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //AreaRegistration.RegisterAllAreas();
            


            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            ViewEngines.Engines.Add(new MyRazorViewEngine());


            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
