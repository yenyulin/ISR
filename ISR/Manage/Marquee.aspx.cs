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
using Tgpf.Isr.Model;
using Tgpf.Isr.Service;
using Tgpf.Isr.BaseLibrary;
using Spring.Data.Core;
using Spring.Data.Common;
using System.Data.OleDb;

public partial class Manage_Marquee : System.Web.UI.Page
{
    //private IMarqueeService mgr = (IMarqueeService)BaseAction.Context.GetObject("MarqueeService");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        //Marquee obj = mgr.getMarquee("A");
        //Msg.Text = obj.Msg;


        String sql = "SELECT * from Marquee where Id=param1  ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("param1", OleDbType.VarChar).Value = "A";
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            Msg.Text = dr["Msg"].ToString();
        }


    }
    protected void SaveBtn_Click(object sender, EventArgs e)
    {
        //Marquee obj = mgr.getMarquee("A");
        //obj.Msg = Msg.Text; 
        //mgr.Save(obj);

        String sqlM = "";
        sqlM = sqlM + " update Marquee";
        sqlM = sqlM + " set [Msg]=@Msg ";
        sqlM = sqlM + " where id=@id";
        OleDbCommand cmdM = new OleDbCommand(sqlM);
        cmdM.Parameters.Add("@Msg", OleDbType.VarChar).Value = Msg.Text;
        cmdM.Parameters.Add("@id", OleDbType.VarChar).Value = "A";
        SQLUtil.ExecuteSql(cmdM);

    }
}
