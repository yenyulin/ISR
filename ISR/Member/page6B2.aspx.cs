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

public partial class Member_page6B2 : System.Web.UI.Page
{
    private ProfileCommon p;
    //private AdoTemplate at;
    //private IReuseTechService mgr = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");

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
        sql += " WHERE  Type='1'   ";
        if (!WasteItem.SelectedValue.Equals("Z"))
            sql += "and  WasteItem='" + WasteItem.SelectedValue + "'";
        if (!TechItem.SelectedValue.Equals("Z"))
            sql += "and  TechItem='" + TechItem.SelectedValue + "'";

        OleDbCommand cmd = new OleDbCommand(sql);
        DataSet ds = SQLUtil.QueryDS(cmd);

        //DataSet ds = new DataSet();
        //at.DataSetFill(ds, CommandType.Text, sql);


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

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Name_Command(object sender, CommandEventArgs e)
    {

        int Pid = int.Parse(e.CommandArgument.ToString());

        ReuseTech obj = GetReuseTech(Pid);

       
        //TechItem2.Text = obj.Techother;
        TechItem2.Text = obj.Techname;
        TechAdv2.Text = obj.Techadv;
        TechDesc2.Text = obj.Techdesc;
       

        MultiView1.ActiveViewIndex = 1;
    }

    protected void ReuseGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ReuseGrid.PageIndex = e.NewPageIndex;
        BindData();
    }

    #region  ReuseTech

    /// <summary>
    /// 取得單筆ReuseTech
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private ReuseTech GetReuseTech(int id)
    {
        String sql = "SELECT * FROM ReuseTech WHERE id=@id ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@id", OleDbType.Integer).Value = id;
        cmd.CommandType = CommandType.Text;
        //DataSet ds = SQLUtil.QueryDS(cmd);
        OleDbDataReader dr = SQLUtil.QueryDR(cmd);
        bool isHasRows = dr.HasRows;
        ReuseTech mod = SetModel(dr);
        dr.Close();
        return isHasRows ? mod : null;
    }

    /// <summary>
    /// 實體物件取得DataRow資料
    /// </summary>
    private ReuseTech SetModel(OleDbDataReader dr)
    {
        ReuseTech mod = new ReuseTech();
        while (dr.Read())
        {
            mod.Id = Convert.ToInt32(dr["Id"].ToString());
            mod.Isapproved = Convert.ToBoolean(dr["IsApproved"].ToString());
            mod.Patent = dr["Patent"].ToString();
            mod.Researchitem = dr["Researchitem"].ToString();
            mod.Reusename = dr["Reusename"].ToString();

            mod.Techadv = dr["Techadv"].ToString();
            mod.Techdesc = dr["Techdesc"].ToString();
            mod.Techitem = dr["Techitem"].ToString();
            mod.Techname = dr["Techname"].ToString();
            mod.Techother = dr["Techother"].ToString();
            mod.Techother = dr["Techother"].ToString();
            mod.Type = dr["Type"].ToString();
            mod.Username = dr["Username"].ToString();

            mod.Wasteitem = dr["Wasteitem"].ToString();
            mod.Wastename = dr["Wastename"].ToString();
            mod.Wasteother = dr["Wasteother"].ToString();
            mod.Createdate = Convert.ToDateTime(dr["Createdate"].ToString());
        }
        return mod;
    }

    #endregion

}
