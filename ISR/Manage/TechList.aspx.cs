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
using System.Data.OleDb;
using Tgpf.Isr.Model;
using Tgpf.Isr.Service;
using Tgpf.Isr.BaseLibrary;
using Spring.Data.Core;
using Spring.Data.Common;

public partial class Manage_TechList : System.Web.UI.Page
{
    //private AdoTemplate at;
    private ProfileCommon p;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
        }
    }

    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }
    }

    public int PageNumber2
    {
        get
        {
            if (ViewState["PageNumber2"] != null)
                return Convert.ToInt32(ViewState["PageNumber2"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber2"] = value;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPages.ItemCommand +=
           new RepeaterCommandEventHandler(rptPages_ItemCommand);
        rptPages2.ItemCommand +=
           new RepeaterCommandEventHandler(rptPages2_ItemCommand);
    }

    void rptPages_ItemCommand(object source,
                           RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid1(type1.Value, keyword1.Value);
    }

    void rptPages2_ItemCommand(object source,
                       RepeaterCommandEventArgs e)
    {

        PageNumber2 = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid2(type2.Value, keyword2.Value);
    }

    /* 學研機構 */
    private void BindGrid1(string item, string keyword)
    {
        //at = SpringUtil.at();
        String sql = "SELECT r.Id,r.UserName,r.TechItem,r.TechName,r.TechOther,r.WasteItem,r.WasteName,r.WasteOther,r.ReuseName,'' as Corp,'' as Name,i.id as id2  ";
        sql += " from ReuseTech r LEFT OUTER JOIN TechInfo i ON r.id=i.Rid where r.type='1' ";

        if (item.Equals("1"))
            sql += " and r.WasteItem = @param1";
        else if (item.Equals("2"))
            sql += " and r.WasteName like @param1";
        else if (item.Equals("3"))
            sql += " and r.TechItem = @param1";
        else if (item.Equals("4"))
            sql += " and r.TechName like @param1";
        else if (item.Equals("5"))
            sql += " and r.ReuseName like @param1";

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.VarChar).Value = keyword;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        //IDbParameters parameters = at.CreateDbParameters();
        //parameters.Add("param1", OleDbType.VarChar).Value = keyword;
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);
        int cnt1 = ds.Tables[0].Rows.Count;
        foreach (DataRow dRow in ds.Tables[0].Rows)
        {
            p = Profile.GetProfile(dRow["UserName"].ToString());
            dRow["Corp"] = p.UserProfile.Corp;
            dRow["Name"] = p.UserProfile.Name;
        }

        PagedDataSource pgitems = new PagedDataSource();
        pgitems.DataSource = ds.Tables[0].DefaultView;
        pgitems.AllowPaging = true;
        pgitems.PageSize = 10;
        pgitems.CurrentPageIndex = PageNumber;
        if (pgitems.PageCount > 1)
        {
            rptPages.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i < pgitems.PageCount; i++)
                pages.Add((i + 1).ToString());
            rptPages.DataSource = pages;
            rptPages.DataBind();
        }
        else
            rptPages.Visible = false;

        TechGrid1.DataSource = pgitems;
        TechGrid1.DataBind();
        if (TechGrid1.Items.Count > 0)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = true;
        }
        else
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }

        pageNow.Text = (PageNumber + 1).ToString();
        pageTotal.Text = pgitems.PageCount.ToString();
        cntTotal.Text = cnt1.ToString();
    }

    /* 業者廠商 */
    private void BindGrid2(string item, string keyword)
    {
        //at = SpringUtil.at();
        String sql = "SELECT Id,UserName,TechItem,TechName,TechOther,WasteItem,WasteName,WasteOther,ReuseName,'' as Corp,'' as Name  ";
        sql += " from ReuseTech where type='2' ";

        if (item.Equals("1"))
            sql += " and WasteItem = @param1";
        else if (item.Equals("2"))
            sql += " and WasteName like @param1";
        else if (item.Equals("3"))
            sql += " and TechItem = @param1";
        else if (item.Equals("4"))
            sql += " and TechName like @param1";
        else if (item.Equals("5"))
            sql += " and ReuseName like @param1";

        //IDbParameters parameters = at.CreateDbParameters();
        //parameters.Add("param1", OleDbType.VarChar).Value = keyword;
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.VarChar).Value = keyword;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        int cnt2 = ds.Tables[0].Rows.Count;
        foreach (DataRow dRow in ds.Tables[0].Rows)
        {
            p = Profile.GetProfile(dRow["UserName"].ToString());
            dRow["Corp"] = p.UserProfile.Corp;
            dRow["Name"] = p.UserProfile.Name;
        }

        PagedDataSource pgitems2 = new PagedDataSource();
        pgitems2.DataSource = ds.Tables[0].DefaultView;
        pgitems2.AllowPaging = true;
        pgitems2.PageSize = 10;
        pgitems2.CurrentPageIndex = PageNumber2;
        if (pgitems2.PageCount > 1)
        {
            rptPages2.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i < pgitems2.PageCount; i++)
                pages.Add((i + 1).ToString());
            rptPages2.DataSource = pages;
            rptPages2.DataBind();
        }
        else
            rptPages2.Visible = false;

        TechGrid2.DataSource = pgitems2;
        TechGrid2.DataBind();
        if (TechGrid2.Items.Count > 0)
        {
            Panel4.Visible = false;
            Panel5.Visible = true;
            Panel6.Visible = true;
        }
        else
        {
            Panel4.Visible = true;
            Panel5.Visible = false;
            Panel6.Visible = false;
        }

        pageNow2.Text = (PageNumber2 + 1).ToString();
        pageTotal2.Text = pgitems2.PageCount.ToString();
        cntTotal2.Text = cnt2.ToString();
    }

    protected void WasteItem1_SelectedIndexChanged(object sender, EventArgs e)
    {
        type1.Value = "1";
        keyword1.Value = WasteItem1.SelectedValue;
        BindGrid1("1", WasteItem1.SelectedValue);
    }

    protected void TechItem1_SelectedIndexChanged(object sender, EventArgs e)
    {
        type1.Value = "3";
        keyword1.Value = TechItem1.SelectedValue;
        BindGrid1("3", TechItem1.SelectedValue);
    }
    protected void QryBtn1A_Click(object sender, EventArgs e)
    {
        type1.Value = "2";
        keyword1.Value = '%' + WasteName1.Text + '%';
        BindGrid1("2", '%' + WasteName1.Text + '%');
    }

    protected void QryBtn2A_Click(object sender, EventArgs e)
    {
        type1.Value = "4";
        keyword1.Value = '%' + TechName1.Text + '%';
        BindGrid1("4", '%' + TechName1.Text + '%');
    }
    protected void QryBtn3A_Click(object sender, EventArgs e)
    {
        type1.Value = "5";
        keyword1.Value = '%' + ReuseName1.Text + '%';
        BindGrid1("5", '%' + ReuseName1.Text + '%');
    }

    protected void WasteItem2_SelectedIndexChanged(object sender, EventArgs e)
    {
        type2.Value = "1";
        keyword2.Value = WasteItem2.SelectedValue;
        BindGrid2("1", WasteItem2.SelectedValue);
    }

    protected void TechItem2_SelectedIndexChanged(object sender, EventArgs e)
    {
        type2.Value = "3";
        keyword2.Value = TechItem2.SelectedValue;
        BindGrid2("3", TechItem2.SelectedValue);
    }
    protected void QryBtn1B_Click(object sender, EventArgs e)
    {
        type2.Value = "2";
        keyword2.Value = '%' + WasteName2.Text + '%';
        BindGrid2("2", '%' + WasteName2.Text + '%');
    }

    protected void QryBtn2B_Click(object sender, EventArgs e)
    {
        type2.Value = "4";
        keyword2.Value = '%' + TechName2.Text + '%';
        BindGrid2("4", '%' + TechName2.Text + '%');
    }
    protected void QryBtn3B_Click(object sender, EventArgs e)
    {
        type2.Value = "5";
        keyword2.Value = '%' + ReuseName2.Text + '%';
        BindGrid2("5", '%' + ReuseName2.Text + '%');
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
