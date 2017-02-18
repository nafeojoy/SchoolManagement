using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SchoolManagementProject
{
    /// <summary>
    /// Summary description for ServiceClass
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class NameSearch : System.Web.Services.WebService
    {


        [WebMethod]
        public string[] GetName(string prefixText, int count)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblStudent where stdName like '%'+@Name+'%'", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<string> items = new List<string>(count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    items.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dt.Rows[i][2].ToString(), dt.Rows[i][0].ToString()));

                }
                catch
                {
                }
            }
            return items.ToArray();

        }

    }
}

