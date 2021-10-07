using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Handler
/// </summary>
/// 
namespace Helper
{
    #region ---  Class  ---
    public class Handler
    {
        #region --- Constructor  ---
        public Handler()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        #endregion

        #region ---  Methods  ---
        public static Users Users_SelectUser(SqlParameterCollection parameters)
        {
            Users user = null;
            DataSet ds = new DataSet();
            ds.Clear();
            try
            {
                ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "", parameters, ClientSessions.ConnectionString_CMSManagementApp());
                if (ds.Tables.Count < 1)
                    ds.Tables.Add(new DataTable());
            }
            catch (Exception)
            {

            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                user = new Users();
                user.ID = int.Parse(ds.Tables[0].Rows[0]["employeeID"].ToString());
                user.FirstName = ds.Tables[0].Rows[0]["firstName"].ToString();
                user.LastName = ds.Tables[0].Rows[0]["lastName"].ToString();
                user.Username = ds.Tables[0].Rows[0]["userName"].ToString();
                user.EmailAddress = ds.Tables[0].Rows[0]["employeeEmail"].ToString();
                user.AspnetUserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                user.CreatedBy = int.Parse(ds.Tables[0].Rows[0]["employeeTitle"].ToString());
                user.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["employeeGender"].ToString());
                user.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString());
                user.AspnetUserID = ds.Tables[0].Rows[0]["AspnetUserID"].ToString();
                user.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
            }

            return user;
        }

        public static Users SessionFill(DataSet ds)
        {
            Users user = null;
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    user = new Users();

                    user.ID = int.Parse(ds.Tables[0].Rows[0]["employeeID"].ToString());
                    user.Username = ds.Tables[0].Rows[0]["userName"].ToString();
                    user.FullName = ds.Tables[0].Rows[0]["fullName"].ToString();
                    user.FirstName = ds.Tables[0].Rows[0]["firstName"].ToString();
                    user.LastName = ds.Tables[0].Rows[0]["lastName"].ToString();
                    user.userID = ds.Tables[0].Rows[0]["UserID"].ToString();
                    user.EmailAddress = ds.Tables[0].Rows[0]["employeeEmail"].ToString();
                    user.AspnetUserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                    user.employeeTitle = ds.Tables[0].Rows[0]["employeeTitle"].ToString();
                    user.employeeGender = ds.Tables[0].Rows[0]["employeeGender"].ToString();
                    user.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString());
                    user.designationID = ds.Tables[1].Rows[0]["designationID"].ToString();
                    user.RoleName = ds.Tables[1].Rows[0]["designationName"].ToString();
                    ClientSessions.UserID = user.userID;
                    ClientSessions.Role = user.RoleName;
                    ClientSessions.ID = user.ID;
                    HttpContext.Current.Session["UserID"] = user.userID;
                    HttpContext.Current.Session["UserName"] = user.Username;
                    HttpContext.Current.Session["UserRole"] = user.RoleName;        

                }

            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public static Users Users_SelectbyUserID(SqlParameterCollection parameters)
        {
            Users user = null;
            DataSet ds = new DataSet();
            ds.Clear();
            try
            {
                ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "Employee_GetByUserId", parameters, ClientSessions.ConnectionString_UserCMSManagementApp());
                if (ds.Tables.Count > 0)
                    ds.Tables.Add(new DataTable());
            }
            catch (Exception)
            {

            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                user = new Users();

                user.ID = int.Parse(ds.Tables[0].Rows[0]["employeeID"].ToString());
                user.Username = ds.Tables[0].Rows[0]["userName"].ToString();
                user.FullName = ds.Tables[0].Rows[0]["fullName"].ToString();
                user.FirstName = ds.Tables[0].Rows[0]["firstName"].ToString();
                user.LastName = ds.Tables[0].Rows[0]["lastName"].ToString();
                user.userID = ds.Tables[0].Rows[0]["UserID"].ToString();
                user.EmailAddress = ds.Tables[0].Rows[0]["employeeEmail"].ToString();
                user.AspnetUserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                user.employeeTitle = ds.Tables[0].Rows[0]["employeeTitle"].ToString();
                user.employeeGender = ds.Tables[0].Rows[0]["employeeGender"].ToString();
                user.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString());

            }

            return user;
        }

        //public static DataSet Users_SelectAll()
        //{
        //    DataSet ds = new DataSet();

        //    ds.Clear();

        //    try
        //    {
        //        ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "Users_SelectAll");
        //        if (ds.Tables.Count < 1)
        //            ds.Tables.Add(new DataTable());
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return ds;
        //}
       
        #endregion
    }

    #endregion
}