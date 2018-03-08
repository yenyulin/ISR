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
using Spring.Data.Core;
using Spring.Data.Common;
using System.Data.OleDb;
using Tgpf.Isr.BaseLibrary;

public partial class Manager_Default : System.Web.UI.Page
{
    //private AdoTemplate at; //主要是這一個

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
            BindMarquee();
        }
    }

    protected void LogoutBtn_Click(object sender, EventArgs e)
    {
        Response.Clear();
        FormsAuthentication.SignOut();
        Response.Redirect("../Default.aspx");
    }


    protected void BindData()
    {
        //at = SpringUtil.at();
        String sql = "SELECT *   from vw_aspnet_MembershipUsers where IsApproved=false     ";
         
        //DataSet ds = new DataSet();
        OleDbCommand cmd = new OleDbCommand(sql);
        DataSet ds = SQLUtil.QueryDS(cmd);
        //at.DataSetFill(ds, CommandType.Text, sql);

        CntView.Text = ds.Tables[0].Rows.Count.ToString();

    }

    protected void BindMarquee()
    {
        String msg = "";
        String sql = "SELECT * from News where IsOnLine<>'D'  and IsShow=true order by CreateDate desc ";
        //at = SpringUtil.at();
        //DataSet ds = new DataSet();
        //at.DataSetFill(ds, CommandType.Text, sql);
        OleDbCommand cmd = new OleDbCommand(sql);
        DataSet ds = SQLUtil.QueryDS(cmd);
        foreach (DataRow dRow in ds.Tables[0].Rows)
        {
            msg += "<a href=\"#\" class=\"qLink_font\"><strong>" + dRow["Title"].ToString() + "</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";


        }



        string text = "<MARQUEE scrolldelay=\"150\">" + msg + "</MARQUEE>";

        Literal1.Text = text;

    }
}
