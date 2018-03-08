using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Controls_left2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet tmpDs = new DataSet();
            tmpDs.ReadXml(Server.MapPath("~/App_Data/Counter.xml"));

            lblCounter.Text = tmpDs.Tables[0].Rows[0]["hits"].ToString();
        }
    }
}
