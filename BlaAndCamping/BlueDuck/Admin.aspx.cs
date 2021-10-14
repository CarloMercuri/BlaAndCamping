using BlaAndCamping.DataControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{
    public partial class Admin : System.Web.UI.Page
    {
        DatabaseInterface _db;
        protected void Page_Load(object sender, EventArgs e)
        {
            _db = new DatabaseInterface("esxi");

            if (!IsPostBack)
            {
                Session["username"] = "";
                Session["password"] = "";
            }

            btn_Submit.Click += (su, args) =>
            {
                int account = _db.AuthenticateUserPass(input_username.Value, input_password.Value);
                Session["AdminUser"] = account;
                Response.Redirect("AdminPage.aspx");
            };
        }
    }
}