using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Helper;

#region ---  Class  ---
public class SystemConfigHelper
{
    #region ---  Constructor  ---
    public SystemConfigHelper()
	{
		 
	}

    #endregion

    #region ---  Methods  ---
    public static DataSet AddSystemConfig(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "Add_SystemConfiguration", parameters, ClientSessions.ConnectionString_UserCMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception e)
        {

        }

        return ds;
    }

    //public static DataSet DeleteSystemConfig(SqlParameterCollection parameters)
    //{
    //    DataSet ds = new DataSet();
    //    ds.Clear();
    //    try
    //    {
    //        ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "", parameters, ClientSessions.ConnectionString_UserCMSManagementApp());
    //        if (ds.Tables.Count < 1)
    //            ds.Tables.Add(new DataTable());
    //    }
    //    catch (Exception)
    //    {

    //    }

    //    return ds;
    //}

    public static DataSet SelectSystemConfig(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "CMS_GetSystemConfiguration", parameters, ClientSessions.ConnectionString_UserCMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception e)
        {

        }

        return ds;
    }

    public static DataSet SelectSystemConfigbyID(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "GetSystemConfigurationbyID", parameters, ClientSessions.ConnectionString_UserCMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet UpdateSystemConfig(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "Update_SystemConfiguration", parameters, ClientSessions.ConnectionString_UserCMSManagementApp());
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