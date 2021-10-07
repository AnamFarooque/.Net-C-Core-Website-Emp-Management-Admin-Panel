using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Helper;

#region ---  Class  ---
public class MachineConfigHelper
{
    #region ---  Constructor  ---
    public MachineConfigHelper()
    {

    }

    #endregion

    #region ---  Methods  ---
    public static DataSet AddServerMachine(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        
        ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ServerMachineConfig_Insert", parameters, ClientSessions.ConnectionString_CMSManagementApp());
        if (ds.Tables.Count < 1)
            ds.Tables.Add(new DataTable());

        return ds;
    }

    public static DataSet AddClientMachine(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();

        ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ClientMachineConfig_Insert", parameters, ClientSessions.ConnectionString_CMSManagementApp());
        if (ds.Tables.Count < 1)
            ds.Tables.Add(new DataTable());

        return ds;
    }

    public static DataSet Update_ServerMachine(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
    
        ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ServerMachineConfig_Update", parameters, ClientSessions.ConnectionString_CMSManagementApp());
        if (ds.Tables.Count < 1)
            ds.Tables.Add(new DataTable());
        return ds;
    }
    
    public static DataSet Update_ClientMachine(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();

        ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ClientMachineConfig_Update", parameters, ClientSessions.ConnectionString_CMSManagementApp());
        if (ds.Tables.Count < 1)
            ds.Tables.Add(new DataTable());
        return ds;
    }

    public static DataSet DeleteMachine(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "MachineConfig_Delete", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet DeleteServerMachine(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ServerMachineConfig_Delete", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }
  
    public static DataSet DeleteClientMachine(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ClientMachineConfig_Delete", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet Select_ServerMachines()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ServerMachineInfo_Select", ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }
 
    public static DataSet ClientMachine_SelectbyID(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ClientMachine_SelectbyID", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet Select_ParentMachinesID()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_ParentMachinesID", ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet ServerMachine_SelectbyID(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ServerMachine_SelectbyID", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet ClientMachine_SelectbyParent(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ClientMachineInfo_SelectbyParent", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet Select_ServerMachinesActive(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ServerMachineInfo_SelectActive", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet Select_ServerMachinesSelectbyID(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ServerMachineInfo_SelectbyID", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    public static DataSet Select_ServerMachinesByStatus(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "ServerMachines_SelectStatus", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception ex)
        {

        }

        return ds;
    }

    #endregion
}

#endregion