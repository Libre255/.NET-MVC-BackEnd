using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.Data;
using MVC_uppgift.Models;

namespace MVC_uppgift.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext db)
        {
            DataSeeder Seeder = new(db);
            Seeder.Seed();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
    }
}
