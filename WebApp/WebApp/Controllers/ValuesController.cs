using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppSDK.Managers.UiManager;
using BulmaUiManager;

namespace WebApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            Layout layout = new Layout("home");
            
            return new string[] { "value1", "value2" };
        }

        public BM GetGithubRepos()
        {
            var box = BM.Box().Add(
                BM.H(5, "Get data from github"),
                BM.Field("Enter username", "username", "text", "Enter username"),
                BM.Buttun(null, "Get Data from Github").IsPrimary()//.OnClick("fetchF", "username")
                ) as BM;
            return box;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
