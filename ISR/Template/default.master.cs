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
using Tgpf.Isr.BaseLibrary;

public partial class template_default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /*public void showMsg(Boolean isErr, Exception err)
    {
         if (isErr)
        {
            ErrMsg.Text = Resources.Resource.error + err.Message;
            PanelErr.Visible = true;
            PanelMsg.Visible = false;
            Utilities.LogError(err);
        }
        else
        {
            Msg.Text = Resources.Resource.success;
            PanelErr.Visible = false;
            PanelMsg.Visible = true;
        } 
    }

    public void hideMsg()
    {
        PanelMsg.Visible = false;
        PanelErr.Visible = false;
    }*/
}
