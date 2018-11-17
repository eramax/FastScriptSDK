using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models.Ui;

namespace WebApp.Controllers
{
    public class UiController : ApiController
    {
        public IHttpActionResult GetDash()
        {
            UiService bm = new UiService();
            return Ok(bm.build3());
        }
    }
}
