using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
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



public partial class Manage_Case : System.Web.UI.Page
{
    //private ICaseService mgr = (ICaseService)BaseAction.Context.GetObject("CaseService");


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
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

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPages.ItemCommand +=
           new RepeaterCommandEventHandler(rptPages_ItemCommand);
    }

    void rptPages_ItemCommand(object source,
                            RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid();
    }


    private void BindGrid()
    {
        String sql = "  SELECT  Id,casedesc,createdate,helpdesc,isdeleted,name ,techitem ,techname ,techother ,type ,wasteitem ,wastename ,wasteother ,datasource FROM ReuseCase  where Isdeleted=false ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);
        IList lists =GetList(ds);

       
        //IList lists = mgr.getCaseList();

        PagedDataSource pgitems = new PagedDataSource();
        pgitems.DataSource = lists;
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


        if (lists != null)
        {
            CaseGrid.DataSource = pgitems;
            CaseGrid.DataBind();
        }
        else
        {
            CaseGrid.DataSource = null;
            CaseGrid.DataBind();
        }

        if (CaseGrid.Items.Count > 0)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
        }
        else
        {
            Panel1.Visible = true;
            Panel2.Visible = true;
        }

        pageNow.Text = (PageNumber + 1).ToString();
        pageTotal.Text = pgitems.PageCount.ToString();
        if (lists != null)
            cntTotal.Text = lists.Count.ToString();
        else
            cntTotal.Text = "0";
    }


    protected void DropBtn_Click(object sender, EventArgs e)
    {
        ArrayList caseList = new ArrayList();
        int i;
        foreach (RepeaterItem repeaterItem in CaseGrid.Items)
        {
            //if (((CheckBox)CaseGrid.Rows[i].FindControl("DropCheckBox")).Checked)
            if (((CheckBox)repeaterItem.FindControl("DropCheckBox")).Checked)
            {
                Case obj = getCase(int.Parse(((CheckBox)repeaterItem.FindControl("DropCheckBox")).ToolTip));
                //Case obj = mgr.getCase(int.Parse(((CheckBox)repeaterItem.FindControl("DropCheckBox")).ToolTip));
                obj.Isdeleted = true;

                caseList.Add(obj);

                String sqlDel = "Delete from ReuseCase where Id=@Id";
                OleDbCommand cmdDel = new OleDbCommand(sqlDel);
                cmdDel.Parameters.Add("@Id", OleDbType.Integer).Value = int.Parse(((CheckBox)repeaterItem.FindControl("DropCheckBox")).ToolTip);
                SQLUtil.ExecuteSql(cmdDel);

            }
        }

        //mgr.Delete(caseList);
        BindGrid();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void NewBtn_Click(object sender, EventArgs e)
    {
        Name1.Text = "";
        TechItem1.SelectedValue = "A";
        TechName1.Text = "";
        WasteItem1.SelectedValue = "A";
        WasteName1.Text = "";
        Type1.SelectedValue = "A";
        CaseDesc1.Text = "";
        HelpDesc1.Text = "";
        HelpDesc1.Visible = true;
        Datasource1.Text = "";
        WasteOther2.Text = "";
        TechOther2.Text = "";
        MultiView1.ActiveViewIndex = 1;
    }

    protected void AppendBtn_Click(object sender, EventArgs e)
    {
        Case obj = new Case();
        obj.Name = Name1.Text;
        obj.Techitem = TechItem1.SelectedValue;
        obj.Techname = TechName1.Text;
        if (!TechItem1.SelectedValue.Equals("V"))
            obj.Techother = TechItem1.SelectedItem.Text;
        else
            obj.Techother = TechOther1.Text;
        obj.Wasteitem = WasteItem1.SelectedValue;
        obj.Wastename = WasteName1.Text;
        if (!WasteItem1.SelectedValue.Equals("U"))
            obj.Wasteother = WasteItem1.SelectedItem.Text;
        else
            obj.Wasteother = WasteOther1.Text;
        obj.Type = Type1.SelectedValue;
        obj.Casedesc = CaseDesc1.Text;
        obj.Helpdesc = HelpDesc1.Text;
        obj.Createdate = DateTime.Now;
        obj.Isdeleted = false;
        obj.Datasource = Datasource1.Text;
        
        String sqlRT = "";
        sqlRT = sqlRT + " insert into ReuseCase (casedesc,createdate,helpdesc,isdeleted,name ,techitem ,techname ,techother ,type ,wasteitem ,wastename ,wasteother ,datasource) ";
        sqlRT = sqlRT + " values (@casedesc,@createdate,@helpdesc,@isdeleted,@name ,@techitem ,@techname ,@techother ,@type ,@wasteitem ,@wastename ,@wasteother ,@datasource)";
        OleDbCommand cmdRT = new OleDbCommand(sqlRT);
        cmdRT.Parameters.Add("@casedesc", OleDbType.VarChar).Value = obj.Casedesc;
        cmdRT.Parameters.Add("@createdate", OleDbType.Date).Value = obj.Createdate;
        cmdRT.Parameters.Add("@helpdesc", OleDbType.VarChar).Value = obj.Helpdesc;
        cmdRT.Parameters.Add("@isdeleted", OleDbType.Boolean).Value = obj.Isdeleted;
        cmdRT.Parameters.Add("@name", OleDbType.VarChar).Value = obj.Name;
        cmdRT.Parameters.Add("@techitem", OleDbType.VarChar).Value = obj.Techitem;          
        cmdRT.Parameters.Add("@techname", OleDbType.VarChar).Value = obj.Techname;
        cmdRT.Parameters.Add("@techother", OleDbType.VarChar).Value = obj.Techother;
        cmdRT.Parameters.Add("@type", OleDbType.VarChar).Value = obj.Type;

        cmdRT.Parameters.Add("@wasteitem", OleDbType.VarChar).Value = obj.Wasteitem;
        cmdRT.Parameters.Add("@wastename", OleDbType.VarChar).Value = obj.Wastename;
        cmdRT.Parameters.Add("@wasteother", OleDbType.VarChar).Value = obj.Wasteother;
        cmdRT.Parameters.Add("@datasource", OleDbType.VarChar).Value = obj.Datasource;
        SQLUtil.ExecuteSql(cmdRT);

         
        //mgr.Save(obj);
        BindGrid();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void ModifyBtn_Click(object sender, EventArgs e)
    {
        Case obj = getCase(int.Parse(Id.Value));
        //Case obj = mgr.getCase(int.Parse(Id.Value));
        obj.Name = Name2.Text;
        obj.Techitem = TechItem2.SelectedValue;
        obj.Techname = TechName2.Text;
        if (!TechItem2.SelectedValue.Equals("V"))
            obj.Techother = TechItem2.SelectedItem.Text;
        else
            obj.Techother = TechOther2.Text;
        obj.Wasteitem = WasteItem2.SelectedValue;
        obj.Wastename = WasteName2.Text;
        if (!WasteItem2.SelectedValue.Equals("U"))
            obj.Wasteother = WasteItem2.SelectedItem.Text;
        else
            obj.Wasteother = WasteOther2.Text;
        obj.Type = Type2.SelectedValue;
        obj.Casedesc = CaseDesc2.Text;
        obj.Helpdesc = HelpDesc2.Text;
        obj.Createdate = DateTime.Now;
        obj.Datasource = Datasource2.Text;



        String sqlRT = "";

        sqlRT = sqlRT + " update ReuseCase ";
        sqlRT = sqlRT + " set casedesc=@casedesc, ";
        sqlRT = sqlRT + " createdate=@createdate, ";
        sqlRT = sqlRT + " helpdesc=@helpdesc, ";
        
        sqlRT = sqlRT + " isdeleted=@isdeleted, ";
        sqlRT = sqlRT + " name=@name , ";
        sqlRT = sqlRT + " techitem=@techitem , ";
        sqlRT = sqlRT + " techname=@techname , ";
        sqlRT = sqlRT + " techother=@techother , ";
        sqlRT = sqlRT + " type=@type , ";
        sqlRT = sqlRT + " wasteitem=@wasteitem , ";
        sqlRT = sqlRT + " wastename=@wastename , ";
        sqlRT = sqlRT + " wasteother=@wasteother , ";
        sqlRT = sqlRT + " datasource=@datasource ";
        sqlRT = sqlRT + " where Id=@Id ";
    
        OleDbCommand cmdRT = new OleDbCommand(sqlRT);
        cmdRT.Parameters.Add("@casedesc", OleDbType.VarChar).Value = obj.Casedesc;
        cmdRT.Parameters.Add("@createdate", OleDbType.Date).Value = obj.Createdate;
        cmdRT.Parameters.Add("@helpdesc", OleDbType.VarChar).Value = obj.Helpdesc;
        cmdRT.Parameters.Add("@isdeleted", OleDbType.Boolean).Value = obj.Isdeleted;
        cmdRT.Parameters.Add("@name", OleDbType.VarChar).Value = obj.Name;
        cmdRT.Parameters.Add("@techitem", OleDbType.VarChar).Value = obj.Techitem;
        cmdRT.Parameters.Add("@techname", OleDbType.VarChar).Value = obj.Techname;
        cmdRT.Parameters.Add("@techother", OleDbType.VarChar).Value = obj.Techother;
        cmdRT.Parameters.Add("@type", OleDbType.VarChar).Value = obj.Type;
        cmdRT.Parameters.Add("@wasteitem", OleDbType.VarChar).Value = obj.Wasteitem;
        cmdRT.Parameters.Add("@wastename", OleDbType.VarChar).Value = obj.Wastename;
        cmdRT.Parameters.Add("@wasteother", OleDbType.VarChar).Value = obj.Wasteother;
        cmdRT.Parameters.Add("@datasource", OleDbType.VarChar).Value = obj.Datasource;
        cmdRT.Parameters.Add("@Id", OleDbType.VarChar).Value = obj.Id;
        SQLUtil.ExecuteSql(cmdRT);

        //mgr.Save(obj);
        BindGrid();
        MultiView1.ActiveViewIndex = 0;


    }

    protected void Name_Command(object sender, CommandEventArgs e)
    {

        int Pid = int.Parse(e.CommandArgument.ToString());
        Case obj = getCase(Pid);
        //Case obj = mgr.getCase(Pid);
        Id.Value = obj.Id.ToString();
        Name2.Text = obj.Name;
        TechItem2.SelectedValue = obj.Techitem;
        TechName2.Text = obj.Techname;
        WasteItem2.SelectedValue = obj.Wasteitem;
        WasteName2.Text = obj.Wastename;
        Type2.SelectedValue = obj.Type;
        CaseDesc2.Text = obj.Casedesc;
        HelpDesc2.Text = obj.Helpdesc;
        Datasource2.Text = obj.Datasource;
        if (obj.Type.Equals("B"))
            HelpDesc2.Visible = false;
        else
            HelpDesc2.Visible = true;

        if (!TechItem2.SelectedValue.Equals("V"))
        {
            ((TextBox)MultiView1.FindControl("Techother2")).Text = "";
            ((TextBox)MultiView1.FindControl("Techother2")).Visible = false;
        }
        else
        {
            ((TextBox)MultiView1.FindControl("Techother2")).Text = obj.Techother;
            ((TextBox)MultiView1.FindControl("Techother2")).Visible = true;
        }

        if (!WasteItem2.SelectedValue.Equals("U"))
        {
            ((TextBox)MultiView1.FindControl("Wasteother2")).Text = "";
            ((TextBox)MultiView1.FindControl("Wasteother2")).Visible = false;
        }
        else
        {
            ((TextBox)MultiView1.FindControl("Wasteother2")).Text = obj.Wasteother;
            ((TextBox)MultiView1.FindControl("Wasteother2")).Visible = true;
        }

        MultiView1.ActiveViewIndex = 2;
    }

    protected void ExitBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Type1.SelectedValue.Equals("B"))
        {
            HelpDesc1.Visible = false;
        }
        else
        {
            HelpDesc1.Visible = true;
        }
    }



    protected void Type2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Type2.SelectedValue.Equals("B"))
        {
            HelpDesc2.Visible = false;
        }
        else
        {
            HelpDesc2.Visible = true;
        }
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void TechItem1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)MultiView1.FindControl("TechItem1")).SelectedValue.Equals("V"))
        {
            ((TextBox)MultiView1.FindControl("TechOther1")).Visible = true;
        }
        else
        {
            ((TextBox)MultiView1.FindControl("TechOther1")).Visible = false;
        }
    }

    protected void WasteItem1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)MultiView1.FindControl("WasteItem1")).SelectedValue.Equals("U"))
        {
            ((TextBox)MultiView1.FindControl("WasteOther1")).Visible = true;
        }
        else
        {
            ((TextBox)MultiView1.FindControl("WasteOther1")).Visible = false;
        }
    }

    protected void TechItem2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)MultiView1.FindControl("TechItem2")).SelectedValue.Equals("V"))
        {
            ((TextBox)MultiView1.FindControl("TechOther2")).Visible = true;
        }
        else
        {
            ((TextBox)MultiView1.FindControl("TechOther2")).Visible = false;
        }
    }

    protected void WasteItem2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)MultiView1.FindControl("WasteItem2")).SelectedValue.Equals("U"))
        {
            ((TextBox)MultiView1.FindControl("WasteOther2")).Visible = true;
        }
        else
        {
            ((TextBox)MultiView1.FindControl("WasteOther2")).Visible = false;
        }
    }

    #region  Cash

    public Case getCase(int obj)
    {
        String sql = " SELECT  Id,casedesc,createdate,helpdesc,isdeleted,name ,techitem ,techname ,techother ,type ,wasteitem ,wastename ,wasteother ,datasource FROM ReuseCase  where  Id=@Id ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@Id", OleDbType.Integer).Value = obj;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);
        IList lists = GetList(ds);
        if (lists == null || lists.Count < 1)
        {
            return null;
        }
        else
        {
            return (Case)lists[0];
        }
    }



    /// <summary>
    /// 實體物件取得DataRow資料
    /// </summary>
    private Case SetModel(DataRow dr)
    {
        Case mod = new Case();
        mod.Id = Convert.ToInt32(dr["Id"].ToString());
        mod.Casedesc= dr["CaseDesc"].ToString();
        mod.Createdate = Convert.ToDateTime(dr["Createdate"].ToString());
        mod.Helpdesc= dr["Helpdesc"].ToString();
        mod.Isdeleted=Convert.ToBoolean(dr["Isdeleted"].ToString());
        mod.Name= dr["Name"].ToString();
        mod.Techitem= dr["Techitem"].ToString();
        mod.Techname= dr["Techname"].ToString();
        mod.Techother= dr["Techother"].ToString();
        mod.Type=dr["Type"].ToString();
        mod.Wasteitem=dr["Wasteitem"].ToString();
        mod.Wastename=dr["Wastename"].ToString();
        mod.Wasteother  =dr["Wasteother"].ToString();
        mod.Datasource=dr["Datasource"].ToString();
        return mod;
    }


    /// <summary>
    /// 由DataSet取得泛型資料列表
    /// </summary>
    private List<Case> GetList(DataSet ds)
    {
        List<Case> li = new List<Case>();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            li.Add(SetModel(dr));
        }
        return li;
    }


    #endregion

}
