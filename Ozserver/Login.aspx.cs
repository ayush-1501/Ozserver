using Newtonsoft.Json;
using Ozserver.Business_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozserver
{
    public partial class Login : System.Web.UI.Page
    {
        string Role = "Admin";
        string OfficeID = "ANZCO";

        bool EDN = false; // Define boolean variable EDN
        bool AQIS = false; // Define boolean variable AQIS
        bool PRA = false; // Define boolean variable PRA
        protected void Page_Load(object sender, EventArgs e)
        {
            // ... (Existing code for checking authentication and redirection)

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user_ids = user_id.Text;
            string password = txtPassword.Text;

            Session["user_id"] = user_ids;
            Session["password"] = password;
           
            string apiUrl = "http://crm2.omnix.com.au/OzdocsServerWebAPI/api/Login/Login?UserName=";
            apiUrl += user_ids + "&";
            apiUrl += "Password=" + txtPassword.Text;

            List<Users> data = new List<Users>();

            if (!string.IsNullOrEmpty(apiUrl))
            {
                // Call the CallRestAPI function from BusinessAccessLayer
                RestAPICaller apiCaller = new RestAPICaller();
                string jsonResult = apiCaller.CallRestAPI(apiUrl);

                // Check if the JSON result contains a valid response
                if (jsonResult!="[]")
                {
                    // Deserialize the JSON result into a User object
                       data = JsonConvert.DeserializeObject<List<Users>>(jsonResult);

                    // Check if the deserialized object is not null
                        int Id = data[0].Id;
                        int OrgId= data[0].OrgId;
                        string CompanyName= data[0].CompanyName;
                        string Email_Address= data[0].EmailAddress;
                   
                        EDN = true;
                        AQIS = true;
                        PRA = true;

                        // Store the values in session state
                        Session["EDN"] = EDN;
                        Session["AQIS"] = AQIS;
                        Session["PRA"] = PRA;
                          Role = "Admin";
                        Session["Role"] = Role;
                        Session["OfficeID"] = OfficeID;
                      
                        OfficeID = "ANZCO";
                        Session["Authenticated"] = true;
                      
                        Response.Redirect("Dashboard.aspx");
   
                }
                else
                {
                    // Empty JSON response, print error message
              
                    ClientScript.RegisterStartupScript(this.GetType(), "LoginFailed", "alert('EMPTY JSON RESPONSE');", true);
                }
            }
            else
            {
                // API URL is empty, print error message
              
                ClientScript.RegisterStartupScript(this.GetType(), "LoginFailed", "alert('WRONG USERNAME OR PASSWORD');", true);
            }
          
          
        }

        public class Users
        {
            public int Id { get; set; }
            public int OrgId { get; set; }
            public string OfficeId { get; set; }
            public string CompanyName { get; set; }
            public string EmailAddress { get; set; }
            public string UserId { get; set; }
            public string Password { get; set; }
        }
    }
}