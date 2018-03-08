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

public partial class Member_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         
         ProfileCommon p = Profile.GetProfile(User.Identity.Name);
         if (p.UserProfile.Type.Equals("1"))
         {
             Response.Redirect("page6C1.aspx");
         }
         else
         {
             Response.Redirect("page6C2.aspx");
         }


    }
}
