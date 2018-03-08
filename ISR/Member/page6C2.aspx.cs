using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

public partial class Member_page6C3 : System.Web.UI.Page
{
    //private IReuseTechService mgr = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");
    //private IParamService mgrParam = (IParamService)BaseAction.Context.GetObject("ParamService");
    //private IMatchService mgrMatch = (IMatchService)BaseAction.Context.GetObject("MatchService");

    private ProfileCommon p;
    private ProfileCommon p2;
    //private AdoTemplate at;
    private MembershipUser user;
    private MembershipUser user2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
            BindProfileView();
        }
    }


    private void BindProfileView()
    {
        user = Membership.GetUser(User.Identity.Name);
        p = Profile.GetProfile(User.Identity.Name);
        //((Label)GridView.FindControl("UsernameView")).Text = User.Identity.Name;
        ((Label)GridView.FindControl("CorpView")).Text = p.UserProfile.Corp;
        ((Label)GridView.FindControl("AddressView")).Text = p.UserProfile.Zipcht + p.UserProfile.Address;
        ((Label)GridView.FindControl("NameView")).Text = p.UserProfile.Name;
        ((Label)GridView.FindControl("TelView")).Text = p.UserProfile.Tel;
        ((Label)GridView.FindControl("FaxView")).Text = p.UserProfile.Fax;
        ((Label)GridView.FindControl("EmailView")).Text = user.Email;

        /*object[] param = new object[2];
        param[0] = "K";
        param[1] = p.UserProfile.Kind;

        Param obj = mgrParam.getParam(param);
        ((Label)GridView.FindControl("KindView")).Text = obj.Paramname;*/

        if (p.UserProfile.Kind.Equals("A"))
            ((Label)GridView.FindControl("KindView")).Text = "公民營處(清)理機構";
        else if (p.UserProfile.Kind.Equals("B"))
            ((Label)GridView.FindControl("KindView")).Text = "許可再利用機構";
        else if (p.UserProfile.Kind.Equals("C"))
            ((Label)GridView.FindControl("KindView")).Text = "公告再利用機構";
        else if (p.UserProfile.Kind.Equals("D"))
            ((Label)GridView.FindControl("KindView")).Text = "應回收廢棄物處理機構";
        else if (p.UserProfile.Kind.Equals("E"))
            ((Label)GridView.FindControl("KindView")).Text = "其他";

    }

    private void BindGrid()
    {
        try
        {
            //at = SpringUtil.at();
            String sql = "SELECT r.Id,r.Patent,r.ResearchItem,r.ReuseName,r.TechItem,r.TechName,r.TechOther,r.UserName,r.WasteItem,r.WasteName,r.WasteOther  ";
            sql += " from ReuseTech r   ";
            sql += " where r.UserName=@param1  order by  r.Id desc ";

            //IDbParameters parameters = at.CreateDbParameters();
            //parameters.Add("param1", OleDbType.VarChar).Value = User.Identity.Name;
            //DataSet ds = new DataSet();
            //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.Parameters.Add("param1", OleDbType.VarChar).Value = User.Identity.Name;
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLUtil.QueryDS(cmd);

            ReuseGrid.DataSource = ds;
            ReuseGrid.DataKeyNames = new string[] { "Id" };

            ReuseGrid.DataBind();

        }
        catch (Exception err)
        {
            Response.Write(err.ToString());
        }
    }

    protected void EditBtn1_Command(object sender, CommandEventArgs e)
    {
        DetailsView1.ChangeMode(DetailsViewMode.Edit);
        int id = int.Parse(e.CommandArgument.ToString());
        BindReuseData(id);
        MultiView1.ActiveViewIndex = 1;
    }

    private void BindReuseData(int id)
    {


        object[] param = new object[2];
        param[0] = id;
        param[1] = User.Identity.Name;


        String sql = "select * from ReuseTech where Id=@id and Username=param1";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@id", OleDbType.Integer).Value = id;
        cmd.Parameters.Add("param1", OleDbType.VarChar).Value = User.Identity.Name;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        //IList lists = mgr.getReuseTechList(param);
        DetailsView1.DataSource = ds;
        DetailsView1.DataKeyNames = new string[] { "Id" };
        DetailsView1.DataBind();

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        MultiView1.ActiveViewIndex = 0;
    }

    protected void cityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList(cityList.SelectedValue);
    }

    protected void TechItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)DetailsView1.FindControl("TechItem")).SelectedValue.Equals("V"))
        {
            ((TextBox)DetailsView1.FindControl("TechOther")).Visible = true;
        }
        else
        {
            ((TextBox)DetailsView1.FindControl("TechOther")).Visible = false;
        }

    }

    protected void WasteItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)DetailsView1.FindControl("WasteItem")).SelectedValue.Equals("U"))
        {
            ((TextBox)DetailsView1.FindControl("WasteOther")).Visible = true;
        }
        else
        {
            ((TextBox)DetailsView1.FindControl("WasteOther")).Visible = false;
        }
    }

    protected void TechItem2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)DetailsView1.FindControl("TechItem2")).SelectedValue.Equals("V"))
        {
            ((TextBox)DetailsView1.FindControl("TechOther2")).Visible = true;
        }
        else
        {
            ((TextBox)DetailsView1.FindControl("TechOther2")).Visible = false;
        }
    }

    protected void WasteItem2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)DetailsView1.FindControl("WasteItem2")).SelectedValue.Equals("U"))
        {
            ((TextBox)DetailsView1.FindControl("WasteOther2")).Visible = true;
        }
        else
        {
            ((TextBox)DetailsView1.FindControl("WasteOther2")).Visible = false;
        }
    }

    private void BindProfile()
    {
        user = Membership.GetUser(User.Identity.Name);
        p = Profile.GetProfile(User.Identity.Name);
        Owner.Text = p.UserProfile.Owner;
        Username.Text = User.Identity.Name;
        Corp.Text = p.UserProfile.Corp;
        Address.Text = p.UserProfile.Address;
        Name.Text = p.UserProfile.Name;
        Tel.Text = p.UserProfile.Tel;
        Fax.Text = p.UserProfile.Fax;
        Fax.Text = p.UserProfile.Fax;
        Email.Text = user.Email;
        OwnerView.Text = p.UserProfile.Owner;
        BindList(p.UserProfile.City);
        cityList.SelectedValue = p.UserProfile.City;
        zipList.SelectedValue = p.UserProfile.Postcode;
        Kind.SelectedValue = p.UserProfile.Kind;
    }

    protected void BindList(string city)
    {
        //at = SpringUtil.at();
        String sql = "SELECT Id,Name,Pid  ";
        sql += " from Zip where Pid=@param1    ";

        //IDbParameters parameters = at.CreateDbParameters();
        //parameters.Add("param1", OleDbType.Char).Value = city;
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.Char).Value = city;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        zipList.DataSource = ds;
        zipList.DataTextField = "Name";
        zipList.DataValueField = "Id";
        zipList.DataBind();
    }

    protected void setMatch(ReuseTech obj)
    {
        /* 配對 */
        //at = SpringUtil.at();
        String sql = "SELECT * FROM ReuseTech   ";
        sql += " WHERE type='1' and ((TechOther like @param1) or (WasteOther like @param2) or (TechName  like @param3) or (WasteName like @param4)) ";
        //IDbParameters parameters = at.CreateDbParameters();

        //parameters.Add("param1", OleDbType.VarChar).Value = obj.Techother;
        //parameters.Add("param2", OleDbType.VarChar).Value = obj.Wasteother;
        //parameters.Add("param3", OleDbType.VarChar).Value = "%" + obj.Techname + "%";
        //parameters.Add("param4", OleDbType.VarChar).Value = "%" + obj.Wastename + "%";
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("param1", OleDbType.VarChar).Value = obj.Techother;
        cmd.Parameters.Add("param2", OleDbType.VarChar).Value = obj.Wasteother;
        cmd.Parameters.Add("param3", OleDbType.VarChar).Value = "%" + obj.Techname + "%";
        cmd.Parameters.Add("param4", OleDbType.VarChar).Value = "%" + obj.Wastename + "%";
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        if (ds.Tables[0].Rows.Count > 0)
        {
            p = Profile.GetProfile(User.Identity.Name);
            ArrayList matchList = new ArrayList();
            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                Match match = new Match();
                user2 = Membership.GetUser(dRow["UserName"].ToString());
                p2 = (ProfileCommon)ProfileCommon.Create(dRow["UserName"].ToString(), true);
                match.Username2 = User.Identity.Name;
                match.Username1 = dRow["UserName"].ToString();
                match.Rid1 = (int)dRow["Id"];
                match.Name2 = p.UserProfile.Name;
                match.Name1 = p2.UserProfile.Name;
                match.Corp2 = p.UserProfile.Corp;
                match.Corp1 = p2.UserProfile.Corp;
                match.Tel2 = p.UserProfile.Tel;
                match.Tel1 = p2.UserProfile.Tel;
                match.Wasteitem2 = obj.Wasteother;
                match.Wasteitem1 = dRow["WasteOther"].ToString();
                match.Wastename2 = obj.Wastename;
                match.Wastename1 = dRow["WasteName"].ToString();
                match.Techitem2 = obj.Techother;
                match.Techitem1 = dRow["TechOther"].ToString();
                match.Techname2 = obj.Techname;
                match.Techname1 = dRow["TechName"].ToString();
                match.Reusename2 = obj.Reusename;
                match.Reusename1 = dRow["ReuseName"].ToString();
                match.Matchdate = DateTime.Now;
                match.Ischecked = "A";
                match.Isdeleted = false;
                match.Isconfirm2 = "A";
                match.Isconfirm1 = "A";
                match.Isdroped2 = "A";
                match.Isdroped1 = "A";
                match.Createdate2 = DateTime.Now;
                match.Createdate1 = (DateTime)dRow["Createdate"];
                match.Isapproved2 = true;
                if (user2.IsApproved)
                    match.Isapproved1 = true;
                else
                    match.Isapproved1 = false;
                match.Techdesc = dRow["TechDesc"].ToString();
                match.Techadv = dRow["TechAdv"].ToString();

                matchList.Add(match);
            }
            Save(obj, matchList);
            //mgr.Save(obj, matchList, null);

            /* Mail */
            MailMessage msgMail = new MailMessage();
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            string strMsg = "";
            string strTo = "";
            string strFrom = "";
            string strSubject = "資源化技術研發供需資訊平台-新增系統配對結果通知";
            strMsg += "<p>請管理者登入「研發合作對象名單」中審核系統自動配對之結果</p>";

            MembershipUser mng = Membership.GetUser("isrmng");
            strTo = mng.Email;
            strFrom = mng.Email;

            msgMail.To = strTo;
            msgMail.From = strFrom;
            msgMail.Subject = strSubject;
            msgMail.BodyFormat = MailFormat.Html;
            msgMail.Body = strMsg;
            msgMail.Cc = "wing@tgpf.org.tw";
            new util().SendMail(strFrom, strTo, strSubject, strMsg, "wing@tgpf.org.tw");
            //SmtpMail.Send(msgMail);
            /* Mail End */
        }
        else
        {
            EditReuseTech(obj);
            //mgr.Save(obj, null, null);
        }

    }

    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        if ((((DropDownList)DetailsView1.FindControl("WasteItem2")).SelectedValue.Equals("U") && ((TextBox)DetailsView1.FindControl("WasteOther2")).Text.Trim().Equals("")) || (((DropDownList)DetailsView1.FindControl("TechItem2")).SelectedValue.Equals("V") && ((TextBox)DetailsView1.FindControl("TechOther2")).Text.Trim().Equals("")))
        {
            Page.RegisterClientScriptBlock("checkinput", @"<script>alert('其他資料未填');</script>");
        }
        else
        {
            ReuseTech obj = new ReuseTech();
            obj.Username = User.Identity.Name;
            obj.Techitem = ((DropDownList)DetailsView1.FindControl("TechItem2")).SelectedValue;
            if (!obj.Techitem.Equals("V"))
                obj.Techother = ((DropDownList)DetailsView1.FindControl("TechItem2")).SelectedItem.Text;
            else
                obj.Techother = ((TextBox)DetailsView1.FindControl("TechOther2")).Text;
            obj.Techname = ((TextBox)DetailsView1.FindControl("TechName2")).Text;
            obj.Wasteitem = ((DropDownList)DetailsView1.FindControl("WasteItem2")).SelectedValue;
            if (!obj.Wasteitem.Equals("U"))
                obj.Wasteother = ((DropDownList)DetailsView1.FindControl("WasteItem2")).SelectedItem.Text;
            else
                obj.Wasteother = ((TextBox)DetailsView1.FindControl("WasteOther2")).Text;
            obj.Wastename = ((TextBox)DetailsView1.FindControl("WasteName2")).Text;
            obj.Reusename = ((TextBox)DetailsView1.FindControl("ReuseName2")).Text;
            obj.Type = "2";
            setMatch(obj);

            BindGrid();
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            MultiView1.ActiveViewIndex = 0;
        }

    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {

        if ((((DropDownList)DetailsView1.FindControl("WasteItem")).SelectedValue.Equals("U") && ((TextBox)DetailsView1.FindControl("WasteOther")).Text.Trim().Equals("")) || (((DropDownList)DetailsView1.FindControl("TechItem")).SelectedValue.Equals("V") && ((TextBox)DetailsView1.FindControl("TechOther")).Text.Trim().Equals("")))
        {
            Page.RegisterClientScriptBlock("checkinput", @"<script>alert('其他資料未填');</script>");
        }
        else
        {
            ReuseTech obj = GetReuseTech(int.Parse(((HiddenField)DetailsView1.FindControl("Id")).Value));
            string TechitemOld = obj.Techitem;
            string TechnameOld = obj.Techname;
            string WasteitemOld = obj.Wasteitem;
            string WastenameOld = obj.Wastename;


            obj.Techitem = ((DropDownList)DetailsView1.FindControl("TechItem")).SelectedValue;
            if (!obj.Techitem.Equals("V"))
                obj.Techother = ((DropDownList)DetailsView1.FindControl("TechItem")).SelectedItem.Text;
            else
                obj.Techother = ((TextBox)DetailsView1.FindControl("TechOther")).Text;
            obj.Techname = ((TextBox)DetailsView1.FindControl("TechName")).Text;
            obj.Wasteitem = ((DropDownList)DetailsView1.FindControl("WasteItem")).SelectedValue;
            if (!obj.Wasteitem.Equals("U"))
                obj.Wasteother = ((DropDownList)DetailsView1.FindControl("WasteItem")).SelectedItem.Text;
            else
                obj.Wasteother = ((TextBox)DetailsView1.FindControl("WasteOther")).Text;
            obj.Wastename = ((TextBox)DetailsView1.FindControl("WasteName")).Text;
            obj.Reusename = ((TextBox)DetailsView1.FindControl("ReuseName")).Text;
            obj.Type = "2";
            if (!obj.Techitem.Equals(TechitemOld) || !obj.Techname.Equals(TechnameOld) || !obj.Wasteitem.Equals(WasteitemOld) || !obj.Wastename.Equals(WastenameOld))
                setMatch(obj);
            else
                EditReuseTech(obj);
                //mgr.Save(obj, null, null);


            BindGrid();
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            MultiView1.ActiveViewIndex = 0;
        }
    }

    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        ReuseTech obj = GetReuseTech(int.Parse(((HiddenField)DetailsView1.FindControl("Id")).Value));
        String sqlReuseTechDel = " delete from ReuseTech where Id =@id ";
        OleDbCommand cmdReuseTechDel = new OleDbCommand(sqlReuseTechDel);
        cmdReuseTechDel.Parameters.Add("@id", OleDbType.Integer).Value = (int.Parse(((HiddenField)DetailsView1.FindControl("Id")).Value));
        SQLUtil.ExecuteSql(cmdReuseTechDel);

        //at = SpringUtil.at();
        String sql = "SELECT * FROM MatchList WHERE Rid2=@param1 ";
        //IDbParameters parameters = at.CreateDbParameters();
        //parameters.Add("param1", OleDbType.Integer).Value = obj.Id;
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.Integer).Value = obj.Id;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        ArrayList matchList = null;
        if (ds.Tables[0].Rows.Count > 0)
        {
            matchList = new ArrayList();
            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                //Match match = mgrMatch.getMatch((int)dRow["Id"]);
                //match.Isdeleted = true;
                //match.Isdeleted2 = true;
                //match.Deletedate2 = DateTime.Now;
                //matchList.Add(match);

                String sqlMatchUp = " Update MatchList  ";
                sqlMatchUp = sqlMatchUp + " Set  Isdeleted=@Isdeleted,";
                sqlMatchUp = sqlMatchUp + " Isdeleted2=@Isdeleted2,  ";
                sqlMatchUp = sqlMatchUp + " Deletedate2=@Deletedate2 ";
                sqlMatchUp = sqlMatchUp + " where id=@id ";
                OleDbCommand cmdMatchDel = new OleDbCommand(sqlMatchUp);
                cmdMatchDel.Parameters.Add("@Deletedate2", OleDbType.Date).Value = DateTime.Now;
                cmdMatchDel.Parameters.Add("@Isdeleted", OleDbType.Boolean).Value = true;
                cmdMatchDel.Parameters.Add("@Isdeleted2", OleDbType.Boolean).Value = true;
                cmdMatchDel.Parameters.Add("@id", OleDbType.Integer).Value = (int)dRow["Id"];
                SQLUtil.ExecuteSql(cmdMatchDel);

            }
        }
        //mgr.Delete(obj, null, matchList);
        BindGrid();
        MultiView1.ActiveViewIndex = 0;
    }


    protected void BtnUpdate2_Click(object sender, EventArgs e)
    {
        //IAspnetUsersService mgrUser = (IAspnetUsersService)BaseAction.Context.GetObject("AspnetUsersService");
        //IMembershipService mgrMember = (IMembershipService)BaseAction.Context.GetObject("MembershipService");

        String sql = "SELECT * from aspnet_Users where UserName=@UserName ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@UserName", OleDbType.Char).Value = User.Identity.Name;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);
        string strUserID = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            strUserID = dr["UserId"].ToString();
        }


        string strMemberShipSql = "update  aspnet_Membership set Email=@Email  where  UserId=@UserId";
        OleDbCommand cmdMemberShip = new OleDbCommand(strMemberShipSql);
        cmdMemberShip.Parameters.Add("@Email", OleDbType.Char).Value = Email.Text;
        cmdMemberShip.Parameters.Add("@UserId", OleDbType.Char).Value = strUserID;
        cmdMemberShip.CommandType = CommandType.Text;
        SQLUtil.ExecuteSql(cmdMemberShip);
        //AspnetUsers aspnetUsers = mgrUser.FindByProperty(User.Identity.Name);
        //AspnetMembership aspnetMembership = mgrMember.FindById(aspnetUsers.UserId);
        //aspnetMembership.Email = Email.Text;
        //mgrMember.Update(aspnetMembership);

        p = Profile.GetProfile(User.Identity.Name);
        p.UserProfile.Owner = Owner.Text;
        p.UserProfile.Name = Name.Text;
        p.UserProfile.Tel = Tel.Text;
        p.UserProfile.Corp = Corp.Text;
        p.UserProfile.City = cityList.SelectedValue;
        p.UserProfile.Postcode = zipList.SelectedValue;
        p.UserProfile.Address = Address.Text;
        p.UserProfile.Fax = Fax.Text;
        p.UserProfile.Kind = Kind.SelectedValue;
        //p.UserProfile.Type = "1";
        p.UserProfile.Zipcht = zipList.SelectedValue +
                cityList.SelectedItem.Text +
                zipList.SelectedItem.Text;
        p.Save();

        BindProfileView();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void BtnCancel2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void EditLinkBtn_Click(object sender, EventArgs e)
    {
        BindProfile();
        MultiView1.ActiveViewIndex = 2;
    }

    protected void NewLinkBtn_Click(object sender, EventArgs e)
    {
        DetailsView1.ChangeMode(DetailsViewMode.Insert);
        MultiView1.ActiveViewIndex = 1;

    }

    protected void LogoutBtn_Click(object sender, EventArgs e)
    {
        Response.Clear();
        FormsAuthentication.SignOut();
        Response.Redirect("../Default.aspx");
    }

    protected void ContinuePushButton_Command(object sender, CommandEventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void PwdBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
    }

    protected void Reuse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ReuseGrid.PageIndex = e.NewPageIndex;
        BindGrid();
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


    public void EditReuseTech(ReuseTech obj)
    {
        #region  Edit


        if (obj != null)
        {
            String sqlRT = "";
            sqlRT = sqlRT + " update ReuseTech ";
            sqlRT = sqlRT + " set isapproved=@isapproved, ";
            sqlRT = sqlRT + " patent=@patent, ";
            sqlRT = sqlRT + " researchitem=@researchitem, ";
            sqlRT = sqlRT + " reusename=@reusename, ";
            sqlRT = sqlRT + " techadv=@techadv, ";
            sqlRT = sqlRT + " techdesc=@techdesc, ";
            sqlRT = sqlRT + " techitem=@techitem, ";
            sqlRT = sqlRT + " techname=@techname, ";
            sqlRT = sqlRT + " techother=@techother, ";
            sqlRT = sqlRT + " type=@type, ";
            sqlRT = sqlRT + " username=@username, ";
            sqlRT = sqlRT + " wasteitem=@wasteitem, ";
            sqlRT = sqlRT + " wastename=@wastename, ";
            sqlRT = sqlRT + " wasteother=@wasteother, ";
            sqlRT = sqlRT + " createdate=@createdate ";
            sqlRT = sqlRT + " where id=@id ";

            OleDbCommand cmdRT = new OleDbCommand(sqlRT);
            cmdRT.Parameters.Add("@isapproved", OleDbType.Boolean).Value = obj.Isapproved;
            cmdRT.Parameters.Add("@patent", OleDbType.VarChar).Value = obj.Patent;
            cmdRT.Parameters.Add("@researchitem", OleDbType.VarChar).Value = obj.Researchitem;
            cmdRT.Parameters.Add("@reusename", OleDbType.VarChar).Value = obj.Reusename;
            cmdRT.Parameters.Add("@techadv", OleDbType.VarChar).Value = obj.Techadv;
            cmdRT.Parameters.Add("@techdesc", OleDbType.VarChar).Value = obj.Techdesc;
            cmdRT.Parameters.Add("@techitem", OleDbType.VarChar).Value = obj.Techitem;
            cmdRT.Parameters.Add("@techname", OleDbType.VarChar).Value = obj.Techname;
            cmdRT.Parameters.Add("@techother", OleDbType.VarChar).Value = obj.Techother;
            cmdRT.Parameters.Add("@type", OleDbType.VarChar).Value = obj.Type;
            cmdRT.Parameters.Add("@username", OleDbType.VarChar).Value = obj.Username;
            cmdRT.Parameters.Add("@wasteitem", OleDbType.VarChar).Value = obj.Wasteitem;
            cmdRT.Parameters.Add("@wastename", OleDbType.VarChar).Value = obj.Wastename;
            cmdRT.Parameters.Add("@wasteother", OleDbType.VarChar).Value = obj.Wasteother;
            cmdRT.Parameters.Add("@createdate", OleDbType.Date).Value = obj.Createdate;
            cmdRT.Parameters.Add("@id", OleDbType.Integer).Value = obj.Id;
            SQLUtil.ExecuteSql(cmdRT);

            //HibernateTemplate.SaveOrUpdate(obj);

        }


        #endregion
    }

    public void Save(ReuseTech obj, IList matchList)
    {
        #region  Save


        if (obj != null)
        {

            String sqlRT = "";
            sqlRT = sqlRT + " insert into ReuseTech (isapproved,patent,researchitem,reusename,techadv,techdesc,techitem,techname,techother,type,username,wasteitem,wastename,wasteother,createdate) ";
            sqlRT = sqlRT + " values (@isapproved,@patent,@researchitem,@reusename,@techadv,@techdesc,@techitem,@techname,@techother,@type,@username,@wasteitem,@wastename,@wasteother,@createdate)";
            OleDbCommand cmdRT = new OleDbCommand(sqlRT);
            cmdRT.Parameters.Add("@isapproved", OleDbType.Boolean).Value = obj.Isapproved;
            cmdRT.Parameters.Add("@patent", OleDbType.VarChar).Value = SQLUtil.CheckDBValue(obj.Patent);
            cmdRT.Parameters.Add("@researchitem", OleDbType.VarChar).Value = SQLUtil.CheckDBValue(obj.Researchitem);
            cmdRT.Parameters.Add("@reusename", OleDbType.VarChar).Value = obj.Reusename;
            cmdRT.Parameters.Add("@techadv", OleDbType.VarChar).Value = SQLUtil.CheckDBValue(obj.Techadv);
            cmdRT.Parameters.Add("@techdesc", OleDbType.VarChar).Value = SQLUtil.CheckDBValue(obj.Techdesc); 
            cmdRT.Parameters.Add("@techitem", OleDbType.VarChar).Value = obj.Techitem;
            cmdRT.Parameters.Add("@techname", OleDbType.VarChar).Value = obj.Techname;
            cmdRT.Parameters.Add("@techother", OleDbType.VarChar).Value = obj.Techother;
            cmdRT.Parameters.Add("@type", OleDbType.VarChar).Value = obj.Type;
            cmdRT.Parameters.Add("@username", OleDbType.VarChar).Value = obj.Username;
            cmdRT.Parameters.Add("@wasteitem", OleDbType.VarChar).Value = obj.Wasteitem;
            cmdRT.Parameters.Add("@wastename", OleDbType.VarChar).Value = obj.Wastename;
            cmdRT.Parameters.Add("@wasteother", OleDbType.VarChar).Value = obj.Wasteother;
            cmdRT.Parameters.Add("@createdate", OleDbType.Date).Value = obj.Createdate;

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

                cmdM.Parameters.Add("@approveddate", OleDbType.Date).Value = item.Approveddate;
                cmdM.Parameters.Add("@confirmdate1", OleDbType.Date).Value = item.Confirmdate1;
                cmdM.Parameters.Add("@confirmdate2", OleDbType.Date).Value = item.Confirmdate2;
                cmdM.Parameters.Add("@corp1", OleDbType.VarChar).Value = item.Isapproved1;
                cmdM.Parameters.Add("@corp2", OleDbType.VarChar).Value = item.Isapproved1;
                cmdM.Parameters.Add("@createdate1", OleDbType.Date).Value = item.Createdate1;
                cmdM.Parameters.Add("@createdate2", OleDbType.Date).Value = item.Createdate2;
                cmdM.Parameters.Add("@deletedate1", OleDbType.Date).Value = item.Deletedate1;
                cmdM.Parameters.Add("@deletedate2", OleDbType.Date).Value = item.Deletedate2;
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
                cmdM.Parameters.Add("@matchdate", OleDbType.Date).Value = item.Matchdate;
                cmdM.Parameters.Add("@name1", OleDbType.VarChar).Value = item.Name1;
                cmdM.Parameters.Add("@name2", OleDbType.VarChar).Value = item.Name2;
                cmdM.Parameters.Add("@reusename1", OleDbType.VarChar).Value = item.Reusename1;
                cmdM.Parameters.Add("@reusename2", OleDbType.VarChar).Value = item.Reusename2;
                cmdM.Parameters.Add("@rid1", OleDbType.Integer).Value = item.Rid1;
                cmdM.Parameters.Add("@rid2", OleDbType.Integer).Value = item.Rid2;
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
}
