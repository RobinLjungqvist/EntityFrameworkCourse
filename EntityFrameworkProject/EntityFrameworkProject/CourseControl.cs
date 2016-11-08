using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    public class CourseControl
    {
        Entities ctx;

        public CourseControl()
        {
            ctx = new Entities();
        }
        public IEnumerable<Courses> GetAllCourses()
        {
            IEnumerable<Courses> courses;

            courses = ctx.Courses;

            return courses;
        }

        public void InsertorUpdateCourse(Courses course)
        {
                ctx.Courses.Add(course);
                ctx.SaveChanges();

        }

        public void RemoveCourse(Courses course)
        {

            ctx.Courses.Attach(course);
            ctx.Courses.Remove(course);
            ctx.SaveChanges();
        }

        public void UpdateCourse(Courses course)
        {
            ctx.Entry(course).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public Courses CourseByID(int id)
        {
            Courses course = ctx.Courses.Where(x => x.Id == id).FirstOrDefault();

            return course;
        }
    }
}
