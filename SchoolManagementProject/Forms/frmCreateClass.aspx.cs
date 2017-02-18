using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;

namespace SchoolManagementProject.Forms
{
    public partial class frmCreatClass : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"].ToString() == "Teacher" || Session["role"].ToString() == "teacher")
                {
                    grdClass.DataSource = dbcontext.tblClasses;
                    grdClass.DataBind();
                }
                else
                {
                    Response.Redirect("~/Forms/frmHome.aspx");
                }
                
            }
        }

        protected void Button_Click_Add_Class(object sender, EventArgs e)
        {
            tblClass item = new tblClass();

           
            item.className = txtClassName.Text;

            dbcontext.tblClasses.AddObject(item);
            dbcontext.SaveChanges();


            grdClass.DataSource = dbcontext.tblClasses;
            grdClass.DataBind();

            string script = "alert('Class Saved');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
        }

        protected void grdClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdClass.Rows[e.RowIndex];
            decimal id = Convert.ToDecimal(((Label)row.FindControl("lblClassId")).Text);
            var item = dbcontext.tblClasses.Single(f => f.ClassId == id);

            dbcontext.tblClasses.DeleteObject(item);
            dbcontext.SaveChanges();

            e.Cancel = true;
            grdClass.EditIndex = -1;

            grdClass.DataSource = dbcontext.tblClasses;
            grdClass.DataBind();
        }
    }
}