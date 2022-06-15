using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.Data;
using MVC_uppgift.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MVC_uppgift.Models;

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
            CountryVM.CountryList = _db.Countries.Include(c => c.ListOfCities).ToList();
            return View(CountryVM);
        }
        [Route("Country/EditCountryCity/{Id}")]
        public IActionResult EditCountryCity(int Id)
        {
            var countrySelected = _db.Countries.FirstOrDefault(c => c.Id == Id);

            CityCountryEdit CC = new() { Name = countrySelected.Name, Id = countrySelected.Id };
            return PartialView("_EditCountryCity", CC);
        }
        public RedirectToActionResult DeletCountry(int Id)
        {
            Country? C = _db.Countries.FirstOrDefault(country => country.Id == Id);
            if(C != null)
            {
                _db.Countries.Remove(C);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult AddCountry(CountryViewModel CountryInfo)
        {
            Country CountryInput = new() { Name = CountryInfo.Name};
            if (ModelState.IsValid)
            {
                _db.Countries.Add(CountryInput);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult UpdateCountryCity(CityCountryEdit obj)
        {
            Country? C = _db.Countries.FirstOrDefault(c => c.Id == obj.Id);
            C.Name = obj.Name;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
