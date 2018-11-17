using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace AppSDK.mvc
{
    public class ErrorController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            //this.InvokeHttp404();
            this.RedirectToAction("NotFound").ExecuteResult(this.ControllerContext);
        }
        public ActionResult NotFound()
        {
            return Content("Error: Not Found 404");
        }
    }

}
