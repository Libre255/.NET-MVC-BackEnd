using MVC_uppgift.Models;

namespace MVC_uppgift.ViewModels
{
    public class CityViewModel
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public List<City> CityList = new();
        public List<Country> ListOfCountries = new();
    }
}
