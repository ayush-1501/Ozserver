using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using Ozserver.Business_layer;
using System.Web.Services.Description;

namespace Ozserver
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string TableLink = System.Configuration.ConfigurationManager.AppSettings["url2"].ToString();
        int MasterCount =0;
        int EDNCount =0;
        int AQISCount = 0;
        int PRACount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is authenticated
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // If not authenticated, redirect to the login page
                Response.Redirect("Login.aspx");
            }
            else
            {
                // Continue loading the dashboard page
         
                Page.Title = "Dashboard";
                string apiUrl = TableLink;

                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyy-MM-dd");
                     apiUrl = TableLink + "EDNDocument/GetEDNDataRecordCount?toDate="+ formattedDate+"&TypeOfQuery=DATE";
                     EDNCount= ReturnCount(apiUrl);
                     lbl1Message.Text = EDNCount.ToString();


                    apiUrl = TableLink + "PRADocument/GetPRADataRecordCount?toDate="+formattedDate+"&TypeOfQuery=DATE";
                    PRACount = ReturnCount(apiUrl);
                    lbl2Message.Text = PRACount.ToString();

                   apiUrl = TableLink + "AQISDocument/GetAQISDataRecordCount?toDate="+formattedDate+"&TypeOfQuery=DATE";
                    AQISCount = ReturnCount(apiUrl);
                   lbl3Message.Text = AQISCount.ToString();


                    apiUrl = TableLink + "MasterDocument/GetMasterDataRecordCount?toDate="+ formattedDate+"&TypeOfQuery=DATE";
                    MasterCount = ReturnCount(apiUrl);
                    lbl4Message.Text = MasterCount.ToString();


            }
        }

        public int ReturnCount(string apiUrl)
        {
            RestAPICaller apiCaller = new RestAPICaller();
            string jsonResult = apiCaller.CallRestAPI(apiUrl);

            try
            {
                // Deserialize to a List of Branch
                List<Branch> branches = JsonConvert.DeserializeObject<List<Branch>>(jsonResult);

                // Assuming the array will always have one element, access the first branch
                if (branches.Count > 0)
                {
                    return branches[0].count;
                }
                else
                {
                    // Handle the case where the array is empty (optional)
                    Console.WriteLine("No branches found in the response.");
                    return -1; // Or some other default value
                }
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
                return -1; // Or some other default value
            }
        }

        public class Branch
        {
            public int count { get; set; }
        }
    }
}


