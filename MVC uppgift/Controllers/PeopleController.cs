using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.ViewModels;
using MVC_uppgift.Models;
namespace MVC_uppgift.Controllers
{
    public class PeopleController : Controller
    {
        MainViewModel MainVM = new MainViewModel();
        public PeopleController()
        {
            MainVM.CreatePersonVM = new CreatePersonViewModel();
            MainVM.PeopleVM = new PeopleViewModel();
        }
        public ViewResult Index()
        {
            return View(MainVM);
        }
        [HttpPost]
        public ViewResult Index(string SearchInput)
        {
            if(SearchInput != null)
            {
                MainVM.PeopleVM.PeopleList = MainVM.PeopleVM.SearchPeople(SearchInput);
                return View(MainVM);
            }
            return View(MainVM);
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
        public RedirectToActionResult AddPeople(CreatePersonViewModel PersonObj)
        {
            if (ModelState.IsValid)
            {
                PeopleViewModel.MainList.Add(new People(PersonObj.Name, PersonObj.PhoneNumber, PersonObj.City));
            }
            return RedirectToAction("Index");
        }

    }
}
