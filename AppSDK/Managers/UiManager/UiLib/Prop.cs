using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.UiLib
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Prop
    {
        public List<string> Indexs { get; set; }
        public List<object> Values { get; set; }
        public List<UiFunction> Funcs { get; set; }

        public void Set(object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null)
        {

            if (_PropValue != null)
            {
                this.Values = this.Values ?? new List<object>();
                this.Values.Add(_PropValue);
            }

            if (_PropValueFunc != null)
            {
                this.Funcs = this.Funcs ?? new List<UiFunction>();
                this.Funcs.Add(_PropValueFunc);
            }
            if (_Index != null)
            {
                if (this.Indexs == null)
                    this.Indexs = new List<string>();
                this.Indexs.Add(_Index);
            }
        }
    }
}
