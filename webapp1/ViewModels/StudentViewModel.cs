using System;
using System.ComponentModel.DataAnnotations;

namespace webapp1.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Display(Name="Naam")]
        public String Name { get; set; }

        [Display(Name = "Voornaam")]
        public String FirstName { get; set; }

        [Display(Name = "Klas")]
        public String Class { get; set; }

        [Display(Name = "Team")]
        public Team Team { get; set; }
    }
}
