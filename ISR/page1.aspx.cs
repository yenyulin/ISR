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

public partial class News : System.Web.UI.Page
{
   // private INewsService mgr = (INewsService)BaseAction.Context.GetObject("NewsService");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                setDetail(Request.QueryString["id"]);
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
            }
                BindGrid();
            
        }
    }

    private void BindGrid()
    {
        //IList lists = mgr.getNewsList();
        OleDbCommand cmd = new OleDbCommand("SELECT * from News where IsOnLine<>'D'  and IsShow=true order by CreateDate desc ");
        NewsGrid.DataSource = SQLUtil.QueryDS(cmd);
        NewsGrid.DataKeyNames = new string[] { "Id" };
        NewsGrid.DataBind();
    }

    protected void setDetail(string id)
    {
        int Pid = int.Parse(id);

        //IList lists = mgr.getNewsListById(Pid);
        OleDbCommand cmd = new OleDbCommand("SELECT * from News where Id=? ");
        cmd.Parameters.AddWithValue("?", Pid);
        NewsList.DataSource = SQLUtil.QueryDS(cmd);
        //NewsList.DataSource = lists;
        NewsList.DataBind();
        MultiView1.ActiveViewIndex = 1;
    }

    /*protected void Name_Command(object sender, CommandEventArgs e)
    {
        int Pid = int.Parse(e.CommandArgument.ToString());

        IList lists = mgr.getNewsListById(Pid);
        NewsList.DataSource = lists;
        NewsList.DataBind();
        MultiView1.ActiveViewIndex = 1;
    }*/


    protected void ExitBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void NewsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        NewsGrid.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}
