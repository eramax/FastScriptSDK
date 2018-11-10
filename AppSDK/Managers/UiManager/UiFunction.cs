using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager
{
    public class UiFunction
    {
        public string FuncName { get; set; }
        public string[] Paramaters { get; set; }
        public List<UiFunction> NextFuncs { get; set; }
    }
}
