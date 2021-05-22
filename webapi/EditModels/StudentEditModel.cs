using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.EditModels
{
    public class StudentEditModel
    {
        public String Name { get; set; }

        public String FirstName { get; set; }

        public String Class { get; set; }

        public Team Team { get; set; }
    }
}
