using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlaAndCamping.BlueDuck
{
    public partial class BookingExtras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tBox_Adults.Text = 0;
            tBox_Children.Text = 0;
            tBox_Dogs.Text = 0;

        }
    }
}