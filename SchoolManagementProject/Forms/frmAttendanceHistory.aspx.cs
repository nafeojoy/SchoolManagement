using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Configuration;
using System.Globalization;
using SchoolManagementProject.Classes;


namespace SchoolManagementProject.Forms
{
    public partial class frmAttendanceHistory : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();
        Load getdata = new Load();
        Utilities util = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"].ToString() == "Teacher" || Session["role"].ToString() == "teacher")
                {
                    divAttendanceCount.Visible = false;
                    divAttendanceCountDate.Visible = false;
                    //LoadDate();
                    LoadClass();
                    //LoadStudent();

                }
                else
                {
                    Response.Redirect("~/Forms/frmHome.aspx");
                }
            }

        }


        //private void LoadStudent()
        //{
        //    drpNameFilter.DataValueField = "StudentId";
        //    drpNameFilter.DataTextField = "stdName";
        //    drpNameFilter.DataSource = getdata.LoadStudent();
        //    drpNameFilter.DataBind();
        //}
        //private void LoadDate()
        //{

        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
        //    SqlDataAdapter da = new SqlDataAdapter("select distinct Date2 from view_Attendance_Count", con);
        //    DataTable item = new DataTable();
        //    item.Columns.Add("Date2", typeof(string));
        //    DataRow dr;
        //    dr = item.NewRow();
        //    dr[0] = "Select";
        //    item.Rows.Add(dr);
        //    da.Fill(item);

        //    if (item.Rows.Count != 0)
        //    {
        //        drpDateFilter.DataValueField = "Date2";
        //        drpDateFilter.DataTextField = "Date2";
        //        drpDateFilter.DataSource = item;
        //        drpDateFilter.DataBind();
        //    }

        //}
        private void LoadClass()
        {

            drpClassFilter.DataValueField = "className";
            drpClassFilter.DataTextField = "className";
            drpClassFilter.DataSource = getdata.LoadClass();
            drpClassFilter.DataBind();

        }


        protected void btnAttendanceHistory_Click(object sender, EventArgs e)
        {
            //grdAttendanceCountDate.DataSource = dbcontext.view_Attendance_Count.Where(d => d.stdName == "Nafeo").Distinct();

            if (Session["ClassTeacherID"] != null)
            {
                int x = int.Parse(Session["ClassTeacherID"].ToString());
                grdAttendanceCountDate.DataSource = dbcontext.view_Attendance_Count.Where(d => d.ClassId == x).OrderBy(c => c.Date2);
                grdAttendanceCountDate.DataBind();
            }
            
            divAttendanceCountDate.Visible = true;
            divAttendanceCount.Visible = false;

        }

        protected void btnAttendanceSummary_Click(object sender, EventArgs e)
        {
            if (Session["ClassTeacherID"] != null)
            {
                int x = int.Parse(Session["ClassTeacherID"].ToString());
                grdAttendaceCount.DataSource = dbcontext.View_Attendance.Where(c => c.ClassId == x);
                grdAttendaceCount.DataBind();
            }
            else
            {
                grdAttendaceCount.DataSource = dbcontext.View_Attendance.Where(c => c.ClassId == 0);
                grdAttendaceCount.DataBind();
            }
            divAttendanceCountDate.Visible = false;
            divAttendanceCount.Visible = true;
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void drpClassFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void drpNameFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            DateTime dt;
            string name="";
            string date, cls;

            if (DateTextbox1.Text == "")
            {
                dt = Convert.ToDateTime("2010-01-01");
            }
            else
            {
                dt = Convert.ToDateTime(DateTextbox1.Text);
            }


            if (txtName.Text == "")
            {
                name = "%";
            }
            else
            {
                name = txtName.Text;
            }


            if (drpClassFilter.SelectedItem.Text=="Select")
            {
                cls = "%";
            }
            else
            {
                cls = drpClassFilter.SelectedItem.Text;
            }

            if (DateTextbox1.Text == "")
            {
                date = "2010-01-01";
            }
            else
            {
                date = dt.Year + "-" + dt.Month + "-" + dt.Day;
            }


            SqlDataAdapter da = new SqlDataAdapter();
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
            if (DateTextbox1.Text == "")
            {
                da = new SqlDataAdapter("select * from view_Attendance_Count where className like '" + cls + "' and stdName like '" + name + "'  ", con);
            }
            else
            {
                da = new SqlDataAdapter("select * from view_Attendance_Count where className like '" + cls + "' and stdName like '" + name + "' and Date='" + date + "' ", con);
            }

            DataTable item = new DataTable();
            da.Fill(item);

            if (item.Rows.Count != 0)
            {
                grdAttendanceCountDate.DataSource = item;
                grdAttendanceCountDate.DataBind();
               
            }
            else
            {

                grdAttendanceCountDate.DataSource = null;
                grdAttendanceCountDate.DataBind();
            }

        }

        protected void DateTextbox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void grdAttendaceCount_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAttendaceCount.EditIndex = e.NewEditIndex;
            search();   
        }

        protected void grdAttendaceCount_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void grdAttendaceCount_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            grdAttendaceCount.EditIndex = -1;
            search();
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            search();
        }

    }
}