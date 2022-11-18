using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBHelperClass
/// </summary>
public class DBHelperClass
{
    private SqlConnection cn = null;
    public DBHelperClass()
    {
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ePharmaTrax"].ConnectionString);
    }

    public int executeQuery(string query)
    {
        SqlCommand cm = new SqlCommand(query, cn);
        cn.Open();
        cm.ExecuteNonQuery();
        cn.Close();
        return 1;
    }

    public int executeSP(string sp, SqlParameter[] param)
    {
        int val = 0;
        try
        {
            SqlCommand cm = new SqlCommand(sp, cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cm.Parameters.AddRange(param.ToArray());
            cn.Open();
            val = Convert.ToInt32(cm.ExecuteScalar());
            cn.Close();
            return val;
        }
        catch (Exception e)
        {

            LogError(e);
            cn.Close();
        }

        return val;
    }

    public DataSet executeSelectSP(string sp, SqlParameter[] param, string tbname = "")
    {
        DataSet val = new DataSet();
        try
        {
            SqlCommand cm = new SqlCommand(sp, cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cm.Parameters.AddRange(param.ToArray());
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            if (tbname == "")
            {
                da.Fill(val);
            }
            else
            {
                da.Fill(val, tbname);
            }

            cn.Close();
            return val;
        }
        catch (Exception e)
        {
            LogError(e);
            cn.Close();
        }

        return val;
    }

    public void LogError(Exception ex)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path = HttpContext.Current.Server.MapPath("~/ErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }

    public DataTable selectDatatable(string query)
    {
        SqlCommand cm = new SqlCommand(query, cn);
        SqlDataAdapter da = new SqlDataAdapter(cm);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }

    public DataSet selectData(string query)
    {
        SqlCommand cm = new SqlCommand(query, cn);
        SqlDataAdapter da = new SqlDataAdapter(cm);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }


}

