using DbManager.DAL;
using System.Data.Entity;

namespace ApiApp1.Models
{
    public class DContext : SdkContext
    {
        public DContext() : base("DefaultConnection") { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cateogry> Cateogries { get; set; }
    }
}