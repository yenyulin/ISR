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

public partial class Manage_MemberQuery : System.Web.UI.Page
{
   // private AdoTemplate at;
    private ProfileCommon p;
    private MembershipUser user;
    //private IReuseTechService mgrRes = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");

    //private IUserProfilesService mgrUp = (IUserProfilesService)BaseAction.Context.GetObject("UserProfilesService");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void QryBtn_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    private void BindGrid()
    {
        //at = SpringUtil.at();

        /* 學研機構 */
        String sql = "SELECT  m.UserId,m.UserName,m.Email, m.IsApproved, m.CreateDate, u.Type, u.Name, u.Corp, u.Tel, u.Address, u.Kind , '' as Pwd ";
        sql += " from UserProfiles u , vw_aspnet_MembershipUsers m where  u.UserName=m.UserName and u.Type='1'  ";
        if (!a1.Text.Trim().Equals(""))
            sql += " and u.UserName='" + a1.Text.Trim() + "'";
        if (!a2.Text.Trim().Equals(""))
            sql += " and u.Name like '%" + a2.Text.Trim() + "%'";
        if (!a3.Text.Trim().Equals(""))
            sql += " and u.Corp like '%" + a3.Text.Trim() + "%'";
        if (!a4.Text.Trim().Equals(""))
            sql += " and u.Address like '%" + a4.Text.Trim() + "%' or  u.ZipCht like '%" + a4.Text.Trim() + "%' ";
        if (!a5.SelectedValue.Equals("Z"))
        {
            if (!a5.SelectedValue.Equals("C") && !a5.SelectedValue.Equals("D") && !a5.SelectedValue.Equals("E") && !a5.SelectedValue.Equals("F") && !a5.SelectedValue.Equals("G"))
            {
                if (a5.SelectedValue.Equals("A"))
                    sql += " and u.Kind='A' ";
                else if (a5.SelectedValue.Equals("B"))
                    sql += " and u.Kind='B' ";
                else if (a5.SelectedValue.Equals("H"))
                    sql += " and u.Kind='C' ";
            }
            else
            {
                sql += " and 1=0";
            }
        }
        if (!a6.Text.Trim().Equals(""))
            sql += " and 1=0";

        //DataSet ds = new DataSet();
        //at.DataSetFill(ds, CommandType.Text, sql);

        OleDbCommand cmd = new OleDbCommand(sql);  
        DataSet ds = SQLUtil.QueryDS(cmd);
        
        foreach (DataRow dRow in ds.Tables[0].Rows)
        {
            user = Membership.GetUser(dRow["UserName"].ToString(), false);
            p = Profile.GetProfile(dRow["UserName"].ToString());

            if (p.UserProfile.Kind.Equals("A"))
                dRow["Kind"] = "學術單位";
            else if (p.UserProfile.Kind.Equals("B"))
                dRow["Kind"] = "研究單位";
            else  
                dRow["Kind"] = "其他";

            dRow["Pwd"] = user.GetPassword();

        }
        MemberGrid1.DataSource = ds;
        MemberGrid1.DataKeyNames = new string[] { "UserId" };
        MemberGrid1.DataBind();


        /* 業者廠商 */
        sql = "SELECT  m.UserId,m.UserName,m.Email, m.IsApproved, m.CreateDate, u.Type, u.Name, u.Corp, u.Tel, u.Address, u.Kind , '' as Pwd ";
        sql += " from UserProfiles u , vw_aspnet_MembershipUsers m where  u.UserName=m.UserName and u.Type='2'  ";
        if (!a1.Text.Trim().Equals(""))
            sql += " and u.UserName='" + a1.Text.Trim() + "'";
        if (!a2.Text.Trim().Equals(""))
            sql += " and u.Name like '%" + a2.Text.Trim() + "%'";
        if (!a3.Text.Trim().Equals(""))
            sql += " and u.Corp like '%" + a3.Text.Trim() + "%'";
        if (!a4.Text.Trim().Equals(""))
            sql += " and u.Address like '%" + a4.Text.Trim() + "%' or  u.ZipCht like '%" + a4.Text.Trim() + "%' ";
        if (!a5.SelectedValue.Equals("Z"))
        {
            if (!a5.SelectedValue.Equals("A") && !a5.SelectedValue.Equals("B") && !a5.SelectedValue.Equals("H"))
            {
                if (a5.SelectedValue.Equals("C"))
                    sql += " and u.Kind='A' ";
                else if (a5.SelectedValue.Equals("D"))
                    sql += " and u.Kind='B' ";
                else if (a5.SelectedValue.Equals("E"))
                    sql += " and u.Kind='C' ";
                else if (a5.SelectedValue.Equals("F"))
                    sql += " and u.Kind='D' ";
                else if (a5.SelectedValue.Equals("G"))
                    sql += " and u.Kind='E' ";

            }
            else
            {
                sql += " and 1=0";
            }
        }
        if (!a6.Text.Trim().Equals(""))
            sql += " and u.Owner like '%" + a6.Text.Trim() + "%'";


        //ds = new DataSet();
        //at.DataSetFill(ds, CommandType.Text, sql);

        OleDbCommand cmd2 = new OleDbCommand(sql);
        ds = SQLUtil.QueryDS(cmd2);
       
        foreach (DataRow dRow in ds.Tables[0].Rows)
        {
            user = Membership.GetUser(dRow["UserName"].ToString(), false);
            p = Profile.GetProfile(dRow["UserName"].ToString());

            if (p.UserProfile.Kind.Equals("A"))
                dRow["Kind"] = "公民營處(清)理機構";
            else if (p.UserProfile.Kind.Equals("B"))
                dRow["Kind"] = "許可再利用機構";
            else if (p.UserProfile.Kind.Equals("C"))
                dRow["Kind"] = "公告再利用機構";
            else if (p.UserProfile.Kind.Equals("D"))
                dRow["Kind"] = "應回收廢棄物處理機構";
            else if (p.UserProfile.Kind.Equals("E"))
                dRow["Kind"] = "其他";
            dRow["Pwd"] = user.GetPassword();

        }
        MemberGrid2.DataSource = ds;
        MemberGrid2.DataKeyNames = new string[] { "UserId" };
        MemberGrid2.DataBind();

     

    }

    protected void DropBtn1_Command(object sender, CommandEventArgs e)
    {
        string Username = e.CommandArgument.ToString();
        bool Deleted = Membership.DeleteUser(Username, true);
        if (Deleted)
        {
            //private IReuseTechService mgrRes = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");

            //private IUserProfilesService mgrUp = (IUserProfilesService)BaseAction.Context.GetObject("UserProfilesService");
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


            //IList lists = mgrRes.getReuseTechListAll(Username);
            ///* UserProfiles */
            //UserProfiles up = mgrUp.getUserProfiles(Username);
            //mgrRes.DeleteAll(lists,up);
        }
        BindGrid();
    }

    protected void DropBtn2_Command(object sender, CommandEventArgs e)
    {
        string Username = e.CommandArgument.ToString();
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

            //IList lists = mgrRes.getReuseTechListAll(Username);
            /* UserProfiles */
            //UserProfiles up = mgrUp.getUserProfiles(Username);
            //mgrRes.DeleteAll(lists,up);
        }
        BindGrid();
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberList.aspx");
    }
}
