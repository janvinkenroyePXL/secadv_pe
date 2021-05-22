using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public class InMemoryStudentData : IStudentData
    {
        private List<Student> _students;

        public InMemoryStudentData()
        {
            _students = new List<Student>
            {
                new Student { Id = 1, FirstName = "Jan", Name = "Vinkenroye", Class = "2TIWA", Team = Team.Yellow },
                new Student { Id = 2, FirstName = "Ward", Name = "Lenaerts", Class = "2TIWA", Team = Team.Blue },
                new Student { Id = 3, FirstName = "Vince", Name = "Wouters", Class = "2TIWA", Team = Team.Red },
                new Student { Id = 4, FirstName = "Jeroen", Name = "Paesen", Class = "2TIWA", Team = Team.Yellow },
            };
        }

        public IEnumerable<Student> GetAll()
        {
            return _students.OrderBy(r => r.Name);
        }

        public Student Get(int id)
        {
            return _students.FirstOrDefault(restaurant => restaurant.Id == id);
        }

        public Student Add(Student student)
        {
            student.Id = _students.Max(r => r.Id) + 1;
            _students.Add(student);
            return student;
        }

        public Student Edit(Student editedStudent)
        {
            Student student = _students.FirstOrDefault(s => s.Id == editedStudent.Id);
            student.Name = editedStudent.Name;
            student.FirstName = editedStudent.FirstName;
            student.Class = editedStudent.Class;
            student.Team = editedStudent.Team;
            return student;
        }

        public Student Delete(Student student)
        {
            _students.Remove(student);
            return student;
        }
    }
}
