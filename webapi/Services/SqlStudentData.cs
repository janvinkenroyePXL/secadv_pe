using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Data;
using webapi.Models;

namespace webapi.Services
{
    public class SqlStudentData : IStudentData
    {
        private WebApiDbContext _context;

        public SqlStudentData(WebApiDbContext context)
        {
            _context = context;
        }
        
        public Student Add(Student newStudent)
        {
            _context.Students.Add(newStudent);
            _context.SaveChanges();
            return newStudent;
        }

        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public Student Edit(Student student)
        {
            _context.Attach(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return student;
        }

        public Student Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.OrderBy(s => s.Name);
        }
    }
}
