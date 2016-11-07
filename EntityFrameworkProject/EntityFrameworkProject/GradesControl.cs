using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    public class GradesControl
    {
        Entities ctx;

        public GradesControl()
        {
            ctx = new Entities();
        }
        public IEnumerable<Grades> GetAllGrades()
        {
            IEnumerable<Grades> grades;

            grades = ctx.Grades;

            return grades;
        }

        public void InsertorUpdateGrade(Grades grade)
        {
            ctx.Grades.Add(grade);
            ctx.SaveChanges();

        }

        public void RemoveGrade(Grades grade)
        {

            ctx.Grades.Attach(grade);
            ctx.Grades.Remove(grade);
            ctx.SaveChanges();
        }

        public void UpdateGrade(Grades grade)
        {
            ctx.Entry(grade).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public Grades GradeByStudentAndCourseID(int sid, int cid)
        {
            Grades grade = ctx.Grades.Where(x => x.StudentID == sid && x.CourseID == cid).FirstOrDefault();

            return grade;
        }
    }
}
