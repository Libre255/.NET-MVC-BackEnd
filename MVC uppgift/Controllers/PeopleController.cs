using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.ViewModels;
using MVC_uppgift.Models;
using MVC_uppgift.Data;
using Microsoft.EntityFrameworkCore;

namespace MVC_uppgift.Controllers
{
    public class PeopleController : Controller
    {
        public readonly ApplicationDbContext _db;
        MainViewModel MainVM = new();

        public PeopleController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ViewResult Index()
        {
            MainVM.PeopleVM.PeopleList = MainVM.PeopleVM.PersonViewList(_db);
            return View(MainVM);
        }

        [HttpPost]
        public ViewResult Index(string SearchInput)
        {
            if(SearchInput != null)
            {
                MainVM.PeopleVM.SearchPeople(SearchInput, MainVM.PeopleVM.PersonViewList(_db));
                return View(MainVM);
            }else
            {
                MainVM.PeopleVM.PeopleList = MainVM.PeopleVM.PersonViewList(_db);
            }
            return View(MainVM);
        }
        public RedirectToActionResult DeletPeople(string InputName)
        {
            People? itemRemove = _db.Peoples.SingleOrDefault(x => x.Name == InputName);
            if (itemRemove != null)
            {
                _db.Peoples.Remove(itemRemove);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult AddPeople(CreatePersonViewModel PersonObj)
        {
            if (ModelState.IsValid)
            {
                City C = new() { Name = PersonObj.City, CountryId = 1};

                People P = new()
                {
                    Name = PersonObj.Name,
                    City = C,
                    PhoneNumber = PersonObj.PhoneNumber,
                };
                Language L = new()
                {
                    Name = PersonObj.Language
                };
                PeopleLanguage PL = new() { Language = L, People = P };
                P.PeopleLanguagues = new() { PL };

                _db.Peoples.Add(P);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Route("People/EditPeople/{Id}")]
        public IActionResult EditPeople(int Id)
        {
            MainVM.PeopleVM.PeopleList = MainVM.PeopleVM.PersonViewList(_db);
            var person = MainVM.PeopleVM.PeopleList.Where(x => x.Id == Id).FirstOrDefault();
            CreatePersonViewModel P = new()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                City = person.City,
                Language = "Spanish"
            };
            return PartialView("_EditPeople", P);
        }


    }
}
