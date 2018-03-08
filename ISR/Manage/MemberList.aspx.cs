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

public partial class Manage_MemberList : System.Web.UI.Page
{
    //private AdoTemplate at;
    private ProfileCommon p;
    private MembershipUser user;
    //private IReuseTechService mgrRes = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");
    //private IUserProfilesService mgrUp = (IUserProfilesService)BaseAction.Context.GetObject("UserProfilesService");

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
        BindGrid(type1.Value);
    }

    void rptPages2_ItemCommand(object source,
                        RepeaterCommandEventArgs e)
    {
        PageNumber2 = Convert.ToInt32(e.CommandArgument) - 1;
        BindGrid(type1.Value);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid("A");
        }
    }

    private void BindGrid(string type)
    {
        //at = SpringUtil.at();

        /* 學研機構 */
        String sql = "SELECT u.UserId,u.UserName,u.Email,u.IsApproved,u.CreateDate,p.Type,p.Name,p.Corp,p.Tel,p.Address,";
        sql += "   IIf(p.Kind='A','學術單位',IIf(p.Kind='B','研究單位','其他')) as Kind ,m.Password as Pwd ";
        sql += "  from vw_aspnet_MembershipUsers u , UserProfiles p , aspnet_Membership m where u.PasswordAnswer='1' and u.UserName=p.UserName and u.UserId=m.UserId ";
        if (type.Equals("A"))
            sql += "   order by u.UserId";
        else if (type.Equals("B"))
            sql += "  and u.IsApproved=true order by u.UserId";
        else if (type.Equals("C"))
            sql += "  and  u.IsApproved=false order by u.UserId";

        //DataSet ds = new DataSet();
        //at.DataSetFill(ds, CommandType.Text, sql);
        OleDbCommand cmd = new OleDbCommand(sql);
        DataSet ds = SQLUtil.QueryDS(cmd);

        int cnt1 = ds.Tables[0].Rows.Count;

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

        MemberGrid1.DataSource = pgitems;
        MemberGrid1.DataBind();
        if (MemberGrid1.Items.Count > 0)
        {
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = true;
        }

        pageNow.Text = (PageNumber + 1).ToString();
        pageTotal.Text = pgitems.PageCount.ToString();
        cntTotal.Text = cnt1.ToString();


        /* 業者廠商 */
        sql = "SELECT u.UserId,u.UserName,u.Email,u.IsApproved,u.CreateDate,p.Type,p.Name,p.Corp,p.Tel,p.Address,";
        sql += "  IIf(p.Kind='A','公民營處(清)理機構',IIf(p.Kind='B','許可再利用機構',IIf(p.Kind='C','公告再利用機構',IIf(p.Kind='D','應回收廢棄物處理機構','其他')))) as Kind ,m.Password as Pwd ";
        sql += "  from vw_aspnet_MembershipUsers u , UserProfiles p , aspnet_Membership m where u.PasswordAnswer='2' and u.UserName=p.UserName and u.UserId=m.UserId ";
        if (type.Equals("A"))
            sql += "   order by u.UserId";
        else if (type.Equals("B"))
            sql += "  and u.IsApproved=true order by u.UserId";
        else if (type.Equals("C"))
            sql += "  and  u.IsApproved=false order by u.UserId";

        //ds = new DataSet();
        //at.DataSetFill(ds, CommandType.Text, sql);
        OleDbCommand cmd2= new OleDbCommand(sql);
        ds = SQLUtil.QueryDS(cmd2);

        int cnt2 = ds.Tables[0].Rows.Count;

        

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

        MemberGrid2.DataSource = pgitems2;
        MemberGrid2.DataBind();
        if (MemberGrid2.Items.Count > 0)
        {
            Panel2.Visible = false;
        }
        else
        {
            Panel2.Visible = true;
        }

        pageNow2.Text = (PageNumber2 + 1).ToString();
        pageTotal2.Text = pgitems2.PageCount.ToString();
        cntTotal2.Text = cnt2.ToString();


        cnt.Text = Convert.ToString(cnt1 + cnt2);

    }

    protected void DropBtn1_Command(object sender, CommandEventArgs e)
    {
        string Username = e.CommandArgument.ToString();
        //ReuseTechService
        //UserProfilesService

        //string strMemberShipSql = "update  aspnet_Membership set Email=@Email  where  UserId=@UserId";
        //OleDbCommand cmdMemberShip = new OleDbCommand(strMemberShipSql);
        //cmdMemberShip.Parameters.Add("@Email", OleDbType.Char).Value = Email.Text;
        //cmdMemberShip.Parameters.Add("@UserId", OleDbType.Char).Value = strUserID;
        //cmdMemberShip.CommandType = CommandType.Text;
        //SQLUtil.ExecuteSql(cmdMemberShip);

        //delete from Membership

        bool Deleted = Membership.DeleteUser(Username, true);
        if (Deleted)
        {
            //String sqlMarquee = "SELECT * from Marquee where Id=?   ";
            //OleDbCommand cmdM = new OleDbCommand(sqlMarquee);
            //cmdM.Parameters.Add("?", OleDbType.VarChar).Value = "B";
            //cmdM.CommandType = CommandType.Text;
            //DataSet dsm = SQLUtil.QueryDS(cmdM);



            String strDelReuseTech = "delete from ReuseTech where UserName = @username";
            OleDbCommand cmdDelReuseTech = new OleDbCommand(strDelReuseTech);
            cmdDelReuseTech.Parameters.Add("@username", OleDbType.VarChar).Value=Username;
            cmdDelReuseTech.CommandType = CommandType.Text;
            SQLUtil.ExecuteSql(cmdDelReuseTech);

            String strDelUserProfile = "delete from UserProfiles where UserName = @username";
            OleDbCommand cmdDelUserProfile = new OleDbCommand(strDelUserProfile);
            cmdDelUserProfile.Parameters.Add("@username", OleDbType.VarChar).Value=Username;
            cmdDelUserProfile.CommandType = CommandType.Text;
            SQLUtil.ExecuteSql(cmdDelUserProfile);

            //IList lists = mgrRes.getReuseTechListAll(Username);
            /* UserProfiles */
            //UserProfiles up = mgrUp.getUserProfiles(Username);
            //mgrRes.DeleteAll(lists, up);
        }
        BindGrid("A");
    }

    protected void DropBtn2_Command(object sender, CommandEventArgs e)
    {
        string Username = e.CommandArgument.ToString();
        bool Deleted = Membership.DeleteUser(Username, true);
        if (Deleted)
        {
            String strDelReuseTech = "delete from ReuseTech where UserName = @username";
            OleDbCommand cmdDelReuseTech = new OleDbCommand(strDelReuseTech);
            cmdDelReuseTech.Parameters.Add("@username", OleDbType.VarChar).Value = Username;
            cmdDelReuseTech.CommandType = CommandType.Text;
            SQLUtil.ExecuteSql(cmdDelReuseTech);

            String strDelUserProfile = "delete from UserProfiles where UserName = @username";
            OleDbCommand cmdDelUserProfile = new OleDbCommand(strDelUserProfile);
            cmdDelUserProfile.Parameters.Add("@username", OleDbType.VarChar).Value = Username;
            cmdDelUserProfile.CommandType = CommandType.Text;
            SQLUtil.ExecuteSql(cmdDelUserProfile);

            //IList lists = mgrRes.getReuseTechListAll(Username);
            ///* UserProfiles */
            //UserProfiles up = mgrUp.getUserProfiles(Username);
            //mgrRes.DeleteAll(lists, up);
        }
        BindGrid("A");
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void SortBtn1_Click(object sender, EventArgs e)
    {
        type1.Value = "A";
        BindGrid("A");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        type1.Value = "B";
        BindGrid("B");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        type1.Value = "C";
        BindGrid("C");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        Panel4.Visible = false;
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel4.Visible = true;
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        Panel4.Visible = true;
    }

}
