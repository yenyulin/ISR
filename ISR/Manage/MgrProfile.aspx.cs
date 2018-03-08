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

public partial class Manage_MgrProfile : System.Web.UI.Page
{
    private MembershipUser user;
    private ProfileCommon p;
    //private AdoTemplate at;
    //private IUserProfilesService mgrUp = (IUserProfilesService)BaseAction.Context.GetObject("UserProfilesService");


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindProfile();
        }
    }


    protected void cityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList(cityList.SelectedValue);
    }


    private void BindProfile()
    {
        user = Membership.GetUser(User.Identity.Name);
        p = Profile.GetProfile(User.Identity.Name);

        Username.Text = User.Identity.Name;
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
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            strUserID = dr["UserId"].ToString();
        }

   
        string strMemberShipSql ="update  aspnet_Membership set Email=@Email  where  UserId=@UserId";
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
        p.UserProfile.Owner = Name.Text;
        p.UserProfile.Name = Name.Text;
        p.UserProfile.Tel = Tel.Text;
        p.UserProfile.Corp = Corp.Text;
        p.UserProfile.City = cityList.SelectedValue;
        p.UserProfile.Postcode = zipList.SelectedValue;
        p.UserProfile.Address = Address.Text;
        p.UserProfile.Fax = Fax.Text;
        p.UserProfile.Kind = Kind.SelectedValue;
        p.UserProfile.Type = "1";
        p.UserProfile.Zipcht = zipList.SelectedValue +
                cityList.SelectedItem.Text +
                zipList.SelectedItem.Text;
        p.Save();

        /* UserProfiles */
        /*  UserProfiles up = mgrUp.getUserProfiles(User.Identity.Name);
        up.Owner = Name.Text;
        up.Name = Name.Text;
        up.Tel = Tel.Text;
        up.Corp = Corp.Text;
        up.City = cityList.SelectedValue;
        up.Postcode = zipList.SelectedValue;
        up.Address = Address.Text;
        up.Fax = Fax.Text;
        up.Kind = Kind.SelectedValue;
        //p.Type = "1";
        up.Zipcht = zipList.SelectedValue +
                cityList.SelectedItem.Text +
                zipList.SelectedItem.Text;
        mgrUp.Save(up);*/

           String sqlUp = "";
        sqlUp = sqlUp + " update UserProfiles ";
        sqlUp = sqlUp + " set Owner = @Owner, ";        
        sqlUp = sqlUp + " Name = @Name, ";
        sqlUp = sqlUp + " Tel = @Tel, ";
        sqlUp = sqlUp + " Corp =@Corp, ";
        sqlUp = sqlUp + " City =@City, ";
        sqlUp = sqlUp + " Postcode = @Postcode, ";
        sqlUp = sqlUp + " Address =@Address, ";
        sqlUp = sqlUp + " Fax = @Fax, ";
        sqlUp = sqlUp + " Kind = Kind.SelectedValue, ";
        //p.Type = "1";
        sqlUp = sqlUp + " Zipcht = @Zipcht  ";
         sqlUp = sqlUp + " where username=@username  ";

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
        //cmdM.Parameters.Add("@type", OleDbType.VarChar).Value = up.Type;
        cmdM.Parameters.Add("@zipcht", OleDbType.VarChar).Value = zipList.SelectedValue +cityList.SelectedItem.Text +zipList.SelectedItem.Text;

        cmdM.Parameters.Add("@username", OleDbType.VarChar).Value = User.Identity.Name;
        
        cmdM.CommandType = CommandType.Text;
        SQLUtil.ExecuteSql(cmdM);

        Response.Redirect("Default.aspx");

    }

    protected void BtnCancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

}
