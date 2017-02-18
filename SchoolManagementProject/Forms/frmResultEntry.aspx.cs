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

namespace SchoolManagementProject.Forms
{
    public partial class frmResultEntry : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAddResult.Visible = false;
                subNameDrp.Visible = false;
                subNameDrp1.Visible = true;
                divAddMarks.Visible = false;
                divEditMarks.Visible = false;
                
            }
        }

        private void showdata2() // to Add
        {
            
         //   int tchid = int.Parse(Session["TeacherID"].ToString());
            int x = int.Parse(drpClassName.SelectedValue);

          
            grdResultAdd.DataSource = dbcontext.tblStudents.Where(d=>d.ClassId==x);
            grdResultAdd.DataBind();
        }

        private void showdata() // to Edit/Update
        {
            int x = int.Parse(drpClassName1.SelectedValue);
            int subid = int.Parse(drpSubName1.SelectedValue);
            //grdResult.DataSource = dbcontext.View_ResultViewUpdate.Where(d => d.ClassId == x && d.SubjectId == subid);
            //grdResult.DataBind();
            search();
        }

        private void LoadClass()
        {

            int y = int.Parse(Session["TeacherID"].ToString());


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from View_ClassLoad where Teacherid="+y+"", con);
            DataTable item = new DataTable();
            item.Columns.Add("className", typeof(string));
            DataRow dr;
            dr = item.NewRow();
            dr[0] = "Select";
            item.Rows.Add(dr);
            da.Fill(item);

            if (item.Rows.Count != 0)
            {
                drpClassName.DataValueField = "ClassId";
                drpClassName.DataTextField = "className";
                drpClassName.DataSource = item;
                drpClassName.DataBind();

                drpClassName1.DataValueField = "ClassId";
                drpClassName1.DataTextField = "className";
                drpClassName1.DataSource = item;
                drpClassName1.DataBind();
            }
            
        }

        //private void LoadSubject()
        //{

        //    List<tblSubject> drpList = new List<tblSubject>();

        //    tblSubject item = new tblSubject();

        //    item.SubjectId = 0;
        //    item.subjectName = "Select";

        //    drpList = dbcontext.tblSubjects.ToList();
        //    drpList.Insert(0, item);

        //    drpSubjectName.DataValueField = "SubjectId";
        //    drpSubjectName.DataTextField = "subjectName";
        //    drpSubjectName.DataSource = drpList;
        //    drpSubjectName.DataBind();
        
        //}


        private void LoadSubject()
        {
            int y = int.Parse(Session["TeacherID"].ToString());
            int cls;

            if (drpClassName1.SelectedIndex == 0)
            {
                cls = int.Parse(drpClassName.SelectedValue.ToString());
            }
            else
            {
                cls = int.Parse(drpClassName1.SelectedValue.ToString());
            }
           

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from View_SubjectLoad where ClassId = " + cls + " and Teacherid = " + y + "  ", con);
            DataTable item = new DataTable();
            item.Columns.Add("subjectName", typeof(string));
            DataRow dr;
            dr = item.NewRow();
            dr[0] = "Select";
            item.Rows.Add(dr);
            da.Fill(item);

            if (item.Rows.Count != 0)
            {
                drpSubName1.DataValueField = "SubjectId";
                drpSubName1.DataTextField = "subjectName";
                drpSubName1.DataSource = item;
                drpSubName1.DataBind();
            }
            if (item.Rows.Count != 0)
            {
                drpSubjectName.DataValueField = "SubjectId";
                drpSubjectName.DataTextField = "subjectName";
                drpSubjectName.DataSource = item;
                drpSubjectName.DataBind();
            }
        }


        protected void grdResult_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdResult.EditIndex = e.NewEditIndex;
            showdata(); 
        }

        protected void grdResult_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                GridViewRow row = grdResult.Rows[e.RowIndex];

                decimal id = Convert.ToDecimal(((Label)row.FindControl("lblResultId")).Text);
                decimal quiz = decimal.Parse(((TextBox)row.FindControl("txtQuiz")).Text);
                decimal final = decimal.Parse(((TextBox)row.FindControl("txtFinal")).Text);
                decimal total = decimal.Parse(((TextBox)row.FindControl("txtTotal")).Text);

                var item = dbcontext.tblResults.Single(f => f.ResultId == id);


                item.Quiz = quiz;
                item.Final = final;
                item.Total = total;

                dbcontext.SaveChanges();



                e.Cancel = true;
                grdResult.EditIndex = -1;
                showdata();
            }

            catch
            {
                string script = "alert('Wrong Input');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        protected void grdResult_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            grdResult.EditIndex = -1;
            showdata(); 
        }

        protected void btnAddResult_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdResultAdd.Rows.Count; i++)
                {
                    GridViewRow row = grdResultAdd.Rows[i];

                    decimal studentid = Convert.ToDecimal(((Label)row.FindControl("lblStudentId")).Text);
                    decimal quiz = decimal.Parse(((TextBox)row.FindControl("txtQuiz")).Text);
                    decimal final = decimal.Parse(((TextBox)row.FindControl("txtFinal")).Text);
                    decimal total = decimal.Parse(((TextBox)row.FindControl("txtTotal")).Text);

                    tblResult item = new tblResult();
                    item.Quiz = quiz;
                    item.Final = final;
                    item.Total = quiz+final;
                    item.StudentId = (int)studentid;
                    item.ClassId = int.Parse(drpClassName.SelectedValue.Trim());
                    item.SubjectId = int.Parse(drpSubjectName.SelectedValue.Trim());

                    dbcontext.tblResults.AddObject(item);
                    dbcontext.SaveChanges();

                }
                showdata2();
            }
            catch
            {
                string script = "alert('Duplicate items are Not Allowed');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        protected void drpClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddResult.Visible = true;
            subNameDrp.Visible = true;
            
        
            showdata2();
            LoadSubject();
            
        }

        protected void drpClassName_SelectedIndexChanged1(object sender, EventArgs e)
        {

            subNameDrp1.Visible = true;
            showdata();

            LoadSubject();
        }

        protected void btnAddMarks_Click(object sender, EventArgs e)
        {
            divAddMarks.Visible = true;
            divEditMarks.Visible = false;
            LoadClass();
        }

        protected void btnUpdagteMarks_Click(object sender, EventArgs e)
        {
            divEditMarks.Visible = true;
            divAddMarks.Visible = false;
            LoadClass();
            
        }

        protected void drpSubName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
     
            string name, cls;

            int tchId = int.Parse(Session["TeacherID"].ToString());
            int clsId = int.Parse(drpClassName1.SelectedValue);
            int subId = int.Parse(drpSubName1.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);



            da = new SqlDataAdapter("select * from View_ResultViewUpdate where ClassId = '" + clsId + "' and SubjectId = '" + subId + "' and TeacherId = '" + tchId + "' ", con);
            

            DataTable item = new DataTable();
            da.Fill(item);

            if (item.Rows.Count != 0)
            {
                grdResult.DataSource = item;
                grdResult.DataBind();

            }
            else
            {

                grdResult.DataSource = null;
                grdResult.DataBind();
            }
          //  int x = int.Parse(drpClassName1.SelectedValue.ToString());
            //grdResult.DataSource = item;
            //grdResult.DataBind();
        }

        protected void drpClassName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubject();
            drpSubName1.Visible = true;
            
        }

    
    }
}