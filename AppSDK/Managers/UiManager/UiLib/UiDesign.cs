using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.UiManager.UiLib
{
    public sealed  class UiDesign
    {
        private static readonly UiDesign instance = new UiDesign();
        static UiDesign()
        {
        }
        private UiDesign()
        {
        }
        public static UiDesign Instance
        {
            get
            {
                return instance;
            }
        }
        public Dictionary<string, Layout> Layouts { get; set; } = new Dictionary<string, Layout>();
        
    }
}
