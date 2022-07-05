using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.ViewModels;
using MVC_uppgift.Models;
using MVC_uppgift.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MVC_uppgift.Controllers
{
    [Route("ReactMVCPeopleList")]
    public class ReactPeopleController : Controller
    {
        public readonly ApplicationDbContext _db;
        public PeopleVM PeopleVM = new PeopleVM();

        public ReactPeopleController(ApplicationDbContext db) {
            _db = db;
        }
        public JsonResult Index()
        {
            List<PeopleVM> listPeople = PeopleVM.PersonViewList(_db);
            return Json(listPeople);
        }
        [HttpGet]
        [Route("Cities")]
        public JsonResult ListOfCities()
        {
            string[] cities = _db.Cities.Select(C => C.Name).ToArray();
            return Json(cities);
        }
        [HttpGet]
        [Route("Languages")]
        public JsonResult ListOfLanguages()
        {
            string[] languages = _db.Languages.Select(C => C.Name).ToArray();
            return Json(languages);
        }
        [HttpPost]
        [Route("AddPerson")]
        public JsonResult AddPerson([FromBody] PeopleVM PersonData)
        {
            int PD_City_Id = _db.Cities.SingleOrDefault(city => city.Name == PersonData.City).Id;
            var ListOfLanguages_PD = _db.Languages.Where(L => PersonData.Languages.Contains(L.Name)).ToList().Select(LN => LN.Id);

            if (ModelState.IsValid)
            {
                People NewPerson = new()
                {
                    Name = PersonData.Name,
                    PhoneNumber = PersonData.PhoneNumber,
                    CityId = PD_City_Id
                };
                NewPerson.PeopleLanguagues = new();
                foreach(var item in ListOfLanguages_PD)
                {
                    NewPerson.PeopleLanguagues.Add(new PeopleLanguage { LanguageId = item, People = NewPerson });
                }
                _db.Peoples.Add(NewPerson);
                _db.SaveChanges();
                return Json("Succesfull added a new person");
            }
            return Json("Failed to add Person");
        }
        [HttpPost]
        [Route("EditPerson")]
        public JsonResult EditPerson([FromBody] PeopleVM IncPersonData)
        {
            if (ModelState.IsValid)
            {
                City TheNewCity = _db.Cities.SingleOrDefault(c => c.Name == IncPersonData.City);
                People EditPerson = _db.Peoples.Include(p => p.PeopleLanguagues).Include(o => o.City).SingleOrDefault(peps => peps.Id == IncPersonData.Id);
                EditPerson.Name = IncPersonData.Name;
                EditPerson.PhoneNumber = IncPersonData.PhoneNumber;
                EditPerson.City = TheNewCity;
                EditPerson.PeopleLanguagues = new List<PeopleLanguage>();
                foreach (var language in IncPersonData.Languages)
                {
                    int languageId = _db.Languages.SingleOrDefault(L => L.Name == language).Id;
                    EditPerson.PeopleLanguagues.Add(new PeopleLanguage { LanguageId = languageId, People = EditPerson });
                }
                _db.SaveChanges();
                return Json("Worked you edited a person");
            }
            return Json("Failed to Edit person");
        }
        [HttpPost]
        [Route("DeletPerson/{Id}")]
        public JsonResult DeletPerson(int Id)
        {
            if (ModelState.IsValid)
            {
                People deletThisPerson = _db.Peoples.SingleOrDefault(p => p.Id == Id);
                _db.Peoples.Remove(deletThisPerson);
                _db.SaveChanges();
                return Json("Succesfull delet person");
            }
            return Json("Failed to delet person");
        }


    }
}
