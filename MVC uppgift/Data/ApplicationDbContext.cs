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
    }
}
