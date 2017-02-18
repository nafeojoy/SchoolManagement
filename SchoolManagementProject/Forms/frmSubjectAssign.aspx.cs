using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;
using SchoolManagementProject.Classes;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SchoolManagementProject.Forms
{
    public partial class frmSubjectAssign : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();
        Load load = new Load();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClass();
                LoadSubject();
                LoadTeacher();
                LoadGrid();
            }

        }

        protected void Button_Click_Subject_Select(object sender, EventArgs e)
        {
            try
            {
                tblAssign item = new tblAssign();

                item.ClassId = int.Parse(drpClass.SelectedValue);
                item.SubjectId = int.Parse(drpSubject.SelectedValue);
                item.Teacherid = int.Parse(drpTeacher.SelectedValue);


                dbcontext.tblAssigns.AddObject(item);
                dbcontext.SaveChanges();

                LoadGrid();
            }
            catch
            {
                string script = "alert('Select Correctly');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }


        private void LoadGrid()
        {
            string cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from View_Assign", con);
                DataTable ds = new DataTable();
                da.Fill(ds);

                grdAssign.DataSource = ds;
                grdAssign.DataBind();
            }


            //grdAssign.DataSource = dbcontext.View_Assign;
            //grdAssign.DataBind();

            grdSubject.DataSource = dbcontext.tblSubjects;
            grdSubject.DataBind();

            grdTeacher.DataSource = dbcontext.tblTeachers;
            grdTeacher.DataBind();
        }


        private void LoadClass()
        {
            List<tblClass> drpList = new List<tblClass>();

            tblClass item = new tblClass();

            item.ClassId = 0;
            item.className = "Select";

            drpList = dbcontext.tblClasses.ToList();
            drpList.Insert(0, item);

            drpClass.DataValueField = "ClassId";
            drpClass.DataTextField = "className";
            drpClass.DataSource = drpList;
            drpClass.DataBind();

        }
        private void LoadSubject()
        {
            List<tblSubject> drpList = new List<tblSubject>();

            tblSubject item = new tblSubject();

            item.SubjectId = 0;
            item.subjectName = "Select";

            drpList = dbcontext.tblSubjects.ToList();
            drpList.Insert(0, item);

            drpSubject.DataValueField = "SubjectId";
            drpSubject.DataTextField = "subjectName";
            drpSubject.DataSource = drpList;
            drpSubject.DataBind();

        }
        private void LoadTeacher()
        {
            List<tblTeacher> drpList = new List<tblTeacher>();

            tblTeacher item = new tblTeacher();

            item.TeacherId = 0;
            item.tchName = "Select";

            drpList = dbcontext.tblTeachers.ToList();
            drpList.Insert(0, item);

            drpTeacher.DataValueField = "TeacherId";
            drpTeacher.DataTextField = "tchName";
            drpTeacher.DataSource = drpList;
            drpTeacher.DataBind();



        }

        protected void grdResult_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAssign.EditIndex = e.NewEditIndex;
            LoadGrid();
        }

        protected void grdResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                GridViewRow row = grdAssign.Rows[e.RowIndex];

                //for (int i = 0; i < grdAssign.Rows.Count; i++) // for all row

                decimal id = Convert.ToDecimal(((Label)row.FindControl("lblAssignId")).Text);
                //  int cls = int.Parse(drpClass.SelectedValue);
                int cls = int.Parse(((DropDownList)row.FindControl("drpClassName")).SelectedValue);
                int sub = int.Parse(((DropDownList)row.FindControl("drpSubjectCode")).SelectedValue);
                int tch = int.Parse(((DropDownList)row.FindControl("drpTeacher1")).SelectedValue);




                var item = dbcontext.tblAssigns.Single(f => f.AssignId == id);

                item.ClassId = cls;
                item.SubjectId = sub;
                item.Teacherid = tch;

                dbcontext.SaveChanges();

            }

            catch
            {
                string script = "alert('Duplicate Subject Allocation');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }

            e.Cancel = true;
            grdAssign.EditIndex = -1;
            LoadGrid();


        }

        protected void grdResult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            grdAssign.EditIndex = -1;
            LoadGrid();
        }

        protected void grdAssign_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if ((e.Row.RowState & DataControlRowState.Edit) != 0)
            {

                DropDownList tchId = (DropDownList)e.Row.FindControl("drpTeacher1");

                tchId.DataSource = load.LoadTeacher();
                tchId.DataValueField = "TeacherId";
                tchId.DataTextField = "tchProfileId";
                tchId.DataBind();

                DropDownList subCode = (DropDownList)e.Row.FindControl("drpSubjectCode");

                subCode.DataSource = load.LoadSubject();
                subCode.DataValueField = "SubjectId";
                subCode.DataTextField = "subjectCode";
                subCode.DataBind();



                DropDownList cls = (DropDownList)e.Row.FindControl("drpClassName");

                cls.DataSource = load.LoadClass();
                cls.DataValueField = "ClassId";
                cls.DataTextField = "className";
                cls.DataBind();

            }
        }

        protected void grdAssign_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdAssign.Rows[e.RowIndex];
            decimal id = Convert.ToDecimal(((Label)row.FindControl("lblAssignId")).Text);
            var item = dbcontext.tblAssigns.Single(f => f.AssignId == id);

            dbcontext.tblAssigns.DeleteObject(item);
            dbcontext.SaveChanges();

            e.Cancel = true;
            grdAssign.EditIndex = -1;
            LoadGrid();

        }

        protected void btnSubAssignExport_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Sheets/");
            Response.Clear();
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


    }
}