using System;
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
using System.Collections.Generic;



public partial class Manage_MatchList : System.Web.UI.Page
{
    //private IMatchService mgr = (IMatchService)BaseAction.Context.GetObject("MatchService");
    //private IMarqueeService mgrM = (IMarqueeService)BaseAction.Context.GetObject("MarqueeService");

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
        String sql = "SELECT * from MatchList where Ischecked<>'N' and Isapproved1=true and Isapproved2=true order by Matchdate  ";
      
        OleDbCommand cmd = new OleDbCommand(sql);
        DataSet ds = SQLUtil.QueryDS(cmd);

          DataTable dtOrder = ds.Tables[0];
         List<Match> li= GetList(ds);
        //先找出IEnumerable所有(該公司及分及司) 的送出訂單而且沒有建立收款單的 照duedate排序
        //System.Collections.Generic.IEnumerable<DataRow> queryOrder =
        //from Order in dtOrder.AsEnumerable()
        //select Order;

        


        //IList lists = mgr.getMatchListForManager();

        PagedDataSource pgitems = new PagedDataSource();
        pgitems.DataSource = li;
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

        //MatchGrid.DataSource = pgitems;
        MatchGrid.DataSource = dtOrder;
        MatchGrid.DataBind();
        if (MatchGrid.Items.Count > 0)
        {
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = true;
        }

        pageNow.Text = (PageNumber + 1).ToString();
        pageTotal.Text = pgitems.PageCount.ToString();
        cntTotal.Text =ds.Tables[0].Rows.Count.ToString();

    }

   

    protected void SaveBtn_Click(object sender, EventArgs e)
    {


        ArrayList matchList = new ArrayList();
        Match match = null;
        foreach (RepeaterItem repeaterItem in MatchGrid.Items)
        {

            if (((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked || ((CheckBox)repeaterItem.FindControl("DropCheckBox")).Checked)
            {

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
                    match.Ischecked = "Y";
                    match.Approveddate = DateTime.Now;
                }
                if (((CheckBox)repeaterItem.FindControl("DropCheckBox")).Checked)
                {
                    match.Ischecked = "N";
                    match.Approveddate = DateTime.Now;
                }

                matchList.Add(match);
            }
        }
        //mgr.Update(matchList);
        foreach (Match item in matchList)
        {
            String sqlUpDateMatch = "update MatchList set  Ischecked=@Ischecked,Approveddate=@Approveddate where ID=@ID";
            OleDbCommand cmdUpDateMatch = new OleDbCommand(sqlUpDateMatch);
            cmdUpDateMatch.Parameters.Add("@Ischecked", OleDbType.VarChar).Value = item.Ischecked;
            cmdUpDateMatch.Parameters.Add("@Approveddate", OleDbType.Date).Value = item.Approveddate;
            cmdUpDateMatch.Parameters.Add("@ID", OleDbType.Integer).Value = item.Id;
            cmdUpDateMatch.CommandType = CommandType.Text;
            SQLUtil.ExecuteSql(cmdUpDateMatch);

            //HibernateTemplate.Update(item);
        }


        /* Mail */
        foreach (RepeaterItem repeaterItem in MatchGrid.Items)
        {

            if (((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked && ((Label)repeaterItem.FindControl("Pass1")).Visible == false)
            {


                String sqlMarquee = "SELECT * from Marquee where Id=?   ";
                OleDbCommand cmdM = new OleDbCommand(sqlMarquee);
                cmdM.Parameters.Add("?", OleDbType.VarChar).Value = "B";
                cmdM.CommandType = CommandType.Text;
                DataSet dsm = SQLUtil.QueryDS(cmdM);
                string strEmailMsg = "";
                foreach (DataRow dr in dsm.Tables[0].Rows)
                {
                    strEmailMsg = dr["Msg"].ToString();
                }

                //Marquee objM = mgrM.getMarquee("B");


                match = getMatch(int.Parse(((CheckBox)repeaterItem.FindControl("PassCheckBox")).ToolTip));
                //match = mgr.getMatch(int.Parse(((CheckBox)repeaterItem.FindControl("PassCheckBox")).ToolTip));
                /* 學研機構 */
                MailMessage msgMail = new MailMessage();
                MembershipUser user = Membership.GetUser(match.Username1);
                ProfileCommon p = Profile.GetProfile(match.Username1);

                string strTo = user.Email;
                string strFrom = "";
                string strMsg1 = "<p>" + p.UserProfile.Name + " 先生/小姐您好:</p>";
                string strMsg2 = "<p>「資源化技術研發供需資訊平台」依您所提供資源化再生技術供需現況進行媒合配對，</p>";
                strMsg2 += "<p>已配對到合適的對象，請再次登入平台會員填寫媒合意願，謝謝。</p>";
                //strMsg2 += "<p><a href=\"" + objM.Msg + "\">" + objM.Msg + "</a></p>";

                strMsg2 += "<p><a href=\"" + strEmailMsg + "\">" + strEmailMsg + "</a></p>";
                strMsg2 += "<p>＊本信依您所提供資源化再生技術供需現況進行媒合配對，</p>";
                strMsg2 += "<p>若您覺得配對系統不精準或太少，請修改或增加資源化再生技術條件來改善。</p>";
                string strMsg = strMsg1 + strMsg2;
                MembershipUser mng = Membership.GetUser("isrmng");
                strFrom = mng.Email;

                string strSubject = "資源化技術研發供需資訊平台-系統配對媒合通知";

                msgMail.To = strTo;
                msgMail.From = strFrom;
                msgMail.Subject = strSubject;
                msgMail.BodyFormat = MailFormat.Html;
                msgMail.Body = strMsg;
                msgMail.Cc = "wing@tgpf.org.tw";
                new util().SendMail(strFrom,strTo, strSubject, strMsg, "wing@tgpf.org.tw");
                //SmtpMail.Send(msgMail);
                /* 業者廠商 */
                user = Membership.GetUser(match.Username2);
                p = Profile.GetProfile(match.Username2);
                strMsg1 = "<p>" + p.UserProfile.Name + " 先生/小姐您好:</p>";
                strMsg = strMsg1 + strMsg2;
                strTo = user.Email;

                msgMail.To = strTo;
                msgMail.From = strFrom;
                msgMail.Subject = strSubject;
                msgMail.BodyFormat = MailFormat.Html;
                msgMail.Body = strMsg;
                msgMail.Cc = "wing@tgpf.org.tw";
                new util().SendMail(strFrom, strTo, strSubject, strMsg, "wing@tgpf.org.tw");
                //SmtpMail.Send(msgMail);

            }

        }
        /* Mail End */

        BindGrid();
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    #region  Match

    public Match getMatch(int obj)
    {
        String sql = " select * from MatchList where Id=@Id ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@Id", OleDbType.Integer).Value = obj;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);
        IList lists =GetList(ds);
      

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

}
