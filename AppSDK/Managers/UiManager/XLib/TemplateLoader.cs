using Newtonsoft.Json;

namespace AppSDK.Managers.UiManager.XLib
{
    public class TemplateLoader
    {
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LoadFromLink { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LoadFromPartials { get; set; }
    }
}
