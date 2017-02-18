using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementLibrary;

namespace SchoolManagementProject.Forms
{
    public partial class frmHome : System.Web.UI.Page
    {
        
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                LoginDiv.Visible = true;
            }
            else 
            {
                LoginDiv.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = txtUserNameStudent.Text.Trim();
            string userPass = txtPasswordStudent.Text.Trim();

            try
            {
                var item = dbcontext.tblUserLoginInfoes.Single(c => c.userName == userName);
                if (item != null)
                {
                    Session["role"] = item.userRole;
                    Session["name"] = item.userName;

                    
                    if (item.userPassword == userPass)
                    {
                        if (item.userRole.ToString() == "Guardian" || item.userRole.ToString() == "guardian")
                        {
                            if (item.IsApproved == 1)
                            {
                                Session["GuardianID"] = item.GuardianId;
                                int x = int.Parse(item.GuardianId.ToString());

                                var item1 = dbcontext.tblGuardians.Single(c => c.GuardianId == x);

                                Session["StudentID"] = item1.StudentId;
                                if (item1.StudentId2 != null)
                                {
                                    Session["StudentID2"] = item1.StudentId2;
                                }
                                if (item1.StudentId3 != null)
                                {
                                    Session["StudentID3"] = item1.StudentId3;
                                }
                                if (item1.StudentId4 != null)
                                {
                                    Session["StudentID4"] = item1.StudentId4;
                                }
                                if (item1.StudentId5 != null)
                                {
                                    Session["StudentID5"] = item1.StudentId5;
                                }

                                int y = item1.StudentId;

                                var item2 = dbcontext.tblStudents.Single(c => c.StudentId == y);

                                Session["StudentName"] = item2.stdName;
                            }
                            else
                            {
                                Session["role"] = null;
                                Session["name"] = null;
                                string script = "alert('Guardian Is Not Approved Yet !!! Please wait or contact with the Administration ... :)');";
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                            }
                            Response.Redirect("~/Forms/frmHome.aspx?a=1");

                        }

                        else if (item.userRole.ToString() == "Student" || item.userRole.ToString() == "student")
                        {
                            int y = (int)item.StudentId;

                            var item2 = dbcontext.tblStudents.Single(c => c.StudentId == y);

                            Session["StudentID"] = item.StudentId;
                            
                            Session["StudentName"] = item2.stdName;
                            Response.Redirect("~/Forms/frmHome.aspx?a=1");
                        }

                        else if (item.userRole.ToString() == "Teacher" || item.userRole.ToString() == "teacher")
                        {
                            Session["TeacherID"] = item.TeacherId;

                            int x = int.Parse(Session["TeacherID"].ToString());
                            var item1 = dbcontext.tblTeachers.Single(c => c.TeacherId == x);
                            int p = int.Parse(item1.ClassTeacherId.ToString());

                            if (p != 0)
                            {
                                Session["ClassTeacherID"] = item1.ClassTeacherId;
                                int z = (int)item1.ClassTeacherId;
                                 var item3 = dbcontext.tblClasses.Single(c => c.ClassId == z);

                                 Session["ClassNameTch"] = item3.className; 
                            }
                            Response.Redirect("~/Forms/frmHome.aspx?a=1");
                        }
                        
                        
                    }
        
                 }
            }
            catch
            {
                lblUserMessagae.InnerText = "Wrong User Name/Password";
            }
       
        }
    }
}