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

public partial class Manage_MemberAppend2 : System.Web.UI.Page
{
    //private IReuseTechService mgr = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");
    private ProfileCommon p;
    private ProfileCommon p2;
    //private AdoTemplate at;
    private MembershipUser user;
    private MembershipUser user2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
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
        cmd.Parameters.Add("param1", OleDbType.Char).Value = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedValue;
        cmd.CommandType = CommandType.Text;
        DataSet ds = SQLUtil.QueryDS(cmd);

        zipList.DataSource = ds;
        zipList.DataTextField = "Name";
        zipList.DataValueField = "Id";
        zipList.DataBind();
    }

    protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect("MemberList.aspx");
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {


        try
        {

            CreateUserWizard1.UserName = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;

            user = Membership.GetUser(CreateUserWizard1.UserName);

            user.ChangePasswordQuestionAndAnswer(user.GetPassword(), "2", "2");
            user.IsApproved = false;
            user.Comment = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Corp")).Text;

            Roles.AddUserToRole(CreateUserWizard1.UserName, "user");
            Membership.UpdateUser(user);


            p = (ProfileCommon)ProfileCommon.Create(CreateUserWizard1.UserName, true);
            p.UserProfile.Name = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Name")).Text;
            p.UserProfile.Owner = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Owner")).Text;
            p.UserProfile.Tel = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Tel")).Text;
            p.UserProfile.Corp = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Corp")).Text;
            p.UserProfile.City = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedValue;
            p.UserProfile.Postcode = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedValue;
            p.UserProfile.Address = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Address")).Text;
            p.UserProfile.Fax = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Fax")).Text;
            p.UserProfile.Kind = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue;
            p.UserProfile.Type = "2";
            p.UserProfile.Zipcht = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedValue +
                           ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedItem.Text +
                           ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedItem.Text;
            p.Save();

            
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
            up.Type = "2";
            up.Zipcht = ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedValue +
                ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("cityList")).SelectedItem.Text +
                ((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("zipList")).SelectedItem.Text;


            String sqlUp = "";
            sqlUp = sqlUp + " insert into UserProfiles ([address],[city],[corp],[fax]	,[kind],[name],[owner],[postcode],[tel],[type],[username],[zipcht]) ";
            sqlUp = sqlUp + " values (@address,@city,@corp,@fax	,@kind,@name,@owner,@postcode,@tel,@type,@username,@zipcht)";
            OleDbCommand cmdM = new OleDbCommand(sqlUp);
            cmdM.Parameters.Add("@address", OleDbType.VarChar).Value = up.Address;
            cmdM.Parameters.Add("@city", OleDbType.VarChar).Value = up.City;
            cmdM.Parameters.Add("@corp", OleDbType.VarChar).Value = up.Corp;
            cmdM.Parameters.Add("@fax", OleDbType.VarChar).Value = up.Fax;
            cmdM.Parameters.Add("@kind", OleDbType.VarChar).Value = up.Kind;
            cmdM.Parameters.Add("@name", OleDbType.VarChar).Value = up.Name;
            cmdM.Parameters.Add("@owner", OleDbType.VarChar).Value = up.Owner;
            cmdM.Parameters.Add("@postcode", OleDbType.VarChar).Value = up.Postcode;
            cmdM.Parameters.Add("@tel", OleDbType.VarChar).Value = up.Tel;
            cmdM.Parameters.Add("@type", OleDbType.VarChar).Value = up.Type;
            cmdM.Parameters.Add("@username", OleDbType.VarChar).Value = up.Username;
            cmdM.Parameters.Add("@zipcht", OleDbType.VarChar).Value = up.Zipcht;
            cmdM.CommandType = CommandType.Text;
            //SQLUtil.ExecuteSql(cmdM);
            object objUserProfile = SQLUtil.ExecuteScalar(cmdM);

            //private IReuseTechService mgr = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");
            //mgr.Save(null, null, up);

            ((Label)CompleteWizardStep1.ContentTemplateContainer.FindControl("Msg")).Text = "業者廠商會員新增完成。";

           
        }
        catch (Exception err)
        {
            Membership.DeleteUser(CreateUserWizard1.UserName, true);

            ((Label)CompleteWizardStep1.ContentTemplateContainer.FindControl("Msg")).Text = "錯誤: " + err.ToString();
        }

    }

    protected void cityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList();
    }

    protected void TechItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("TechItem")).SelectedValue.Equals("V"))
        {
            ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechOther")).Visible = true;
        }
        else
        {
            ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("TechOther")).Visible = false;
        }
    }

    protected void WasteItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("WasteItem")).SelectedValue.Equals("U"))
        {
            ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("WasteOther")).Visible = true;
        }
        else
        {
            ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("WasteOther")).Visible = false;
        }

    }

    protected void CheckBtn_Click(object sender, EventArgs e)
    {
        if (((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text.Trim().Equals(""))
        {
            ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Text = "帳號未輸入";
            ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).ForeColor = System.Drawing.Color.Red;
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
            cmd.Parameters.Add("@param1", OleDbType.VarChar).Value = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLUtil.QueryDS(cmd);

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
    }
    protected void ContinueButton_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("MemberList.aspx");
    }

    protected void CreateUserWizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;
        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserNameView")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;
        ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Password")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Password")).Text;
        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("PasswordView")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Password")).Text;
        ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ConfirmPassword")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("ConfirmPassword")).Text;
        ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Owner")).Text = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("Owner")).Text;
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
            ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Kind")).Text = "公民營處(清)理機構";
        else if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue.Equals("B"))
            ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Kind")).Text = "許可再利用機構";
        else if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue.Equals("C"))
            ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Kind")).Text = "公告再利用機構";
        else if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue.Equals("D"))
            ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Kind")).Text = "應回收廢棄物處理機構";
        else if (((DropDownList)UserTemplate.ContentTemplateContainer.FindControl("Kind")).SelectedValue.Equals("E"))
            ((Label)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Kind")).Text = "其他";

 

    }

    protected void UserName_TextChanged(object sender, EventArgs e)
    {
        if (((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text.Trim().Equals(""))
        {
            ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).Text = "帳號未輸入";
            ((Label)UserTemplate.ContentTemplateContainer.FindControl("CheckMsg")).ForeColor = System.Drawing.Color.Red;
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
            cmd.Parameters.Add("@param1", OleDbType.VarChar).Value = ((TextBox)UserTemplate.ContentTemplateContainer.FindControl("UserName")).Text;
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLUtil.QueryDS(cmd);

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

    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberList.aspx");
    }
}
