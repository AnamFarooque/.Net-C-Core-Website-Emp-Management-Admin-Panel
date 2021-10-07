using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Helper;
using System.Collections.ObjectModel;

namespace Helper
{
    #region ---  Class  ---
    public class Users
    {
        #region ---  Properties  ---
        public int ID { set; get; }
        public String FirstName { set; get; }
        public String LastName { set; get; }
        public String Username { set; get; }
        public String EmailAddress { set; get; }
        public String AspnetUserID { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
        public Boolean IsActive { set; get; }
        public String RoleName { set; get; }
        public String designationID { set; get; }
        public String FullName { set; get; }
        public String designationName { set; get; }
        public String employeeTitle { set; get; }
        public String employeeGender { set; get; }
        public String userID { set; get; }

        #endregion

        #region ---  Constructor  ---
        public Users()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region ---  Methods  ---

        /// <summary>
        /// Method is to Validate User in Login. 
        /// </summary>     
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Return True or False .</returns>
        ///Created by: Anam

        public static bool ValidateUser(string username, string password)
        {
            Boolean IsAuthorizedUser = false;
            SqlParameterCollection collection = ClientSessions.GetParameterCollectionConstructor();
            if (username == null) { return false; }
            if (password == null) { return false; }
            try
            {
                collection.Clear();
                collection.AddWithValue("@UserName", username);
                collection.AddWithValue("@Password", password);
                DataSet ds = Users.Users_SelectbyUsername(collection);
                if (ds.Tables.Count == 0)
                    IsAuthorizedUser = false;
                
                if (ds.Tables.Count > 0)
                {
                   Users usr = Handler.SessionFill(ds);
                    
                   IsAuthorizedUser = true;
                }
            }
            catch (Exception ex)
            {
                IsAuthorizedUser = false;
            }
            return IsAuthorizedUser;
        }

        public static DataSet Users_SelectbyUsername(SqlParameterCollection parameters)
        {
            Users user = null;
            DataSet ds = new DataSet();
            ds.Clear();
            try
            {
                ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "CMS_Employee_Authentication", parameters, ClientSessions.ConnectionString_UserCMSManagementApp());
                if (ds.Tables.Count > 0)
                    ds.Tables.Add(new DataTable());
            }
            catch (Exception ex)
            {

            }


            return ds;
        }

        //public static DataSet User_Insert(SqlParameterCollection parameters)
        //{
        //    DataSet ds = new DataSet();
        //    // ds.Clear();
        //    try
        //    {
        //        ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "USER_INSERT", parameters, ClientSessions.ConnectionString_CMSManagementApp());
        //        if (ds.Tables.Count < 1)
        //            ds.Tables.Add(new DataTable());
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Write(e);
        //    }
        //    return ds;
        //}

        //public static DataSet User_Update(SqlParameterCollection parameters)
        //{
        //    DataSet ds = new DataSet();
        //    ds.Clear();
        //    try
        //    {
        //        ds = SQLHelper.ExecuteDataset(CommandType.StoredProcedure, "USER_Update", parameters, ClientSessions.ConnectionString_CMSManagementApp());
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
