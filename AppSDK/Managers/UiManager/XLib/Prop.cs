using Newtonsoft.Json;
using System.Collections.Generic;
namespace AppSDK.Managers.UiManager.XLib
{
    public class Prop
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Indexs { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Values { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<UiFunction> Funcs { get; set; }
    }
}
