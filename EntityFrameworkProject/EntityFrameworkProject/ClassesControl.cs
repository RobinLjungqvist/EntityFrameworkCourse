using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    public class ClassesControl
    {
        Entities ctx;

        public ClassesControl()
        {
            ctx = new Entities();
        }
        public IEnumerable<StudentClasses> GetAllClasses()
        {
            IEnumerable<StudentClasses> classes;

            classes = ctx.StudentClasses;

            return classes;
        }

        public void InsertorUpdateClass(StudentClasses studentClass)
        {
            ctx.StudentClasses.Add(studentClass);

            ctx.SaveChanges();

        }

        public void RemoveClass(StudentClasses studentClass)
        {

            ctx.StudentClasses.Attach(studentClass);
            ctx.StudentClasses.Remove(studentClass);
            ctx.SaveChanges();
        }

        public void UpdateClass(StudentClasses studentClass)
        {
            ctx.Entry(studentClass).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public StudentClasses ClassByID(int id)
        {
            StudentClasses studentClass = ctx.StudentClasses.Where(x => x.Id == id).FirstOrDefault();

            return studentClass;
        }
    }
}
