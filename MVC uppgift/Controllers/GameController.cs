using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC_uppgift.Models;
namespace MVC_uppgift.Controllers
{
    public class GameController : Controller
    {
        public IActionResult GuessingGame()
        {
            if (HttpContext.Session.GetInt32("RandomNumber") == null)
            {
                AddNewRandomNr();
            }
            return View();
        }
        [HttpPost]
        public IActionResult GuessingGame(int UserGuess)
        {
            ControllGuessNr(UserGuess);
            return View();
        }
        private void ControllGuessNr(int UserGuess)
        {
            if (HttpContext.Session.GetInt32("RandomNumber") != null)
            {
                int SecretNumber = (int)HttpContext.Session.GetInt32("RandomNumber");
                string GuessResult = Game.GuessTheNumber(UserGuess, SecretNumber);
                ViewBag.Message = GuessResult;
                if (Game.foundTheNr)
                {
                    AddNewRandomNr();
                }
            }
        }

        public void AddNewRandomNr()
        {
            int RandomNumber = new Random().Next(1, 101);
            HttpContext.Session.SetInt32("RandomNumber", RandomNumber);
        }
    }
}
