using webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Services
{
    public interface IStudentData
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student newStudent);
        Student Edit(Student student);
        Student Delete(Student student);
    }
}
