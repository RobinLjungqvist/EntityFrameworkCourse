using EntityFrameworkProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformsProject
{
    public partial class AttendancePage : System.Web.UI.Page
    {
        private AttendanceControl ac = new AttendanceControl();
        private StudentControl sc = new StudentControl();
        private CourseControl cc = new CourseControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindDropDowns();
            }
        }

        private void BindDropDowns()
        {
            ddl_student.DataSource = sc.GetAllStudents().Select(x => new
            {
                Name = x.People.FirstName + " " + x.People.LastName,
                Id = x.Id
            });
            ddl_student.DataTextField = "Name";
            ddl_student.DataValueField = "Id";
            ddl_student.Items.Insert(0, new ListItem("<Students>", "0"));

            ddl_student.AppendDataBoundItems = true;
            ddl_student.DataBind();

            ddl_courses.DataSource = cc.GetAllCourses().Select(c => new
            {
                CourseName = c.CourseName,
                CourseID = c.Id
            });
            ddl_courses.DataTextField = "CourseName";
            ddl_courses.DataValueField = "CourseID";
            ddl_courses.Items.Insert(0, new ListItem("<Courses>", "0"));

            ddl_courses.AppendDataBoundItems = true;

            ddl_courses.DataBind();

            ddl_addAtt.Items.Insert(0, new ListItem("True", "True"));
            ddl_addAtt.Items.Insert(0, new ListItem("False", "False"));

            ddl_addAtt.AppendDataBoundItems = true;





        }

        private void BindGrid()
        {
            GridViewAllAttendance.DataSource = ac.GetAllAttendance().Select(a => new
            {
                AttendanceID = a.id,
                Attendance = a.Attendance1,
                Date = a.Date,
                CourseName = a.Courses.CourseName,
                StudentName = a.Students.People.FirstName + " " + a.Students.People.LastName
            });

            GridViewAllAttendance.DataBind();
        }

        protected void GridViewAllAttendance_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewAllAttendance.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridViewAllAttendance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridViewAllAttendance.EditIndex = -1;
            BindGrid();
        }

        protected void GridViewAllAttendance_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvr = GridViewAllAttendance.Rows[e.RowIndex];

            var attID = int.Parse(GridViewAllAttendance.DataKeys[e.RowIndex].Values[0].ToString());

            var attendanceToUpdate = ac.GetAllAttendance().Where(x => x.id == attID).FirstOrDefault();

            TextBox att = (TextBox)gvr.FindControl("TextBoxAttendance");


            if(attendanceToUpdate != null)
            {
                if (att.Text == "False")
                {
                    attendanceToUpdate.Attendance1 = false;
                    ac.UpdateAttendance(attendanceToUpdate);
                }
                else if (att.Text == "True")
                {
                    attendanceToUpdate.Attendance1 = true;
                    ac.UpdateAttendance(attendanceToUpdate);

                }

                e.Cancel = true;
                GridViewAllAttendance.EditIndex = -1;
                BindGrid();

            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            var att = new Attendance();

            att.StudentID = int.Parse(ddl_student.SelectedValue);
            att.CourseID = int.Parse(ddl_courses.SelectedValue);
            att.Date = calendar_date.SelectedDate;
            att.Attendance1 = bool.Parse(ddl_addAtt.SelectedValue);

            ac.InsertAttendance(att);

            Response.Redirect("AttendancePage.aspx");
        }

        protected void lb_delete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            var id = int.Parse(lb.CommandArgument);

            var attToRemove = ac.GetAllAttendance().ToList().Where(a => a.id == id).FirstOrDefault();

            if(attToRemove != null)
            {
                ac.RemoveAttendance(attToRemove);
            }

            Response.Redirect("AttendancePage.Aspx");
            

        }
    }
}