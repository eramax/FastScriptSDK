using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DbManager.DAL
{
    public class DbxContext : DbContext
    {
        public DbxContext(string connection) : base(connection)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<DbxContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}