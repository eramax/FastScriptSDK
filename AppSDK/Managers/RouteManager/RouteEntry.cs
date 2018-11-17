using System.Web.Mvc;

namespace AppSDK.Managers.RouteManager
{
    public class RouteEntry
    {
        public object Defaults { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public RouteEntry(string url, string controller, string action)
        {
            this.Url = url.ToLower();
            this.Controller = controller;
            this.Action = action;
            this.Name = url.Replace("{", "_").Replace("}", "_").Replace("/", "_");

            if (url.ToLower().Contains("{title}") && url.ToLower().Contains("{id}"))
                this.Defaults = new { Controller = controller, Action = action, title = UrlParameter.Optional, id = UrlParameter.Optional };
            else if (url.ToLower().Contains("{title}"))
                this.Defaults = new { Controller = controller, Action = action, title = UrlParameter.Optional };
            else if (url.ToLower().Contains("{id}"))
                this.Defaults = new { Controller = controller, Action = action, id = UrlParameter.Optional };
            else
                this.Defaults = new { Controller = controller, Action = action };
        }
    }
}
