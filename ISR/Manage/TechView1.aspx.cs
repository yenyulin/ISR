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

public partial class Manage_TechView1 : System.Web.UI.Page
{
    private ProfileCommon p;
    //private AdoTemplate at;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            BindData();

        }
    }

    private void BindData()
    {
        //at = SpringUtil.at();
        String sql = "SELECT r.*, p1.ParamName as pn1, p2.ParamName as pn2, p3.ParamName as pn3 FROM ReuseTech AS r, Param AS p1, Param AS p2, Param AS p3  ";
        sql += " WHERE id=@param1 and r.TechItem=p1.ParamCode And p1.ParamId='T' And r.WasteItem=p2.ParamCode And p2.ParamId='W' And r.ResearchItem=p3.ParamCode And p3.ParamId='R' ";
        //IDbParameters parameters = at.CreateDbParameters();
        //parameters.Add("param1", OleDbType.VarChar).Value = Request.QueryString["id"].ToString();
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.VarChar).Value = Request.QueryString["id"].ToString();
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        TechData.DataSource = ds;

        TechData.DataBind();

    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.close();}</script>");

    }
}
