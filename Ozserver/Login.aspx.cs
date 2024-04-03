using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozserver
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ... (Existing code for checking authentication and redirection)

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string randomEmail = "test@example.com";
            string randomPassword = "randompassword123";

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string Role = "Admin";
            string OfficeID = "ANZCO";

            bool EDN = false; // Define boolean variable EDN
            bool AQIS = false; // Define boolean variable AQIS
            bool PRA = false; // Define boolean variable PRA


            // Assuming you set the values of EDN, AQIS, and PRA based on some conditions
            if (email == randomEmail && password == randomPassword)
            {
                EDN = true;
                AQIS = true;
                PRA = true;
                Role = "Non-Admin";
                OfficeID = "ANZCO";
            }

            // Store the values in session state
            Session["EDN"] = EDN;
            Session["AQIS"] = AQIS;
            Session["PRA"] = PRA;
            //store value of kind of user
            Session["Role"] = Role;
            Session["OfficeID"] = OfficeID;

            if (email == randomEmail && password == randomPassword)
            {
                // Authentication successful
                Session["Authenticated"] = true;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                // Authentication failed
                // Show alert message using client-side JavaScript
                ClientScript.RegisterStartupScript(this.GetType(), "LoginFailed", "alert('WRONG USERNAME OR PASSWORD');", true);
            }
        }
    }
}