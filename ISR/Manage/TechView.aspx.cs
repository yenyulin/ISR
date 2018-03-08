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
using System.Data.OleDb;

public partial class Manage_TechView : System.Web.UI.Page
{
    //private IReuseTechService mgr = (IReuseTechService)BaseAction.Context.GetObject("ReuseTechService");


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int Pid = int.Parse(Request.QueryString["id"].ToString());
            //ReuseTech obj = mgr.getReuseTech(Pid);
            //if (obj != null)
            //{
            //    TechItem3.Text = obj.Techname;
            //    TechAdv3.Text = obj.Techadv;
            //    TechDesc3.Text = obj.Techdesc;
            //}
            //else
            //{
            //    TechItem3.Text = "";
            //    TechAdv3.Text = "";
            //    TechDesc3.Text = "";
            //}

            TechItem3.Text = "";
            TechAdv3.Text = "";
            TechDesc3.Text = "";
            String sql = "SELECT * from ReuseTech WHERE id=@param1";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.Parameters.Add("@param1", OleDbType.Numeric).Value = Pid;
            cmd.CommandType = CommandType.Text;
            DataSet ds = SQLUtil.QueryDS(cmd);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TechItem3.Text = dr["Techname"].ToString();
                TechAdv3.Text = dr["Techadv"].ToString();
                TechDesc3.Text = dr["Techdesc"].ToString();
            }


        }
    }

}
