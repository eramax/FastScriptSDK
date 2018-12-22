using AppSDK.Api;
using AppSDK.Managers.UiManager.UiLib;
using System.Collections.Generic;

namespace ApiApp1.Views
{
    public class UiController : SDKEmptyAPIController
    {
        public UiDesign GetDesign()
        {
            var des = UiDesign.Instance;

            var lay1 = new Layout() { Name = "lay1", Link = "layoutComponentLinks" };

            
            var lay2 = new Layout() { Name = "lay2", Link = "layoutComponentLinks" };
            des.Layouts.Add("lay1", lay1);
            des.Layouts.Add("lay2", lay2);

            var pg1 = new Page();
            lay1.PageLinks.Add("pg1", "pg1.json");
            lay1.PageLinks.Add("pg2", "pg2.json");
            lay1.PageLinks.Add("pg3", "pg3.json");
            lay1.PageLinks.Add("pg4", "pg4.json");
            lay1.PageLinks.Add("pg5", "pg5.json");

            lay1.Default = new List<Page>();
            var layoutDesign = new Page();
            lay1.Default.Add(layoutDesign);
            var tb1 = Bootstrap.Table();
            layoutDesign.Components.Add(tb1);

            return des;

        }
    }
}