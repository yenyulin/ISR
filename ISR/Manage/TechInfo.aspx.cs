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

public partial class Manage_TechInfo : System.Web.UI.Page
{
    //private ITechInfoService mgr = (ITechInfoService)BaseAction.Context.GetObject("TechInfoService");
    private ProfileCommon p;
    //private AdoTemplate at;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["type"].ToString().Equals("new"))
            {
                BindData1();
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                BindData2();
                MultiView1.ActiveViewIndex = 1;
            }
        }
    }

    protected void BindData1()
    {
        //at = SpringUtil.at();
        String sql = "SELECT * from ReuseTech WHERE id=@param1";

        //IDbParameters parameters = at.CreateDbParameters();
        //parameters.Add("param1", OleDbType.Numeric).Value = Request.QueryString["id"].ToString();
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.Numeric).Value = Request.QueryString["id"].ToString();
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        foreach (DataRow dRow in ds.Tables[0].Rows)
        {
            TechAdv1.Text = dRow["TechAdv"].ToString();
            TechDesc1.Text = dRow["TechDesc"].ToString();
            TechItem1.Value = dRow["TechItem"].ToString();
            TechName1.Value = dRow["TechName"].ToString();
            TechOther1.Value = dRow["TechOther"].ToString();
            WasteItem1.Value = dRow["WasteItem"].ToString();
            WasteName1.Value = dRow["WasteName"].ToString();
            WasteOther1.Value = dRow["WasteOther"].ToString();
            ReuseName1.Value = dRow["ReuseName"].ToString();
            Type1.Value = dRow["Type"].ToString();
        }
        Rid1.Value = Request.QueryString["id"].ToString();
    }

    protected void BindData2()
    {
        //IList lists = mgr.getTechInfoList(int.Parse(Request.QueryString["id2"].ToString()));
        //TechData.DataSource = lists;
        //TechData.DataBind();

        String sql = "SELECT * from TechInfo where id=@param1";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.Numeric).Value = Convert.ToInt32(Request.QueryString["id2"].ToString());
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);
        TechData.DataSource = ds;
        TechData.DataBind();
        

    }

    protected void SaveBtn1_Click(object sender, EventArgs e)
    {
        TechInfo obj = new TechInfo();
        obj.Techadv = TechAdv1.Text;
        obj.Techdesc = TechDesc1.Text;
        obj.Rid = int.Parse(Rid1.Value);
        obj.Techitem = TechItem1.Value;
        obj.Techname = TechName1.Value;
        obj.Techother = TechOther1.Value;
        obj.Wasteitem = WasteItem1.Value;
        obj.Wastename = WasteName1.Value;
        obj.Wasteother = WasteOther1.Value;
        obj.Reusename = ReuseName1.Value;
        obj.Type = Type1.Value;
        obj.Username = Request.QueryString["username"].ToString();
        obj.Isapproved = true;
        //mgr.Save(obj);



        String sqlRT = "";
        sqlRT = sqlRT + "  insert into TechInfo (Rid,Username,Techitem,Techname, Techother,Wasteitem,Wastename,Wasteother,Reusename,Techadv,Techdesc,[Type],Isapproved) ";
        sqlRT = sqlRT + " values( @Rid,@Username,@Techitem,@Techname, @Techother,@Wasteitem,@Wastename,@Wasteother,@Reusename,@Techadv,@Techdesc,@Type,@Isapproved) ";
        OleDbCommand cmdRT = new OleDbCommand(sqlRT);
        cmdRT.Parameters.Add("@Techadv", OleDbType.VarChar).Value = TechAdv1.Text;
        cmdRT.Parameters.Add("@Techdesc", OleDbType.VarChar).Value = TechDesc1.Text;
        cmdRT.Parameters.Add("@Rid", OleDbType.Integer).Value = int.Parse(Rid1.Value);
        cmdRT.Parameters.Add("@Techitem", OleDbType.VarChar).Value = TechItem1.Value;
        cmdRT.Parameters.Add("@Techname", OleDbType.VarChar).Value = TechName1.Value;
        cmdRT.Parameters.Add("@Techother", OleDbType.VarChar).Value = TechOther1.Value;
        cmdRT.Parameters.Add("@Wasteitem", OleDbType.VarChar).Value = WasteItem1.Value;
        cmdRT.Parameters.Add("@Wastename", OleDbType.VarChar).Value = WasteName1.Value;
        cmdRT.Parameters.Add("@Wasteother", OleDbType.VarChar).Value = WasteOther1.Value;
        cmdRT.Parameters.Add("@Reusename", OleDbType.VarChar).Value = ReuseName1.Value;
        cmdRT.Parameters.Add("@Type", OleDbType.VarChar).Value = Type1.Value;
        cmdRT.Parameters.Add("@Username", OleDbType.VarChar).Value = Request.QueryString["username"].ToString();
        cmdRT.Parameters.Add("@Isapproved", OleDbType.Boolean).Value = true;
        SQLUtil.ExecuteSql(cmdRT);


        Response.Write("<script language='javascript'> { window.close();}</script>");
    }

    protected void SaveBtn2_Click(object sender, EventArgs e)
    {
        //TechInfo obj = mgr.getTechInfo(int.Parse(Request.QueryString["id2"].ToString()));
        //for (int i = 0; i < TechData.Items.Count; i++)
        //{
        //    obj.Techadv = ((TextBox)TechData.Items[i].FindControl("TechAdv2")).Text;
        //    obj.Techdesc = ((TextBox)TechData.Items[i].FindControl("TechDesc2")).Text;
        //}
        //mgr.Save(obj);

        string strTechadv = "";
        string strTechdesc = "";
        for (int i = 0; i < TechData.Items.Count; i++)
        {
            strTechadv = ((TextBox)TechData.Items[i].FindControl("TechAdv2")).Text;
            strTechdesc = ((TextBox)TechData.Items[i].FindControl("TechDesc2")).Text;
        }

        String sqlRT = "";
        sqlRT = sqlRT + " update TechInfo ";
        sqlRT = sqlRT + " set Techadv=@Techadv, ";
        sqlRT = sqlRT + " Techdesc=@Techdesc ";       
        sqlRT = sqlRT + " where id=@id ";

        OleDbCommand cmdRT = new OleDbCommand(sqlRT);
        cmdRT.Parameters.Add("@Techadv", OleDbType.VarChar).Value = strTechadv;
        cmdRT.Parameters.Add("@Techdesc", OleDbType.VarChar).Value = strTechdesc;
        cmdRT.Parameters.Add("@id", OleDbType.Integer).Value = int.Parse(Request.QueryString["id2"].ToString());
        SQLUtil.ExecuteSql(cmdRT);

        Response.Write("<script language='javascript'> { window.close();}</script>");
    }

    protected void ExitBtn_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.close();}</script>");
    }
}
