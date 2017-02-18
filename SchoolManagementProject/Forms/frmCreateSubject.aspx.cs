using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;
using SchoolManagementProject.Classes;
using System.IO;


namespace SchoolManagementProject.Forms
{
    public partial class frmCreateSubject : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"].ToString() == "Teacher" || Session["role"].ToString() == "teacher")
                {
                    grdSubject.DataSource = dbcontext.tblSubjects;
                    grdSubject.DataBind();
                }
                else
                {
                    Response.Redirect("~/Forms/frmHome.aspx");
                }
              
            }
        }

        protected void Button_Click_Add_Subject(object sender, EventArgs e)
        {
            tblSubject item = new tblSubject();

            item.subjectCode = txtSubjectCode.Text;
            item.subjectName = txtSubjectName.Text;

            dbcontext.tblSubjects.AddObject(item);
            dbcontext.SaveChanges();


            grdSubject.DataSource = dbcontext.tblSubjects;
            grdSubject.DataBind();

            string script = "alert('Subject Saved');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
        }

        protected void grdSubject_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdSubject.EditIndex = e.NewEditIndex;

            grdSubject.DataSource = dbcontext.tblSubjects;
            grdSubject.DataBind();
        }

        protected void grdSubject_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            {

                GridViewRow row = grdSubject.Rows[e.RowIndex];

                decimal id = Convert.ToDecimal(((Label)row.FindControl("lblSubjectId")).Text);

                string SubCode = (((TextBox)row.FindControl("txtSubCode")).Text);
                string SubName = (((TextBox)row.FindControl("txtStdName")).Text);
                //decimal total = decimal.Parse(((TextBox)row.FindControl("txtTotal")).Text);

                var item = dbcontext.tblSubjects.Single(f => f.SubjectId == id);


                item.subjectCode = SubCode;
                item.subjectName = SubName;
                

                dbcontext.SaveChanges();

            }

            e.Cancel = true;
            grdSubject.EditIndex = -1;
            grdSubject.DataSource = dbcontext.tblSubjects;
            grdSubject.DataBind();
        }

        protected void grdSubject_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            grdSubject.EditIndex = -1;
            grdSubject.DataSource = dbcontext.tblSubjects;
            grdSubject.DataBind(); 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Sheets/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StreamWriter writer = File.AppendText(path + "GridView.xls");
                    grdSubject.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }



        //protected void grdSubject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    GridViewRow row = grdSubject.Rows[e.RowIndex];
        //    decimal id = Convert.ToDecimal(((Label)row.FindControl("lblSubjectId")).Text);
        //    var item = dbcontext.tblSubjects.Single(f => f.SubjectId == id);

        //    dbcontext.tblSubjects.DeleteObject(item);
        //    dbcontext.SaveChanges();

        //    e.Cancel = true;
        //    grdSubject.EditIndex = -1;

        //    grdSubject.DataSource = dbcontext.tblSubjects;
        //    grdSubject.DataBind();
        //}
    }
}