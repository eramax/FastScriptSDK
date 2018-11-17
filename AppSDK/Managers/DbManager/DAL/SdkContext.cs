using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace DbManager.DAL
{
    public class SdkContext : DbContext
    {
        public SdkContext() : base("name=DefaultConnection") { }
        public SdkContext(string connection) : base(connection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }


 



}