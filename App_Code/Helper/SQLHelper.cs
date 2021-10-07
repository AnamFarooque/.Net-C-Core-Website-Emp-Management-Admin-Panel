using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;


namespace Helper
{
    
    public class SQLHelper
    {
        // ============ ConnectionString ============

        public static string ClientsConfiguration
        {
            get
            {
                string conn = ConfigurationManager.ConnectionStrings["ClientsConfiguration"].ConnectionString;

                if (conn == null || conn == String.Empty)
                {
                    throw new Exception("Connection string is empty.  Check Web.config");
                }
                return conn;
            }


        }

        public static string ConnectionString
        {
            get
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                if (conn == null || conn == String.Empty)
                {
                    throw new Exception("Connection string is empty.  Check Web.config");
                }
                return conn;
            }


        }

        public static string UserConnectionString
        {
            get
            {
                string conn = ConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString;

                if (conn == null || conn == String.Empty)
                {
                    throw new Exception("Connection string is empty.  Check Web.config");
                }
                return conn;
            }
        }

        public static string MembershipConnectionString
        {
            get
            {
                string conn = ConfigurationManager.ConnectionStrings["ASPNETDBConnectionString"].ConnectionString;

                if (conn == null || conn == String.Empty)
                {
                    throw new Exception("Connection string is empty.  Check Web.config");
                }
                return conn;
            }
        }
    
        // ============ ExecuteReaderCmd with Two Parameters ============

        public static SqlDataReader ExecuteReaderCmd(string cmdText, CommandType cmdType)
        {
            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandTimeout = 9999;

            sqlCmd.Connection.Open();
            return sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static SqlDataReader ExecuteReaderCmd(SqlConnection SqlCon, string cmdText, CommandType cmdType)
        {
            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            SqlConnection sqlConn = SqlCon;
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandTimeout = 9999;

            sqlCmd.Connection.Open();
            return sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        // ============ ExecuteReaderCmd with Three Parameters ============
        public static SqlDataReader ExecuteReaderCmd(string cmdText, CommandType cmdType, SqlParameterCollection sqlParameters)
        {
            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            if (sqlParameters == null)
                throw new ArgumentNullException("sqlParameters");

            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandTimeout = 9999;

            foreach (SqlParameter p in sqlParameters)
            {
                sqlCmd.Parameters.AddWithValue(p.ParameterName, p.Value);
            }

            sqlCmd.Connection.Open();
            return sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static SqlDataReader ExecuteReaderCmd(SqlConnection SqlCon, string cmdText, CommandType cmdType, SqlParameterCollection sqlParameters)
        {
            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            if (sqlParameters == null)
                throw new ArgumentNullException("sqlParameters");

            SqlConnection sqlConn = SqlCon;
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandTimeout = 9999;

            foreach (SqlParameter p in sqlParameters)
            {
                sqlCmd.Parameters.AddWithValue(p.ParameterName, p.Value);
            }

            sqlCmd.Connection.Open();
            return sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        // ============ ExecuteReaderCmd with Three Parameters ============
        //
        //Description:

        public static SqlDataReader ExecuteReaderCmd(string connectionString, string cmdText, SqlParameterCollection sqlParameters)
        {
            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            if (sqlParameters == null)
                throw new ArgumentNullException("sqlParameters");

            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in sqlParameters)
            {
                sqlCmd.Parameters.AddWithValue(p.ParameterName, p.Value);
            }

            sqlCmd.Connection.Open();
            return sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //---------------------------------- end ---------------------------------------

        // ============ ExecuteNonQueryCmd with Two Parameters ============

        public static int ExecuteNonQueryCmd(string cmdText, CommandType cmdType)
        {
            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandTimeout = 9999;
            int retVal = 0;

            try
            {
                sqlCmd.Connection.Open();
                retVal = sqlCmd.ExecuteNonQuery();
            }

            finally
            {
                sqlCmd.Connection.Close();
            }

            return retVal;
        }

        // ============ ExecuteNonQueryCmd with Three Parameters ============

        public static object ExecuteNonQueryCmdMembership(string cmdText, CommandType cmdType, SqlParameterCollection sqlParameters)
        {
            // this method will return the return value parameter of the stored procedure, if there is one,
            // otherwise it will return the number of rows affected

            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            if (sqlParameters == null)
                throw new ArgumentNullException("sqlParameters");

            SqlConnection sqlConn = new SqlConnection(MembershipConnectionString);
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = cmdType;
            string retParamName = String.Empty;
            object retVal = null;

            foreach (SqlParameter p in sqlParameters)
            {
                if (p.Direction == ParameterDirection.ReturnValue)
                {
                    retParamName = p.ParameterName;
                    sqlCmd.Parameters.Add(p.ParameterName, p.SqlDbType);
                    sqlCmd.Parameters[retParamName].Direction = ParameterDirection.ReturnValue;
                }
                else
                {
                    sqlCmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
                sqlCmd.Connection.Open();
                retVal = sqlCmd.ExecuteNonQuery();

                if (retParamName != String.Empty)
                {
                    retVal = sqlCmd.Parameters[retParamName].Value;
                }
            }

            finally
            {
                sqlCmd.Connection.Close();
            }

            return retVal;
        }
        
        public static object ExecuteNonQuery(SqlCommand sqlCommand, SqlTransaction objSqlTransaction)
        {
            // Validating SqlCommand
            if (sqlCommand == null) throw new Exception("Error in provided parameter <SqlCommand>. Please review your SqlCommand object.");

            // Validating Connection
            if (sqlCommand.Connection == null) throw new Exception("Error in provided Connection. Please set SqlCommand.Connection = new SqlConnection(string ConnectionString); or in other ways.");

            // Validating CommandText
            if (String.IsNullOrEmpty(sqlCommand.CommandText)) throw new Exception("Error in provided Command Text. Please set SqlCommand.CommandText = \"Some SQL query or StoredProcedure name\"; or in other ways.");

            using (sqlCommand)
            {
                sqlCommand.Transaction = objSqlTransaction;

                try
                {
                    // Finally, execute the command
                    object retval = sqlCommand.ExecuteNonQuery();
                    //sqlCommand.ExecuteXmlReader();
                    // If @@Identity returned from SP then return @@Identity
                    for (Int32 i = 0; i < sqlCommand.Parameters.Count; i++)
                    {
                        if (sqlCommand.Parameters[i].Direction == ParameterDirection.ReturnValue)
                        {
                            if (sqlCommand.Parameters[i].Value != null)
                                retval = sqlCommand.Parameters[i].Value;
                            break;
                        }
                    }

                    return retval;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static object ExecuteNonQueryCmd(string cmdText, CommandType cmdType, SqlParameterCollection sqlParameters)
        {
            // this method will return the return value parameter of the stored procedure, if there is one,
            // otherwise it will return the number of rows affected

            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            if (sqlParameters == null)
                throw new ArgumentNullException("sqlParameters");

            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandTimeout = 9999;
            string retParamName = String.Empty;
            object retVal = null;

            foreach (SqlParameter p in sqlParameters)
            {
                if (p.Direction == ParameterDirection.ReturnValue)
                {
                    retParamName = p.ParameterName;
                    sqlCmd.Parameters.Add(p.ParameterName, p.SqlDbType);
                    sqlCmd.Parameters[retParamName].Direction = ParameterDirection.ReturnValue;
                }
                else
                {
                    sqlCmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
                sqlCmd.Connection.Open();
                retVal = sqlCmd.ExecuteNonQuery();

                if (retParamName != String.Empty)
                {
                    retVal = sqlCmd.Parameters[retParamName].Value;
                }
            }
            catch (Exception ex) { }
            finally
            {
                sqlCmd.Connection.Close();
            }

            return retVal;
        }

        public static object ExecuteScalarCmd(string cmdText, CommandType cmdType, SqlParameterCollection sqlParameters)
        {
            // this method will return the return value parameter of the stored procedure, if there is one,
            // otherwise it will return the number of rows affected

            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            if (sqlParameters == null)
                throw new ArgumentNullException("sqlParameters");

            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandTimeout = 9999;
            string retParamName = String.Empty;
            object retVal = null;

            foreach (SqlParameter p in sqlParameters)
            {
                if (p.Direction == ParameterDirection.ReturnValue)
                {
                    retParamName = p.ParameterName;
                    sqlCmd.Parameters.Add(p.ParameterName, p.SqlDbType);
                    sqlCmd.Parameters[retParamName].Direction = ParameterDirection.ReturnValue;
                }
                else
                {
                    sqlCmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
                sqlCmd.Connection.Open();
                retVal = sqlCmd.ExecuteScalar();

                if (retParamName != String.Empty)
                {
                    retVal = sqlCmd.Parameters[retParamName].Value;
                }
            }
            catch (Exception ex) { }
            finally
            {
                sqlCmd.Connection.Close();
            }

            return retVal;
        }

        public static object ExecuteNonQueryCmd(SqlConnection sqlCon, string cmdText, CommandType cmdType, SqlParameterCollection sqlParameters)
        {
            // this method will return the return value parameter of the stored procedure, if there is one,
            // otherwise it will return the number of rows affected

            // validate parameters
            if (cmdText == String.Empty)
                throw new ArgumentOutOfRangeException("cmdText");

            if (sqlParameters == null)
                throw new ArgumentNullException("sqlParameters");

            SqlConnection sqlConn = sqlCon;
            SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConn);
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandTimeout = 9999;
            string retParamName = String.Empty;
            object retVal = null;

            foreach (SqlParameter p in sqlParameters)
            {
                if (p.Direction == ParameterDirection.ReturnValue)
                {
                    retParamName = p.ParameterName;
                    sqlCmd.Parameters.Add(p.ParameterName, p.SqlDbType);
                    sqlCmd.Parameters[retParamName].Direction = ParameterDirection.ReturnValue;
                }
                else
                {
                    sqlCmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
                sqlCmd.Connection.Open();
                retVal = sqlCmd.ExecuteNonQuery();

                if (retParamName != String.Empty)
                {
                    retVal = sqlCmd.Parameters[retParamName].Value;
                }
            }

            finally
            {
                sqlCmd.Connection.Close();
            }

            return retVal;
        }

        //---------------------------------- end ---------------------------------------

        /// <summary>
        /// Execute a SqlCommand (that returns a Dataset) against the database with specified connection string.
        /// </summary>     
        /// <param name="CmdType">The CommandType (stored procedure or text).</param>
        /// <param name="CmdText">The stored procedure name or T-SQL command.</param>
        /// <returns>A dataset containing the resultset generated by the command.</returns>
        public static DataSet ExecuteDataset(CommandType CmdType, string CmdText)
        {
            // create a new instance of SQL Connection
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Create a new instance of SQL Command and set attributes
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CmdType;
                cmd.CommandText = CmdText;
                cmd.CommandTimeout = 9999;

                //  Create a new instance of SQL DataAdapter and fill DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    connection.Close();
                    if (ds.Tables.Count < 1)
                        ds.Tables.Add(new DataTable());
                    return ds;
                }
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a Dataset) against the database with specified connection string.
        /// </summary>    
        /// <param name="CmdType">The CommandType (stored procedure or text).</param>
        /// <param name="CmdText">The stored procedure name or T-SQL command.</param>
        /// <param name="sqlParam">The stored procedure parameters.</param>
        /// <returns>A dataset containing the resultset generated by the command.</returns>
        public static DataSet ExecuteDataset(CommandType CmdType, string CmdText, SqlParameter sqlParam)
        {
            // create a new instance of SQL Connection
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Create a new instance of SQL Command and set attributes
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CmdType;
                cmd.CommandText = CmdText;
                cmd.CommandTimeout = 9999;
                cmd.Parameters.AddWithValue(sqlParam.ParameterName, sqlParam.Value);

                //  Create a new instance of SQL DataAdapter and fill DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    connection.Close();
                    return ds;
                }
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a Dataset) against the database with specified connection string.
        /// </summary>  
        /// <param name="CmdType">The CommandType (stored procedure or text).</param>
        /// <param name="cmdText">The stored procedure name or T-SQL command.</param>
        /// <param name="sqlParam">The stored procedure parameters.</param>
        /// <returns>A dataset containing the resultset generated by the command.</returns>
        public static DataSet ExecuteDataset(CommandType CmdType, string cmdText, SqlParameterCollection sqlParameters)
        {
            // create a new instance of SQL Connection
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // validate parameters
                if (cmdText == String.Empty)
                    throw new ArgumentOutOfRangeException("cmdText");

                if (sqlParameters == null)
                    throw new ArgumentNullException("sqlParameters");

                // Create a new instance of SQL Command and set attributes
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CmdType;
                cmd.CommandText = cmdText;
                cmd.CommandTimeout = 9999;

                foreach (SqlParameter p in sqlParameters)
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);

                //  Create a new instance of SQL DataAdapter and fill DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    connection.Close();
                    if (ds.Tables.Count < 1)
                        ds.Tables.Add(new DataTable());
                    return ds;
                }
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a Dataset) against the database with specified connection string.
        /// </summary> 
        /// <param name="sqlconn">A connection string for a SqlConnection.</param>
        /// <param name="CmdType">The CommandType (stored procedure or text).</param>
        /// <param name="cmdText">The stored procedure name or T-SQL command.</param>
        /// <param name="sqlParameters">The stored procedure parameters.</param>
        /// <returns>A dataset containing the resultset generated by the command.</returns>
        public static DataSet ExecuteDataset(CommandType CmdType, string cmdText, SqlParameterCollection sqlParameters, String sqlconn)
        {
            // create a new instance of SQL Connection
            using (SqlConnection connection = new SqlConnection(sqlconn))//isReportingPortal ? ReportingConnectionString : ConnectionString))
            {
                connection.Open();
                // validate parameters
                if (cmdText == String.Empty)
                    throw new ArgumentOutOfRangeException("cmdText");

                if (sqlParameters == null)
                    throw new ArgumentNullException("sqlParameters");

                // Create a new instance of SQL Command and set attributes
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CmdType;
                cmd.CommandText = cmdText;
                cmd.CommandTimeout = 9999;

                foreach (SqlParameter p in sqlParameters)
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);

                //  Create a new instance of SQL DataAdapter and fill DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    connection.Close();
                    if (ds.Tables.Count  > 0)
                        ds.Tables.Add(new DataTable());
                    return ds;
                }
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a Dataset) against the database with specified connection string.
        /// </summary> 
        /// <param name="sqlconn">A connection string for a SqlConnection.</param>
        /// <param name="CmdType">The CommandType (stored procedure or text).</param>
        /// <param name="cmdText">The stored procedure name or T-SQL command.</param>
        /// <param name="sqlParameters">The stored procedure parameters.</param>
        /// <returns>A dataset containing the resultset generated by the command.</returns>
        public static DataSet ExecuteDataset(CommandType CmdType, string cmdText, SqlParameterCollection sqlParameters, SqlConnection sqlconn)
        {
            // create a new instance of SQL Connection
            using (SqlConnection connection = new SqlConnection(sqlconn.ConnectionString))
            {
                connection.Open();
                // validate parameters
                if (cmdText == String.Empty)
                    throw new ArgumentOutOfRangeException("cmdText");

                if (sqlParameters == null)
                    throw new ArgumentNullException("sqlParameters");

                // Create a new instance of SQL Command and set attributes
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CmdType;
                cmd.CommandText = cmdText;
                cmd.CommandTimeout = 9999;

                foreach (SqlParameter p in sqlParameters)
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);

                //  Create a new instance of SQL DataAdapter and fill DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    connection.Close();
                    if (ds.Tables.Count < 1)
                        ds.Tables.Add(new DataTable());
                    return ds;
                }
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a Dataset) against the database with specified connection string.
        /// </summary>
        /// <param name="sqlconn">A connection string for a SqlConnection.</param>
        /// <param name="cmdType">The CommandType (stored procedure or text).</param>
        /// <param name="CmdText">The stored procedure name or T-SQL command.</param>
        /// <returns>A dataset containing the resultset generated by the command.</returns>
        public static DataSet ExecuteDataset(CommandType CmdType, string cmdText, string sqlconn)
        {
            // create a new instance of SQL Connection
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                connection.Open();

                // Create a new instance of SQL Command and set attributes
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CmdType;
                cmd.CommandText = cmdText;
                cmd.CommandTimeout = 9999;

                //  Create a new instance of SQL DataAdapter and fill DataSet
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    connection.Close();
                    if (ds.Tables.Count > 0)
                        ds.Tables.Add(new DataTable());
                    return ds;
                }
            }

        }

        //---------------------------------- end ---------------------------------------

    }
}