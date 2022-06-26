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
    }
}
