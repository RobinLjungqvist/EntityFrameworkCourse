using EntityFrameworkProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformsProject
{
    public partial class Education : Page
    {
        private EducationsControl edc = new EducationsControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
       

        protected void lb_insert_Click(object sender, EventArgs e)
        {
            var txtbox_edu = (TextBox)GridViewEducation.FooterRow.FindControl("txtbox_edu");

            var educationName = txtbox_edu.Text;

            var edu = new Educations();

            edu.EducationName = educationName;

            edc.InsertorUpdateEducation(edu);

            txtbox_edu.Text = string.Empty;

            GridViewEducation.DataBind();
            

        }

        protected void GridViewEducation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEducation.EditIndex = e.NewEditIndex;
            GridViewEducation.DataBind();
        }

        protected void GridViewEducation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEducation.EditIndex = -1;
            GridViewEducation.DataBind();

        }

        protected void GridViewEducation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //GridViewRow r = GridViewEducation.Rows[e.RowIndex];
            //TextBox t = (r.FindControl("txtbox_edit") as TextBox);

            //HiddenField hd = (r.FindControl("hf_ID") as HiddenField);

            //var edu = new Educations();

            //edu.EducationName = t.Text;
            //edu.Id = int.Parse(hd.Value);

            //edc.UpdateEducation(edu);

            //GridViewEducation.DataBind();

        }

        protected void lb_save_Click(object sender, EventArgs e)
        {
            var txtbox_edu = (TextBox)GridViewEducation.FooterRow.FindControl("txtbox_edu");

            var educationName = txtbox_edu.Text;

            var edu = new Educations();

            edu.EducationName = educationName;

            edc.InsertorUpdateEducation(edu);

            txtbox_edu.Text = string.Empty;

            GridViewEducation.DataBind();
        }
    }
}