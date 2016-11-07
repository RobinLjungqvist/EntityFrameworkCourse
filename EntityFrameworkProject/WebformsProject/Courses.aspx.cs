using EntityFrameworkProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformsProject
{
    public partial class Courses : System.Web.UI.Page
    {
        private StudentControl sc = new StudentControl();
        private CourseControl cc = new CourseControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["StudentID"] != null)
                {
                    var id = Request.QueryString["StudentID"];
                    FillStudentData(id);
                    GridViewCourses.Visible = true;
                    addgradediv.Visible = true;
                    studentinfo.Visible = true;

                }
                else
                {
                    GridViewCourses.Visible = false;
                    addgradediv.Visible = false;
                    studentinfo.Visible = false;

                    FillCourses();
                }
            }
            
        }

        protected void FillStudentData(string studID)
        {
            

            int studentID = int.Parse(studID);

            var student = sc.StudentsByID(studentID);

            lbl_FullName.Text = student.People.FirstName + " " + student.People.LastName;
            lbl_Education.Text = student.Educations.EducationName;
            lbl_Class.Text = student.StudentClasses.ClassName;

            this.GridViewCourses.DataSource = student.Grades.Select(g => new
            {
                Course = g.Courses.CourseName,
                Grade = g.Grade,
                Teacher = g.Courses.Staffs.People.FirstName + " " + g.Courses.Staffs.People.LastName,
                Completed = g.Completed
            });

            this.GridViewCourses.DataBind();

            
            ddl_studCourse.DataSource = cc.GetAllCourses().ToList();
            ddl_studCourse.DataTextField = "CourseName";
            ddl_studCourse.DataValueField = "Id";
            ddl_studCourse.Items.Insert(0, new ListItem("<Course>", "0"));

            ddl_studCourse.AppendDataBoundItems = true;
            ddl_studCourse.DataBind();

            ddl_studGrade.Items.Insert(0, new ListItem("<Not Set>", "Not Set"));
            ddl_studGrade.Items.Insert(1, new ListItem("IG", "IG"));
            ddl_studGrade.Items.Insert(2, new ListItem("G", "G"));
            ddl_studGrade.Items.Insert(3, new ListItem("VG", "VG"));
            ddl_studGrade.Items.Insert(4, new ListItem("MVG", "MVG"));
            ddl_studGrade.AppendDataBoundItems = true;

            ddl_studGrade.Enabled = false;

        }

        protected void FillCourses()
        {
            this.GridViewAllCourses.DataSource = cc.GetAllCourses().Select(c => new
            {
                Course = c.CourseName,
                GradeRange = c.Grade,
                Teacher = c.Staffs.People.FirstName + " " + c.Staffs.People.LastName
            });
            GridViewAllCourses.DataBind();
        }

        protected void btn_addCourse_Click(object sender, EventArgs e)
        {
            var grade = new Grades();
            string param = Request.QueryString["studentID"];

            if (ddl_studCourse.SelectedValue != "0")
            {
                
                var studID = int.Parse(param);
                grade.Grade = ddl_studGrade.SelectedValue;
                grade.Completed = chkbox_completed.Checked;
                grade.CourseID = int.Parse(ddl_studCourse.SelectedValue);
                grade.StudentID = studID;

                var student = sc.StudentsByID(studID);

                if (student.Grades.Where(x => x.CourseID == grade.CourseID) != null)
                {
                    var gc = new GradesControl();
                    gc.UpdateGrade(grade);
                }
                else
                {
                    student.Grades.Add(grade);
                    sc.UpdateStudent(student);
                } 
            }

            Response.Redirect($"Courses?StudentID={param}");
        }

        protected void chkbox_completed_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbox_completed.Checked == true)
            {
                ddl_studGrade.Enabled = true;
            }
        }
    }

    
}