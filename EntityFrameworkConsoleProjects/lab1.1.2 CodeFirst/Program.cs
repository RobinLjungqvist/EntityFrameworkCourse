using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._1._2_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new School())
            {
                Student student = new Student()
                {
                    StudentName = "Robin", StudentBirthDate = DateTime.Now.AddYears(-26)};
                ctx.Students.Add(student);
                ctx.SaveChanges();

                var result = from x in ctx.Students
                             where x.StudentName.StartsWith("R")
                             select x;

                Console.WriteLine(result.First().StudentName);

            }
        }
    }
}
