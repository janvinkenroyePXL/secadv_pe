using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public class InMemoryPoemData : IPoemData
    {
        private List<Poem> _poems;

        public InMemoryPoemData()
        {
            _poems = new List<Poem>
            {
                new Poem { Id = 1, 
                    Title = "U, nu!", 
                    Text = "U, nu!", 
                    Year = 1620, 
                    Author = "Joost van den Vondel", 
                    Info = "Dit is het kortste Nederlandstalige gedicht ooit volgens het Guinness World Records Book." },
                new Poem { Id = 2, Title = "Om te weten", 
                    Text = "Om te weten / " +
                    "dat er woord / " +
                    "voor woord / " +
                    "een andere taal is / " +
                    "daarom schrijf ik.", 
                    Year = 1975, 
                    Author = "Jan Arends",
                    Info = "Jan Arends schreef vlak voor zijn eigen dood, dat het enige wat hij wilde, een echt gesprek was met een ander mens. " +
                    "Hij was hier echter niet toe in staat, omdat anderen voor hem wel een andere taal leken te spreken." },
            };
        }

        public IEnumerable<Poem> GetAll()
        {
            return _poems.OrderBy(r => r.Title);
        }

        public Poem Get(int id)
        {
            return _poems.FirstOrDefault(poem => poem.Id == id);
        }

        public Poem Add(Poem poem)
        {
            poem.Id = _poems.Max(r => r.Id) + 1;
            _poems.Add(poem);
            return poem;
        }

    }
}
