using AppSDK.Managers.PluginManager;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppSDK.mvc
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var c = PluginManager.GetController(controllerName);
            return c;
        }
    }
}
