using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    public class EducationsControl
    {
        Entities ctx;

        public EducationsControl()
        {
            ctx = new Entities();
        }
        public IEnumerable<Educations> GetAllEducations()
        {
            IEnumerable<Educations> courses;

            courses = ctx.Educations;

            return courses;
        }

        public void InsertorUpdateEducation(Educations education)
        {
           ctx.Educations.Add(education);
           ctx.SaveChanges();

        }

        public void RemoveEducation(Educations education)
        {

            ctx.Educations.Attach(education);
            ctx.Educations.Remove(education);
            ctx.SaveChanges();
        }

        public void UpdateEducation(Educations education)
        {
            var edu = ctx.Educations.Where(x => x.Id == education.Id).FirstOrDefault();
            edu.EducationName = education.EducationName;
            ctx.Educations.Attach(edu);
            ctx.Entry(edu).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public Educations EducationByID(int id)
        {
            Educations course = ctx.Educations.Where(x => x.Id == id).FirstOrDefault();

            return course;
        }
    }
}
