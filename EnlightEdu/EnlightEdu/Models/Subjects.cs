using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnlightEdu.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Students> CourseOfStudents { get; set; }
    }
}