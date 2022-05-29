using System.ComponentModel.DataAnnotations;

namespace MVC_uppgift.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<PeopleLanguage> PeopleLanguagues { get; set; }
    }
}
