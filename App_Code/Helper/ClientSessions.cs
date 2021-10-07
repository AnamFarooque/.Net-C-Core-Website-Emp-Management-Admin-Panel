using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Configuration;


/// <summary>
/// Summary description for Handler
/// </summary>
/// 
namespace Helper
{
    public class ClientSessions
    {
        #region --- Methods ---
        public static SqlParameterCollection GetParameterCollectionConstructor()
        {
            return (SqlParameterCollection)typeof(SqlParameterCollection).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null).Invoke(null);
        }

        public static String ConnectionString_CMSManagementApp()
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return conn;
        }

        public static String ConnectionString_UserCMSManagementApp()
        {
            string conn = ConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString;
            return conn;
        }

        public static String ConnectionString_ClientsConfiguration()
        {
            return ConfigurationManager.ConnectionStrings["ClientsConfiguration"].ConnectionString;
        }

        public static string Encrypt(string toEncode)
        {
            var toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            var returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string Decrypt(string encodeData)
        {

            var encodeDataAsBytes = System.Convert.FromBase64String(encodeData);
            var returnValue = Encoding.ASCII.GetString(encodeDataAsBytes);
            return returnValue;
        }

        public static String UserID
        {
            get
            {
                if (HttpContext.Current.Session["UserID"] == null)
                    return "";
                else
                    return HttpContext.Current.Session["UserID"].ToString();
            }
            set { HttpContext.Current.Session["UserID"] = value; }
        }

        public static int? ID
        {
            get
            {
                if (HttpContext.Current.Session["ID"] == null)
                    return null;
                else
                    return int.Parse(HttpContext.Current.Session["ID"].ToString());
            }
            set { HttpContext.Current.Session["ID"] = value; }
        }

        public static String Role
        {
            get
            {
                if (HttpContext.Current.Session["Role"] == null)
                    return "";
                else
                    return HttpContext.Current.Session["Role"].ToString();
            }
            set { HttpContext.Current.Session["Role"] = value; }
        }

        public static String UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] == null)
                    return "";
                else
                    return HttpContext.Current.Session["UserName"].ToString();
            }
            set { HttpContext.Current.Session["UserName"] = value; }
        }

        public static Users Users
        {
            get
            {
                if (!String.IsNullOrEmpty(UserID))
                {
                    if (HttpContext.Current.Session["_Users"] == null)
                    {
                        SqlParameterCollection collection = GetParameterCollectionConstructor();
                        collection.AddWithValue("@UserID", UserID);
                        Users user = Handler.Users_SelectbyUserID(collection);

                        HttpContext.Current.Session["_Users"] = user;
                        return HttpContext.Current.Session["_Users"] as Users;
                    }
                    else
                        return HttpContext.Current.Session["_Users"] as Users;
                }
                else
                {
                    HttpContext.Current.Session["_Users"] = null;
                    return HttpContext.Current.Session["_Users"] as Users;
                }
            }
            set { HttpContext.Current.Session["_Users"] = value; }
        }

        public ClientSessions()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion
    }
}