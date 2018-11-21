using AppSDK.Managers.UiManager.Bulma;
using System.Collections.Generic;

namespace AppSDK.Managers.UiManager.XLib
{
    public class UixPackage
    {
        public List<Uix> Components { get; set; } = new List<Uix>();
        public List<object> Data { get; set; } = new List<object>();
    }
}
