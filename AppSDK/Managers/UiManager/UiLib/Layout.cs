using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.UiLib
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Layout
    {
        public string Name;
        public string Link;
        public List<Page> Default;
        public Dictionary<string, string> PageLinks { get; set; } = new Dictionary<string, string>();
    }
}
