using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementSystem
{
    #region --- Class ---
    public partial class Default : System.Web.UI.Page
    {
        #region --- Events ---
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (!this.Page.User.Identity.IsAuthenticated)
            //    Response.Redirect("~/Login.aspx");

            //if (!Page.IsPostBack)
            //{
            //    CheckRoles();
            //}
        }

        #endregion

        #region --- Methods ---

        //public void CheckRoles()
        //{

        //    DivAppConfig.Visible = divMachines.Visible = divSysConfig.Visible = false;
        //    //divUsers.Visible = false;
        //    if(Session["role"] != null)
        //    {
        //        if ((Session["role"].ToString() == "twc superadmin") || (Session["role"].ToString() == "Superadmin"))
        //        {
        //            //divUsers.Visible = true;
        //            DivAppConfig.Visible = divMachines.Visible = divSysConfig.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("~/Login.aspx");
        //    }
         
        //}

        #endregion
    }
    #endregion
}