using EntityFrameworkProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformsProject
{
    public partial class Course : System.Web.UI.Page
    {
        private StudentControl sc = new StudentControl();
        private CourseControl cc = new CourseControl();
        private StaffControl tc = new StaffControl();
        private EducationsControl ec = new EducationsControl();
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
                    AddNewCoursesDiv.Visible = false;

                }
                else
                {
                    GridViewCourses.Visible = false;
                    addgradediv.Visible = false;
                    studentinfo.Visible = false;
                    AddNewCoursesDiv.Visible = true;


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
            lbl_adress.Text = student.People.Address;
            lbl_email.Text = student.People.Email;

            this.GridViewCourses.DataSource = student.Grades.Select(g => new
            {
                Course = g.Courses.CourseName,
                Grade = g.Grade,
                Teacher = g.Courses.Staffs.People.FirstName + " " + g.Courses.Staffs.People.LastName,
                Completed = g.Completed,
                CourseID = g.CourseID
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
                CourseID = c.Id,
                Course = c.CourseName,
                GradeRange = c.Grade,
                Teacher = c.Staffs.People.FirstName + " " + c.Staffs.People.LastName
            });
            GridViewAllCourses.DataBind();

            FillNewCourseDropDowns();


        }

        private void FillNewCourseDropDowns()
        {
            ddl_teachers.DataSource = tc.GetAllStaff().Select(t => new
            {
                t.Id,
                Fullname = t.People.FirstName + " " + t.People.LastName

            });
            ddl_teachers.DataTextField = "Fullname";
            ddl_teachers.DataValueField = "Id";
            ddl_teachers.Items.Insert(0, new ListItem("<Teacher>", "-1"));
            ddl_teachers.AppendDataBoundItems = true;

            ddl_teachers.DataBind();

            ddl_education.DataSource = ec.GetAllEducations().ToList();

            ddl_education.DataTextField = "EducationName";
            ddl_education.DataValueField = "Id";
            ddl_education.Items.Insert(0, new ListItem("<Education>", "-1"));
            ddl_education.AppendDataBoundItems = true;

            ddl_education.DataBind();



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
                var myBool = student.Grades.FirstOrDefault(x => x.CourseID == grade.CourseID && x.StudentID == grade.StudentID) != null;
                if (myBool)
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

            Response.Redirect($"Course?StudentID={param}");
        }

        protected void chkbox_completed_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbox_completed.Checked == true)
            {
                ddl_studGrade.Enabled = true;
            }
        }

        protected void btn_savenewcourse_Click(object sender, EventArgs e)
        {
            var course = new EntityFrameworkProject.Courses();

            if (ddl_teachers.SelectedValue != "-1" && ddl_education.SelectedValue != "-1")
            {
                course.CourseName = txtbox_newcourse.Text;
                course.Education_Id = int.Parse(ddl_education.SelectedValue);
                course.Grade = "IG - MVG";
                course.Staff_Id = int.Parse(ddl_teachers.SelectedValue);

                cc.InsertorUpdateCourse(course);
                Response.Redirect($"Course");

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            var id = lb.CommandArgument;
            
            var gc = new GradesControl();

            int studID = int.Parse(Request.QueryString["StudentID"]);
            int courseID = int.Parse(id);
            var studentGradeToRemove = gc.GradeByStudentAndCourseID(studID, courseID);

            gc.RemoveGrade(studentGradeToRemove);

            Response.Redirect($"Course?StudentID={studID}");



        }

        protected void lb_studdelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            var id = int.Parse(lb.CommandArgument);

            var courseToRemove = cc.CourseByID(id);
            var gc = new GradesControl();

            var gradesToRemove = gc.GetAllGrades().ToList().Where(x => x.CourseID == courseToRemove.Id);
            foreach (var grade in gradesToRemove)
            {
                gc.RemoveGrade(grade);
            }

            var ac = new AttendanceControl();
            var attendanceToRemove = ac.GetAllAttendance().ToList().Where(a => a.CourseID == courseToRemove.Id);

            foreach (var attendance in attendanceToRemove)
            {
                ac.RemoveAttendance(attendance);
            }

            cc.RemoveCourse(courseToRemove);

            Response.Redirect($"Course");

        }
    }

    
}