using DbManager.DAL;
using AppSDK.Managers.DbManager.Models;
namespace ApiApp1.Models
{
    public class Seeds  : ISdkSeed
    {
        public void DoSeed()
        {
            Cateogry[] cats = new[]
{
                new Cateogry(){Name = "Action", Id=1},
                new Cateogry(){Name = "Comdy", Id=2 },
                new Cateogry(){Name = "Drama",Id=3 },
            };
            UnitOfWork<Cateogry , DContext> Uwork = new UnitOfWork<Cateogry, DContext>();
            Uwork.Repository.AddOrUpdate(cats);
            Uwork.Save();
        }
    }
}