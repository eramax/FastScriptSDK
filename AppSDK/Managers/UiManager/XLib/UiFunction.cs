using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppSDK.Managers.UiManager.XLib
{
    public class UiFunction
    {
        public string FuncName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Prop> Paramaters { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<UiFunction> NextFuncs { get; set; }
        public UiFunction(string name, string value = null, string index = null , UiFunction fun = null, params Prop[] pars )
        {
            FuncName = name;
            Paramaters = new List<Prop>();
            var p = new Prop();
            if (value != null) {
                p.Values = new List<object> { value };
            }
            if (index != null)
            {
                p.Indexs = new List<string>() { index };
            }

            if (fun != null)
            {
                p.Funcs = new List<UiFunction>() { fun };
            }
            Paramaters.Add(p);

            if (pars != null)
            {
                Paramaters.AddRange(pars);
            }
        }
    }
}
