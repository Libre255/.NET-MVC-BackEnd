using System.ComponentModel.DataAnnotations;
namespace MVC_uppgift.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required(ErrorMessage ="Insert name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Insert phone number")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Insert City")]
        public string City { get; set; }
    }
}
