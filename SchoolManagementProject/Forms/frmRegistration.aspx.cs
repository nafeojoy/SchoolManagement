using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;
using System.Globalization;
using SchoolManagementProject.Classes;


namespace SchoolManagementProject.Forms
{
    public partial class frmRegistration : System.Web.UI.Page
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();
        Load getdata = new Load();
        Load getdata1 = new Load();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"].ToString() == "Teacher" || Session["role"].ToString() == "teacher")
                {
                    teacherDiv.Visible = false;
                    studentDiv.Visible = false;
                    guardianDiv.Visible = false;

                    LoadStudent();
                    LoadClass();
                }
                else
                {
                    Response.Redirect("~/Forms/frmHome.aspx");
                }
            }

        }


        private void LoadClass()
        {

            drpStdClass.DataValueField = "ClassId";
            drpStdClass.DataTextField = "className";
            drpStdClass.DataSource = getdata.LoadClass();
            drpStdClass.DataBind();

            drpClassTeacher.DataValueField = "ClassId";
            drpClassTeacher.DataTextField = "className";
            drpClassTeacher.DataSource = getdata1.LoadClass();
            drpClassTeacher.DataBind();

        }

        private void LoadStudent()
        {
            //drpStudentId.DataValueField = "StudentId";
            //drpStudentId.DataTextField = "stdName";
            //drpStudentId.DataSource = getdata.LoadStudent();
            //drpStudentId.DataBind();

            //drpStudentId2.DataValueField = "StudentId";
            //drpStudentId2.DataTextField = "stdName";
            //drpStudentId2.DataSource = getdata.LoadStudent2();
            //drpStudentId2.DataBind();

            //drpStudentId3.DataValueField = "StudentId";
            //drpStudentId3.DataTextField = "stdName";
            //drpStudentId3.DataSource = getdata.LoadStudent2();
            //drpStudentId3.DataBind();

            //drpStudentId4.DataValueField = "StudentId";
            //drpStudentId4.DataTextField = "stdName";
            //drpStudentId4.DataSource = getdata.LoadStudent2();
            //drpStudentId4.DataBind();

            //drpStudentId5.DataValueField = "StudentId";
            //drpStudentId5.DataTextField = "stdName";
            //drpStudentId5.DataSource = getdata.LoadStudent2();
            //drpStudentId5.DataBind();
        }

        //private void LoadGuardian()
        //{
        //    drpStudentId.DataValueField = "GuardianId";
        //    drpStudentId.DataTextField = "guardName";
        //    drpStudentId.DataSource = getdata.LoadGuardian();
        //    drpStudentId.DataBind();

        //}

        


        protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpType.SelectedItem.Text == "Teacher")
            {
                studentDiv.Visible = false;
                teacherDiv.Visible = true;
                guardianDiv.Visible = false;
                divUser.Visible = true;
            }

            else if (drpType.SelectedItem.Text == "Student")
            {
                teacherDiv.Visible = false;
                studentDiv.Visible = true;
                guardianDiv.Visible = false;
                divUser.Visible = true;
            }
            else if (drpType.SelectedItem.Text == "Guardian")
            {
                teacherDiv.Visible = false;
                studentDiv.Visible = false;
                guardianDiv.Visible = true;
                divUser.Visible = false;
                grdApprovalGuardian.DataSource = dbcontext.view_GuardianIsChecked.Where(c => c.IsApproved != 1);
                grdApprovalGuardian.DataBind();
                
            }

        }

        protected void Button_Click_Guardian_Register(object sender, EventArgs e)
        {

            for (int i = 0; i < grdApprovalGuardian.Rows.Count; i++)
            {
                GridViewRow row = grdApprovalGuardian.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;
                

              //  tblUserLoginInfo item = new tblUserLoginInfo();
               


                if (isChecked)
                {
                    decimal userid = Convert.ToDecimal(((Label)row.FindControl("lblLoginId")).Text);
                    var item = dbcontext.tblUserLoginInfoes.Single(c=>c.LoginId==userid);
                    item.IsApproved = 1;
                    dbcontext.SaveChanges();
                }

                
            }


            grdApprovalGuardian.DataSource = dbcontext.view_GuardianIsChecked.Where(c => c.IsApproved != 1);
            grdApprovalGuardian.DataBind();

        }

        protected void Button_Click_Student_Register(object sender, EventArgs e)
        {
            try
            {
                IFormatProvider ff = new CultureInfo("fr-FR", true);


                tblStudent item = new tblStudent();


                item.stdName = txtStudentName.Text.Trim();
                item.stdAddress = txtAddress.Text.Trim();
                item.ClassId = int.Parse(drpStdClass.SelectedValue);

                item.stdEmail = txtStudentEmail.Text.Trim();
                item.stdFatherName = txtFatherName.Text.Trim();
                item.stdMotherName = txtMotherName.Text.Trim();

                item.stdId = txtStudentId.Text.ToString();
                item.stdBirthDate = DateTime.ParseExact(DateTextbox.Text, "dd.MM.yyyy", ff);

                dbcontext.tblStudents.AddObject(item);
                dbcontext.SaveChanges();


                tblUserLoginInfo item1 = new tblUserLoginInfo();

                item1.userName = txtUserNameStudent.Text.Trim();
                item1.userPassword = txtPasswordStudent.Text.Trim();
                //item1.userRole = drpType.Text.Trim();
                item1.userRole = "Student";
                item1.StudentId = item.StudentId;


                dbcontext.tblUserLoginInfoes.AddObject(item1);
                dbcontext.SaveChanges();

                string script = "alert('User Saved');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
            catch
            {
                string script = "alert('Duplicate items are Not Allowed');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }

        protected void Button_Click_Teacher_Register(object sender, EventArgs e)
        {
            try
            {
                tblTeacher item = new tblTeacher();

                item.ClassTeacherId = int.Parse(drpClassTeacher.SelectedValue);
                item.tchName = txtTeacherName.Text.ToString();
                item.tchProfileId = txtTeacherId.Text.ToString();
                item.tchDesignation = txtTeacherDesignation.Text.ToString();
                item.tchPhone = txtTeacherContactNo.Text.ToString();
                item.tchEmail = txtTeacherEmail.Text.ToString();
                item.SSC = Convert.ToDecimal(txtSSC.Text.Trim());
                item.HSC = Convert.ToDecimal(txtHSC.Text.Trim());
                item.Honors = Convert.ToDecimal(txtHonors.Text.Trim());
                item.Masters = Convert.ToDecimal(txtMasters.Text.Trim());
                item.Others = txtOtherDegree.Text.Trim();

                dbcontext.tblTeachers.AddObject(item);
                dbcontext.SaveChanges();

                tblUserLoginInfo item1 = new tblUserLoginInfo();

                item1.userName = txtUserNameStudent.Text.Trim();
                item1.userPassword = txtPasswordStudent.Text.Trim();
                item1.userRole = "Teacher";
                item1.TeacherId = (int)item.TeacherId;


                dbcontext.tblUserLoginInfoes.AddObject(item1);
                dbcontext.SaveChanges();

                clear();
                string script = "alert('User Saved');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
            catch
            {
                string script = "alert('Duplicate items are Not Allowed');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
            
        }

        private void clear()
        {
            txtTeacherName.Text = "";
            txtStudentName.Text = "";
            txtTeacherContactNo.Text = "";
            txtTeacherEmail.Text = "";
            //txtGuardianContactNo.Text = "";
            //txtGuardianEmail.Text = "";
            txtStudentEmail.Text = "";

        }
    }
}