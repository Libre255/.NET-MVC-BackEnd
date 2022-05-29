using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.Data;
using MVC_uppgift.ViewModels;
using Microsoft.EntityFrameworkCore;
using MVC_uppgift.Models;

namespace MVC_uppgift.Controllers
{
    public class CityController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CityViewModel CityVM = new();
        public CityController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            CityVM.CityList = _db.Cities.ToList();
           var obj = _db.Countries.Include(c => c.ListOfCities).ToList();

            return View(CityVM);
        }
    }
}
