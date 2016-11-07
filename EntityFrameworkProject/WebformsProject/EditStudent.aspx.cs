using EntityFrameworkProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformsProject
{
    public partial class EditStudent : Page
    {
        private EducationsControl edc = new EducationsControl();
        private ClassesControl cc = new ClassesControl();
        private StudentControl sc = new StudentControl();
        private PeopleControl pc = new PeopleControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["StudentID"] != null)
                {
                    var param = Request.QueryString["StudentID"];
                    int id = -1;
                    if (int.TryParse(param, out id))
                    {
                        var student = sc.StudentsByID(id);
                        txtbox_firstname.Text = student.People.FirstName;
                        txtbox_lastname.Text = student.People.LastName;
                        txtbox_adress.Text = student.People.Address;
                        txtbox_email.Text = student.People.Email;
                        hf_id.Value = student.Id.ToString();

                        ddl_education.SelectedValue = student.EducationId.ToString();
                        ddl_class.SelectedValue = student.StudentClass_Id.ToString();



                        FillDropDowns();

                    }
                    else
                    {
                        Response.Redirect("Default.aspx");

                    }


                }
            }
                


                
        }

        protected void FillDropDowns()
        {
            ddl_education.DataSource = edc.GetAllEducations().ToList();
            ddl_education.DataTextField = "EducationName";
            ddl_education.DataValueField = "Id";

            ddl_education.Items.Insert(0, new ListItem("<Educations>", "0"));

            ddl_education.DataBind();

            ddl_class.DataSource = cc.GetAllClasses().ToList();
            ddl_class.DataTextField = "ClassName";
            ddl_class.DataValueField = "Id";

            ddl_class.Items.Insert(0, new ListItem("<Classes>", "0"));


            ddl_class.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            var studentToUpdate = sc.StudentsByID(int.Parse(hf_id.Value));

            studentToUpdate.People.FirstName = txtbox_firstname.Text;
            studentToUpdate.People.LastName = txtbox_lastname.Text;
            studentToUpdate.People.Address = txtbox_adress.Text;
            studentToUpdate.People.Email = txtbox_email.Text;

            studentToUpdate.StudentClass_Id = int.Parse(ddl_class.SelectedValue);
            studentToUpdate.EducationId = int.Parse(ddl_education.SelectedValue);


            sc.UpdateStudent(studentToUpdate);

            lbl_msg.Text = $"Updated Student {studentToUpdate.People.FirstName} {studentToUpdate.People.LastName}";
            ClearTxtBoxes();
            Response.Redirect("Default.aspx");

        }

        protected void ClearTxtBoxes()
        {
            txtbox_firstname.Text = string.Empty;
            txtbox_lastname.Text = string.Empty;
            txtbox_email.Text = string.Empty;
            txtbox_adress.Text = string.Empty;

        }
    }
}