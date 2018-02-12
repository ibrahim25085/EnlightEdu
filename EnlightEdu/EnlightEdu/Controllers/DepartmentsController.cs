using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using EnlightEdu.Models;

namespace EnlightEdu.Controllers
{
    public class DepartmentsController : ApiController
    {

        EduDbContext context = new EduDbContext();

        public IEnumerable<Departments> Get()
        {
            var depts = this.context.Department.ToList();

            return depts;
        }

        public Departments Get(int id)
        {
            var dept = this.context.Department.SingleOrDefault(x => x.Id == id);
            return dept;
        }

        public void Post(Departments department)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            context.Department.Add(department);
            context.SaveChanges();

          //  return CreatedAtRoute("DefaultApi", new { id = department.Id }, department);

        }

        public void Put(int id, Departments departments)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var dept = this.context.Department.SingleOrDefault(x => x.Id == id);

            dept.Code = departments.Code;
            dept.Name = departments.Name;

            context.SaveChanges();
           // return StatusCode(HttpStatusCode.NoContent);
        }

        public void Delete(int id)
        {
            var dept = this.context.Department.SingleOrDefault(x => x.Id == id);
            context.Department.Remove(dept);
            context.SaveChanges();
            //return Ok(dept);
        }

    }
}
