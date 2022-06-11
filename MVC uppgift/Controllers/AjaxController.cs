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
        public IActionResult PersonDetails(int IdNumber)
        {
            var SelectedPerson = PeopleVM.SelectAPeople(IdNumber);
            if (SelectedPerson != null)
            {
                return PartialView("_PersonView", SelectedPerson);
            }
            return PartialView("_DetailsModalMsg", "Could not find the person or that ID dont exists");
        }
        public IActionResult DeletPerson(int IdNumber)
        {
            var SelectedPerson = PeopleVM.SelectAPeople(IdNumber);

            if (SelectedPerson != null)
            {
                PeopleViewModel.MainList.Remove(SelectedPerson);
                return PartialView("_DetailsModalMsg", $"The user {SelectedPerson.Name} with the ID of {SelectedPerson.ID} has been removed");
            }

            return PartialView("_DetailsModalMsg", "Could not find the person or that ID dont exists");
        }
    }
}
