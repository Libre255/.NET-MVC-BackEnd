using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.ViewModels;
using MVC_uppgift.Models;
namespace MVC_uppgift.Controllers
{
    public class PeopleController : Controller
    {
        public ViewResult Index()
        {
            return View(PeopleViewModel.MainList);
        }
        [HttpPost]
        public ViewResult Index(string SearchInput)
        {
            if(SearchInput != null)
            {
                return View(PeopleViewModel.SearchPeople(SearchInput));
            }
            return View(PeopleViewModel.MainList);
        }
        public RedirectToActionResult AddPeople(string nameInput, int PhoneInput, string CityInput)
        {
            if (ModelState.IsValid)
            {
                PeopleViewModel.MainList.Add(new People(nameInput, PhoneInput, CityInput));
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult DeletPeople(string InputName)
        {
            People? itemRemove = PeopleViewModel.MainList.SingleOrDefault(x => x.Name == InputName);
            if (itemRemove != null)
            {
                PeopleViewModel.MainList.Remove(itemRemove);
            }
            return RedirectToAction("Index");
        }
        
    }
}
