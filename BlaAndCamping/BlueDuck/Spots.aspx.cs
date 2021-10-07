using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{ 
    public partial class Spots : System.Web.UI.Page
    {
        int spotType;

        protected void Page_Load(object sender, EventArgs e)
        {
            string spotType = Request.QueryString["Type"];

           
        }
    }
}