using System.ComponentModel.DataAnnotations;

namespace MVC_uppgift.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<City> ListOfCities { get; set; }
    }
}
