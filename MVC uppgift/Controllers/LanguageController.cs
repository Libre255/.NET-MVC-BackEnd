using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_uppgift.Data;
using MVC_uppgift.ViewModels;

namespace MVC_uppgift.Controllers
{
    public class LanguageController : Controller
    {
        public readonly ApplicationDbContext _db;
        public LanguageViewModel LanguageVM = new();
        public LanguageController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            LanguageVM.ListOfLanguages = _db.Language.ToList();
            //var obj = _db.PeopleLanguages.Include(r => r.People).ToList(); use this to display both language and Person
            return View(LanguageVM);
        }
    }
}
