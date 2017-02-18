using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class CS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("City");
        dt.Rows.Add();
        dt.Rows.Add();
        dt.Rows.Add();
        dt.Rows[0]["Name"] = "John Smith";
        dt.Rows[0]["City"] = "California";
        dt.Rows[1]["Name"] = "Andrew Clark";
        dt.Rows[1]["City"] = "Tokio";
        dt.Rows[2]["Name"] = "Mitchell Doe";
        dt.Rows[2]["City"] = "Dubai";
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/Sheets/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                StreamWriter writer = File.AppendText(path + "GridView.xls");
                GridView1.RenderControl(hw);
                writer.WriteLine(sw.ToString());
                writer.Close();
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    } 

}