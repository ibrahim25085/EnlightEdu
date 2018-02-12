using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using EnlightEdu.Models;

namespace EnlightEdu.Controllers
{
    public class SubjectsController : ApiController
    {
        EduDbContext context=new EduDbContext();

        public IEnumerable<Subjects> Get()
        {
            var subjects = this.context.Subject.ToList();
           
            return subjects;
        }

        public Subjects Get(int id)
        {
            var subject = this.context.Subject.SingleOrDefault(x => x.Id == id);
            return subject;
        }

        public void Post(Subjects subjects)
        {
            if (!ModelState.IsValid)
            {
              //  return BadRequest(ModelState);
            }

                context.Subject.Add(subjects);
                context.SaveChanges();
           /// return CreatedAtRoute("DefaultApi", new {id = subjects.Id}, subjects);


        }

        public void Put(int id, Subjects subjects)
        {
            //if (!ModelState.IsValid)
            //{
            //  //  return BadRequest(ModelState);
            //}
            var subject = this.context.Subject.SingleOrDefault(x => x.Id == subjects.Id);
            subject.Name = subjects.Name;
            subject.Code = subjects.Code;

            context.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        }

        public void Delete(int id)
        {
            var subject = this.context.Subject.SingleOrDefault(x => x.Id == id);
            context.Subject.Remove(subject);
            context.SaveChanges();
          //  return Ok(subject);
        }
        
    }
}
