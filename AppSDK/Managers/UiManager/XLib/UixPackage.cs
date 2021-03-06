﻿using AppSDK.Managers.UiManager.Bulma;
using System.Collections.Generic;

namespace AppSDK.Managers.UiManager.XLib
{
    public class UixPackage
    {
        public List<Uix> Components { get; set; } = new List<Uix>();
        public Dictionary<string, Uix> PartialComponents { get; set; } = new Dictionary<string, Uix>();
        public Dictionary<string,object> Data { get; set; } = new Dictionary<string, object>();
    }
}
