using MVC_uppgift.Data;
using MVC_uppgift.Models;

namespace MVC_uppgift.ViewModels
{
    public class PeopleViewModel
    {
        public List<People> PeopleList { get; set; }

        public void SearchPeople(string SearchInput, List<People> listOfPeople)
        {
            PeopleList = listOfPeople.FindAll(People => 
                People.Name.ToLower().Contains(SearchInput.ToLower()) 
                    || 
                People.City.Name.ToLower().Contains(SearchInput.ToLower())
            );
        }
    }
}
