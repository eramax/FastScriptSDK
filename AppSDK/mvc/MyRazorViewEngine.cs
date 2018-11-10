using System.Web.Mvc;

namespace AppSDK.mvc
{
    public class MyRazorViewEngine : RazorViewEngine
    {
        public MyRazorViewEngine() : base()
        {
            AreaViewLocationFormats = new[] {
            "/{1}/{0}.cshtml",
            "/{1}/{0}.vbhtml",
            "/Shared/{0}.cshtml",
            "/Shared/{0}.vbhtml"
            };

            AreaMasterLocationFormats = new[] {
            "/{1}/{0}.cshtml",
            "/{1}/{0}.vbhtml",
            "/Shared/{0}.cshtml",
            "/Shared/{0}.vbhtml"
            };

            AreaPartialViewLocationFormats = new[] {
            "/{1}/{0}.cshtml",
            "/{1}/{0}.vbhtml",
            "/Shared/{0}.cshtml",
            "/Shared/{0}.vbhtml"
            };

            ViewLocationFormats = new[] {
            "/{1}/{0}.cshtml",
            "/{1}/{0}.vbhtml",
            "/Shared/{0}.cshtml",
            "/Shared/{0}.vbhtml"
            };

            MasterLocationFormats = new[] {
            "/{1}/{0}.cshtml",
            "/{1}/{0}.vbhtml",
            "/Shared/{0}.cshtml",
            "/Shared/{0}.vbhtml"
            };

            PartialViewLocationFormats = new[] {
            "/{1}/{0}.cshtml",
            "/{1}/{0}.vbhtml",
            "/Shared/{0}.cshtml",
            "/Shared/{0}.vbhtml"
            };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var nameSpace = controllerContext.Controller.GetType().Namespace;
            string controllersViewsDir = PluginManager.GetControllerViews(controllerContext.Controller.GetType().Name);
            string newPath = controllersViewsDir + partialPath;
            return base.CreatePartialView(controllerContext, newPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var nameSpace = controllerContext.Controller.GetType().Namespace;
            string controllersViewsDir = PluginManager.GetControllerViews(controllerContext.Controller.GetType().Name);
            string newPath = controllersViewsDir + viewPath;
            return base.CreateView(controllerContext, newPath, "");
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            var controllerName = controllerContext.Controller.GetType().Name;
            string controllersViewsDir = PluginManager.GetControllerViews(controllerName);
            string newPath = controllersViewsDir + virtualPath;
            bool x = base.FileExists(controllerContext, newPath);
            return x;
        }

    }
}
