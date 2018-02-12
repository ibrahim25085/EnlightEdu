using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EnlightEdu.Models
{
    public class EduDbContext : DbContext
    {
        public DbSet<Departments> Department { get; set; }
        public DbSet<Students> Student { get; set; }
        public DbSet<Subjects> Subject { get; set; }
        public DbSet<SubjectAndStudentRelations> SubjectAndStudentRelation { get; set; }
    }
}