using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager
{
    public class Layout
    {
        public string LayoutName;
        public Ui Components;
        public Layout(string name) { LayoutName = name; }
    }
}
