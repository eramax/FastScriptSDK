using System.Collections.Generic;
namespace AppSDK.Managers.UiManager.XLib
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
