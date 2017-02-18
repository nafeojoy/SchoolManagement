using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;


namespace SchoolManagementProject.Forms
{
    public partial class frmGuardianInfo : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        private void LoadInfo()
        {
            int x= int.Parse(Session["GuardianID"].ToString());
            var item = dbcontext.tblGuardians.Single(c => c.GuardianId == x); // 3 will be replaced by Session["id"]
            var item1 = dbcontext.tblStudents.Single(c => c.StudentId == item.StudentId);
            txtGuardianName.Text = item.guardName;
            txtGuardStdId.Text = item1.stdId;
            txtGuardianPhone.Text = item.guardPhone;
            txtGuardianEmail.Text = item.guardEmail;
        }



        protected void btnGuardianUpdate_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Session["GuardianID"].ToString());
            var item = dbcontext.tblGuardians.Single(c => c.GuardianId == x);

            item.guardName = txtGuardianName.Text.Trim();
            item.guardPhone = txtGuardianPhone.Text.Trim();
            item.guardEmail = txtGuardianEmail.Text.Trim();

            dbcontext.SaveChanges();
            LoadInfo();
        }
    }
}