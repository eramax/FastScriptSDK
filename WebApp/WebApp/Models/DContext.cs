using DbManager.DAL;
using System.Data.Entity;

namespace WebApp.Models
{
    public class DContext : DbxContext 
    {
        public DContext() : base("DefaultConnection") { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cateogry> Cateogries { get; set; }
    }
}