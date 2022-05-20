using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.Models;

namespace MVC_uppgift.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult FeverCheck()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FeverCheck(int temperature)
        {
            if(temperature != null)
            {
                ViewBag.TemperatureResult = Doctor.HasFever(temperature);
            }
            return View();
        }
    }
}
