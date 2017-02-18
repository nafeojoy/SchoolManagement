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
    public partial class frmGuardianRegistration : System.Web.UI.Page
    {

        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();
        Load getdata = new Load();
        Load getdata1 = new Load();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudent();
            }
        }

        private void LoadStudent()
        {
            drpStudentId.DataValueField = "StudentId";
            drpStudentId.DataTextField = "stdName";
            drpStudentId.DataSource = getdata.LoadStudent();
            drpStudentId.DataBind();

            drpStudentId2.DataValueField = "StudentId";
            drpStudentId2.DataTextField = "stdName";
            drpStudentId2.DataSource = getdata.LoadStudent2();
            drpStudentId2.DataBind();

            drpStudentId3.DataValueField = "StudentId";
            drpStudentId3.DataTextField = "stdName";
            drpStudentId3.DataSource = getdata.LoadStudent2();
            drpStudentId3.DataBind();

            drpStudentId4.DataValueField = "StudentId";
            drpStudentId4.DataTextField = "stdName";
            drpStudentId4.DataSource = getdata.LoadStudent2();
            drpStudentId4.DataBind();

            drpStudentId5.DataValueField = "StudentId";
            drpStudentId5.DataTextField = "stdName";
            drpStudentId5.DataSource = getdata.LoadStudent2();
            drpStudentId5.DataBind();
        }

        protected void Button_Click_Guardian_Register(object sender, EventArgs e)
        {
            try
            {
                tblGuardian item = new tblGuardian();

                item.StudentId = int.Parse(drpStudentId.SelectedValue);

                item.StudentId2 = int.Parse(drpStudentId2.SelectedValue);
                item.StudentId3 = int.Parse(drpStudentId3.SelectedValue);
                item.StudentId4 = int.Parse(drpStudentId4.SelectedValue);
                item.StudentId5 = int.Parse(drpStudentId5.SelectedValue);

                item.guardName = txtGuardianName.Text.ToString();
                //  item.guardAddress = txtGuardianAddress.Text.ToString();
                item.guardPhone = txtGuardianContactNo.Text.Trim();
                item.guardEmail = txtGuardianEmail.Text.ToString();
                dbcontext.tblGuardians.AddObject(item);

                tblUserLoginInfo item1 = new tblUserLoginInfo();

                item1.userName = txtUserNameStudent.Text.Trim();
                item1.userPassword = txtPasswordStudent.Text.Trim();
                item1.userRole = "Guardian";
                item1.GuardianId = (int)item.GuardianId;

                dbcontext.tblUserLoginInfoes.AddObject(item1);

                dbcontext.SaveChanges();

                for (int i = 2; i <= 5; i++)
                {
                    var container = Master.FindControl("ContentPlaceHolder1");
                    string rayhan = "drpStudentId" + i;
                    DropDownList lbl = (DropDownList)container.FindControl(rayhan);



                }
                string script = "alert('User Saved');";
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