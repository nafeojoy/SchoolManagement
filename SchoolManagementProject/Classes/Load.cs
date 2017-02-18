using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagementLibrary;

namespace SchoolManagementProject.Classes
{

    public class Load
    {
        SchoolManagementDBEntities dbcontext = new SchoolManagementDBEntities();


        public List<tblStudent> LoadStudent2()
        {
            List<tblStudent> cboList = null;
            tblStudent item = new tblStudent();
            item.StudentId = 0;
            item.stdName = "Select(Optional)";
            try
            {
                cboList = dbcontext.tblStudents.OrderBy(c => c.stdName).ToList();
            }
            catch
            {
            }
            cboList.Insert(0, item);
            return cboList;
        }


        public List<tblClass> LoadClass()
        {
            List<tblClass> drpList = new List<tblClass>();

            tblClass item = new tblClass();

            item.ClassId = 0;
            item.className = "Select";

            drpList = dbcontext.tblClasses.ToList();
            drpList.Insert(0, item);
            return drpList;
           

        }
        public List<tblTeacher> LoadTeacher()
        {
            List<tblTeacher> drpList = new List<tblTeacher>();

            tblTeacher item = new tblTeacher();

            item.TeacherId = 0;
            item.tchName = "Select";
            item.tchProfileId = "Select";

            drpList = dbcontext.tblTeachers.ToList();
            drpList.Insert(0, item);
            return drpList;


        }

        public List<tblSubject> LoadSubject()
        {
            List<tblSubject> drpList = new List<tblSubject>();

            tblSubject item = new tblSubject();

            item.SubjectId = 0;
            item.subjectCode = "Select";

            drpList = dbcontext.tblSubjects.ToList();
            drpList.Insert(0, item);
            return drpList;


        }



        public List<tblStudent> LoadStudent()
        {
            List<tblStudent> cboList = null;
            tblStudent item = new tblStudent();
            item.StudentId = 0;
            item.stdName = "Select";
            try
            {
                cboList = dbcontext.tblStudents.OrderBy(c => c.stdName).ToList();
            }
            catch
            {
            }
            cboList.Insert(0, item);
            return cboList;
        }

        public List<tblGuardian> LoadGuardian()
        {
            List<tblGuardian> cboList = null;
            tblGuardian item = new tblGuardian();
            item.GuardianId = 0;
            item.guardName = "Select";
            try
            {
                cboList = dbcontext.tblGuardians.OrderBy(c => c.guardName).ToList();
            }
            catch
            {
            }
            cboList.Insert(0, item);
            return cboList;
        }


        
    }
}