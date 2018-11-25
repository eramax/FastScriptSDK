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
        public UixPackage List()
        {
            UixPackage pkg = new UixPackage();

            var sec = Uix.BMTags.Section();
            Uix.BMTags.Field("Search", "inp1").AddValidator(new UiFunction("IsInt", null, "inp1"))
                .AddTo(ref sec);
              //  .HideIf(new UiFunction("GetLength",null,"tb1.data"));
            sec.Include("tb1");
            pkg.Components.Add(sec);

            List<object> xx = new List<object>();
            xx.AddRange(new[] { "ahmed", "ali", "eeee" });
            pkg.Data.AddRange(xx);

            var buttonsTemplate = Uix.Tags.Div().Id("buttonsTemplate").Add(
                Uix.BMTags.Buttun().Content("Edit").OnClick(new UiFunction("OpenLink",null,"link")),
                Uix.BMTags.Buttun().Content("Delete").OnClick(new UiFunction("SubmitForm", "http://dadad.dasdas.dasd", "id"))
                );

            pkg.Components.Add(buttonsTemplate);
            var tb1 = Uix.Tags.Table().Id("tb1").Add(
                Uix.Tags.Thead().Add(
                    Uix.Tags.Th("Name"),
                    Uix.Tags.Th("ID"),
                    Uix.Tags.Th("Email"),
                    Uix.Tags.Th("Firt Friend Name"),
                    Uix.Tags.Th("First Friend Age"),
                    Uix.Tags.Th("Number or Friends"),
                    Uix.Tags.Th("Operations")
                )
                .Add(
                    Uix.Tags.Tbody().Add(
                        Uix.Tags.Tr().RepeatFor(xx).Add(
                            Uix.Tags.Td().Content(index: "Name"),
                            Uix.Tags.Td().Content(index: "Id"),
                            Uix.Tags.Td().Content(index: "email"),
                            Uix.Tags.Td().Content(index: "friends.0.Name"),
                            Uix.Tags.Td().Content(index: "friends.0.Age"),
                            Uix.Tags.Td().Content(fun: new UiFunction("GetLengh",null, "friends")),
                            Uix.Tags.Td().Include("buttonsTemplate")
                        )
                    )
                 ));
            pkg.Components.Add(tb1);

            return pkg;
        }

        [HttpGet]
        public Uix Details()
        {
            return Uix.BMTags.Conainer();
        }

        [HttpGet]
        public Uix Form()
        {
            return Uix.Tags.Form("ddasdasdsa/dadsa/dasdsa");
        }

    }
}
