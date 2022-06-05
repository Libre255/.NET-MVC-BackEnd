using MVC_uppgift.Data;
using MVC_uppgift.Models;

namespace MVC_uppgift.ViewModels
{
    public class PeopleViewModel
    {
        public List<CreatePersonViewModel> PeopleList;

        public void SearchPeople(string SearchInput, List<CreatePersonViewModel> listOfPeople)
        {
            PeopleList = listOfPeople.FindAll(People => 
                People.Name.ToLower().Contains(SearchInput.ToLower()) 
                    || 
                People.City.ToLower().Contains(SearchInput.ToLower())
            );
        }
    }
}
