using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.Data;
using MVC_uppgift.ViewModels;
using Microsoft.EntityFrameworkCore;
using MVC_uppgift.Models;
using Microsoft.AspNetCore.Authorization;

namespace MVC_uppgift.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CityViewModel CityVM = new();
        public CityController(ApplicationDbContext db)
        {
            _db = db;

            CityVM.ListOfCountries = _db.Countries.ToList();
        }
        public IActionResult Index()
        {
            CityVM.CityList = _db.Cities.ToList();

            return View(CityVM);
        }
        [Route("City/EditCountryCity/{Id}")]
        public IActionResult EditCountryCity(int Id)
        {
            var citySelected = _db.Cities.FirstOrDefault(c => c.Id == Id);

            CityCountryEdit a = new() { Name = citySelected.Name };
            return PartialView("_EditCountryCity", a);
        }

        public RedirectToActionResult DeletCity(int Id)
        {
            City? C = _db.Cities.FirstOrDefault(city => city.Id == Id);
            if(C != null)
            {
                _db.Cities.Remove(C);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult AddCity(CityViewModel CityInfo)
        {
            City CityInput = new() { Name = CityInfo.Name, CountryId = CityInfo.CountryId};
            if (ModelState.IsValid)
            {
                _db.Cities.Add(CityInput);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult UpdateCountryCity(CityCountryEdit obj)
        {
            City? C = _db.Cities.FirstOrDefault(c => c.Id == obj.Id);
            C.Name = obj.Name;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
