using MVC_uppgift.Data;
using MVC_uppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_uppgift.ViewModels
{
    public class PeopleViewModel
    {
        public bool ShowEditModal = false;
        public List<CreatePersonViewModel> PeopleList;
        
        public void SearchPeople(string SearchInput, List<CreatePersonViewModel> listOfPeople)
        {
            PeopleList = listOfPeople.FindAll(People => 
                People.Name.ToLower().Contains(SearchInput.ToLower()) 
                    || 
                People.City.ToLower().Contains(SearchInput.ToLower())
            );
        }

        public List<CreatePersonViewModel> PersonViewList(ApplicationDbContext db)
        {
            var ListOfPeoples = db.Peoples.Include(peps => peps.City).Include(PL => PL.PeopleLanguagues).ThenInclude(L => L.Language);

            List<CreatePersonViewModel> NewPersonList = new();

            if (db.Peoples != null)
            {
                foreach (People p in ListOfPeoples)
                {
                    List<Language> LanguageList = new();
                    foreach (var L in p.PeopleLanguagues)
                    {
                        LanguageList.Add(L.Language);
                    }
                    NewPersonList.Add(new CreatePersonViewModel
                    {
                        Id  = p.Id,
                        Name = p.Name,
                        ListOfLanguages = LanguageList,
                        City = p.City.Name,
                        PhoneNumber = p.PhoneNumber,
                    }); ;
                }
            }
            return NewPersonList;
        }
    }
}
