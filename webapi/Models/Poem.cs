using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Poem
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Text { get; set; }

        public int Year { get; set; }

        public String Author { get; set; }

        public String Info { get; set; }
    }
}
