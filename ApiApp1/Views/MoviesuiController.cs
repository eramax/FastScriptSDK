using ApiApp1.Models;
using AppSDK.Managers.UiManager.Bulma;
using AppSDK.Managers.UiManager.Designer;
using AppSDK.Managers.UiManager.XLib;
using System.Collections.Generic;
using System.Linq;

namespace ApiApp1.Views
{
    public class MoviesuiController : SdkCrudViewController<Movie, DContext>
    {
        public override UixPackage List()
        {
            UixPackage pkg = new UixPackage();

            var section = Uix.BMTags.Section();
            Uix.BMTags.Field("Search", "inp1").AddValidator(new UiFunction("IsInt", null, "inp1"))
                .AddTo(ref section);
            //  .HideIf(new UiFunction("GetLength",null,"tb1.data"));
            section.Include("tb1");
            pkg.Components.Add(section);

            List<object> xx = new List<object>();
            xx.AddRange(Person.Demo(5));
            pkg.Data.Add("list1", xx);

            var buttonsTemplate = Uix.Tags.Div().Id("buttonsTemplate").Add(
                Uix.BMTags.Buttun().Content("Edit").OnClick(new UiFunction("OpenLink", null, "link")),
                Uix.BMTags.Buttun().Content("Delete").OnClick(new UiFunction("SubmitForm", "http://dadad.dasdas.dasd", "id"))
                );

            pkg.PartialComponents.Add(buttonsTemplate);
            var tb1 = Uix.Tags.Table().Id("tb1").Add(
                Uix.Tags.Thead().Add(
                    Uix.Tags.Th("Name"),
                    Uix.Tags.Th("ID"),
                    Uix.Tags.Th("Email"),
                    Uix.Tags.Th("Firt Friend Name"),
                    Uix.Tags.Th("First Friend Age"),
                    Uix.Tags.Th("Number or Friends"),
                    Uix.Tags.Th("Operations")
                ))
                .Add(
                    Uix.Tags.Tbody().Add(
                        Uix.Tags.Tr().RepeatFor("list1").Add(
                            Uix.Tags.Td().Content(index: "Name"),
                            Uix.Tags.Td().Content(index: "Id"),
                            Uix.Tags.Td().Content(index: "Email"),
                            Uix.Tags.Td().Content(index: "Friends.0.Name"),
                            Uix.Tags.Td().Content(index: "Friends.0.Age"),
                            Uix.Tags.Td().Content(fun: new UiFunction("GetLengh", null, "Friends")),
                            Uix.Tags.Td().Include("buttonsTemplate")
                        )
                    )
                 );
            pkg.PartialComponents.Add(tb1);
            return pkg;
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public ICollection<Person> Friends { get; set; }

        public static List<Person> Demo(int count,bool recursive=true)
        {
            return Enumerable.Range(0, count).ToList().Select(n =>
                new Person()
                { Id = n, Age = n, Email = $"email{n}@aaa.com", Name = $"Ahmed{n}",Friends= recursive? Demo(n,false):null }
            ).ToList();

        }
    }

}