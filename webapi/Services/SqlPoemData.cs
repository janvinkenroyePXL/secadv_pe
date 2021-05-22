using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Data;
using webapi.Models;

namespace webapi.Services
{
    public class SqlPoemData : IPoemData
    {
        private WebApiDbContext _context;

        public SqlPoemData(WebApiDbContext context)
        {
            _context = context;
        }

        public Poem Add(Poem newPoem)
        {
            _context.Poems.Add(newPoem);
            _context.SaveChanges();
            return newPoem;
        }

        public Poem Get(int id)
        {
            return _context.Poems.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Poem> GetAll()
        {
            return _context.Poems.OrderBy(p => p.Title);
        }
    }
}
