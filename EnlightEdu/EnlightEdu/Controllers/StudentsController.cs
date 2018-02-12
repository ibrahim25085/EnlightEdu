using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnlightEdu.Models;
using System.Web.Mvc;

namespace EnlightEdu.Controllers
{
    public class StudentsController : ApiController
    {
        EduDbContext context = new EduDbContext();

        public IEnumerable<Students> Get()
        {
            var students = this.context.Student.ToList();

            return students;
        }

        public Students Get(int id)
        {
            var student = this.context.Student.SingleOrDefault(x => x.Id == id);
            return student;
        }

        public void Post(Students students)
        {
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }
            context.Student.Add(students);
            context.SaveChanges();

           /// return CreatedAtRoute("DefaultApi", new { id = students.Id }, students);
        }

        public void Put(int id, Students stu)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var student = this.context.Student.SingleOrDefault(x => x.Id == stu.Id);
            student.Name = stu.Name;
            student.Contacts = stu.Contacts;
            student.RegistrationNo = stu.RegistrationNo;
            student.Email = stu.Email;
            context.SaveChanges();

            //return StatusCode(HttpStatusCode.NoContent);
        }

        public void Delete(int id)
        {
            var student = this.context.Student.SingleOrDefault(x => x.Id == id);
            context.Student.Remove(student);
            context.SaveChanges();
           // return Ok(student);
        }
    }
}
