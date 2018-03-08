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
using System.Web.Mail;

public partial class page5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PasswordBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        msg.Text = "";
        UserName2.Text = "";
    }



    protected void GetPasswordButton_Click(object sender, EventArgs e)
    {

        MembershipUser u = Membership.GetUser(UserName2.Text.Trim(), false);

        if (u == null)
        {

            msg.Text = "無此帳號!!";
            msg.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            /* Mail */
            MailMessage msgMail = new MailMessage();
            string strMsg = "";
            string strTo = "";
            string strFrom = "";
            string strSubject = "資源化技術研發供需資訊平台 - 忘記密碼";
            strMsg += "<p>帳號: " + UserName2.Text.Trim() + "</p>";
            strMsg += "<p>密碼: " + u.GetPassword() + "</p>";
            strTo = u.Email;

            MembershipUser mng = Membership.GetUser("isrmng");
            strFrom = mng.Email;

            msgMail.To = strTo;
            msgMail.From = strFrom;
            msgMail.Subject = strSubject;
            msgMail.BodyFormat = MailFormat.Html;
            msgMail.Body = strMsg;
            new util().SendMail(strFrom, strTo, strSubject, strMsg, "");
            //SmtpMail.Send(msgMail);
            
            /* Mail End */

            msg.Text = "您的密碼已經以電子郵件寄出!!";
            msg.ForeColor = System.Drawing.Color.Blue;


        }

    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        if (Login1.UserName.Equals("isrmng"))
        {
            Response.Redirect("Manage/Default.aspx");
        }
        else
        {
            Response.Redirect("Member/Default.aspx");
        }
    }
   
}
