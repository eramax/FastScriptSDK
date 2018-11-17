using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AppSDK.Api;
using AppSDK.Managers.FilterManager;
using AppSDK.Managers.RouteManager;
namespace AppSDK.Managers.AppStartManager
{
    public class AppStartManager :  System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //PluginManager.LoadLocalControllers();
            ////PluginManager.LoadPlugin("/plugins/plugin1/plugin1.dll");
            //GlobalConfiguration.Configure(SDKWebApiConfig.Register);
            ////ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

            GlobalConfiguration.Configure(SDKWebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ViewEngines.Engines.Add(new MyRazorViewEngine());


        }
    }
}
