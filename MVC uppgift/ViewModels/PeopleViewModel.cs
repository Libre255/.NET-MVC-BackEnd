using MVC_uppgift.Models;

namespace MVC_uppgift.ViewModels
{
    public class PeopleViewModel
    {
        static public List<People> MainList = new List<People>()
        {
            new People("Crypto Papi", 90044430, "Narnia"),
            new People("Mickey Mouse", 2293920, "Disneyland"),
            new People("Jerry Seinfeld", 299344992, "New York")
        };
        public List<People> PeopleList { get; set; }

        public PeopleViewModel()
        {
            PeopleList = MainList;
        }

        public List<People> SearchPeople(string SearchInput)
        {
            return MainList.FindAll(People => 
                People.Name.ToLower().Contains(SearchInput.ToLower()) 
                    || 
                People.City.ToLower().Contains(SearchInput.ToLower())
            );
        }
    }
}
