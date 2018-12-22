using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.XLib
{
    public class FunctionParameter
    {
        public string ParameterName { get; set; }
        public object DefaultVal { get; set; }
        public string Index { get; set; }
        public bool SendByRefence { get; set; }
    }
}
