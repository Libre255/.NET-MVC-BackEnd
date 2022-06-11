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
            foreach(var city in _db.Cities)
            {
                MainVM.CreatePersonVM.ListOfCities.Add(city);
            }
            foreach (var language in _db.Language)
            {
                MainVM.CreatePersonVM.ListOfLanguages.Add(language);
            }
        }
        public ViewResult Index()
        {
            MainVM.PeopleVM.PeopleList = PersonViewList();
            return View(MainVM);
        }

        [HttpPost]
        public ViewResult Index(string SearchInput)
        {
            if(SearchInput != null)
            {
                MainVM.PeopleVM.SearchPeople(SearchInput, PersonViewList());
                return View(MainVM);
            }else
            {
                MainVM.PeopleVM.PeopleList = PersonViewList();
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
            Language languageId = _db.Language.SingleOrDefault(L => L.Name == PersonObj.Language);

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
        private List<CreatePersonViewModel> PersonViewList()
        {
            var dbMain = _db.Peoples.Include(peps => peps.City).Include(PL => PL.PeopleLanguagues).ThenInclude(L => L.Language);

            List <CreatePersonViewModel> NewPersonList = new();

            if(_db.Peoples != null)
            {
                foreach (People p in dbMain)
                {
                    List<Language> LanguageList = new();
                    foreach(var L in p.PeopleLanguagues)
                    {
                        LanguageList.Add(L.Language);
                    }
                    NewPersonList.Add(new CreatePersonViewModel
                    {
                        Name = p.Name,
                        ListOfLanguages = LanguageList,
                        City = p.City.Name,
                        PhoneNumber = p.PhoneNumber,
                    }); ;
                }
            }
            return NewPersonList;
        }
    }
}
