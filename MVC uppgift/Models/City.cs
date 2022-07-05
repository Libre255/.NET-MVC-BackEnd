﻿using System.ComponentModel.DataAnnotations;

namespace MVC_uppgift.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual List<People> ListOfPeople { get; set; }
    }
}