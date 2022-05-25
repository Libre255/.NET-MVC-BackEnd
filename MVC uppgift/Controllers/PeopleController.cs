using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.ViewModels;
using MVC_uppgift.Models;
using MVC_uppgift.Data;

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
            MainVM.PeopleVM.PeopleList = _db.Peoples.ToList();
            return View(MainVM);
        }

        [HttpPost]
        public ViewResult Index(string SearchInput)
        {
            if(SearchInput != null)
            {
                MainVM.PeopleVM.SearchPeople(SearchInput, _db.Peoples.ToList());
                return View(MainVM);
            }else
            {
                MainVM.PeopleVM.PeopleList = _db.Peoples.ToList();
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
        public RedirectToActionResult AddPeople(People PersonObj)
        {
            if (ModelState.IsValid)
            {
                _db.Peoples.Add(PersonObj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
