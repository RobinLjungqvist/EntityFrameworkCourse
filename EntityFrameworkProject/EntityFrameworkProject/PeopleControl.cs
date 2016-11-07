using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkProject;
using System.Data.Entity;

namespace EntityFrameworkProject
{
    public class PeopleControl
    {
        Entities ctx;

        public PeopleControl()
        {
            ctx = new Entities();
        }
        public IEnumerable<People> GetAllPeople()
        {
            IEnumerable<People> people;

            people = ctx.People;

            return people;
        }

        public void InsertPeople(People person)
        {

            ctx.People.Add(person);
            ctx.SaveChanges();

        }

        public void RemovePeople(People person)
        {

            ctx.People.Attach(person);
            ctx.People.Remove(person);
            ctx.SaveChanges();
        }
        public void RemovePeople(int id)
        {
            var pToRemove = ctx.People.Where(x => x.Id == id).FirstOrDefault();
            if(pToRemove != null)
            {
                ctx.People.Remove(pToRemove);
            }
            ctx.SaveChanges();
        }

        public void UpdatePeople(People person)
        {
            ctx.Entry(person).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public People PeopleByID(int id)
        {
            People people = ctx.People.Where(x => x.Id == id).FirstOrDefault();

            return people;
        }
    }
}
