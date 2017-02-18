using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;
using System.Globalization;

namespace SchoolManagementProject.Forms
{
    public partial class frmAttendanceCount : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // Session["Class"] = 1; // Session["Class"] will be set at the time of Login
                if (Session["role"].ToString() == "Teacher" || Session["role"].ToString() == "teacher")
                {
                    if (Session["ClassTeacherID"] != null)
                    {
                        LoadClassNo();

                    }
                }
                else
                {
                    Response.Redirect("~/Forms/frmHome.aspx");
                }
                
                
            }
        }

   


        private void LoadClassNo()
        {
            int x = int.Parse(Session["ClassTeacherID"].ToString());

            var item = dbcontext.tblClasses.Single(c => c.ClassId == x);

            lblClassName.InnerText = item.className;

            grdAttendaceCount.DataSource = dbcontext.tblStudents.Where(c => c.ClassId == x);
           
            grdAttendaceCount.DataBind();
        }

        protected void Button_Click_Attendace_Count(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdAttendaceCount.Rows.Count; i++)
                {
                    GridViewRow row = grdAttendaceCount.Rows[i];

                    IFormatProvider ff = new CultureInfo("fr-FR", true);


                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    tblAttendanceCount item = new tblAttendanceCount();


                    item.StudentId = Convert.ToInt16(((Label)row.FindControl("lblStudentId")).Text);
                    if (isChecked)
                    {
                        item.Status = 0;
                    }

                    else
                    {
                        item.Status = 1;
                    }


                    // item.Date = DateTime.Now;
                    item.Date = DateTime.ParseExact(DateTextbox1.Text, "dd.MM.yyyy", ff);

                    dbcontext.tblAttendanceCounts.AddObject(item);
                    dbcontext.SaveChanges();

                }

                string script = "alert('Attendance Taken');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);

            }
            catch
            {
                string script = "alert('Duplicate items are Not Allowed');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        
    }
}