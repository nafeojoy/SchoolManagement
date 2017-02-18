using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace SchoolManagementLibrary
{
    public class clsManager
    {
        public DataSet RetrunDataset(string query)
        {
            DataSet ds = new DataSet();
            string cons = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            {
                using (SqlConnection myConnection = new SqlConnection(cons))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, myConnection);
                    sda.SelectCommand.CommandTimeout = 0;
                    sda.Fill(ds, "Result");
                    return ds;
                }
            }
        }
        //Here we get the Connection String 
        public static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }

        public DataRow RetrunDataRow(string query)
        {
            DataSet ds = new DataSet();
            string cons = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            {
                using (SqlConnection myConnection = new SqlConnection(cons))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, myConnection);
                    sda.Fill(ds, "Result");
                    return ds.Tables[0].Rows[0];
                }
            }
        }

        public System.Data.Common.DbCommand GetStoredProcCommand(string p)
        {
            throw new NotImplementedException();
        }

        public DataSet ExecuteDataSet(System.Data.Common.DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        public DataSet viewEmpCV(string pfno)
        {
            DataSet ds = new DataSet();
            string cons = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            {
                using (SqlConnection myConnection = new SqlConnection(cons))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select *from View_EmpCV where ProfileNo='" + pfno + "'", myConnection);
                    sda.Fill(ds, "Result");
                    return ds;
                }
            }

        }

        public DataSet SubviewEmpCV()
        {
            DataSet ds = new DataSet();
            string cons = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            {
                using (SqlConnection myConnection = new SqlConnection(cons))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select *from AppointmentHistoryorExperience", myConnection);
                    sda.Fill(ds, "Result");
                    return ds;
                }
            }

        }

    }
}
