using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using Tgpf.Isr.Model;
using Tgpf.Isr.Service;
using Tgpf.Isr.BaseLibrary;
using Spring.Data.Core;
using Spring.Data.Common;

public partial class _Default : System.Web.UI.Page
{

    private AdoTemplate at;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String msg = "";
            String sql = "SELECT * from News where IsOnLine<>'D'  and IsShow=true order by CreateDate desc ";
            //at = SpringUtil.at();
            //DataSet ds = new DataSet();
            //at.DataSetFill(ds, CommandType.Text, sql);
            //OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\ISR\ISR\App_Data\ASPNetDB.mdb;Persist Security Info=False");
            OleDbCommand cmd = new OleDbCommand(sql);
            //using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            //{    
            //    da.Fill(ds);
            //}
            DataSet ds = SQLUtil.QueryDS(cmd);

            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                msg += "<a href=\"#\" class=\"qLink_font\"><strong>" + dRow["Title"].ToString() + "</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";


            }

            string text = "<MARQUEE scrolldelay=\"150\">" + msg + "</MARQUEE>";

            Literal1.Text = text;


            //¨ì³X¤H¼Æ²Ö¿n
            DataSet tmpDs = new DataSet();
            tmpDs.ReadXml(Server.MapPath("~/App_Data/Counter.xml"));

            int hits = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());

            hits += 1;

            tmpDs.Tables[0].Rows[0]["hits"] = hits.ToString();

            tmpDs.WriteXml(Server.MapPath("~/App_Data/Counter.xml")); 


        }
    }

}