using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace AppSDK.mvc
{
    public class ApiControllerSelector : DefaultHttpControllerSelector
    {
        
        public ApiControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //string controllerName = GetControllerName(request);
            ////Type type = PluginManager.GetControllerType(controllerName);
            ////return new HttpControllerDescriptor(null, controllerName, type);
            //var c = PluginManager.GetApiController(controllerName);
            //var t = PluginManager.GetControllerType(controllerName);
            //return new HttpControllerDescriptor(GlobalConfiguration, controllerName, t);

            return base.SelectController(request);
        }
    }
}
