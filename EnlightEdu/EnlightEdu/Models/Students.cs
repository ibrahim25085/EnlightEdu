using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnlightEdu.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNo { get; set; }
        public string Address { get; set; }
        public string  Email { get; set; }
        public string Contacts { get; set; }

        public int DepartmentId { get; set; }
        public Departments Departments { get; set; }

        public virtual ICollection<Subjects> StudentSubjectses { get; set; }
    }
}