using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Giris.Models;

namespace WebAPI_Giris.Controllers.api
{
    public class StudentController : ApiController
    {
        SchoolDBEntities ctx = new SchoolDBEntities();
        public IHttpActionResult GetStudentId(int id)
        {
            IList<StudentViewModel> student = ctx.Students.Where(x => x.StudentID == id).Select(x=> new StudentViewModel
            {
                StudentID = x.StudentID,
                StudentName = x.StudentName
            }).ToList<StudentViewModel>();
            if (student==null)
            {
                return NotFound();
            }
            return Ok(student);

        }
        public IHttpActionResult GetAllStudents()
        {
            IList<StudentViewModel> student = ctx.Students.Select(x => new StudentViewModel
            {
                StudentID = x.StudentID,

                StudentName = x.StudentName
               
            }).ToList<StudentViewModel>();
            if (student.Count==0)
            {
                return NotFound();
            }
            return Ok(student);
        }

        public IHttpActionResult PostNewStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            ctx.Students.Add(new Student()
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
            });
            ctx.SaveChanges();
            return Ok();
        }
        
        public IHttpActionResult Put(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");

            }
            var existingStudent = ctx.Students.Where(s => s.StudentID == student.StudentID).FirstOrDefault<Student>();

            if (existingStudent!=null)
            {
                existingStudent.StudentName = student.StudentName;
                ctx.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            if (id<=0)
            {
                return BadRequest("Not a valid student id");
            }
            var student = ctx.Students.Where(s => s.StudentID == id).FirstOrDefault();
            ctx.Students.Remove(student);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
