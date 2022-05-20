using Microsoft.AspNetCore.Mvc;

namespace MVC_uppgift.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
