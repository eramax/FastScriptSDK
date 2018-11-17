using DbManager.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Managers.DbManager.DAL
{
    class DbMigrat<TContext> where TContext : SdkContext, new()
    {
        public static void Migrat()
        {
            Database.SetInitializer(new DataDbInitializer());
            var configuration = new DataDbConfiguration();
            var migrator = new DbMigrator(configuration);

            if (migrator.GetPendingMigrations().Any())
                migrator.Update();
        }
    internal sealed class DataDbInitializer : MigrateDatabaseToLatestVersion<TContext, DataDbConfiguration> { }
        internal sealed class DataDbConfiguration : DbMigrationsConfiguration<TContext>
        {
            public DataDbConfiguration()
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
            }

            protected override void Seed(TContext context)
            {
                DataSeedInitializer.Seed(context);
                base.Seed(context);
            }
        }
        internal static class DataSeedInitializer
        {
            public static void Seed(TContext context)
            {
                context.SaveChanges();
            }
        }
    }



    //internal sealed class DataDbConfiguration<TContext> : DbMigrationsConfiguration<TContext>
    //     where TContext : SdkContext, new()
    //{
    //    public DataDbConfiguration()
    //    {
    //        AutomaticMigrationsEnabled = true;
    //        AutomaticMigrationDataLossAllowed = true;
    //    }

    //    protected override void Seed(TContext context)
    //    {
    //        DataSeedInitializer<TContext>.Seed(context);
    //        base.Seed(context);
    //    }
    //}

    //internal static class DataSeedInitializer<TContext>
    //    where TContext : SdkContext, new()
    //{
    //    public static void Seed(TContext context)
    //    {
    //        context.SaveChanges();
    //    }
    //}
}
