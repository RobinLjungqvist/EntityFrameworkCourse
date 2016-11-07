using EntityFrameworkProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformsProject
{
    public partial class _Default : Page
    {
        private StudentControl studentsControl = new StudentControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();

            }
            
        }

       

        public void BindGrid()
        {
            this.GridViewStudents.DataSource = studentsControl.GetAllStudents().Select(
                stud => new
                {
                    studentID = stud.Id,
                    firstname = stud.People.FirstName,
                    lastname = stud.People.LastName,
                    classname = stud.StudentClasses.ClassName,
                    education = stud.Educations.EducationName

                });
            this.GridViewStudents.DataBind();
     
        }

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldStudID");

            int studentID = int.Parse(hd.Value);

            var ac = new AttendanceControl();

            var studentToRemove = studentsControl.GetAllStudents().Where(x => x.Id == studentID).FirstOrDefault();
            
            if(studentToRemove.Attendance.Count > 0)
            {
                ac.RemoveAttendanceByStudentID(studentID);

            }
            if(studentToRemove != null)
            {

            studentsControl.RemoveStudent(studentID);

            var pc = new PeopleControl();

            pc.RemovePeople(studentToRemove.PersonId);
            }



            BindGrid();
        }

        protected void lb_addstudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddStudent.aspx");
        }

        protected void lb_edit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenFieldStudID");

            int studentID = int.Parse(hd.Value);

            Response.Redirect($"EditStudent.aspx?StudentID={studentID}");
        }
    }
}