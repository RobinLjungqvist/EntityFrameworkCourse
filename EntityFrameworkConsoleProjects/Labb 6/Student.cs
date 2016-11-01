using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_6
{
    public class Student
    {
        

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }

        public Student(string lastname, string firstMidName, DateTime enrollmentdate)
        {
            this.Enrollments = new HashSet<Enrollment>();
            LastName = lastname;
            FirstMidName = firstMidName;
            EnrollmentDate = enrollmentdate;
        }

    }
}
