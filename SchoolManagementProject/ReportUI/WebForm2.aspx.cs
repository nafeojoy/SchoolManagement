﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




using Microsoft.Reporting.WebForms;
using System.Collections;
using SchoolManagementLibrary;


namespace SchoolManagementProject.ReportUI
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        SchoolManagementDBEntities dbCon = new SchoolManagementDBEntities();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrintLeave();
            }
        }


        private void PrintLeave()
        {

            try
            {
                clsManager manager = new clsManager();
                ReportViewer1.Visible = true;

                ReportDataSource rds = new ReportDataSource();
                ReportViewer1.Reset();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                LocalReport rep = ReportViewer1.LocalReport;


                rep.Refresh();

                rds.Name = "Student";
                rep.ReportPath = "Reports/rptStudentInfo.rdlc";


                rds.Value = manager.RetrunDataset("select *from tblStudent").Tables[0];




                ReportParameter[] p = { new ReportParameter("Company", "Square") };
                rep.SetParameters(p);

                //This name must be in "<datasetname>_<datatablename>" format. This name can also be seen in dataset's datasource view.
                rep.DataSources.Add(rds);


            }
            catch
            {
            }


        }
    }
}