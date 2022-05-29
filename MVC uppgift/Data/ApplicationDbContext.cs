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
        public DbSet<Language> Language { get; set; }
        public DbSet<PeopleLanguage> PeopleLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
            .HasData(new People { Id = 1, Name = "Tony montana", PhoneNumber = 24523421, CityId = 1 });
            modelBuilder.Entity<People>()
            .HasData(new People { Id = 2, Name = "Werrever Tommorow", PhoneNumber = 345363234, CityId = 2 });
            modelBuilder.Entity<People>()
            .HasData(new People { Id = 3, Name = "Lu Xiaojun", PhoneNumber = 43523413, CityId = 3 });
            modelBuilder.Entity<People>()
            .HasData(new People { Id = 4, Name = "Goku Sayaying", PhoneNumber = 452423, CityId = 3 });

            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Kyoto", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 4, Name = "Hiroshima", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Paris", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Gävle", CountryId = 3 });
            
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Japan" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Sweden" });

            modelBuilder.Entity<Language>().HasData(new Language { Id = 1, Name = "Japanese"});
            modelBuilder.Entity<Language>().HasData(new Language { Id = 2, Name = "French"});
            modelBuilder.Entity<Language>().HasData(new Language { Id = 3, Name = "Swedish"});

            modelBuilder.Entity<PeopleLanguage>().HasKey(id => new { id.PeopleId, id.LanguageId });
            modelBuilder.Entity<PeopleLanguage>().HasOne(p => p.Language).WithMany(am => am.PeopleLanguagues).HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<PeopleLanguage>().HasOne(p => p.People).WithMany(am => am.PeopleLanguagues).HasForeignKey(c => c.PeopleId);
            modelBuilder.Entity<PeopleLanguage>().HasData(new PeopleLanguage { LanguageId = 1, PeopleId = 3 });
            modelBuilder.Entity<PeopleLanguage>().HasData(new PeopleLanguage { LanguageId = 1, PeopleId = 4 });
            modelBuilder.Entity<PeopleLanguage>().HasData(new PeopleLanguage { LanguageId = 2, PeopleId = 2 });
        }
    }
}
