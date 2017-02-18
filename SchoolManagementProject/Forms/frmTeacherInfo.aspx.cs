using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;

namespace SchoolManagementProject.Forms
{
    public partial class frmTeacherInfo : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        protected void btnTeacherUpdate_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Session["TeacherID"].ToString());

            var item = dbcontext.tblTeachers.Single(c => c.TeacherId == x); 


            item.tchDesignation = txtTeacherName.Text.Trim();
            item.tchName = txtTeacherDes.Text.Trim();
            item.tchEmail = txtTeacherEmail.Text.Trim();
            item.tchPhone = txtTeacherPhone.Text.Trim();
            item.tchProfileId = txtTeacherId.Text.Trim();
            item.SSC = Convert.ToDecimal(txtSSC.Text.Trim());
            item.HSC = Convert.ToDecimal(txtHSC.Text.Trim());
            item.Honors = Convert.ToDecimal(txtHonors.Text.Trim());
            item.Masters = Convert.ToDecimal(txtMasters.Text.Trim());
            item.Others = txtOtherDegree.Text.Trim();

            dbcontext.SaveChanges();
            LoadInfo();
        }

        private void LoadInfo()
        {
            int x = int.Parse(Session["TeacherID"].ToString());

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
    }
}