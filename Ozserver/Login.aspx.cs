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

        bool EDN = false;
        bool AQIS = false; 
        bool PRA = false; 
        bool MASTER = false; 
        protected void Page_Load(object sender, EventArgs e)
        {
           

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
               
                RestAPICaller apiCaller = new RestAPICaller();
                string jsonResult = apiCaller.CallRestAPI(apiUrl);





               
                if (jsonResult!="[]")
                {
                    
                       data = JsonConvert.DeserializeObject<List<Users>>(jsonResult);

                  
                        int Id = data[0].Id;
                        int OrgId= data[0].OrgId;
                        string CompanyName= data[0].CompanyName;
                        string Email_Address= data[0].EmailAddress;
                        string OfficeId = data[0].OfficeId;

                        EDN = true;
                        AQIS = true;
                        PRA = true;
                        MASTER = true;
                        // Store the values in session state
                        Session["EDN"] = EDN;
                        Session["AQIS"] = AQIS;
                        Session["PRA"] = PRA;
                        Session["MASTER"] = MASTER;
                        Role = "Admin";
                        Session["Role"] = Role;
                        Session["OfficeID"] = OfficeID;
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