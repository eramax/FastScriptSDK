using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AppSDK.Api;
using AppSDK.Managers.DbManager.DAL;
using AppSDK.Managers.DbManager.Models;
using AppSDK.Managers.FilterManager;
using AppSDK.Managers.RouteManager;
using DbManager.DAL;

namespace AppSDK.Managers.AppStartManager
{
    public class AppStartManager<TContext> : System.Web.HttpApplication
        where TContext : SdkContext, new()
    {
        public List<ISdkSeed> Seeds { get; set; } = new List<ISdkSeed>();
        protected void Application_Start()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TContext, DataDbConfiguration<TContext>>());
            DbMigrat<TContext>.Migrat();
            Seeds.ForEach(i => i.DoSeed());

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
