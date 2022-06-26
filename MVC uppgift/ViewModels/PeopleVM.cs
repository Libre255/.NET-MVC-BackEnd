using Microsoft.EntityFrameworkCore;
using MVC_uppgift.Data;
using MVC_uppgift.Models;

namespace MVC_uppgift.ViewModels
{
    public class PeopleVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int PhoneNumber { get; set; }
        public string? City { get; set; }
        public List<string>? Languages { get; set; }

        public List<PeopleVM> PersonViewList(ApplicationDbContext db)
        {
            var ListOfPeoples = db.Peoples.Include(peps => peps.City).Include(PL => PL.PeopleLanguagues).ThenInclude(L => L.Language);

            List<PeopleVM> NewPersonList = new();

            if (db.Peoples != null)
            {
                foreach (People p in ListOfPeoples)
                {
                    List<string> LanguageList = new();
                    foreach (var L in p.PeopleLanguagues)
                    {
                        LanguageList.Add(L.Language.Name);
                    }
                    NewPersonList.Add(new PeopleVM
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Languages = LanguageList,
                        City = p.City.Name,
                        PhoneNumber = p.PhoneNumber,
                    }); ;
                }
            }
            return NewPersonList;
        }
        public List<PeopleVM> SearchPeople(string SearchInput, List<PeopleVM> listOfPeople)
        {
            List<PeopleVM> SearchedList = listOfPeople.FindAll(People =>
                People.Name.ToLower().Contains(SearchInput.ToLower())
                    ||
                People.City.ToLower().Contains(SearchInput.ToLower())
            );

            return SearchedList;
        }
    }
}
