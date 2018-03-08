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


public partial class Member_page6B1 : System.Web.UI.Page
{
    private ProfileCommon p;
    //private AdoTemplate at;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Panel1.Visible = false;
        }
    }

    private void BindData()
    {
        //at = SpringUtil.at();
        String sql = "SELECT  *   FROM ReuseTech   ";
        sql += " WHERE  Type='2'   ";
        if (!WasteItem.SelectedValue.Equals("Z"))
            sql += "and  WasteItem='" + WasteItem.SelectedValue + "'";
        if (!TechItem.SelectedValue.Equals("Z"))
            sql += "and  TechItem='" + TechItem.SelectedValue + "'";

        //DataSet ds = new DataSet();
        //at.DataSetFill(ds, CommandType.Text, sql);
        OleDbCommand cmd = new OleDbCommand(sql);
        DataSet ds = SQLUtil.QueryDS(cmd);

        ReuseGrid.DataSource = ds;
        ReuseGrid.DataKeyNames = new string[] { "Id" };
        ReuseGrid.DataBind();

        if (ds.Tables[0].Rows.Count > 0)
        {
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = true;
        }


    }

    protected void QryBtn_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void ReuseGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ReuseGrid.PageIndex = e.NewPageIndex;
        BindData();
    }
}
