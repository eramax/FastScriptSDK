using AppSDK;
using AppSDK.Api;
using AppSDK.Managers.AppStartManager;
using AppSDK.mvc;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApp.Models;

namespace WebApp
{
    public class WebApiApplication : AppStartManager<DContext> { }
}
