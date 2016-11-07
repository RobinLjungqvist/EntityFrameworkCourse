using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    public class AttendanceControl
    {
        Entities ctx;

        public AttendanceControl()
        {
            ctx = new Entities();
        }
        public IEnumerable<Attendance> GetAllAttendance()
        {
            IEnumerable<Attendance> attendance;

            attendance = ctx.Attendance;

            return attendance;
        }

        public void InsertAttendance(Attendance attendance)
        {

            ctx.Attendance.Add(attendance);
            ctx.SaveChanges();

        }

        public void RemoveAttendance(Attendance attendance)
        {

            ctx.Attendance.Attach(attendance);
            ctx.Attendance.Remove(attendance);
            ctx.SaveChanges();
        }

        public void RemoveAttendanceByStudentID(int id)
        {
            var attendanceToRemove = ctx.Attendance.Single(ac => ac.StudentID == id);
            ctx.Attendance.Remove(attendanceToRemove);
                ctx.SaveChanges();
        }

        public void UpdateAttendance(Attendance attendance)
        {
            ctx.Entry(attendance).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public Attendance AttendaceByStudentAndCourseID(int sid, int cid)
        {
            Attendance people = ctx.Attendance.Where(x => x.StudentID == sid && x.CourseID == cid).FirstOrDefault();

            return people;
        }
    }
}
