using EntityFrameworkProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformsProject
{
    public partial class Contact : Page
    {
        private EducationsControl edc = new EducationsControl();
        private ClassesControl cc = new ClassesControl();
        private StudentControl sc = new StudentControl();
        private PeopleControl pc = new PeopleControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                FillDropDowns();
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
            People newPerson = new People();

            newPerson.FirstName = txtbox_firstname.Text;
            newPerson.LastName = txtbox_lastname.Text;
            newPerson.Address = txtbox_adress.Text;
            newPerson.Email = txtbox_email.Text;

            //pc.InsertPeople(newPerson);

            Students newStudent = new Students();

            newStudent.People = newPerson;
            newStudent.StudentClass_Id = int.Parse(ddl_class.SelectedValue);
            newStudent.EducationId = int.Parse(ddl_education.SelectedValue);

            sc.InsertStudent(newStudent);

            lbl_msg.Text = $"Added Student {newPerson.FirstName} {newPerson.LastName}";
            ClearTxtBoxes();
            

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