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

public partial class import : System.Web.UI.Page
{
    //private AdoTemplate at;
    private MembershipCreateStatus mc;
    private MembershipUser user;
    private ProfileCommon p;
    //private IReuseTechService mgr = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void importBtn_Click(object sender, EventArgs e)
    {
        //at = SpringUtil.at();
        String sql = "SELECT  a.* , a.Param13+c.city+b.name as zipcht from ImportData a , zip b , QryCity c where a.Param13=b.id and a.Param12=c.pid";
        //DataTable lists = new DataTable();
        //at.DataTableFill(lists, CommandType.Text, sql);

        OleDbCommand cmd = new OleDbCommand(sql);
        DataSet ds = SQLUtil.QueryDS(cmd);

        //foreach (DataRow dRow in lists.Rows)
        foreach (DataRow dRow in ds.Tables[0].Rows)
        {
            MembershipUser user = Membership.CreateUser(dRow["Param1"].ToString(), dRow["Param2"].ToString(),
                dRow["Param8"].ToString(), dRow["Param9"].ToString(), dRow["Param9"].ToString(), true, out mc);

            user.Comment = dRow["Param3"].ToString();
            Roles.AddUserToRole(dRow["Param1"].ToString(), "user");
            Membership.UpdateUser(user);

            p = (ProfileCommon)ProfileCommon.Create(dRow["Param1"].ToString(), true);
            p.UserProfile.Owner = dRow["Param11"].ToString();
            p.UserProfile.Name = dRow["Param5"].ToString();
            p.UserProfile.Tel = dRow["Param6"].ToString();
            p.UserProfile.Corp = dRow["Param3"].ToString();
            p.UserProfile.City = dRow["Param12"].ToString();
            p.UserProfile.Postcode = dRow["Param13"].ToString();
            p.UserProfile.Address = dRow["Param4"].ToString();
            p.UserProfile.Fax = dRow["Param7"].ToString();
            p.UserProfile.Kind = dRow["Param10"].ToString();
            p.UserProfile.Type = dRow["Param9"].ToString();
            p.UserProfile.Zipcht = dRow["zipcht"].ToString(); 
            p.Save();


            UserProfiles up = new UserProfiles();
            up.Username = dRow["Param1"].ToString();
            up.Owner = dRow["Param11"].ToString();
            up.Name = dRow["Param5"].ToString();
            up.Tel = dRow["Param6"].ToString();
            up.Corp = dRow["Param3"].ToString();
            up.City = dRow["Param12"].ToString();
            up.Postcode = dRow["Param13"].ToString();
            up.Address = dRow["Param4"].ToString();
            up.Fax = dRow["Param7"].ToString();
            up.Kind = dRow["Param10"].ToString();
            up.Type = dRow["Param9"].ToString();
            up.Zipcht = dRow["zipcht"].ToString(); 




            //mgr.Save(null, null, up);

        }

    }

}
