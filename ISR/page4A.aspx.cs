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
using System.Net.Mail;
using System.Data;
using System.Data.OleDb;

public partial class page4_A : System.Web.UI.Page
{
    //private IReuseTechService mgr = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");
    private ProfileCommon p;
    private ProfileCommon p2;
    //private AdoTemplate at;
    private MembershipUser user;
    private MembershipUser user2;
    //private IMarqueeService mgrM = (IMarqueeService)BaseAction.Context.GetObject("MarqueeService");


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindList();
            ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("TechItem")).Attributes.Add("onchange", "javascript:onSelectChanged1(this); ");
            ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("WasteItem")).Attributes.Add("onchange", "javascript:onSelectChanged2(this); ");
        }
        else
        {
            ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Password")).Attributes.Add("value", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Password")).Text);
            ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("ConfirmPassword")).Attributes.Add("value", ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ConfirmPassword")).Text);
        }
    }


    protected void BindList()
    {


        //at = SpringUtil.at();
        String sql = "SELECT Id,Name,Pid  ";
        sql += " from Zip where Pid=@param1    ";
        //IDbParameters parameters = at.CreateDbParameters();
        //parameters.Add("param1", OleDbType.Char).Value = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedValue;
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);
        
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.AddWithValue("?", ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedValue);
        zipList.DataSource = SQLUtil.QueryDS(cmd);
        zipList.DataTextField = "Name";
        zipList.DataValueField = "Id";
        zipList.DataBind();
    }


    protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        try
        {
            CreateUserWizard1.UserName = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;

            user = Membership.GetUser(CreateUserWizard1.UserName);

            user.ChangePasswordQuestionAndAnswer(user.GetPassword(), "1", "1");
            user.IsApproved = false;
            user.Comment = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Corp")).Text;

            Roles.AddUserToRole(CreateUserWizard1.UserName, "user");
            Membership.UpdateUser(user);

            p = (ProfileCommon)ProfileCommon.Create(CreateUserWizard1.UserName, true);
            p.UserProfile.Owner = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Name")).Text;
            p.UserProfile.Name = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Name")).Text;
            p.UserProfile.Tel = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Tel")).Text;
            p.UserProfile.Corp = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Corp")).Text;
            p.UserProfile.City = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedValue;
            p.UserProfile.Postcode = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedValue;
            p.UserProfile.Address = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Address")).Text;
            p.UserProfile.Fax = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Fax")).Text;
            p.UserProfile.Kind = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue;
            p.UserProfile.Type = "1";
            p.UserProfile.Zipcht = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedValue +
                ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedItem.Text +
                ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedItem.Text;
            p.Save();

            /* ReuseTech */
            ReuseTech obj = new ReuseTech();
            obj.Username = CreateUserWizard1.UserName;
            obj.Techitem = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("TechItem")).SelectedValue;
            if (!obj.Techitem.Equals("V"))
                obj.Techother = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("TechItem")).SelectedItem.Text;
            else
                obj.Techother = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechOther")).Text;
            obj.Techname = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechName")).Text;
            obj.Wasteitem = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("WasteItem")).SelectedValue;
            if (!obj.Wasteitem.Equals("U"))
                obj.Wasteother = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("WasteItem")).SelectedItem.Text;
            else
                obj.Wasteother = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("WasteOther")).Text;
            obj.Wastename = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("WasteName")).Text;
            obj.Reusename = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("ReuseName")).Text;
            obj.Researchitem = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("ResearchItem")).SelectedValue;
            obj.Patent = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Patent")).Text;
            obj.Techadv = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechAdv")).Text;
            obj.Techdesc = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechDesc")).Text;
            obj.Type = "1";
            obj.Isapproved = false;
            obj.Createdate = DateTime.Now;

            /* UserProfiles */
            UserProfiles up = new UserProfiles();
            up.Username = CreateUserWizard1.UserName;
            up.Owner = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Name")).Text;
            up.Name = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Name")).Text;
            up.Tel = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Tel")).Text;
            up.Corp = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Corp")).Text;
            up.City = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedValue;
            up.Postcode = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedValue;
            up.Address = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Address")).Text;
            up.Fax = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Fax")).Text;
            up.Kind = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue;
            up.Type = "1";
            up.Zipcht = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedValue +
                ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedItem.Text +
                ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedItem.Text;


            /* 配對 */
            String sql = "SELECT * FROM ReuseTech   ";
            sql += " WHERE type='2' and ((TechOther like @param1) or (WasteOther like @param2) or (TechName  like @param3) or (WasteName like @param4)) ";
         
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.Parameters.Add("param1", OleDbType.VarChar).Value = obj.Techother;
            cmd.Parameters.Add("param2", OleDbType.VarChar).Value = obj.Wasteother;
            cmd.Parameters.Add("param3", OleDbType.VarChar).Value = "%" + obj.Techname + "%";
            cmd.Parameters.Add("param4", OleDbType.VarChar).Value = "%" + obj.Wastename + "%";
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLUtil.QueryDS(cmd);

            ArrayList matchList = new ArrayList();
            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                Match match = new Match();
                user2 = Membership.GetUser(dRow["UserName"].ToString());
                p2 = (ProfileCommon)ProfileCommon.Create(dRow["UserName"].ToString(), true);
                match.Username1 = CreateUserWizard1.UserName;
                match.Username2 = dRow["UserName"].ToString();
                match.Rid2 = (int)dRow["Id"];
                match.Name1 = p.UserProfile.Name;
                match.Name2 = p2.UserProfile.Name;
                match.Corp1 = p.UserProfile.Corp;
                match.Corp2 = p2.UserProfile.Corp;
                match.Tel1 = p.UserProfile.Tel;
                match.Tel2 = p2.UserProfile.Tel;
                match.Wasteitem1 = obj.Wasteother;
                match.Wasteitem2 = dRow["WasteOther"].ToString();
                match.Wastename1 = obj.Wastename;
                match.Wastename2 = dRow["WasteName"].ToString();
                match.Techitem1 = obj.Techother;
                match.Techitem2 = dRow["TechOther"].ToString();
                match.Techname1 = obj.Techname;
                match.Techname2 = dRow["TechName"].ToString();
                match.Reusename1 = obj.Reusename;
                match.Reusename2 = dRow["ReuseName"].ToString();
                match.Matchdate = DateTime.Now;
                match.Ischecked = "A";
                match.Isdeleted = false;
                match.Isconfirm1 = "A";
                match.Isconfirm2 = "A";
                match.Isdroped1 = "A";
                match.Isdroped2 = "A";
                match.Createdate1 = DateTime.Now;
                match.Createdate2 = (DateTime)dRow["Createdate"];
                match.Isapproved1 = false;

                if (user2 != null)
                {
                    if (user2.IsApproved)
                        match.Isapproved2 = true;
                    else
                        match.Isapproved2 = false;
                }
                else
                {
                    match.Isapproved2 = false;
                }

                match.Techdesc = obj.Techdesc;
                match.Techadv = obj.Techadv;


                matchList.Add(match);
            }
            Save(obj, matchList, up);

            //mgr.Save(obj, matchList, up);
            //OleDbCommand cmd = new OleDbCommand("select * from Examples where Year=?");
            //cmd.Parameters.AddWithValue("?", e.CommandArgument.ToString());

            ((Label)CompleteWizardStep1.ContentTemplateContainer.FindControl("Msg")).Text = "您的帳號申請資料已經送出，請等待審核通知。";

             

            #region  Email     
            
            /* Mail */
            /* to 會員 */
            //Marquee objM = mgrM.getMarquee("B");

            String sqlMarquee = "SELECT * from Marquee where Id=?   ";
            OleDbCommand cmdM = new OleDbCommand(sqlMarquee);
            cmdM.Parameters.Add("?", OleDbType.VarChar).Value = "B";
            cmdM.CommandType = CommandType.Text;
            DataSet dsm = SQLUtil.QueryDS(cmdM);
            string strEmailMsg = "";
            foreach (DataRow dr in dsm.Tables[0].Rows)
            { 
                strEmailMsg=dr["Msg"].ToString();
            }
            
            //string

         

            SmtpClient sc = new SmtpClient("smtp.tgpf.org.tw");
            sc.Credentials = new System.Net.NetworkCredential("recycling@tgpf.org.tw", "IDB.riw@2018");
            string strMsg = "";
            string strTo = "";
            string strFrom = "";
            string strSubject = "資源化技術研發供需資訊平台通知";
            //strMsg += "帳號: " + CreateUserWizard1.UserName + "\n";
            //strMsg += "單位: " + p.UserProfile.Corp + "\n";
            //strMsg += "會員姓名: " + p.UserProfile.Name + "\n";
            //strMsg += "Email: " + ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Email")).Text + "\n";
            strMsg += "<p>" + p.UserProfile.Name + " 先生/小姐您好</p>";
            strMsg += "<p>感謝您加入「資源化技術研發供需資訊平台」 會員！！</p>";
            strMsg += "<p>目前正在審核您的會員資料，造成不便敬請見諒。</p>";
            strMsg += "<p>待審核後系統將主動通知您審核結果，</p>";
            strMsg += "<p>通過審核後即可再次登入「資源化技術研發供需資訊平台」，</p>";
            strMsg += "<p>獲得平台所提供的相關功能與服務！</p><br/><br/>";
            strMsg += "<p>此信件為系統自動發送，請勿直接回覆，謝謝。</p>";
            MembershipUser mng = Membership.GetUser("isrmng");
            strFrom = mng.Email;
            strTo = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Email")).Text;

            MailMessage msgMail = new MailMessage(strFrom, strTo);             
            msgMail.Subject = strSubject;
            msgMail.IsBodyHtml = true;
            msgMail.Body = strMsg;
            msgMail.CC.Add("wing@tgpf.org.tw");
            //sc.Send(msgMail);
            new util().SendMail(strFrom, strTo, strSubject, strMsg, "wing@tgpf.org.tw");

            /* to Manager */
            strSubject = "資源化技術研發供需資訊平台-新增會員通知";
            strMsg = "<p>學研機構</p>";
            strMsg += "<p>單位名稱:" + p.UserProfile.Corp + "</p>";
            strMsg += "<p>聯絡人:" + p.UserProfile.Name + "</p>";
            strMsg += "<p>地址:" + ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedItem.Text +
                ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedItem.Text +
                ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Address")).Text + "</p>";
            strMsg += "<p>電話:" + ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Tel")).Text + "</p>";
            if (strEmailMsg.Length > 0)
            {
                strMsg += "<p><a href=\"" + strEmailMsg + "\">" + strEmailMsg + "</a></p>";
            }
            //strMsg += "<p><a href=\"" + objM.Msg + "\">" + objM.Msg + "</a></p>";
            strTo = mng.Email;

            msgMail = new MailMessage(strFrom, strTo);     
            msgMail.Subject = strSubject;
            msgMail.IsBodyHtml = true;
            msgMail.Body = strMsg;
            msgMail.CC.Add("wing@tgpf.org.tw");
            new util().SendMail(strFrom, strTo, strSubject, strMsg, "wing@tgpf.org.tw");
            //sc.Send(msgMail);
            /* Mail End */
            
            #endregion
        }
        catch (Exception err)
        {
            Membership.DeleteUser(CreateUserWizard1.UserName, true);

            String strDelReuseTech = "delete from ReuseTech where UserName = @username";
            OleDbCommand cmdDelReuseTech = new OleDbCommand(strDelReuseTech);
            cmdDelReuseTech.Parameters.Add("@username", OleDbType.VarChar).Value = CreateUserWizard1.UserName;
            cmdDelReuseTech.CommandType = CommandType.Text;
            SQLUtil.ExecuteSql(cmdDelReuseTech);

            String strDelUserProfile = "delete from UserProfiles where UserName = @username";
            OleDbCommand cmdDelUserProfile = new OleDbCommand(strDelUserProfile);
            cmdDelUserProfile.Parameters.Add("@username", OleDbType.VarChar).Value = CreateUserWizard1.UserName;
            cmdDelUserProfile.CommandType = CommandType.Text;
            SQLUtil.ExecuteSql(cmdDelUserProfile);


            ((Label)CompleteWizardStep1.ContentTemplateContainer.FindControl("Msg")).Text = "錯誤: " + err.ToString();
        }


    }

    public void Save(ReuseTech obj, IList matchList, UserProfiles up)
    {
        #region  Save
      
        if (up != null)
        {
            
            String sqlUp = "";
            sqlUp=sqlUp+" insert into UserProfiles ([address],[city],[corp],[fax]	,[kind],[name],[owner],[postcode],[tel],[type],[username],[zipcht]) ";
            sqlUp=sqlUp+" values (@address,@city,@corp,@fax	,@kind,@name,@owner,@postcode,@tel,@type,@username,@zipcht)";
            OleDbCommand cmdM = new OleDbCommand(sqlUp);
            cmdM.Parameters.Add("@address", OleDbType.VarChar).Value=up.Address;
	        cmdM.Parameters.Add("@city", OleDbType.VarChar).Value=up.City;
	        cmdM.Parameters.Add("@corp", OleDbType.VarChar).Value=up.Corp;
	        cmdM.Parameters.Add("@fax", OleDbType.VarChar).Value=up.Fax;
	        cmdM.Parameters.Add("@kind", OleDbType.VarChar).Value=up.Kind;
	        cmdM.Parameters.Add("@name", OleDbType.VarChar).Value=up.Name;
	        cmdM.Parameters.Add("@owner", OleDbType.VarChar).Value=up.Owner;
	        cmdM.Parameters.Add("@postcode", OleDbType.VarChar).Value=up.Postcode;
	        cmdM.Parameters.Add("@tel", OleDbType.VarChar).Value=up.Tel;
	        cmdM.Parameters.Add("@type", OleDbType.VarChar).Value=up.Type;
	        cmdM.Parameters.Add("@username", OleDbType.VarChar).Value=up.Username;
	        cmdM.Parameters.Add("@zipcht", OleDbType.VarChar).Value=up.Zipcht;
            cmdM.CommandType = CommandType.Text;
            //SQLUtil.ExecuteSql(cmdM);
            object objUserProfile = SQLUtil.ExecuteScalar(cmdM);
            int intID = 0;
            if (obj != null && int.TryParse(obj.ToString(), out intID))
            {
                //mod.AccountsPayableID = intID;

                String sqlAspUser = "";
                sqlAspUser = sqlAspUser + " insert into aspnet_Users ([userid],[username],[mobilealias],[isanonymous]	,[lastactivitydate]) ";
                sqlAspUser = sqlAspUser + " values ( @userid,@username,@mobilealias,@isanonymous,@lastactivitydate)";

                OleDbCommand cmdAspUser = new OleDbCommand(sqlAspUser);
                cmdAspUser.Parameters.Add("@userid", OleDbType.VarChar).Value = up.Address;
                cmdAspUser.Parameters.Add("@username", OleDbType.VarChar).Value = up.Name;
                cmdAspUser.Parameters.Add("@mobilealias", OleDbType.VarChar).Value = "";
                cmdAspUser.Parameters.Add("@isanonymous", OleDbType.Boolean).Value = false;
                cmdAspUser.Parameters.Add("@lastactivitydate", OleDbType.Date).Value = DateTime.Now;
                cmdAspUser.CommandType = CommandType.Text;
                SQLUtil.ExecuteSql(cmdAspUser);



            }
  

            	
        }
        if (obj != null)
        {

            String sqlRT = "";
            sqlRT=sqlRT+" insert into ReuseTech (isapproved,patent,researchitem,reusename,techadv,techdesc,techitem,techname,techother,type,username,wasteitem,wastename,wasteother,createdate) ";
            sqlRT=sqlRT+" values (@isapproved,@patent,@researchitem,@reusename,@techadv,@techdesc,@techitem,@techname,@techother,@type,@username,@wasteitem,@wastename,@wasteother,@createdate)";
            OleDbCommand cmdRT = new OleDbCommand(sqlRT);
            cmdRT.Parameters.Add("@isapproved", OleDbType.Boolean).Value=obj.Isapproved;
	        cmdRT.Parameters.Add("@patent", OleDbType.VarChar).Value=obj.Patent;
            cmdRT.Parameters.Add("@researchitem", OleDbType.VarChar).Value=obj.Researchitem;
            cmdRT.Parameters.Add("@reusename", OleDbType.VarChar).Value=obj.Reusename;
            
            cmdRT.Parameters.Add("@techadv", OleDbType.VarChar).Value=obj.Techadv;
            cmdRT.Parameters.Add("@techdesc", OleDbType.VarChar).Value=obj.Techdesc;
            cmdRT.Parameters.Add("@techitem", OleDbType.VarChar).Value=obj.Techitem;
            cmdRT.Parameters.Add("@techname", OleDbType.VarChar).Value=obj.Techname;
            cmdRT.Parameters.Add("@techother", OleDbType.VarChar).Value=obj.Techother;
            cmdRT.Parameters.Add("@type", OleDbType.VarChar).Value=obj.Type;
            cmdRT.Parameters.Add("@username", OleDbType.VarChar).Value=obj.Username;
            
            cmdRT.Parameters.Add("@wasteitem", OleDbType.VarChar).Value=obj.Wasteitem;
            cmdRT.Parameters.Add("@wastename", OleDbType.VarChar).Value=obj.Wastename;
            cmdRT.Parameters.Add("@wasteother", OleDbType.VarChar).Value=obj.Wasteother;
            cmdRT.Parameters.Add("@createdate", OleDbType.Date).Value=obj.Createdate;
   
            SQLUtil.ExecuteSql(cmdRT);

            //HibernateTemplate.SaveOrUpdate(obj);

        }
        if (matchList != null)
        {
            foreach (Match item in matchList)
            {
                if (obj.Type.Equals("1"))
                    item.Rid1 = obj.Id; // ReuseTech 編號
                else
                    item.Rid2 = obj.Id; // ReuseTech 編號


                String sqlM = "";
                sqlM = sqlM + " insert into MatchList ([approveddate],[confirmdate1],[confirmdate2],[corp1],[corp2]";
                sqlM = sqlM + " ,[createdate1],[createdate2],[deletedate1],[deletedate2],[isapproved1],[isapproved2]";
                sqlM = sqlM + " ,[ischecked],[isconfirm1],[isconfirm2],[isdeleted],[isdeleted1],[isdeleted2],[isdroped1],[isdroped2],[matchdate],[name1],[name2]";
                sqlM = sqlM + " ,[reusename1],[reusename2],[rid1],[rid2],[techadv],[techdesc],[techitem1],[techitem2],[techname1],[techname2]";
                sqlM = sqlM + " ,[tel1],[tel2],[username1],[username2],[wasteitem1],[wasteitem2],[wastename1],[wastename2])";
                sqlM = sqlM + " values (@approveddate,@confirmdate1,@confirmdate2,@corp1,@corp2";
                sqlM = sqlM + " ,@createdate1,@createdate2,@deletedate1,@deletedate2,@isapproved1,@isapproved2";
                sqlM = sqlM + " ,@ischecked,@isconfirm1,@isconfirm2,@isdeleted,@isdeleted1,@isdeleted2,@isdroped1,@isdroped2,@matchdate,@name1,@name2";
                sqlM = sqlM + " ,@reusename1,@reusename2,@rid1,@rid2,@techadv,@techdesc,@techitem1,@techitem2,@techname1,@techname2";
                sqlM = sqlM + " ,@tel1,@tel2,@username1,@username2,@wasteitem1,@wasteitem2,@wastename1,@wastename2 )";
                OleDbCommand cmdM = new OleDbCommand(sqlM);

                cmdM.Parameters.Add("@approveddate", OleDbType.Date).Value=item.Approveddate;
                 cmdM.Parameters.Add("@confirmdate1", OleDbType.Date).Value=item.Confirmdate1;
                 cmdM.Parameters.Add("@confirmdate2", OleDbType.Date).Value=item.Confirmdate2;
                cmdM.Parameters.Add("@corp1", OleDbType.VarChar).Value = item.Isapproved1;
                cmdM.Parameters.Add("@corp2", OleDbType.VarChar).Value = item.Isapproved1;
                cmdM.Parameters.Add("@createdate1", OleDbType.Date).Value=item.Createdate1;
                cmdM.Parameters.Add("@createdate2", OleDbType.Date).Value=item.Createdate2;
                cmdM.Parameters.Add("@deletedate1", OleDbType.Date).Value=item.Deletedate1;
                cmdM.Parameters.Add("@deletedate2", OleDbType.Date).Value=item.Deletedate2;
                cmdM.Parameters.Add("@isapproved1", OleDbType.Boolean).Value = item.Isapproved1;
                cmdM.Parameters.Add("@isapproved2", OleDbType.Boolean).Value = item.Isapproved2;
                cmdM.Parameters.Add("@ischecked", OleDbType.VarChar).Value = item.Ischecked;
                cmdM.Parameters.Add("@isconfirm1", OleDbType.VarChar).Value = item.Isconfirm1;
                cmdM.Parameters.Add("@isconfirm2", OleDbType.VarChar).Value = item.Isconfirm2;
                cmdM.Parameters.Add("@isdeleted", OleDbType.Boolean).Value = item.Isdeleted;
                cmdM.Parameters.Add("@isdeleted1", OleDbType.Boolean).Value = item.Isdeleted1;
                cmdM.Parameters.Add("@isdeleted2", OleDbType.Boolean).Value = item.Isdeleted2;
                cmdM.Parameters.Add("@isdroped1", OleDbType.VarChar).Value = item.Isdroped1;
                cmdM.Parameters.Add("@isdroped2", OleDbType.VarChar).Value = item.Isdroped2;
                cmdM.Parameters.Add("@matchdate", OleDbType.Date).Value=item.Matchdate;
                cmdM.Parameters.Add("@name1", OleDbType.VarChar).Value = item.Name1;
                cmdM.Parameters.Add("@name2", OleDbType.VarChar).Value = item.Name2;
                cmdM.Parameters.Add("@reusename1", OleDbType.VarChar).Value = item.Reusename1;
                cmdM.Parameters.Add("@reusename2", OleDbType.VarChar).Value = item.Reusename2;
                cmdM.Parameters.Add("@rid1", OleDbType.Integer).Value=item.Rid1;
                cmdM.Parameters.Add("@rid2", OleDbType.Integer).Value=item.Rid2;
                cmdM.Parameters.Add("@techadv", OleDbType.VarChar).Value = item.Techadv;
                cmdM.Parameters.Add("@techdesc", OleDbType.VarChar).Value = item.Techdesc;
                cmdM.Parameters.Add("@techitem1", OleDbType.VarChar).Value = item.Techitem1;
                cmdM.Parameters.Add("@techitem2", OleDbType.VarChar).Value = item.Techitem2;
                cmdM.Parameters.Add("@techname1", OleDbType.VarChar).Value = item.Techname1;
                cmdM.Parameters.Add("@techname2", OleDbType.VarChar).Value = item.Techname2;
                cmdM.Parameters.Add("@tel1", OleDbType.VarChar).Value = item.Tel1;
                cmdM.Parameters.Add("@tel2", OleDbType.VarChar).Value = item.Tel2;
                cmdM.Parameters.Add("@username1", OleDbType.VarChar).Value = item.Username1;
                cmdM.Parameters.Add("@username2", OleDbType.VarChar).Value = item.Username2;
                cmdM.Parameters.Add("@wasteitem1", OleDbType.VarChar).Value = item.Wasteitem1;
                cmdM.Parameters.Add("@wasteitem2", OleDbType.VarChar).Value = item.Wasteitem2;
                cmdM.Parameters.Add("@wastename1", OleDbType.VarChar).Value = item.Wastename1;
                cmdM.Parameters.Add("@wastename2", OleDbType.VarChar).Value = item.Wastename2;
                SQLUtil.ExecuteSql(cmdM);

                //HibernateTemplate.Save(item);
            }
        }

        #endregion
    }

    protected void cityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList();
    }



    /*protected void CheckBtn_Click(object sender, EventArgs e)
    {
        if (((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text.Trim().Equals(""))
        {
            ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Text = "帳號未輸入";
            ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            at = SpringUtil.at();
            String sql = "SELECT  *  From vw_aspnet_Users   WHERE  UserName=@param1   ";
            IDbParameters parameters = at.CreateDbParameters();
            parameters.Add("param1", OleDbType.VarChar).Value = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;

            DataSet ds = new DataSet();
            at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

            if (ds.Tables[0].Rows.Count == 0)
            {
                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Text = "帳號可以註冊";
                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).ForeColor = System.Drawing.Color.Blue;
                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Visible = true;
            }
            else
            {

                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Text = "帳號已經被註冊";
                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).ForeColor = System.Drawing.Color.Red;
                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Visible = true;
            }
        }
    }*/


    protected void ContinueButton_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void CreateUserWizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        if (CreateUserWizard1.ActiveStepIndex == 0)
        {
            if ((((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("WasteItem")).SelectedValue.Equals("U") && ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("WasteOther")).Text.Trim().Equals("")) || (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("TechItem")).SelectedValue.Equals("V") && ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechOther")).Text.Trim().Equals("")))
            {
                Page.RegisterClientScriptBlock("checkinput", @"<script>alert('其他資料未填');</script>");
                e.Cancel = true;
            }
            else
            {
                //at = SpringUtil.at();
                String sql = "SELECT  *  From vw_aspnet_Users   WHERE  UserName=@param1   ";
                //IDbParameters parameters = at.CreateDbParameters();
                //parameters.Add("param1", OleDbType.VarChar).Value = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;

                //DataSet ds = new DataSet();
                //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

                OleDbCommand cmd = new OleDbCommand(sql);
                cmd.Parameters.Add("param1", OleDbType.VarChar).Value = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;
                cmd.CommandType = CommandType.Text;
                DataSet ds = SQLUtil.QueryDS(cmd);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserNameView")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;
                    ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Password")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Password")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("PasswordView")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Password")).Text;
                    ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ConfirmPassword")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("ConfirmPassword")).Text;

                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Corp")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Corp")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Address")).Text = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedValue +
                                        ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedItem.Text +
                                        ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedItem.Text +
                                        ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Address")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Name")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Name")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Tel")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Tel")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Fax")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Fax")).Text;

                    ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Email")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Email")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("EmailView")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Email")).Text;

                    if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue.Equals("A"))
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Kind")).Text = "學術單位";
                    else if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue.Equals("B"))
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Kind")).Text = "研究單位";
                    else if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue.Equals("C"))
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Kind")).Text = "其他";

                    if (!((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("TechItem")).SelectedValue.Equals("V"))
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TechItem")).Text = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("TechItem")).SelectedItem.Text;
                    else
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TechItem")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechOther")).Text;

                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TechName")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechName")).Text;

                    if (!((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("WasteItem")).SelectedValue.Equals("U"))
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("WasteItem")).Text = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("WasteItem")).SelectedItem.Text;
                    else
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("WasteItem")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("WasteOther")).Text;

                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("WasteName")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("WasteName")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ReuseName")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("ReuseName")).Text;

                    if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("ResearchItem")).SelectedValue.Equals("A"))
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ResearchItem")).Text = "已完成";
                    else if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("ResearchItem")).SelectedValue.Equals("B"))
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ResearchItem")).Text = "研發中";
                    else if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("ResearchItem")).SelectedValue.Equals("C"))
                        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ResearchItem")).Text = "擬新增";

                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Patent")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Patent")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TechAdv")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechAdv")).Text;
                    ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("TechDesc")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechDesc")).Text;
                }
                else
                {

                    //((CustomValidator)UserTemplate.ContentTemplateContainer.FindControl("CustomValidator1")).IsValid = false;
                    //((CustomValidator)UserTemplate.ContentTemplateContainer.FindControl("CustomValidator1")).ErrorMessage = "帳號已經被註冊";
                    //Response.Write("<script>alert('帳號已經被註冊')</script>");
                    Page.RegisterClientScriptBlock("checkinput", @"<script>alert('帳號已經被註冊');</script>");
                    e.Cancel = true;
                }
            }
        }

    }

    /*protected void UserName_TextChanged(object sender, EventArgs e)
    {
        if (((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text.Trim().Equals(""))
        {
            ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Text = "帳號未輸入";
            ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            at = SpringUtil.at();
            String sql = "SELECT  *  From vw_aspnet_Users   WHERE  UserName=@param1   ";
            IDbParameters parameters = at.CreateDbParameters();
            parameters.Add("param1", OleDbType.VarChar).Value = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;

            DataSet ds = new DataSet();
            at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

            if (ds.Tables[0].Rows.Count == 0)
            {

                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Visible = false;
            }
            else
            {
                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Text = "帳號已經被註冊";
                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).ForeColor = System.Drawing.Color.Red;
                ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Visible = true;
            }
        }

    }*/


}

