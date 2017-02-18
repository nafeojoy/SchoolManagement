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


using SchoolManagementProject.Classes;
using System.IO;

namespace SchoolManagementProject.Forms
{
    public partial class frmAllResult : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"].ToString() == "Teacher" || Session["role"].ToString() == "teacher")
                {
                    subNameDrp.Visible = false;
                    LoadClass();
                }
                else
                {
                    Response.Redirect("~/Forms/frmHome.aspx");
                }
            }
        }

        private void showdata2() // to Add
        {

            //   int tchid = int.Parse(Session["TeacherID"].ToString());
            int x = int.Parse(drpClassName.SelectedValue);


            grdResultAdd.DataSource = dbcontext.View_ResultView.Where(d => d.ClassId == x);
 
            grdResultAdd.DataBind();
        }

        private void showdata3()
        {
            int x = int.Parse(drpClassName.SelectedValue);
            int y = int.Parse(drpSubjectName.SelectedValue);

            grdResultAdd.DataSource = dbcontext.View_ResultView.Where(d => d.ClassId == x && d.SubjectId == y);

            grdResultAdd.DataBind();
        }
        private void LoadClass()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from tblClass", con);
            DataTable item = new DataTable();
            item.Columns.Add("className", typeof(string));
            DataRow dr;
            dr = item.NewRow();
            dr[0] = "Select";
            item.Rows.Add(dr);
            da.Fill(item);

            if (item.Rows.Count != 0)
            {
                drpClassName.DataValueField = "classId";
                drpClassName.DataTextField = "className";
                drpClassName.DataSource = item;
                drpClassName.DataBind();
            }

        }

        private void LoadSubject()
        {
        
            int cls = int.Parse(drpClassName.SelectedValue.ToString());


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from View_SubjectLoad where ClassId = " + cls + "  ", con);
            DataTable item = new DataTable();
            item.Columns.Add("subjectCode", typeof(string));
            DataRow dr;
            dr = item.NewRow();
            // dr[0] = "Select";
            // item.Rows.Add(dr);
            da.Fill(item);

            if (item.Rows.Count != 0)
            {
                drpSubjectName.DataValueField = "SubjectId";
                drpSubjectName.DataTextField = "subjectName";
                drpSubjectName.DataSource = item;
                drpSubjectName.DataBind();
            }
        }

        protected void drpClassName_SelectedIndexChanged(object sender, EventArgs e)
        {

            subNameDrp.Visible = true;
            showdata2();
            LoadSubject();

        }

        protected void drpSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            showdata3();
        }

        protected void btnExport_Click(object sender, EventArgs e)
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
                    StreamWriter writer = File.AppendText(path + "GridView2.xls");
                    grdResultAdd.RenderControl(hw);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

    }
}