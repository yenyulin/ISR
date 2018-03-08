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
using System.Web.Mail;


public partial class Manage_ApproveList : System.Web.UI.Page
{
    //private AdoTemplate at;
    private ProfileCommon p;
    private MembershipUser user;
    //以下有問題
    //private IMatchService mgr = new Tgpf.Isr.Service.IMatchService();// IMatchService();


    //private IMatchService mgr = (IMatchService)BaseAction.Context.GetObject("IMatchService");
    //private IReuseTechService mgrRes = (IReuseTechService)BaseAction.Context.GetObject("IReuseTechService");
    //private IUserProfilesService mgrUp = (IUserProfilesService)BaseAction.Context.GetObject("IUserProfilesService");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Msg.Text = "顯示未審資料";
            DropBtn.Visible = true;
            BindGrid("A");
        }
    }

    private void BindGrid(string type)
    {
        //at = SpringUtil.at();

        /* 帳號未審核 */
        String sql = "SELECT IsApproved, UserId,UserName,Email,CreateDate,'' as Type,'' as Name,'' as Corp,'' as Tel    ";
        sql += " from vw_aspnet_MembershipUsers   ";
        if (type.Equals("A"))
            sql += " where IsApproved=false ";
        else if (type.Equals("B"))
            sql += " where UserName not in ('isrmng','root') ";

        if (!qryText.Text.Trim().Equals(""))
            sql += " and Comment like '%" + qryText.Text.Trim() + "%'";

        //DataSet ds = new DataSet();
        //at.DataSetFill(ds, CommandType.Text, sql);

        OleDbCommand cmd = new OleDbCommand(sql);
        DataSet ds = SQLUtil.QueryDS(cmd);

        foreach (DataRow dRow in ds.Tables[0].Rows)
        {
            p = Profile.GetProfile(dRow["UserName"].ToString());
            dRow["Type"] = p.UserProfile.Type;
            dRow["Name"] = p.UserProfile.Name;
            dRow["Corp"] = p.UserProfile.Corp;
            dRow["Tel"] = p.UserProfile.Tel;
        }
        ApproveGrid.DataSource = ds;

        ApproveGrid.DataBind();

        cnt.Text = Convert.ToString(ds.Tables[0].Rows.Count);
    }

    protected void ShowBtn1_Click(object sender, EventArgs e)
    {
        Msg.Text = "顯示未審資料";
        DropBtn.Visible = true;
        BindGrid("A");
    }

    protected void ShowBtn2_Click(object sender, EventArgs e)
    {
        Msg.Text = "顯示全部資料";
        DropBtn.Visible = false;
        BindGrid("B");
    }

    protected void SaveBtn_Click(object sender, EventArgs e)
    {

        ArrayList matchList = new ArrayList();
        foreach (RepeaterItem repeaterItem in ApproveGrid.Items)
        {
            string Username = "";
            if (((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked)
            {
                Username = ((CheckBox)repeaterItem.FindControl("PassCheckBox")).ToolTip;
                user = Membership.GetUser(Username);
                user.IsApproved = true;
                Membership.UpdateUser(user);
                p = Profile.GetProfile(Username);
                 
                //private IMatchService mgr = (IMatchService)BaseAction.Context.GetObject("IMatchService");
                //IList lists = mgr.getNotApprovedMatch(Username);
                //if (lists != null)
                //{
                //    foreach (Match item in lists)
                //    {
                //        if (p.UserProfile.Type.Equals("1"))
                //            item.Isapproved1 = true;
                //        else
                //            item.Isapproved2 = true;
                //        matchList.Add(item);
                //    }
                //    mgr.Save(matchList, user);
                //}

                String sql = "SELECT * from MatchList where (Username1=@param1 or  Username2=@param1) and (Isapproved1=false  or Isapproved2=false) ";
                OleDbCommand cmd = new OleDbCommand(sql);
                cmd.Parameters.Add("@param1", OleDbType.VarChar).Value = Username;
                cmd.CommandType = CommandType.Text;
                DataSet ds = SQLUtil.QueryDS(cmd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        int intID = Convert.ToInt32(dr["ID"].ToString());
                        bool Isapproved1 = Convert.ToBoolean(dr["Isapproved1"].ToString());
                        bool Isapproved2 = Convert.ToBoolean(dr["Isapproved2"].ToString());

                        if (p.UserProfile.Type.Equals("1"))
                        {
                            Isapproved1 = true;
                        }
                        else
                        {
                            Isapproved2=true;
                        }

                        String sqlUpDateMatch = "update MatchList set  Isapproved1=@Isapproved1,Isapproved2=@Isapproved2 where ID=@ID";
                        OleDbCommand cmdUpDateMatch = new OleDbCommand(sqlUpDateMatch);
                        cmdUpDateMatch.Parameters.Add("@Isapproved1", OleDbType.Boolean).Value = Isapproved1;
                        cmdUpDateMatch.Parameters.Add("@Isapproved2", OleDbType.Boolean).Value = Isapproved2;
                        cmdUpDateMatch.Parameters.Add("@ID", OleDbType.Integer).Value = intID;
                        cmdUpDateMatch.CommandType = CommandType.Text;
                        SQLUtil.ExecuteSql(cmdUpDateMatch);
                    }
                    Membership.UpdateUser(user);
                    //String sqlUpDateMemberShip = "update aspnet_MemberShip set  IsApproved=@IsApproved where UserID=@UserID";
                    //OleDbCommand cmdUpDateMemberShip = new OleDbCommand(sqlUpDateMemberShip);
                    //cmdUpDateMemberShip.Parameters.Add("@IsApproved", OleDbType.Boolean).Value = user.IsApproved;
                    //cmdUpDateMemberShip.Parameters.Add("@UserID", OleDbType.Integer).Value = p.UserProfil.;
                    //cmdUpDateMemberShip.CommandType = CommandType.Text;
                    //SQLUtil.ExecuteSql(cmdUpDateMemberShip);
                }

                /* Mail */
                MailMessage msgMail = new MailMessage();
                string strTo = user.Email;
                string strMsg = "<p>" + p.UserProfile.Name + " 先生/小姐您好</p>";
                strMsg += "<p>恭喜您正式成為「資源化技術研發供需資訊平台」 會員！！</p>";
                strMsg += "<p>您可再次登入「資源化技術研發供需資訊平台」，使用平台所提供的相關功能與服務！</p><br/><br/>";
                strMsg += "<p>此信件為系統自動發送，請勿直接回覆，謝謝。</p>";
                MembershipUser mng = Membership.GetUser("isrmng");
                string strFrom = mng.Email;
                string strSubject = "資源化技術研發供需資訊平台-正式成為會員通知";

                msgMail.To = strTo;
                msgMail.From = strFrom;
                msgMail.Subject = strSubject;
                msgMail.BodyFormat = MailFormat.Html;
                msgMail.Body = strMsg;
                msgMail.Cc = "wing@tgpf.org.tw";
                new util().SendMail(strFrom,strTo, strSubject, strMsg, "wing@tgpf.org.tw");
                //SmtpMail.Send(msgMail);
                /* Mail End */

            }
        }
        BindGrid("A");
    }

    protected void DropBtn_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem repeaterItem in ApproveGrid.Items)
        {
            string Username = "";
            string strTo = "";
            string strMsg = "";
            string strFrom = "";
            string strSubject = "";
            string Name = "";
            string email = "";
            if (((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked)
            {

                Username = ((CheckBox)repeaterItem.FindControl("PassCheckBox")).ToolTip;
                user = Membership.GetUser(Username);
                email = user.Email;
                p = Profile.GetProfile(Username);
                Name = p.UserProfile.Name;
                bool Deleted = Membership.DeleteUser(Username, true);
                if (Deleted)
                {

                    String sqlReuseTech = "select * from ReuseTech where Username=@Username";
                    OleDbCommand cmdReuseTech = new OleDbCommand(sqlReuseTech);
                    cmdReuseTech.Parameters.Add("@Username", OleDbType.VarChar).Value = Username;
                    cmdReuseTech.CommandType = CommandType.Text;
                    DataSet dsReuseTech = SQLUtil.QueryDS(cmdReuseTech);
                    foreach (DataRow dr in dsReuseTech.Tables[0].Rows)
                    {
                        String sqlDel = "Delete from ReuseTech where Id=@Id";
                        OleDbCommand cmdDel = new OleDbCommand(sqlDel);
                        cmdDel.Parameters.Add("@Id", OleDbType.Integer).Value = Convert.ToInt32(dr["Id"].ToString());
                        SQLUtil.ExecuteSql(cmdDel);
                    }
                   

                    //DataSet ds = new DataSet();
                    //at.DataSetFill(ds, CommandType.Text, sql);
                    String sqlGetUserProfile = "SELECT from UserProfiles where Username=@Username     ";
                    OleDbCommand cmdGetUserProfile = new OleDbCommand(sqlGetUserProfile);
                    cmdGetUserProfile.Parameters.Add("@Username", OleDbType.VarChar).Value = Username;
                    cmdGetUserProfile.CommandType = CommandType.Text;
                    DataSet dsProfile = SQLUtil.QueryDS(cmdGetUserProfile);
                    foreach (DataRow dr in dsProfile.Tables[0].Rows)
                    {
                        String sqlDel = "Delete from UserProfiles where Id=@Id";
                        OleDbCommand cmdDel = new OleDbCommand(sqlDel);
                        cmdDel.Parameters.Add("@Id", OleDbType.Integer).Value = Convert.ToInt32(dr["Id"].ToString());
                        SQLUtil.ExecuteSql(cmdDel);
                    }
                    //private IReuseTechService mgrRes = (IReuseTechService)BaseAction.Context.GetObject("IReuseTechService");
                    //private IUserProfilesService mgrUp = (IUserProfilesService)BaseAction.Context.GetObject("IUserProfilesService");
                    //ReuseTech obj = mgrRes.getReuseTechByName(Username);
                    /* UserProfiles */
                    //UserProfiles up = mgrUp.getUserProfiles(Username);
                    //mgrRes.Delete(obj, up, null);

                    /* Mail */
                    MailMessage msgMail = new MailMessage();
                    strTo = email;
                    strMsg = "<p>" + Name + " 先生/小姐您好</p>";
                    strMsg += "<p>審核未通過原因:" + addText.Text + "</p><br/><br/>";
                    strMsg += "<p>此信件為系統自動發送，請勿直接回覆，謝謝。</p>";
                    MembershipUser mng = Membership.GetUser("isrmng");
                    strFrom = mng.Email;
                    strSubject = "資源化技術研發供需資訊平台-審核未通過通知";

                    msgMail.To = strTo;
                    msgMail.From = strFrom;
                    msgMail.Subject = strSubject;
                    msgMail.BodyFormat = MailFormat.Html;
                    msgMail.Body = strMsg;
                    msgMail.Cc = "wing@tgpf.org.tw";
                    new util().SendMail(strFrom,strTo, strSubject, strMsg, "wing@tgpf.org.tw");
                    //SmtpMail.Send(msgMail);

                    /* Mail End */

                }

            }
        }
        BindGrid("A");
    }


    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


    protected void QryBtn1_Click(object sender, EventArgs e)
    {
        BindGrid("B");
    }

    protected void SelectBtn_Click(object sender, EventArgs e)
    {
        if (selectState.Value.Equals("N"))
        {
            foreach (RepeaterItem repeaterItem in ApproveGrid.Items)
            {

                ((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked = true;
            }
            selectState.Value = "Y";
        }
        else
        {
            foreach (RepeaterItem repeaterItem in ApproveGrid.Items)
            {

                ((CheckBox)repeaterItem.FindControl("PassCheckBox")).Checked = false;
            }
            selectState.Value = "N";
        }

    }
}
