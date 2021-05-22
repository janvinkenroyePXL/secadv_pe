using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;
using webapi.Services;
using webapi.EditModels;
using Microsoft.AspNetCore.Authorization;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private IStudentData _studentData;

        public StudentsController(IStudentData studentData)
        {
            _studentData = studentData;
        }

        [HttpGet]
        [Route("")]
        [Route("All")]
        [Authorize("team")]
        public IActionResult Get()
        {
            var model = _studentData.GetAll();
            return new ObjectResult(model);
        }

        [HttpGet]
        [Route("{id?}")]
        [Authorize("team")]
        public IActionResult GetById(int id)
        {
            var model = _studentData.Get(id);
            if(model == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(model);
            }
        }

        [HttpPost]
        [Route("new")]
        [Authorize("admin")]
        public IActionResult PostNewStudent([FromBody] StudentEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                var newStudent = new Student();
                newStudent.FirstName = model.FirstName;
                newStudent.Name = model.Name;
                newStudent.Class = model.Class;
                newStudent.Team = model.Team;
                Student addedStudent = _studentData.Add(newStudent);
                return Ok(addedStudent);
            }
        }

        [HttpPut]
        [Route("{id}/update")]
        [Authorize("admin")]
        public IActionResult PutStudent([FromBody] StudentEditModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                var student = _studentData.Get(id);
                student.Id = id;
                student.FirstName = model.FirstName;
                student.Name = model.Name;
                student.Class = model.Class;
                student.Team = model.Team;
                Student editedStudent = _studentData.Edit(student);
                return Ok(student);
            }
        }

        [HttpDelete]
        [Route("{id}/delete")]
        [Authorize("admin")]
        public IActionResult DeleteStudent(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                var student = _studentData.Get(id);
                _studentData.Delete(student);
                return Ok(student);
            }
        }
    }
}
