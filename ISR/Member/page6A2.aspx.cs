using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using System.Web.Mail;

public partial class Member_page6A2 : System.Web.UI.Page
{
    //private IMatchService mgr = (IMatchService)BaseAction.Context.GetObject("MatchService");
    //private IReuseTechService mgr2 = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");

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
        //IList lists = mgr.getMatchListForUser2(User.Identity.Name);

        String sql = " select * from MatchList where  Username2=@Username2 and Ischecked='Y' and Isconfirm2<>'N' order by Matchdate ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@Username2", OleDbType.VarChar).Value = User.Identity.Name;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);
        List<Match> lists = GetList(ds);

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
            MatchGrid.DataSource = pgitems;
            MatchGrid.DataBind();
        }
        else
        {
            MatchGrid.DataSource = null;
            MatchGrid.DataBind();
        }


        if (MatchGrid.Items.Count > 0)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        else
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        pageNow.Text = (PageNumber + 1).ToString();
        pageTotal.Text = pgitems.PageCount.ToString();
        if (lists != null)
            cntTotal.Text = lists.Count.ToString();
        else
            cntTotal.Text = "0";

    }

    protected void SaveBtn_Click(object sender, EventArgs e)
    {

        ArrayList matchList = new ArrayList();
        Match match = null;
        foreach (RepeaterItem repeaterItem in MatchGrid.Items)
        {
            if (((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked || ((CheckBox)repeaterItem.FindControl("DropCheckBox")).Checked)
            {
                //ProfileCommon p = Profile.GetProfile(User.Identity.Name);

                if (((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked && ((Label)repeaterItem.FindControl("Pass1")).Visible == false)
                {
                    match = getMatch(int.Parse(((CheckBox)repeaterItem.FindControl("PassCheckBox")).ToolTip));
                }
                else
                {
                    match = getMatch(int.Parse(((CheckBox)repeaterItem.FindControl("DropCheckBox")).ToolTip));
                }
                if (((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked && ((Label)repeaterItem.FindControl("Pass1")).Visible == false)
                {
                    match.Isconfirm2 = "Y";
                    match.Confirmdate2 = DateTime.Now;
                }
                if (((CheckBox)repeaterItem.FindControl("DropCheckBox")).Checked)
                {
                    match.Isconfirm2 = "N";
                    match.Confirmdate2 = DateTime.Now;
                }

                matchList.Add(match);
            }
        }

        foreach (Match item in matchList)
        {
            String sqlUpDateMatch = "update MatchList ";
            sqlUpDateMatch += sqlUpDateMatch + "set ";
            sqlUpDateMatch += sqlUpDateMatch + "Isconfirm2=@Isconfirm2, ";
            sqlUpDateMatch += sqlUpDateMatch + "Confirmdate2=@Confirmdate2 ";
            sqlUpDateMatch += sqlUpDateMatch + " where ID=@ID";
            OleDbCommand cmdUpDateMatch = new OleDbCommand(sqlUpDateMatch);

            cmdUpDateMatch.Parameters.Add("@Isconfirm2", OleDbType.VarChar).Value = item.Isconfirm2;
            cmdUpDateMatch.Parameters.Add("@Confirmdate2", OleDbType.Date).Value = item.Confirmdate2;
            cmdUpDateMatch.Parameters.Add("@ID", OleDbType.Integer).Value = item.Id;
            cmdUpDateMatch.CommandType = CommandType.Text;
            SQLUtil.ExecuteSql(cmdUpDateMatch);

        }

        //private IMatchService mgr = (IMatchService)BaseAction.Context.GetObject("MatchService");
        //mgr.Update(matchList);

        /* Mail */
        foreach (RepeaterItem repeaterItem in MatchGrid.Items)
        {

            if (((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked && ((Label)repeaterItem.FindControl("Pass1")).Visible == false)
            {
                match = getMatch(int.Parse(((CheckBox)repeaterItem.FindControl("PassCheckBox")).ToolTip));

                MembershipUser user = Membership.GetUser(User.Identity.Name);
                ProfileCommon p = Profile.GetProfile(User.Identity.Name);

                /* Mail to Manager */
                MailMessage msgMail = new MailMessage();
                string strMsg1 = "<p>請管理者登入「研發合作對象名單」中，查閱新增產學研界媒合意願名單。</p>";
                MembershipUser mng = Membership.GetUser("isrmng");
                string strTo = mng.Email;
                string strFrom = mng.Email;

                string strSubject = "資源化技術研發供需資訊平台-新增產學研界媒合意願通知";

                msgMail.To = strTo;
                msgMail.From = strFrom;
                msgMail.Subject = strSubject;
                msgMail.BodyFormat = MailFormat.Html;
                msgMail.Body = strMsg1;
                msgMail.Cc = "wing@tgpf.org.tw";
                new util().SendMail(strFrom,strTo, strSubject, strMsg1, "wing@tgpf.org.tw");
                //SmtpMail.Send(msgMail);

                /* Mail to User */
                strSubject = "資源化技術研發供需資訊平台通知";
                string strMsg2 = "<p>" + p.UserProfile.Name + " 先生/小姐您好:</p>";
                strMsg2 += "<p>「資源化技術研發供需資訊平台」已收到您勾選進一步嘹解產學研發合作媒合之意願，</p>";
                strMsg2 += "<p>需等候研發合作對象亦有此意願，造成不便敬請見諒。管理者將主動聯繫雙方，謝謝。</p>";
                strTo = user.Email;

                msgMail.To = strTo;
                msgMail.From = strFrom;
                msgMail.Subject = strSubject;
                msgMail.BodyFormat = MailFormat.Html;
                msgMail.Body = strMsg2;
                msgMail.Cc = "wing@tgpf.org.tw";
                new util().SendMail(strFrom,strTo, strSubject, strMsg2, "wing@tgpf.org.tw");
                //SmtpMail.Send(msgMail);

                /* Mail End */
            }

        }
        /* Mail End */


        BindGrid();
        Response.Write("<script>alert('資料已送出')</script>");
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("page6C2.aspx");
    }

    protected void BackBtn2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void TechNameBtn1_Command(object sender, CommandEventArgs e)
    {

        int Pid = int.Parse(e.CommandArgument.ToString());
        ReuseTech obj = GetReuseTech(Pid);

        if (obj != null)
        {
            TechItem3.Text = obj.Techname;
            TechAdv3.Text = obj.Techadv;
            TechDesc3.Text = obj.Techdesc;
        }
        else
        {
            TechItem3.Text = "";
            TechAdv3.Text = "";
            TechDesc3.Text = "";
        }
        MultiView1.ActiveViewIndex = 1;



    }

    #region  Match

    public Match getMatch(int obj)
    {
        String sql = " select * from MatchList where Id=@Id ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@Id", OleDbType.Integer).Value = obj;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);
        IList lists = GetList(ds);


        //  IList lists = HibernateTemplate.Find("from Match where Id=? ", obj);
        if (lists == null || lists.Count < 1)
        {
            return null;
        }
        else
        {
            return (Match)lists[0];
        }
    }



    /// <summary>
    /// 實體物件取得DataRow資料
    /// </summary>
    private Match SetModel(DataRow dr)
    {
        Match mod = new Match();
        mod.Id = Convert.ToInt32(dr["Id"].ToString());
        mod.Approveddate = Convert.ToDateTime(dr["Approveddate"].ToString());
        mod.Confirmdate1 = Convert.ToDateTime(dr["Confirmdate1"].ToString());
        mod.Confirmdate2 = Convert.ToDateTime(dr["Confirmdate2"].ToString());
        mod.Corp1 = dr["Corp1"].ToString();
        mod.Corp2 = dr["Corp2"].ToString();
        mod.Createdate1 = Convert.ToDateTime(dr["Createdate1"].ToString());
        mod.Createdate2 = Convert.ToDateTime(dr["Createdate2"].ToString());
        mod.Deletedate1 = Convert.ToDateTime(dr["Deletedate1"].ToString());
        mod.Deletedate2 = Convert.ToDateTime(dr["Deletedate2"].ToString());
        mod.Isapproved1 = Convert.ToBoolean(dr["Isapproved1"].ToString());
        mod.Isapproved2 = Convert.ToBoolean(dr["Isapproved2"].ToString());
        mod.Ischecked = dr["Ischecked"].ToString();
        mod.Isconfirm1 = dr["Isconfirm1"].ToString();
        mod.Isconfirm2 = dr["Isconfirm2"].ToString();
        mod.Isdeleted = Convert.ToBoolean(dr["Isdeleted"].ToString());
        mod.Isdeleted1 = Convert.ToBoolean(dr["Isdeleted1"].ToString());
        mod.Isdeleted2 = Convert.ToBoolean(dr["Isdeleted2"].ToString());
        mod.Isdroped1 = dr["Isdroped1"].ToString();
        mod.Isdroped2 = dr["Isdroped2"].ToString();
        mod.Matchdate = Convert.ToDateTime(dr["Matchdate"].ToString());
        mod.Name1 = dr["Name1"].ToString();
        mod.Name2 = dr["Name2"].ToString();
        mod.Reusename1 = dr["Reusename1"].ToString();
        mod.Reusename2 = dr["Reusename2"].ToString();
        mod.Rid1 = Convert.ToInt32(dr["Rid1"].ToString());
        mod.Rid2 = Convert.ToInt32(dr["Rid2"].ToString());
        mod.Techadv = dr["Techadv"].ToString();
        mod.Techdesc = dr["Techdesc"].ToString();
        mod.Techitem1 = dr["Techitem1"].ToString();
        mod.Techitem2 = dr["Techitem2"].ToString();
        mod.Techname1 = dr["Techname1"].ToString();
        mod.Techname2 = dr["Techname2"].ToString();
        mod.Tel1 = dr["Tel1"].ToString();
        mod.Tel2 = dr["Tel2"].ToString();
        mod.Username1 = dr["Username1"].ToString();
        mod.Username2 = dr["Username2"].ToString();
        mod.Wasteitem1 = dr["Wasteitem1"].ToString();
        mod.Wasteitem2 = dr["Wasteitem2"].ToString();
        mod.Wastename1 = dr["Wastename1"].ToString();
        mod.Wastename2 = dr["Wastename2"].ToString();

        return mod;
    }


    /// <summary>
    /// 由DataSet取得泛型資料列表
    /// </summary>
    private List<Match> GetList(DataSet ds)
    {
        List<Match> li = new List<Match>();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            li.Add(SetModel(dr));
        }
        return li;
    }


    #endregion

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
