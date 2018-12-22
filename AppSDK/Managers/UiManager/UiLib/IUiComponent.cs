using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.UiLib
{
    public interface IUiComponent
    {
        string Type { get; set; }
        string Key { get; set; }
        PropList Props { get; set; }
        Prop Contents { get; set; }
        Dictionary<string, List<UiFunction>> Events { get; set; }
        List<IUiComponent> Childerns { get; set; }
        string RepeatWith { get; set; }
        TemplateLoader Loader { get; set; }
        string Disabled { get; set; }

        void AddProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null);
        void AddEvent(string _EventName, UiFunction _PropValueFunc);
        void AddContent(object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null);
    }
   
}
