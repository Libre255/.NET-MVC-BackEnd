using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC_uppgift.Models;
namespace MVC_uppgift.Controllers
{
    public class GameController : Controller
    {
        public GameController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GuessingGame()
        {
            if (HttpContext.Session.GetInt32("RandomNumber") == null)
            {
                AddNewRandomNr();
            }
            ViewBag.Testa = (int)HttpContext.Session.GetInt32("RandomNumber");
            return View();
        }
        [HttpPost]
        public IActionResult GuessingGame(int UserGuess)
        {
            if (HttpContext.Session.GetInt32("RandomNumber") != null)
            {
                int SecretNumber = (int)HttpContext.Session.GetInt32("RandomNumber");
                string GuessResult = Game.GuessTheNumber(UserGuess, SecretNumber);
                ViewBag.Message = GuessResult;
                ViewBag.Testa = (int)HttpContext.Session.GetInt32("RandomNumber");
            }
            return View();
        }

        public void AddNewRandomNr()
        {
            int RandomNumber = new Random().Next(1, 101);
            HttpContext.Session.SetInt32("RandomNumber", RandomNumber);
        }
    }
}
