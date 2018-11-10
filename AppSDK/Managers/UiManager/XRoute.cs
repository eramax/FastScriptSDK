using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager
{
    public class XRoute
    {
        public string action { get; set; }
        public string link { get; set; }
        public List<string> vars = new List<string>();
        public XRoute(string _action, string _link, params string[] _vars)
        {
            action = _action;
            link = _link;
            vars.AddRange(_vars);
        }
    }
}
