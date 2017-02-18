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
    public partial class frmStudentInfo : System.Web.UI.Page
    {
        static int x;
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();
        Utilities util = new Utilities();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GuardianID"] != null)
                {
                    divEdit.Visible = false;
                    btnStudentUpdate.Visible = false;
                    LoadInfo();
                }
                else
                {
                    divButtons.Visible = false;
                    LoadInfo();
                }
            }
        }

        private void LoadInfo()
        {
            int std = int.Parse(Session["StudentID"].ToString());
            var item = dbcontext.tblStudents.Single(c => c.StudentId == std);


            txtStdName.Text = item.stdName;
            txtStdId.Text = item.stdId;
            txtStdAdd.Text = item.stdAddress;
            //lblDateTextbox.Text = item.stdBirthDate.ToString(); 
            DateTextbox.Text = util.DateToString2(DateTime.Parse(item.stdBirthDate.ToString()));
            txtStdEmail.Text = item.stdEmail;
            txtStdFatherName.Text = item.stdFatherName;
            txtMotherName.Text = item.stdMotherName;


        }

        

        protected void btnStudentUpdate_Click(object sender, EventArgs e)
        {
            IFormatProvider ff = new CultureInfo("fr-FR", true);
         
            if (Session["StudentID"] != null)
            {
                x = int.Parse(Session["StudentID"].ToString());
            }

            else if (Session["StudentID2"] != null)
            {
                x = int.Parse(Session["StudentID2"].ToString());
            }

            else if (Session["StudentID3"] != null)
            {
                x = int.Parse(Session["StudentID3"].ToString());
            }

            else if (Session["StudentID4"] != null)
            {
                x = int.Parse(Session["StudentID4"].ToString());
            }

            else if (Session["StudentID5"] != null)
            {
                x = int.Parse(Session["StudentID5"].ToString());
            }
            var item = dbcontext.tblStudents.Single(c => c.StudentId == x); 

            item.stdName = txtStdName.Text.Trim();
            item.stdId = txtStdId.Text.Trim();
            item.stdAddress = txtStdAdd.Text.Trim();

            item.stdBirthDate = DateTime.ParseExact(DateTextbox.Text, "dd.MM.yyyy", ff);

            item.stdEmail = txtStdEmail.Text.Trim();
            item.stdFatherName = txtStdFatherName.Text.Trim();
            item.stdMotherName = txtMotherName.Text.Trim();
          

            dbcontext.SaveChanges();
            LoadInfo();
        }

        protected void btnstudentId_Click(object sender, EventArgs e)
        {
            LoadInfo();
        }

        protected void btnstudentId2_Click(object sender, EventArgs e)
        {
            try
            {
                int std = int.Parse(Session["StudentID2"].ToString());
                var item = dbcontext.tblStudents.Single(c => c.StudentId == std);


                txtStdName.Text = item.stdName;
                txtStdId.Text = item.stdId;
                txtStdAdd.Text = item.stdAddress;
                //lblDateTextbox.Text = item.stdBirthDate.ToString(); 
                DateTextbox.Text = util.DateToString2(DateTime.Parse(item.stdBirthDate.ToString()));
                txtStdEmail.Text = item.stdEmail;
                txtStdFatherName.Text = item.stdFatherName;
                txtMotherName.Text = item.stdMotherName;
            }
            catch
            {
                string script = "alert('No Student!!!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        protected void btnstudentId3_Click(object sender, EventArgs e)
        {
            try
            {
                int std = int.Parse(Session["StudentID3"].ToString());
                var item = dbcontext.tblStudents.Single(c => c.StudentId == std);


                txtStdName.Text = item.stdName;
                txtStdId.Text = item.stdId;
                txtStdAdd.Text = item.stdAddress;
                //lblDateTextbox.Text = item.stdBirthDate.ToString(); 
                DateTextbox.Text = util.DateToString2(DateTime.Parse(item.stdBirthDate.ToString()));
                txtStdEmail.Text = item.stdEmail;
                txtStdFatherName.Text = item.stdFatherName;
                txtMotherName.Text = item.stdMotherName;
            }
            catch
            {
                string script = "alert('No Student!!!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        protected void btnstudentId4_Click(object sender, EventArgs e)
        {
            try
            {
                int std = int.Parse(Session["StudentID4"].ToString());
                var item = dbcontext.tblStudents.Single(c => c.StudentId == std);


                txtStdName.Text = item.stdName;
                txtStdId.Text = item.stdId;
                txtStdAdd.Text = item.stdAddress;
                //lblDateTextbox.Text = item.stdBirthDate.ToString(); 
                DateTextbox.Text = util.DateToString2(DateTime.Parse(item.stdBirthDate.ToString()));
                txtStdEmail.Text = item.stdEmail;
                txtStdFatherName.Text = item.stdFatherName;
                txtMotherName.Text = item.stdMotherName;
            }
            catch
            {
                string script = "alert('No Student!!!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        protected void btnstudentId5_Click(object sender, EventArgs e)
        {
            try
            {
                int std = int.Parse(Session["StudentID5"].ToString());
                var item = dbcontext.tblStudents.Single(c => c.StudentId == std);


                txtStdName.Text = item.stdName;
                txtStdId.Text = item.stdId;
                txtStdAdd.Text = item.stdAddress;
                //lblDateTextbox.Text = item.stdBirthDate.ToString(); 
                DateTextbox.Text = util.DateToString2(DateTime.Parse(item.stdBirthDate.ToString()));
                txtStdEmail.Text = item.stdEmail;
                txtStdFatherName.Text = item.stdFatherName;
                txtMotherName.Text = item.stdMotherName;
            }
            catch
            {
                string script = "alert('No Student!!!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }
    }
}