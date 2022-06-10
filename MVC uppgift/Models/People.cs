using System.ComponentModel.DataAnnotations;
namespace MVC_uppgift.Models
{
    public class People
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        
        public People(int Id, string name, int phone, string city)
        {
            ID = Id;
            Name = name;
            PhoneNumber = phone;
            City = city;
        }
    }
}
