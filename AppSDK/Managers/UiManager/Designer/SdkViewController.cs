using AppSDK.Api;
using DbManager.DAL;
using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppSDK.Managers.UiManager.Designer
{
    public class SdkCrudViewController<T,TContext> : SdkApiController<T, TContext>
        where T : class, IBaseEntity, new()
        where TContext : SdkContext, new()
    {
        //[HttpGet]
        //public Ui List()
        //{
        //    return Ui.Div("Continer");
        //}

        //[HttpGet]
        //public Ui Details()
        //{
        //    return Ui.Div("Row");
        //}

        //[HttpGet]
        //public Ui Form()
        //{
        //    return Ui.Form("/api/movies/post");
        //}

    }
}
