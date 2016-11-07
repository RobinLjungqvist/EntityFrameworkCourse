using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkProject
{
    public class StudentControl
    {
        Entities ctx;

        public StudentControl()
        {
            ctx = new Entities();
        }
        public IEnumerable<Students> GetAllStudents()
        {
            IEnumerable<Students> students;

            students = ctx.Students;

            return students;
        }

        public void InsertStudent(Students student)
        {

            ctx.Students.Add(student);


            ctx.SaveChanges();

        }

        public void RemoveStudent(Students student)
        {

                ctx.Students.Attach(student);
                ctx.Students.Remove(student);
                ctx.SaveChanges();
        }
        public void RemoveStudent(int id)
        {
            var sToRemove = ctx.Students.Where(x => x.Id == id).FirstOrDefault();
            if (sToRemove != null)
            {
                ctx.Students.Remove(sToRemove);
            }
            ctx.SaveChanges();
        }
        public void UpdateStudent(Students student)
        {
                ctx.Students.Attach(student);
                ctx.Entry(student).State = EntityState.Modified;
                ctx.SaveChanges();
        }

        public Students StudentsByID(int id)
        {
            Students student = ctx.Students.Where(x => x.Id == id).FirstOrDefault();

            return student;
        }
    }
}
