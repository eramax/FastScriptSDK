using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.UiLib
{
    public class PropList : Dictionary<string, Prop>
    {
        public void AddProp(string _PropName, object _PropValue = null, UiFunction _PropValueFunc = null, string _Index = null)
        {
            if (_PropValue == null && _PropValueFunc == null && _Index == null) return;
            if (!this.ContainsKey(_PropName))
                this.Add(_PropName, new Prop());

            this[_PropName].Set(_PropValue, _PropValueFunc, _Index);
        }
    }
}
