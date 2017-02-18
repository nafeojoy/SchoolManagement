using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Globalization;
using SchoolManagementLibrary;

namespace SchoolManagementProject.Forms
{
    public partial class frmNoticeUpload : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["TeacherId"] != null)
            {
                grdViewNoticeNonEditable.Visible = false;

                grdViewNotice.DataSource = dbcontext.tblUploads;
                grdViewNotice.DataBind();

            }
            else
            {

                grdViewNoticeNonEditable.DataSource = dbcontext.tblUploads;
                grdViewNoticeNonEditable.DataBind();

                uploadNotice.Visible = false;
                grdViewNoticeNonEditable.Visible = true;
                grdViewNotice.Visible = true;
            }

           
        }

        protected void btnNoticeBoardUpload_Click(object sender, EventArgs e)
        {
            if(fileNoticeBoard.HasFile)
            {
                IFormatProvider ff = new CultureInfo("fr-FR", true);

                string str = fileNoticeBoard.FileName;  
                string fileName = txtFileName.Text;
                DateTime dt = DateTime.ParseExact(DateTextbox1.Text, "dd.MM.yyyy", ff);
                fileNoticeBoard.PostedFile.SaveAs(Server.MapPath("~") +"//Uploads//" + str);
                string path = "~//Uploads//" + str.ToString();
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into tblUploads values('" + path + "','" + fileName + "','" + dt + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();


                
                SqlDataAdapter da = new SqlDataAdapter("select * from tblUploads", con);
                DataTable item = new DataTable();
                da.Fill(item);
                grdViewNotice.DataSource = item;
                DataBind();

      

                lblMessage.Visible = false;
            }

            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select a file first";
            }

        }

        protected void btnNoticeBoardCancel_Click(object sender, EventArgs e)
        {

        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        
      

        }

        protected void grdViewNotice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdViewNotice.Rows[e.RowIndex];
            decimal id = Convert.ToDecimal(((Label)row.FindControl("lblUploadId")).Text);
            var item = dbcontext.tblUploads.Single(f => f.UploadId == id);

            dbcontext.tblUploads.DeleteObject(item);
            dbcontext.SaveChanges();

            e.Cancel = true;
            grdViewNotice.EditIndex = -1;

            grdViewNotice.DataSource = dbcontext.tblUploads;
            grdViewNotice.DataBind();

            string script = "alert('Notice Deleted');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
        }
    }
}