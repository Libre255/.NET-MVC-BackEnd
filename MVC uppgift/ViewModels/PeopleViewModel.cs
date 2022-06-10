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
            var dbMain = db.Peoples.Include(peps => peps.City).Include(PL => PL.PeopleLanguagues).ThenInclude(L => L.Language);

            List<CreatePersonViewModel> NewPersonList = new();
            if (db.Peoples != null)
            {
                foreach (People p in dbMain)
                {
                    NewPersonList.Add(new CreatePersonViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        PeopleLanguagues = p.PeopleLanguagues,
                        City = p.City.Name,
                        PhoneNumber = p.PhoneNumber,
                    });
                }
            }
            return NewPersonList;
        }
    }
}
