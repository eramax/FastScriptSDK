using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.i18n
{
    public static class i18n
    {
        public static Dictionary<string, Dictionary<string, string>> Langs = new Dictionary<string, Dictionary<string, string>>();

        public static Dictionary<string, string> GetLang(string lngName)
        {
            if (Langs.ContainsKey(lngName))
                return Langs[lngName];
            return null;
        }

        public static Dictionary<string, Dictionary<string, string>> GetAllLangs()
        {
            return Langs;
        }

        public static void Add(string lngName, string key , string val)
        {
            if (!Langs.ContainsKey(lngName)) Langs[lngName] = new Dictionary<string, string>();
            if (!Langs[lngName].ContainsKey(key)) Langs[lngName].Add(key, val);
            else Langs[lngName][key] = val;
        }
    }
    
}
