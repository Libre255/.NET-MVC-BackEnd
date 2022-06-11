using MVC_uppgift.Models;
using System.ComponentModel.DataAnnotations;
namespace MVC_uppgift.ViewModels
{
    public class CreatePersonViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Insert name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Insert phone number")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Insert City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Insert Language")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Insert Country")]

        public List<City> ListOfCities = new();
        public List<Language> ListOfLanguages = new();
    }
}
