using AppSDK.Api;
using AppSDK.Managers.UiManager.Bulma;
using AppSDK.Managers.UiManager.XLib;
using DbManager.DAL;
using DbManager.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace AppSDK.Managers.UiManager.Designer
{
    public class SdkCrudViewController<T,TContext> : SdkApiController<T, TContext>
        where T : class, IBaseEntity, new()
        where TContext : SdkContext, new()
    {
        [HttpGet]
        public virtual UixPackage List()
        {
            UixPackage pkg = new UixPackage();
            return pkg;
        }

        [HttpGet]
        public virtual UixPackage Details()
        {
            UixPackage pkg = new UixPackage();
            return pkg;
        }

        [HttpGet]
        public virtual UixPackage Form()
        {
            UixPackage pkg = new UixPackage();
            return pkg;
        }

    }
}
