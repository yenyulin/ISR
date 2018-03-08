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
using Spring.Context.Support;
using System.Data.OleDb;

//using ISR.DAL;

public partial class Manage_News : System.Web.UI.Page
{

    //private INewsService mgr = new HibernateNewsDao();
    //private INewsService mgr = (INewsService)BaseAction.Context.GetObject("NewsService");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        //at = SpringUtil.at();
        String sql = "SELECT * from News  where Isonline <> 'D' order by Showdate desc  ";    
        OleDbCommand cmd = new OleDbCommand(sql);
     

        NewsGrid.DataSource = SQLUtil.QueryDS(cmd); ;
        NewsGrid.DataKeyNames = new string[] { "Id" };
        NewsGrid.DataBind();

    }

    protected void NewBtn_Click(object sender, EventArgs e)
    {
        Title1.Text = "";
        Showdate1.Text = "";
        Summary1.Text = "";
        Link1.Text = "";
        IsOnLine1.SelectedValue = "Y";
        IsShow1.SelectedValue = "Y";
        MultiView1.ActiveViewIndex = 1;
    }

    protected void Name_Command(object sender, CommandEventArgs e)
    {
        int Pid = int.Parse(e.CommandArgument.ToString());
        News obj = GetNewsByID(Pid);
        //News obj = mgr.getNews(Pid);
        Id.Value = obj.Id.ToString();
        Title2.Text = obj.Title;
        Showdate2.Text = obj.Showdate.ToString("yyyy/M/d");

        Summary2.Text = obj.Summary;
        Link2.Text = obj.Link;
        IsOnLine2.SelectedValue = obj.Isonline;
        if (obj.Isshow)
            IsShow2.SelectedValue = "Y";
        else
            IsShow2.SelectedValue = "N";

        MultiView1.ActiveViewIndex = 2;
    }

    protected void ExitBtn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void ModifyBtn_Click(object sender, EventArgs e)
    {
        News obj = GetNewsByID(int.Parse(Id.Value));
        //News obj = mgr.getNews(int.Parse(Id.Value));
        obj.Title = Title2.Text;
        obj.Showdate = DateTime.ParseExact(Showdate2.Text, "yyyy/M/d", null);
        obj.Createdate = DateTime.Now;
        obj.Summary = Summary2.Text;
        obj.Link = Link2.Text;
        obj.Isonline = IsOnLine2.SelectedValue;
        if (IsShow2.SelectedValue.Equals("Y"))
            obj.Isshow = true;
        else
            obj.Isshow = false;
        /*Edit*/

        String sqlM = "";
        sqlM = sqlM + " update News";
        sqlM = sqlM + " set [Createdate]=@Createdate, ";
        sqlM = sqlM + " [Isonline]=@Isonline, ";
        sqlM = sqlM + " [Isshow]=@Isshow,";     
        sqlM = sqlM + " [Link]=@Link,";
        sqlM = sqlM + " [Showdate]=@Showdate, ";  
        sqlM = sqlM + " [Summary]=@Summary,";
        sqlM = sqlM + " [Title]=@Title";
        sqlM = sqlM + " where id=@id ";  
        OleDbCommand cmdM = new OleDbCommand(sqlM);
        
        cmdM.Parameters.Add("@Createdate", OleDbType.Date).Value = obj.Createdate;
        cmdM.Parameters.Add("@Isonline", OleDbType.VarChar).Value = obj.Isonline;
        cmdM.Parameters.Add("@Isshow", OleDbType.Boolean).Value = obj.Isshow;
        cmdM.Parameters.Add("@Link", OleDbType.VarChar).Value = obj.Link;
        cmdM.Parameters.Add("@Showdate", OleDbType.Date).Value = obj.Showdate;
        cmdM.Parameters.Add("@Summary", OleDbType.VarChar).Value = obj.Summary;
        cmdM.Parameters.Add("@Title", OleDbType.VarChar).Value = obj.Title;
        cmdM.Parameters.Add("@id", OleDbType.Integer).Value = obj.Id;
        SQLUtil.ExecuteSql(cmdM);

        //mgr.Save(obj);
        BindGrid();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void AppendBtn_Click(object sender, EventArgs e)
    {
        News obj = new News();
        obj.Title = Title1.Text;
        obj.Showdate = DateTime.ParseExact(Showdate1.Text, "yyyy/M/d", null);
        obj.Createdate = DateTime.Now;
        obj.Summary = Summary1.Text;
        obj.Link = Link1.Text;
        obj.Isonline = IsOnLine1.SelectedValue;
        if (IsShow1.SelectedValue.Equals("Y"))
            obj.Isshow = true;
        else
            obj.Isshow = false;
        /*Add*/
        
        String sqlM = "";
        sqlM = sqlM + " insert into News ([Createdate],[Isonline],[Isshow],[Link],[Showdate],[Summary],[Title])";

        sqlM = sqlM + " values (@Createdate,@Isonline,@Isshow,@Link,@Showdate,@Summary,@Title)";
        OleDbCommand cmdM = new OleDbCommand(sqlM);

        cmdM.Parameters.Add("@Createdate", OleDbType.Date).Value = obj.Createdate;
        cmdM.Parameters.Add("@Isonline", OleDbType.VarChar).Value = obj.Isonline;
        cmdM.Parameters.Add("@Isshow", OleDbType.Boolean).Value = obj.Isshow;
        cmdM.Parameters.Add("@Link", OleDbType.VarChar).Value = obj.Link;
        cmdM.Parameters.Add("@Showdate", OleDbType.Date).Value = obj.Showdate;
        cmdM.Parameters.Add("@Summary", OleDbType.VarChar).Value = obj.Summary;
        cmdM.Parameters.Add("@Title", OleDbType.VarChar).Value = obj.Title;
        cmdM.CommandType = CommandType.Text;
        SQLUtil.ExecuteSql(cmdM);


        //mgr.Save(obj);
        BindGrid();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    /// <summary>
    /// 取得單筆news
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private News GetNewsByID(int id)
    {
        String sql = "SELECT * from News where id=@id ";
        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add("@id", OleDbType.Integer).Value = id;
        cmd.CommandType = CommandType.Text;
        //DataSet ds = SQLUtil.QueryDS(cmd);
        OleDbDataReader dr = SQLUtil.QueryDR(cmd);
        bool isHasRows = dr.HasRows;
        News mod = SetModel(dr);
        dr.Close();
        return isHasRows ? mod : null;
    }

    /// <summary>
    /// 實體物件取得DataRow資料
    /// </summary>
    private News SetModel(OleDbDataReader dr)
    {
        News mod = new News();
        while (dr.Read())
        {
            mod.Id = Convert.ToInt32(dr["Id"].ToString());
            mod.Createdate = Convert.ToDateTime(dr["Createdate"].ToString());
            mod.Isonline = dr["Isonline"].ToString();
            mod.Isshow = Convert.ToBoolean(dr["Isshow"].ToString());
            mod.Link = dr["Link"].ToString();
            mod.Showdate = Convert.ToDateTime(dr["Showdate"].ToString());
            mod.Summary = dr["Summary"].ToString();
            mod.Title = dr["Title"].ToString();
           
        }
        return mod;
    }
}
