using System.ComponentModel.DataAnnotations;

namespace MVC_uppgift.Models
{
    public class PeopleLanguage
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int PeopleId { get; set; }
        public People People { get; set; }
    }
}
