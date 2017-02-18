using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementProject.Forms
{
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");

     

                if (Session["role"] != null)
                {
                    lblUser.Text = Session["name"].ToString();
                    sessionCondition();

                }
                else
                {
                    makeFalse();
                }
            }

        }

        protected void btnStudentRegister_Click(object sender, EventArgs e)
        {
            Session["role"] = null;
            Session["name"] = null;
            Session["TeacherId"] = null;
            Session["GuardianID"] = null;
            Session["StudentID"] = null;

            //  reglog.Visible = true;
            Response.Redirect("~/Forms/frmHome.aspx");
        }


        private void sessionCondition()
        {

            string role = Session["role"].ToString();

            if (role == "teacher" || role == "Teacher" || role == "admin" || role == "Admin")
            {
                makeTrue();
            }

            else if (role == "student" || role == "Student")
            {

                TagstudentInfoTag.Visible = true;
                TagresultEntryTag.Visible = false;
                TagGuardRegTag.Visible = false;
                TagResultView.Visible = false;
                tagCreateSubject.Visible = false;
                TagattendaceTag.Visible = false;
                TagattendanceHistoryTag.Visible = false;
                TagcreateClassTag.Visible = false;
                TagguardianInfoTag.Visible = false;
                TagregistrationTag.Visible = false;
                TagsubjectAssignTag.Visible = false;
                TagteacherInfoTag.Visible = false;
                TagAllTeacherInfo.Visible = false;

                lblUser.Visible = true;
                btnLogOut.Visible = true;
            }

            else if (role == "guardian" || role == "Guardian")
            {
                //HtmlContainerControl registrationTag = (HtmlContainerControl)this.Master.FindControl("registrationTag");

                TagstudentInfoTag.Visible = true;
                TagresultEntryTag.Visible = false;
                TagteacherInfoTag.Visible = false;
                TagguardianInfoTag.Visible = true;
                TagResultView.Visible = false;
                tagCreateSubject.Visible = false;
                TagattendaceTag.Visible = false;
                TagattendanceHistoryTag.Visible = false;
                TagcreateClassTag.Visible = false;
                TagregistrationTag.Visible = false;
                TagsubjectAssignTag.Visible = false;
                TagAllTeacherInfo.Visible = true;
                TagGuardRegTag.Visible = false;

                lblUser.Visible = true;
                btnLogOut.Visible = true;
            }
            else
            {
                makeFalse();
            }

        }

        private void makeTrue()
        {
            lblUser.Visible = true;
            if (Session["ClassTeacherID"] != null)
            {
                TagattendaceTag.Visible = true;
                TagattendanceHistoryTag.Visible = true;
            }
            else
            {
                TagattendaceTag.Visible = false;
                TagattendanceHistoryTag.Visible = false;
            }


            TagAllTeacherInfo.Visible = true;
           
            TagcreateClassTag.Visible = true;
            tagCreateSubject.Visible = true;
            TagregistrationTag.Visible = true;
            TagresultEntryTag.Visible = true;
            TagsubjectAssignTag.Visible = true;
            TagGuardRegTag.Visible = false;
            TagstudentInfoTag.Visible = false;
            TagguardianInfoTag.Visible = false;
            TagteacherInfoTag.Visible = true;

            btnLogOut.Visible = true;


        }

        private void makeFalse()
        {
            lblUser.Visible = false;

            TagAllResultStudnet.Visible = false;
            TagattendaceTag.Visible = false;
            TagattendanceHistoryTag.Visible = false;
            TagcreateClassTag.Visible = false;
            TagguardianInfoTag.Visible = false;
            TagregistrationTag.Visible = false;
            TagresultEntryTag.Visible = false;
            tagCreateSubject.Visible = false;
            TagstudentInfoTag.Visible = false;
            TagsubjectAssignTag.Visible = false;
            TagteacherInfoTag.Visible = false;
            TagAllTeacherInfo.Visible = false;
            TagResultView.Visible = false;
            btnLogOut.Visible = false;
            TagGuardRegTag.Visible = true;
        }

    }
}