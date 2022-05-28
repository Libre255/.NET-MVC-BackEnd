using Microsoft.EntityFrameworkCore;
using MVC_uppgift.Models;
namespace MVC_uppgift.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<People> Peoples { get; set; }
        public DbSet<City>Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
            .HasData(new People { Id = 1, Name = "Tony montana", PhoneNumber = 24523421, CityId = 1 });
            modelBuilder.Entity<People>()
            .HasData(new People { Id = 2, Name = "Werrever Tommorow", PhoneNumber = 345363234, CityId = 2 });
            modelBuilder.Entity<People>()
            .HasData(new People { Id = 3, Name = "Lu Xiaojun", PhoneNumber = 43523413, CityId = 3 });
            
            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Kyoto", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Paris", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Gävle", CountryId = 3 });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Japan" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Sweden" });
        }
    }
}
