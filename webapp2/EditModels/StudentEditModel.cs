using System;
using System.ComponentModel.DataAnnotations;

namespace webapp2.EditModels
{
    public class StudentEditModel
    {
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
        [Required]
        public Team Team { get; set; }
    }
}
