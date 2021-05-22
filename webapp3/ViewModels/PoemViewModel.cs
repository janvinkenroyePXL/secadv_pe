using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp3.ViewModels
{
    public class PoemViewModel
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Text { get; set; }

        public int Year { get; set; }

        public String Author { get; set; }

        public String Info { get; set; }
    }
}
