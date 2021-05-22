using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name="Naam")]
        [Required, MaxLength(40)]
        public String Name { get; set; }

        [Display(Name = "Voornaam")]
        [Required, MaxLength(20)]
        public String FirstName { get; set; }

        [Display(Name = "Klas")]
        [Required, MaxLength(20)]
        public String Class { get; set; }

        [Display(Name = "Team")]
        public Team Team { get; set; }
    }
}
