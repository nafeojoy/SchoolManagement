using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;
using SchoolManagementProject.Classes;

namespace SchoolManagementProject.Forms
{
    public partial class frmAllTeacherInfo : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();
        Load getdata = new Load();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"].ToString() == "Teacher" || Session["role"].ToString() == "teacher" || Session["role"].ToString() == "Guardian" || Session["role"].ToString() == "guardian")
                {
                    LoadTeacher();
                }
                else
                {
                    Response.Redirect("~/Forms/frmHome.aspx");
                }
                
                
            }
        }

        private void LoadTeacher()
        {
            drpSelectTeacher.DataValueField = "TeacherId";
            drpSelectTeacher.DataTextField = "tchName";
            drpSelectTeacher.DataSource = getdata.LoadTeacher();
            drpSelectTeacher.DataBind();
        }
        private void LoadInfo()
        {
            int x = int.Parse(drpSelectTeacher.SelectedValue); 

            var item = dbcontext.tblTeachers.Single(c => c.TeacherId == x);

            txtTeacherName.Text = item.tchName;
            txtTeacherDes.Text = item.tchDesignation;
            txtTeacherEmail.Text = item.tchEmail;
            txtTeacherPhone.Text = item.tchPhone;
            txtTeacherId.Text = item.tchProfileId;
            txtSSC.Text = item.SSC.ToString();
            txtHSC.Text = item.HSC.ToString();
            txtHonors.Text = item.Honors.ToString();
            txtMasters.Text = item.Masters.ToString();
            txtOtherDegree.Text = item.Others;
        }

        protected void drpSelectTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInfo();
        }
    }
}