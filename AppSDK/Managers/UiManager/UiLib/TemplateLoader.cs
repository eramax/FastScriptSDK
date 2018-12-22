using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.UiLib
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TemplateLoader
    {
        public string Name { get; set; }
        public string LoadFromLink { get; set; }
        public string LoadFromPartials { get; set; }
    }
}
