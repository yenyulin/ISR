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

public partial class Manage_ProfileView1 : System.Web.UI.Page
{
    //private IReuseTechService mgr = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");
    //private IParamService mgrParam = (IParamService)BaseAction.Context.GetObject("ParamService");
    //private IZipService mgrZip = (IZipService)BaseAction.Context.GetObject("ZipService");
    private MembershipUser user;
    private ProfileCommon p;
    //private AdoTemplate at;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindProfileView();
        }
    }

    private void BindProfileView()
    {
        /* 基本資料 */
        user = Membership.GetUser(Request.QueryString["Username"].ToString());
        p = Profile.GetProfile(Request.QueryString["Username"].ToString());
        UsernameView.Text = Request.QueryString["Username"].ToString();
        CorpView.Text = p.UserProfile.Corp;
        AddressView.Text = p.UserProfile.Zipcht + p.UserProfile.Address;
        NameView.Text = p.UserProfile.Name;
        TelView.Text = p.UserProfile.Tel;
        FaxView.Text = p.UserProfile.Fax;
        EmailView.Text = user.Email;


        if (p.UserProfile.Kind.Equals("A"))
            KindView.Text = "學術單位";
        else if (p.UserProfile.Kind.Equals("B"))
            KindView.Text = "研究單位";
        else if (p.UserProfile.Kind.Equals("C"))
            KindView.Text = "其他";



        /* 供給現況 */
        //at = SpringUtil.at();
        String sql = "SELECT r.*, p1.ParamName as pn1, p2.ParamName as pn2, p3.ParamName as pn3 FROM ReuseTech AS r, Param AS p1, Param AS p2, Param AS p3  ";
        sql += " WHERE UserName=@param1 and r.TechItem=p1.ParamCode And p1.ParamId='T' And r.WasteItem=p2.ParamCode And p2.ParamId='W' And r.ResearchItem=p3.ParamCode And p3.ParamId='R' ";
      
        //IDbParameters parameters = at.CreateDbParameters();
        //parameters.Add("param1", OleDbType.VarChar).Value = Request.QueryString["Username"].ToString();
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.VarChar).Value = Request.QueryString["Username"].ToString();
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        TechDataList.DataSource = ds;
        TechDataList.DataBind();

    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.close();}</script>");

    }
}
