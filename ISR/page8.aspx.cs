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
using System.Data;
using System.Data.OleDb;

public partial class page8 : System.Web.UI.Page
{
    //private IExamplesService mgr = (IExamplesService)BaseAction.Context.GetObject("ExamplesService");
     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        OleDbCommand cmd = new OleDbCommand("select * from Examples");
        DataSet ds1 = SQLUtil.QueryDS(cmd);
        //IList lists = mgr.getExamplesList();

        ExpGrid.DataSource = SQLUtil.QueryDS(cmd);
        ExpGrid.DataBind();

    }

    protected void Btn_Command(object sender, CommandEventArgs e)
    { 
        //IList lists = mgr.getExamplesListByYear(e.CommandArgument.ToString());
        OleDbCommand cmd = new OleDbCommand("select * from Examples where Year=? order by Year desc");
        cmd.Parameters.AddWithValue("?", e.CommandArgument.ToString());
        DataSet ds1 = SQLUtil.QueryDS(cmd);
        ExpGrid.DataSource = ds1;
        ExpGrid.DataBind();
    }
}
