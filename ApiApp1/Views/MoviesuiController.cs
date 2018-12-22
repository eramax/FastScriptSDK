/*using ApiApp1.Models;
using AppSDK.Managers.UiManager.Bulma;
using AppSDK.Managers.UiManager.Designer;
using AppSDK.Managers.UiManager.XLib;
using System.Collections.Generic;
using System.Linq;

namespace ApiApp1.Views
{
    public class MoviesuiController : SdkCrudViewController<Movie, DContext>
    {

        /*
        public override UixPackage List()
        {
            UixPackage pkg = new UixPackage();

            var section = Uix.BMTags.Section();
            Uix.BMTags.Field("Search", "inp1").AddValidator(new UiFunction("IsInt").AddParameter("var1",null,"inp1"))
                .AddTo(ref section);
            //  .HideIf(new UiFunction("GetLength",null,"tb1.data"));
            section.Import("tb1");
            pkg.Components.Add(section);

            List<object> xx = new List<object>();
            xx.AddRange(Person.Demo(5));
            pkg.Data.Add("list1", xx);

            var buttonsTemplate = Uix.Tags.Div().Id("buttonsTemplate").Add(
                Uix.BMTags.Buttun().IsPrimary().Content("Open").OnClick(new UiFunction("OpenLink").AddParameter("link",  "www.google.com")),
                Uix.BMTags.Buttun().IsWarning().Content("Edit").OnClick(new UiFunction("Update").AddParameter("index", null, "Name", true)
                .AddParameter("Val","Ahmed Essam")),
                Uix.BMTags.Buttun().IsDanger().Content("Delete").OnClick(new UiFunction("Delete").AddParameter("index",null,"",true))
                );

            pkg.PartialComponents.Add("buttonsTemplate",buttonsTemplate);

            var trTemplate = Uix.Tags.Tr().RepeatFor("list1").Add(
                            Uix.Tags.Td().Content(index: "Id"),
                            Uix.Tags.Td().Content(index: "Name"),
                            Uix.Tags.Td().Content(index: "Age"),
                            Uix.Tags.Td().Content(index: "Email"),
                            Uix.Tags.Td().Content(index: "Friends.0.Name"),
                            Uix.Tags.Td().Content(index: "Friends.0.Age"),
                            Uix.Tags.Td().Content(fun: new UiFunction("GetLengh").AddParameter("inp",null, "Friends")),
                            Uix.Tags.Td().Import("buttonsTemplate"));

            pkg.PartialComponents.Add("trTemplate", trTemplate);

            var tb1 = Uix.BMTags.Table("trTemplate", "ID", "Name", "Age", "Email", "First Friend Name", "First Friend Age", "Number or Friends", "Operations");

            pkg.PartialComponents.Add("tb1",tb1);
            return pkg;
        }


        public override UixPackage Form()
        {
            UixPackage pkg = new UixPackage();
            

            //var section = Uix.BMTags.


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
    
}*/