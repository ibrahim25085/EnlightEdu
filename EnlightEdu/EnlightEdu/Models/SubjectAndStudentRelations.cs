using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnlightEdu.Models
{
    public class SubjectAndStudentRelations
    {
        public int  Id { get; set; }

        public int StudentId { get; set; }
        public Students Student { get; set; }

        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }
    }
}