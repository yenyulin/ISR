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

public partial class page7 : System.Web.UI.Page
{
    //private ICaseService mgr = (ICaseService)BaseAction.Context.GetObject("CaseService");

    //private AdoTemplate at;
     
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

            
            Panel1.Visible = false;
        }
    }

    private void BindData()
    {
        int i = 0;
        if (!WasteItem.SelectedValue.Equals("Z"))
        {
            //at = SpringUtil.at();
            String sql = "SELECT r.*, p1.ParamName as pn1  FROM ReuseCase AS r, Param AS p1  ";
            sql += " WHERE r.IsDeleted=false and r.Type=p1.ParamCode And p1.ParamId='C'   ";
            if (!WasteItem.SelectedValue.Equals("9"))
                sql += "and r.WasteItem='" + WasteItem.SelectedValue + "'";
             
            //DataSet ds1 = new DataSet();
            //at.DataSetFill(ds1, CommandType.Text, sql);
            OleDbCommand cmd = new OleDbCommand(sql);
            DataSet ds1 = SQLUtil.QueryDS(cmd);
            CaseGrid1.DataSource = ds1;
            CaseGrid1.DataBind();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                i++;
            }
        }

        if (!TechItem.SelectedValue.Equals("Z"))
        {
            //at = SpringUtil.at();
            String sql = "SELECT r.*, p1.ParamName as pn1  FROM ReuseCase AS r, Param AS p1  ";
            sql += " WHERE r.IsDeleted=false and r.Type=p1.ParamCode And p1.ParamId='C'   ";
            if (!TechItem.SelectedValue.Equals("9"))
                sql += "and r.TechItem='" + TechItem.SelectedValue + "'";

            //DataSet ds2 = new DataSet();
             OleDbCommand cmd = new OleDbCommand(sql);
            DataSet ds2 = SQLUtil.QueryDS(cmd);
            //at.DataSetFill(ds2, CommandType.Text, sql);
            CaseGrid2.DataSource = ds2;
            CaseGrid2.DataBind();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                i++;
            }
        }


        if (i > 0)
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

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["t1"] != null)
        {
            WasteItem.SelectedValue = Request.QueryString["t1"];
        }
        if (Request.QueryString["t2"] != null)
        {
            TechItem.SelectedValue = Request.QueryString["t2"];
        }

        BindData();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void setDetail(string id)
    {
        int Pid = int.Parse(id);

        //Case obj = mgr.getCase(Pid);
        OleDbCommand cmd = new OleDbCommand("select * from ReuseCase where Id=?");
        cmd.Parameters.AddWithValue("?", Pid);
        using (OleDbDataReader dr=SQLUtil.QueryDR(cmd))
        {
            while (dr.Read())
            {
                Name2.Text = dr["Name"].ToString();
                TechItem2.Text = dr["Techother"].ToString();
                TechName2.Text = dr["Techname"].ToString();
                WasteItem2.Text = dr["Wasteother"].ToString();
                WasteName2.Text = dr["Wastename"].ToString();
                if (dr["Type"].ToString().Equals("A"))
                    Type2.Text = "研發補助案例";
                else
                    Type2.Text = "再生實廠案例";
                CaseDesc2.Text = dr["Casedesc"].ToString();
                HelpDesc2.Text = dr["Helpdesc"].ToString();
                Datasource2.Text = dr["Datasource"].ToString();
                if (dr["Type"].ToString().Equals("B"))
                {
                    Panel2.Visible = false;

                }
                else
                {
                    Panel2.Visible = true;
                }
            }
            dr.Close();
        }
       
        //Name2.Text = obj.Name;
        //TechItem2.Text = obj.Techother;
        //TechName2.Text = obj.Techname;
        //WasteItem2.Text = obj.Wasteother;
        //WasteName2.Text = obj.Wastename;
        //if (obj.Type.Equals("A"))
        //    Type2.Text = "研發補助案例";
        //else
        //    Type2.Text = "再生實廠案例";
        //CaseDesc2.Text = obj.Casedesc;
        //HelpDesc2.Text = obj.Helpdesc;
        //Datasource2.Text = obj.Datasource;
        //if (obj.Type.Equals("B"))
        //{
        //    Panel2.Visible = false;

        //}
        //else
        //{
        //    Panel2.Visible = true;
        //}


        MultiView1.ActiveViewIndex = 1;
    }


    /*protected void Name_Command(object sender, CommandEventArgs e)
    {

        int Pid = int.Parse(e.CommandArgument.ToString());

        Case obj = mgr.getCase(Pid);

        Name2.Text = obj.Name;
        TechItem2.Text = obj.Techother;
        TechName2.Text = obj.Techname;
        WasteItem2.Text = obj.Wasteother;
        WasteName2.Text = obj.Wastename;
        if (obj.Type.Equals("A"))
            Type2.Text = "研發補助案例";
        else
            Type2.Text = "再生實廠案例";
        CaseDesc2.Text = obj.Casedesc;
        HelpDesc2.Text = obj.Helpdesc;
        Datasource2.Text = obj.Datasource;
        if (obj.Type.Equals("B"))
        {
            Panel2.Visible = false;

        }
        else
        {
            Panel2.Visible = true;
        }


        MultiView1.ActiveViewIndex = 1;
    }*/

    protected void CaseGrid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CaseGrid1.PageIndex = e.NewPageIndex;
        BindData();
    }

    protected void CaseGrid2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CaseGrid2.PageIndex = e.NewPageIndex;
        BindData();
    }

}
