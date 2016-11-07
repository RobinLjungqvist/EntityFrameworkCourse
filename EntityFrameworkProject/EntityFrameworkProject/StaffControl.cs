using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    public class StaffControl
    {
        Entities ctx;

        public StaffControl()
        {
            ctx = new Entities();
        }
        public IEnumerable<Staffs> GetAllStaff()
        {
            IEnumerable<Staffs> staff;

            staff = ctx.Staffs;

            return staff;
        }

        public void InsertStaff(Staffs staffMember)
        {

            ctx.Staffs.Add(staffMember);
            ctx.SaveChanges();

        }

        public void RemoveStaffMember(Staffs staffMember)
        {

            ctx.Staffs.Attach(staffMember);
            ctx.Staffs.Remove(staffMember);
            ctx.SaveChanges();
        }
        public void RemoveStaff(int id)
        {
            var sToRemove = ctx.Staffs.Where(x => x.Id == id).FirstOrDefault();
            if (sToRemove != null)
            {
                ctx.Staffs.Remove(sToRemove);
            }

        }
        public void UpdateStaffMember(Staffs staffMember)
        {
            ctx.Entry(staffMember).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public Staffs GetStaffMemberByID(int id)
        {
            Staffs staffMember = ctx.Staffs.Where(x => x.Id == id).FirstOrDefault();

            return staffMember;
        }
    }
}
