using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Text;

/// <summary>
/// SQLUtil 的摘要描述
/// </summary>
public abstract class SQLUtil
{
	public SQLUtil()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}
    //資料庫連接字符串(web.config)
    public static readonly string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    
    /// <summary>
    /// 執行SQL語句，回傳影響的資料筆數
    /// </summary>
    /// <param name="cmd">OleDbCommand</param>
    /// <returns>影響的資料筆數</returns>
    public static int ExecuteSql(OleDbCommand cmd)
    {
        using (OleDbConnection cn = new OleDbConnection(CS))
        {
            cmd.Connection = cn;
            cn.Open();
            int intRows = cmd.ExecuteNonQuery();
            cn.Close();
            return intRows;
        }
    }

    /// <summary>
    /// 執行SQL語句，回傳影響的資料筆數
    /// </summary>
    /// <param name="strConn">連線字串</param>
    /// <param name="cmd">OleDbCommand</param>
    /// <returns>影響的資料筆數</returns>
    public static int ExecuteSql(string strConn, OleDbCommand cmd)
    {
        using (OleDbConnection cn = new OleDbConnection(strConn))
        {
            cmd.Connection = cn;
            cn.Open();
            int intRows = cmd.ExecuteNonQuery();
            cn.Close();
            return intRows;
        }
    }

    /// <summary>
    /// 執行SQL語句，回傳結果
    /// </summary>
    /// <param name="cmd">OleDbCommand</param>
    /// <returns>影響的資料筆數</returns>
    public static object ExecuteScalar(OleDbCommand cmd)
    {
        using (OleDbConnection cn = new OleDbConnection(CS))
        {
            cmd.Connection = cn;
            cn.Open();
            object obj = cmd.ExecuteScalar();
            cn.Close();
            return obj;
        }
    }

    /// <summary>
    /// 執行SQL語句，回傳結果
    /// </summary>
    /// <param name="strConn">連線字串</param>
    /// <param name="cmd">OleDbCommand</param>
    /// <returns>影響的資料筆數</returns>
    public static object ExecuteScalar(string strConn, OleDbCommand cmd)
    {
        using (OleDbConnection cn = new OleDbConnection(strConn))
        {
            cmd.Connection = cn;
            cn.Open();
            object obj = cmd.ExecuteScalar();
            cn.Close();
            return obj;
        }
    }

    /// <summary>
    /// 執行查詢語句，回傳DataSet
    /// </summary>
    /// <param name="cmd">OleDbCommand</param>
    /// <returns>DataSet</returns>
    public static DataSet QueryDS(OleDbCommand cmd)
    {
        using (OleDbConnection cn = new OleDbConnection(CS))
        {
            cmd.Connection = cn;
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }

    /// <summary>
    /// 執行查詢語句，回傳DataSet
    /// </summary>
    /// <param name="strConn">連線字串</param>
    /// <param name="cmd">OleDbCommand</param>
    /// <returns>DataSet</returns>
    public static DataSet QueryDS(string strConn, OleDbCommand cmd)
    {
        using (OleDbConnection cn = new OleDbConnection(strConn))
        {
            cmd.Connection = cn;
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }

    /// <summary>
    /// 執行查詢語句，回傳OleDbDataReader
    /// </summary>
    /// <param name="cmd">OleDbCommand</param>
    /// <returns>OleDbDataReader</returns>
    public static OleDbDataReader QueryDR(OleDbCommand cmd)
    {
        OleDbConnection cn = new OleDbConnection(CS);
        OleDbDataReader dr;
        try
        {
            cmd.Connection = cn;
            cn.Open();
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            throw new Exception(ex.Message);
        }
        return dr;
    }

    /// <summary>
    /// 執行查詢語句，回傳OleDbDataReader
    /// </summary>
    /// <param name="strConn">連線字串</param>
    /// <param name="cmd">OleDbCommand</param>
    /// <returns>OleDbDataReader</returns>
    public static OleDbDataReader QueryDR(string strConn, OleDbCommand cmd)
    {
        OleDbConnection cn = new OleDbConnection(strConn);
        OleDbDataReader dr;
        try
        {
            cmd.Connection = cn;
            cn.Open();
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            throw new Exception(ex.Message);
        }
        return dr;
    }

    /// <summary>
    /// 執行SQL語句，回傳影響的資料筆數
    /// </summary>
    /// <param name="cmd">OleDbCommand</param>
    /// <returns>影響的資料筆數</returns>
    public static int CheckConnectionState()
    {
        using (OleDbConnection cn = new OleDbConnection(CS))
        {
            int intState = 0;

            cn.Open();
            if (cn.State == ConnectionState.Open)
            {
                intState = 1;
            }
            cn.Close();
            return intState;
        }
    }

    /// <summary>
    /// 查詢FK
    /// </summary>
    /// <param name="strTable">Table Name</param>
    /// <returns>OleDbDataReader</returns>
    public static OleDbDataReader QueryFK(string TableName)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = "STP_GetFKInfo";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TableName", TableName);
        return QueryDR(CS, cmd);
    }

    /// <summary>
    /// 資料庫輸入值的Check
    /// </summary>
    /// <param name="obj">資料庫輸入值</param>
    /// <returns>確認後的資料庫輸入值</returns>
    public static object CheckDBValue(object obj)
    {
        if (obj == null)
        {
            return DBNull.Value;
        }
        else
        {
            return obj;
        }
    }

    #region 由Object取值

    /// <summary>
    /// 取得string值
    /// </summary>
    /// <param name="obj">物件</param>
    /// <returns>字串</returns>
    public static string GetString(object obj)
    {
        return obj.ToString();
    }

    /// <summary>
    /// 取得Int值
    /// </summary>
    /// <param name="obj">物件</param>
    /// <returns>Int or Null</returns>
    public static int? GetInt(object obj)
    {
        if (obj != DBNull.Value)
            return int.Parse(obj.ToString());
        else
            return null;
    }

    /// <summary>
    /// 取得Decimal值
    /// </summary>
    /// <param name="obj">物件</param>
    /// <returns>Decimal or Null</returns>
    public static decimal? GetDecimal(object obj)
    {
        if (obj != DBNull.Value)
            return decimal.Parse(obj.ToString());
        else
            return null;
    }

    /// <summary>
    /// 取得DateTime值
    /// </summary>
    /// <param name="obj">物件</param>
    /// <returns>DateTime or Null</returns>
    public static DateTime? GetDateTime(object obj)
    {
        if (obj != DBNull.Value)
            return DateTime.Parse(obj.ToString());
        else
            return null;
    }

    /// <summary>
    /// 取得bool值
    /// </summary>
    /// <param name="obj">物件</param>
    /// <returns>bool or Null</returns>
    public static bool? GetBool(object obj)
    {
        if (obj.ToString() == "1" || obj.ToString().ToLower() == "true")
            return true;
        else
            return false;
    }

    /// <summary>
    /// 取得byte[]
    /// </summary>
    /// <param name="obj">物件</param>
    /// <returns>byte[] or Null</returns>
    public static Byte[] GetByte(object obj)
    {
        if (obj != DBNull.Value)
        {
            return (Byte[])obj;
        }
        else
            return null;
    }

    /// <summary>
    /// 取得Guid值
    /// </summary>
    /// <param name="obj">物件</param>
    /// <returns>Guid or Guid.Empty</returns>
    public static Guid GetGuid(object obj)
    {
        if (obj != DBNull.Value)
            return new Guid(obj.ToString());
        else
            return Guid.Empty;
    }

    #endregion\

}