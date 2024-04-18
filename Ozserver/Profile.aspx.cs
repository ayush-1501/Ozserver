using Newtonsoft.Json;
using Ozserver.Business_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Ozserver.Login;
using static Ozserver.WebForm1;

namespace Ozserver
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {

                Response.Redirect("Login.aspx");
            }
            else
            {
                Page.Title = "Profile";

                string user_ids = (string)Session["user_id"];
                string password = (string)Session["password"];


                string apiUrl = "http://crm2.omnix.com.au/OzdocsServerWebAPI/api/Login/Login?UserName=";
                apiUrl += user_ids + "&";
                apiUrl += "Password=" + password;

                List<Users> data = new List<Users>();

                if (!string.IsNullOrEmpty(apiUrl))
                {

                    RestAPICaller apiCaller = new RestAPICaller();
                    string jsonResult = apiCaller.CallRestAPI(apiUrl);


                    if (jsonResult != "[]")
                    {

                         data = JsonConvert.DeserializeObject<List<Users>>(jsonResult);


                    }
                    if (data != null && data.Count > 0)
                    {
                       
                        Users firstUser = data[0];

                      
                        int orgId = firstUser.OrgId;
                        string userId = firstUser.UserId;
                        string emailAddress = firstUser.EmailAddress;
                        string officeId= firstUser.OfficeId;



                        OrgIdControl.Value = orgId.ToString(); 
                        UserIdControl.Value = userId;
                        EmailAddress.Value = emailAddress;
                        OfficeIdControl.Value = officeId.ToString();


                    }

                }
               
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