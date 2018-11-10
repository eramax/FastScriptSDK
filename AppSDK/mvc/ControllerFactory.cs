using System.Web.Mvc;
using System.Web.Routing;

namespace AppSDK.mvc
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            return PluginManager.GetController(controllerName);
        }
    }
}
