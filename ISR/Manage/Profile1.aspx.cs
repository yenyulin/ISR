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

public partial class Manage_Profile1 : System.Web.UI.Page
{
    //private IReuseTechService mgr = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");
    //private IParamService mgrParam = (IParamService)BaseAction.Context.GetObject("ParamService");
    //private IUserProfilesService mgrUp = (IUserProfilesService)BaseAction.Context.GetObject("UserProfilesService");
    //private IMatchService mgrMatch = (IMatchService)BaseAction.Context.GetObject("MatchService");

    private ProfileCommon p;
    private ProfileCommon p2;
    private AdoTemplate at;
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
        user = Membership.GetUser(Request.QueryString["Username"].ToString());
        p = Profile.GetProfile(Request.QueryString["Username"].ToString());
        //((Label)GridView.FindControl("UsernameView")).Text = Request.QueryString["Username"].ToString();
        ((Label)GridView.FindControl("CorpView")).Text = p.UserProfile.Corp;
        ((Label)GridView.FindControl("AddressView")).Text = p.UserProfile.Zipcht + p.UserProfile.Address;
        ((Label)GridView.FindControl("NameView")).Text = p.UserProfile.Name;
        ((Label)GridView.FindControl("TelView")).Text = p.UserProfile.Tel;
        ((Label)GridView.FindControl("FaxView")).Text = p.UserProfile.Fax;
        ((Label)GridView.FindControl("EmailView")).Text = user.Email;
        ((Label)GridView.FindControl("UserNameView")).Text = Request.QueryString["Username"].ToString();
        ((Label)GridView.FindControl("PwdView")).Text = user.GetPassword();
        /*object[] param = new object[2];
        param[0] = "K";
        param[1] = p.UserProfile.Kind;

        Param obj = mgrParam.getParam(param);
        ((Label)GridView.FindControl("KindView")).Text = obj.Paramname;*/


        if (p.UserProfile.Kind.Equals("A"))
            ((Label)GridView.FindControl("KindView")).Text = "學術單位";
        else if (p.UserProfile.Kind.Equals("B"))
            ((Label)GridView.FindControl("KindView")).Text = "研究單位";
        else if (p.UserProfile.Kind.Equals("C"))
            ((Label)GridView.FindControl("KindView")).Text = "其他";

    }

    private void BindGrid()
    {
        try
        {

            //at = SpringUtil.at();
            String sql = "SELECT r.Id,r.Patent,r.ResearchItem,r.ReuseName,r.TechItem,r.TechName,r.TechOther,r.UserName,r.WasteItem,r.WasteName,r.WasteOther,p.ParamName ";
            sql += " from ReuseTech r , Param p  ";
            sql += " where r.UserName=@param1 and r.ResearchItem=p.ParamCode and p.ParamId='R' order by  r.Id desc ";

            //IDbParameters parameters = at.CreateDbParameters();
            //parameters.Add("param1", OleDbType.VarChar).Value = Request.QueryString["Username"].ToString();
            //DataSet ds = new DataSet();
            //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.Parameters.Add("@param1", OleDbType.VarChar).Value = Request.QueryString["Username"].ToString();
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
        param[1] = Request.QueryString["Username"].ToString();



        String sql = "SELECT *   from ReuseTech where Id=@id and Username=@Username";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@id", OleDbType.VarChar).Value = param[0];
        cmd.Parameters.Add("@Username", OleDbType.VarChar).Value = param[1];
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
        user = Membership.GetUser(Request.QueryString["Username"].ToString());
        p = Profile.GetProfile(Request.QueryString["Username"].ToString());

        Username.Text = Request.QueryString["Username"].ToString();
        Corp.Text = p.UserProfile.Corp;
        Address.Text = p.UserProfile.Address;
        Name.Text = p.UserProfile.Name;
        Tel.Text = p.UserProfile.Tel;
        Fax.Text = p.UserProfile.Fax;
        Fax.Text = p.UserProfile.Fax;
        Email.Text = user.Email;

        BindList(p.UserProfile.City);
        cityList.SelectedValue = p.UserProfile.City;
        zipList.SelectedValue = p.UserProfile.Postcode;
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
        sql += " WHERE type='2' and ((TechOther like @param1) or (WasteOther like @param2) or (TechName  like @param3) or (WasteName like @param4)) ";

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
            p = Profile.GetProfile(Request.QueryString["Username"].ToString());
            ArrayList matchList = new ArrayList();
            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                Match match = new Match();
                user2 = Membership.GetUser(dRow["UserName"].ToString());
                p2 = (ProfileCommon)ProfileCommon.Create(dRow["UserName"].ToString(), true);
                match.Username1 = Request.QueryString["Username"].ToString();
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
                match.Isapproved1 = true;
                if (user2.IsApproved)
                    match.Isapproved2 = true;
                else
                    match.Isapproved2 = false;
                match.Techdesc = obj.Techdesc;
                match.Techadv = obj.Techadv;

                matchList.Add(match);
            }

            //mgr.Save(obj, matchList, null);
            Save(obj, matchList);

        }
        else
        {
            //mgr.Save(obj, null, null);
            EditReuseTech(obj);
        }

    }

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
            cmdRT.Parameters.Add("@patent", OleDbType.VarChar).Value = SQLUtil.CheckDBValue(obj.Patent);
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

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        ReuseTech obj = GetReuseTech(int.Parse(((HiddenField)DetailsView1.FindControl("Id")).Value));
        //ReuseTech obj = mgr.getReuseTech(int.Parse(((HiddenField)DetailsView1.FindControl("Id")).Value));
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
        obj.Researchitem = ((DropDownList)DetailsView1.FindControl("ResearchItem")).SelectedValue;
        obj.Patent = ((TextBox)DetailsView1.FindControl("Patent")).Text;
        obj.Techadv = ((TextBox)DetailsView1.FindControl("TechAdv")).Text;
        obj.Techdesc = ((TextBox)DetailsView1.FindControl("TechDesc")).Text;
        obj.Type = "1";
        if (!obj.Techitem.Equals(TechitemOld) || !obj.Techname.Equals(TechnameOld) || !obj.Wasteitem.Equals(WasteitemOld) || !obj.Wastename.Equals(WastenameOld))
            setMatch(obj);
        else
            //Wmgr.Save(obj, null, null);  xxx edit
            EditReuseTech(obj);
        BindGrid();
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        MultiView1.ActiveViewIndex = 0;
    }

    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        //ReuseTech obj = GetReuseTech(int.Parse(((HiddenField)DetailsView1.FindControl("Id")).Value));

        String sqlReuseTechDel = " delete from ReuseTech where Id =@id ";
        OleDbCommand cmdReuseTechDel = new OleDbCommand(sqlReuseTechDel);
        cmdReuseTechDel.Parameters.Add("@id", OleDbType.Integer).Value = (int.Parse(((HiddenField)DetailsView1.FindControl("Id")).Value));
        SQLUtil.ExecuteSql(cmdReuseTechDel);

        //ReuseTech obj = mgr.getReuseTech(int.Parse(((HiddenField)DetailsView1.FindControl("Id")).Value));
        //at = SpringUtil.at();
        String sql = "SELECT * FROM MatchList WHERE Rid1=@param1 ";
        //IDbParameters parameters = at.CreateDbParameters();
        //parameters.Add("param1", OleDbType.Integer).Value = obj.Id;
        //DataSet ds = new DataSet();
        //at.DataSetFillWithParameters(ds, CommandType.Text, sql, parameters);

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.Integer).Value = (int.Parse(((HiddenField)DetailsView1.FindControl("Id")).Value));
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        ArrayList matchList = null;
        if (ds.Tables[0].Rows.Count > 0)
        {
            matchList = new ArrayList();
            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                String sqlMatchUp = " Update MatchList  ";
                sqlMatchUp = sqlMatchUp + " Set  Isdeleted=@Isdeleted,";
                sqlMatchUp = sqlMatchUp + " Isdeleted1=@Isdeleted1,  ";
                sqlMatchUp = sqlMatchUp + " Deletedate1=@Deletedate1 ";
                sqlMatchUp = sqlMatchUp + " where id=@id ";
                OleDbCommand cmdMatchDel = new OleDbCommand(sqlMatchUp);
                cmdMatchDel.Parameters.Add("@Deletedate1", OleDbType.Date).Value = DateTime.Now;
                cmdMatchDel.Parameters.Add("@Isdeleted", OleDbType.Boolean).Value = true;
                cmdMatchDel.Parameters.Add("@Isdeleted1", OleDbType.Boolean).Value = true;
                cmdMatchDel.Parameters.Add("@id", OleDbType.Integer).Value = (int)dRow["Id"];
                SQLUtil.ExecuteSql(cmdMatchDel);


                //Match match = mgrMatch.getMatch((int)dRow["Id"]);
                //match.Isdeleted = true;
                //match.Isdeleted1 = true;
                //match.Deletedate1 = DateTime.Now;
                //matchList.Add(match);
            }
        }
        //mgr.Delete(obj, null, matchList);
        BindGrid();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        ReuseTech obj = new ReuseTech();
        obj.Username = Request.QueryString["Username"].ToString();
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
        obj.Researchitem = ((DropDownList)DetailsView1.FindControl("ResearchItem2")).SelectedValue;
        obj.Patent = ((TextBox)DetailsView1.FindControl("Patent2")).Text;
        obj.Techadv = ((TextBox)DetailsView1.FindControl("TechAdv2")).Text;
        obj.Techdesc = ((TextBox)DetailsView1.FindControl("TechDesc2")).Text;
        obj.Type = "1";

        setMatch(obj);


        BindGrid();
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        MultiView1.ActiveViewIndex = 0;



    }

    protected void BtnUpdate2_Click(object sender, EventArgs e)
    {
        //IAspnetUsersService mgrUser = (IAspnetUsersService)BaseAction.Context.GetObject("AspnetUsersService");
        //IMembershipService mgrMember = (IMembershipService)BaseAction.Context.GetObject("MembershipService");        

        //AspnetUsers aspnetUsers = mgrUser.FindByProperty(Request.QueryString["Username"].ToString());
        //AspnetMembership aspnetMembership = mgrMember.FindById(aspnetUsers.UserId);
        //aspnetMembership.Email = Email.Text;
        //mgrMember.Update(aspnetMembership);

        String sql = "SELECT * FROM aspnet_Users WHERE Username=@param1 ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@param1", OleDbType.VarChar).Value = Request.QueryString["Username"].ToString();
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        string strUserID = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        { 
            strUserID=dr["UserId"].ToString();
        }

        if (strUserID.Length > 0)
        {
            String sqlUpMemberShip = " Update aspnet_Membership set Email=@Email WHERE UserID=@UserID ";
            OleDbCommand cmdUpMemberShip = new OleDbCommand(sqlUpMemberShip);
            cmdUpMemberShip.Parameters.Add("@UserID", OleDbType.Integer).Value = Convert.ToInt32(strUserID);
            cmdUpMemberShip.Parameters.Add("@Email", OleDbType.VarChar).Value = Email.Text;

            cmdUpMemberShip.CommandType = CommandType.Text;
            SQLUtil.ExecuteSql(cmdUpMemberShip);

            //DataSet ds = SQLUtil.QueryDS(cmd);
        }


        p = Profile.GetProfile(Request.QueryString["Username"].ToString());
        p.UserProfile.Owner = Name.Text;
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


        /* UserProfiles */
        //UserProfiles up = mgrUp.getUserProfiles(Request.QueryString["Username"].ToString());
        //up.Owner = Name.Text;
        //up.Name = Name.Text;
        //up.Tel = Tel.Text;
        //up.Corp = Corp.Text;
        //up.City = cityList.SelectedValue;
        //up.Postcode = zipList.SelectedValue;
        //up.Address = Address.Text;
        //up.Fax = Fax.Text;
        //up.Kind = Kind.SelectedValue;
        //up.Type = "1";
        //up.Zipcht = zipList.SelectedValue +
        //        cityList.SelectedItem.Text +
        //        zipList.SelectedItem.Text;
        //mgrUp.Save(up);

        String sqlUp = "";
        sqlUp = sqlUp + " Update UserProfiles ";
        sqlUp = sqlUp + " set owner=@owner, ";
        sqlUp = sqlUp + " name=@name, ";
        sqlUp = sqlUp + " tel=@tel, ";
        sqlUp = sqlUp + " corp=@corp, ";
        sqlUp = sqlUp + " city=@city, ";
        sqlUp = sqlUp + " postcode=@postcode, ";
        sqlUp = sqlUp + " address=@address, ";
        sqlUp = sqlUp + " fax=@fax, ";
        sqlUp = sqlUp + " kind=@kind, ";
        sqlUp = sqlUp + " type=@type, ";
        sqlUp = sqlUp + " zipcht=@zipcht ";
        sqlUp = sqlUp + " where  username=@username";

        OleDbCommand cmdM = new OleDbCommand(sqlUp);
        cmdM.Parameters.Add("@owner", OleDbType.VarChar).Value = Name.Text;
        cmdM.Parameters.Add("@name", OleDbType.VarChar).Value = Name.Text;
        cmdM.Parameters.Add("@tel", OleDbType.VarChar).Value = Tel.Text;
        cmdM.Parameters.Add("@corp", OleDbType.VarChar).Value = Corp.Text;
        cmdM.Parameters.Add("@city", OleDbType.VarChar).Value = cityList.SelectedValue;
        cmdM.Parameters.Add("@postcode", OleDbType.VarChar).Value = zipList.SelectedValue;
        cmdM.Parameters.Add("@address", OleDbType.VarChar).Value = Address.Text;
        cmdM.Parameters.Add("@fax", OleDbType.VarChar).Value = Fax.Text;
        cmdM.Parameters.Add("@kind", OleDbType.VarChar).Value = Kind.SelectedValue;
        cmdM.Parameters.Add("@type", OleDbType.VarChar).Value = "1";
        cmdM.Parameters.Add("@zipcht", OleDbType.VarChar).Value = zipList.SelectedValue + cityList.SelectedItem.Text + zipList.SelectedItem.Text;
        cmdM.Parameters.Add("@username", OleDbType.VarChar).Value = Request.QueryString["Username"].ToString();
        
        cmdM.CommandType = CommandType.Text;
        SQLUtil.ExecuteSql(cmdM);
        //object objUserProfile = SQLUtil.ExecuteScalar(cmdM);

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
        Response.Redirect("Default.aspx");
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.close();}</script>");

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
