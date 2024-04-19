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
                     if(EDNCount <= 0)EDNCount = 0;
                     lbl1Message.Text = EDNCount.ToString();


                    apiUrl = TableLink + "PRADocument/GetPRADataRecordCount?toDate="+formattedDate+"&TypeOfQuery=DATE";
                    PRACount = ReturnCount(apiUrl);
                     if (PRACount <= 0) PRACount = 0;
                     lbl2Message.Text = PRACount.ToString();

                   apiUrl = TableLink + "AQISDocument/GetAQISDataRecordCount?toDate="+formattedDate+"&TypeOfQuery=DATE";
                    AQISCount = ReturnCount(apiUrl);
                    if (AQISCount <= 0) AQISCount = 0;
                    lbl3Message.Text = AQISCount.ToString();


                    apiUrl = TableLink + "MasterDocument/GetMasterDataRecordCount?toDate="+ formattedDate+"&TypeOfQuery=DATE";
                    MasterCount = ReturnCount(apiUrl);
                    if (MasterCount <= 0) MasterCount = 0;
                    lbl4Message.Text = MasterCount.ToString();


            }
        }

        public int ReturnCount(string apiUrl)
        {
            RestAPICaller apiCaller = new RestAPICaller();
            string jsonResult = apiCaller.CallRestAPI(apiUrl);

            try
            {
               
                List<Branch> branches = JsonConvert.DeserializeObject<List<Branch>>(jsonResult);

              
                if (branches.Count > 0)
                {
                    return branches[0].count;
                }
                else
                {
                    
                    Console.WriteLine("No branches found in the response.");
                    return -1; 
                }
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
                return -1;
            }
        }

        public class Branch
        {
            public int count { get; set; }
        }
    }
}


