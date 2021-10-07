using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Helper;

public class ReportsHelper
{
    #region --- Constructor ---
    public ReportsHelper()
	{
		 
	}

    #endregion

    #region --- Methods ---

    public static DataSet Select_VersionSummary(SqlParameterCollection parameters)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        try
        {
            ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "AppVersionSummary_Select", parameters, ClientSessions.ConnectionString_CMSManagementApp());
            if (ds.Tables.Count < 1)
                ds.Tables.Add(new DataTable());
        }
        catch (Exception)
        {

        }

        return ds;
    }

    #endregion
}