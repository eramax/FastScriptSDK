using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppSDK.Api
{
    public class ErrorApiController : ApiController
    {
        public string Get()
        {
            return "Error: Not Found 404";
        }
    }
}
