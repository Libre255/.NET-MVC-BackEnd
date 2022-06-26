using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.ViewModels;
using MVC_uppgift.Models;
using MVC_uppgift.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MVC_uppgift.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class PeopleController : Controller
    {
        public readonly ApplicationDbContext _db;
        MainViewModel MainVM = new();

        public PeopleController(ApplicationDbContext db)
        {
            _db = db;
            foreach(var city in _db.Cities)
            {
                MainVM.CreatePersonVM.ListOfCities.Add(city);
            }
            foreach (var language in _db.Languages)
            {
                MainVM.CreatePersonVM.ListOfLanguages.Add(language);
            }
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

            City cityId = _db.Cities.SingleOrDefault(cityInfo => cityInfo.Name == PersonObj.City);
            Language languageId = _db.Languages.SingleOrDefault(L => L.Name == PersonObj.Language);

            if (ModelState.IsValid)
            {
                People P = new()
                {
                    Name = PersonObj.Name,
                    CityId = cityId.Id,
                    PhoneNumber = PersonObj.PhoneNumber
                };
                P.PeopleLanguagues = new() { new PeopleLanguage { LanguageId = languageId.Id, People = P } };

                _db.Peoples.Add(P);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Route("People/EditPeople/{Id}")]
        public IActionResult EditPeople(int Id)
        {
            MainVM.PeopleVM.PeopleList = MainVM.PeopleVM.PersonViewList(_db);
            var person = _db.Peoples.FirstOrDefault(p => p.Id == Id);
            CreatePersonViewModel P = new()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                City = person.City.Name,
                Language = person.PeopleLanguagues[0].Language.Name,
                ListOfCities = MainVM.CreatePersonVM.ListOfCities,
                ListOfLanguages = MainVM.CreatePersonVM.ListOfLanguages
            };
            return PartialView("_EditPeople", P);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult UpdatePeople(CreatePersonViewModel Person)
        {
            People SelectedPerson = _db.Peoples.Include(c => c.PeopleLanguagues).FirstOrDefault(p => p.Id == Person.Id);
            Language L = _db.Languages.FirstOrDefault(lang => lang.Name == Person.Language);
            SelectedPerson.Name = Person.Name;
            SelectedPerson.PhoneNumber = Person.PhoneNumber;
            SelectedPerson.City.Name = Person.City;
            SelectedPerson.PeopleLanguagues = new List<PeopleLanguage>
            {
                new PeopleLanguage() { PeopleId = Person.Id, LanguageId = L.Id }
            };
                
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
