using System.Collections.Generic;

namespace AppSDK.Managers.UiManager.XLib
{
    public class UiFunction
    {
        public string FuncName { get; set; }
        public string[] Paramaters { get; set; }
        public List<UiFunction> NextFuncs { get; set; }
    }
}
