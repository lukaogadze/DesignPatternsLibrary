using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Web.Models;
using Web.Models.Specs;

namespace Web.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SmartPlaylist> SmartPlaylists { get; set; }

        public AppDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new AppDbContextInitializer());
            Database.Log = s => Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SmartPlaylist>()
                .Ignore(sp => sp.Specification)
                .Property(sp => sp.Json)
                .HasColumnName("SpecificationJson");
        }
    }
}