using MVC_uppgift.Models;

namespace MVC_uppgift.ViewModels
{
    public class CountryViewModel
    {
        public string Name { get; set; }
        public List<Country> CountryList = new();
    }
}
