using webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Services
{
    public interface IPoemData
    {
        IEnumerable<Poem> GetAll();
        Poem Get(int id);
        Poem Add(Poem newPoem);
    }
}
