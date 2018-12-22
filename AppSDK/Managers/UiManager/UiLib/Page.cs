using AppSDK.Managers.UiManager.Bulma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.UiLib
{
    public class Page
    {
        public List<IUiComponent> Components { get; set; } = new List<IUiComponent>();
        public Dictionary<string, IUiComponent> PartialComponents { get; set; } = new Dictionary<string, IUiComponent>();
    }
}
