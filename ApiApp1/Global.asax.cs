using ApiApp1.Models;
using AppSDK.Managers.AppStartManager;
namespace ApiApp1
{
    public class WebApiApplication : AppStartManager<DContext>
    {
        public WebApiApplication()
        { Seeds.Add(new Seeds()); }
    }
}
