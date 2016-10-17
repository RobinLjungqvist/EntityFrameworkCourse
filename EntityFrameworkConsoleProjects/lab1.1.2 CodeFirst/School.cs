using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._1._2_CodeFirst
{
    class School: DbContext
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Education> Educations { get; set; }
    }
}
