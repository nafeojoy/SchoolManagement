using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;

namespace SchoolManagementProject.Forms
{
    public partial class frmAllResultStudent : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["StudentID"] != null && Session["GuardianID"] != null)
                {
                    int x = int.Parse(Session["StudentID"].ToString());

                    grdAllResult.DataSource = dbcontext.View_AllResult.Where(c => c.StudentId == x);
                    grdAllResult.Columns[1].Visible = false;
                    grdAllResult.DataBind();
                    lblStudentName.Text = Session["StudentName"].ToString();
                    divStudentName.Visible = true;
                    divClassName.Visible = false;
                }
                else if (Session["StudentID"] != null)
                {
                    int x = int.Parse(Session["StudentID"].ToString());

                    grdAllResult.DataSource = dbcontext.View_AllResult.Where(c => c.StudentId == x);
                    grdAllResult.Columns[1].Visible = false;
                    grdAllResult.DataBind();
                    lblStudentName.Text = Session["StudentName"].ToString();
                    divStudentName.Visible = true;
                    divClassName.Visible = false;
                    divButtons.Visible = false;
                }

                else if(Session["ClassTeacherID"] != null)
                {
                    int y = int.Parse(Session["ClassTeacherID"].ToString());
                    grdAllResult.DataSource = dbcontext.View_AllResult.Where(c => c.ClassId == y);
                    grdAllResult.DataBind();
                    lblClassName.Text = Session["ClassNameTch"].ToString();
                    divStudentName.Visible = false;
                    divClassName.Visible = true; 
                    divButtons.Visible = false;
                }

            }
        }

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(Session["StudentID"].ToString());

                grdAllResult.DataSource = dbcontext.View_AllResult.Where(c => c.StudentId == x);
                grdAllResult.Columns[1].Visible = false;
                grdAllResult.DataBind();
                lblStudentName.Text = Session["StudentName"].ToString();
                divStudentName.Visible = true;
                divClassName.Visible = false;
            }
            catch
            {
                string script = "alert('No Student!!!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }

        }

        protected void btnStudent2_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(Session["StudentID2"].ToString());
                var item = dbcontext.View_AllResult.Single(c => c.StudentId == x);

                grdAllResult.DataSource = dbcontext.View_AllResult.Where(c => c.StudentId == x);
                grdAllResult.Columns[1].Visible = false;
                grdAllResult.DataBind();
                lblStudentName.Text = item.stdName;
                divStudentName.Visible = true;
                divClassName.Visible = false;
            }
            catch
            {
                string script = "alert('No Student!!!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        protected void btnStudent3_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(Session["StudentID3"].ToString());
                var item = dbcontext.View_AllResult.Single(c => c.StudentId == x);

                grdAllResult.DataSource = dbcontext.View_AllResult.Where(c => c.StudentId == x);
                grdAllResult.Columns[1].Visible = false;
                grdAllResult.DataBind();
                lblStudentName.Text = item.stdName;
                divStudentName.Visible = true;
                divClassName.Visible = false;
            }
            catch
            {
                string script = "alert('No Student!!!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        protected void btnStudent4_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(Session["StudentID4"].ToString());
                var item = dbcontext.View_AllResult.Single(c => c.StudentId == x);

                grdAllResult.DataSource = dbcontext.View_AllResult.Where(c => c.StudentId == x);
                grdAllResult.Columns[1].Visible = false;
                grdAllResult.DataBind();
                lblStudentName.Text = item.stdName;
                divStudentName.Visible = true;
                divClassName.Visible = false;
            }
            catch
            {
                string script = "alert('No Student!!!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        protected void btnStudent5_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(Session["StudentID5"].ToString());

                var item = dbcontext.View_AllResult.Single(c => c.StudentId == x);
                grdAllResult.DataSource = dbcontext.View_AllResult.Where(c => c.StudentId == x);
                grdAllResult.Columns[1].Visible = false;
                grdAllResult.DataBind();
                lblStudentName.Text = item.stdName;
                divStudentName.Visible = true;
                divClassName.Visible = false;
            }
            catch
            {
                string script = "alert('No Student!!!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }
    }
}