using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.Data;
using MVC_uppgift.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MVC_uppgift.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CountryViewModel CountryVM = new();
        public CountryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            CountryVM.CountryList = _db.Countries.ToList();
            return View(CountryVM);
        }
    }
}
