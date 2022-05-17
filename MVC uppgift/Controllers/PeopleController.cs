using Microsoft.AspNetCore.Mvc;

namespace MVC_uppgift.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
