using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Helper;

#region ---  Class  ---
public class AppConfigHelper
{
    #region ---  Constructor  ---
    public AppConfigHelper()
	{
		 
	}

    #endregion

    #region ---  Methods  ---
    public static DataSet AddAppConfig(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "AppConfig_Insert", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception e)
        {

        }

        return ds;
    }

    public static DataSet DeleteAppConfig(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "AppConfig_Delete", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet SelectAppConfig(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "AppConfig_Select", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet SelectAppConfigbyID(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "AppConfig_SelectByID", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet UpdateAppConfigbyID(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "AppConfig_update", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception e)
        {

        }

        return ds;
    }

    #endregion
}

#endregion