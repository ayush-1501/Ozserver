using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Ozserver
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear session used during login
            Session.Clear();
            Session.Abandon();

            // Write "You are logged out" on the page inside a div
            Response.Write("<div style='position: absolute; top: 50%; left: 50%; transform: translate(-50%, -50%); text-align: center;'>You are logged out</div>");

            // Redirect to the login page after a brief delay
            Response.AddHeader("REFRESH", "3;URL=Login.aspx");
        }
    }
}