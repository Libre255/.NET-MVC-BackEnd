using Microsoft.AspNetCore.Mvc;
using MVC_uppgift.Models;
using MVC_uppgift.ViewModels;

namespace MVC_uppgift.Controllers
{
    public class AjaxController : Controller
    {
        PeopleViewModel PeopleVM = new PeopleViewModel();
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowList()
        {
            return PartialView("_ListOfPeople", PeopleVM);
        }
        public IActionResult ShowPerson(int IdNumber)
        {
            int PersonIndex = PeopleVM.PeopleList.FindIndex(p => p.ID == IdNumber);
            if(PersonIndex >= 0)
            {
                return PartialView("_PersonView", PeopleVM.PeopleList[PersonIndex]);
            }
            return PartialView("_DetailsModalMsg", "Could not find the person or that ID dont exists");
        }
        public IActionResult DeletPerson(int IdNumber)
        {
            People? itemRemove = PeopleViewModel.MainList.SingleOrDefault(x => x.ID == IdNumber);

            if (itemRemove != null)
            {
                PeopleViewModel.MainList.Remove(itemRemove);
                return PartialView("_DetailsModalMsg", $"The user {itemRemove.Name} with the ID of {itemRemove.ID} has been removed");
            }

            return PartialView("_DetailsModalMsg", "Could not find the person or that ID dont exists");
        }
    }
}
