using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_6
{
    class SchoolContext : DbContext
    {
        public SchoolContext(): base("name=SchoolContextConnectionString")
        {

        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
    }
}
