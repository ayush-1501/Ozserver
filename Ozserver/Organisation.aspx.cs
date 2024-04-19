using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Ozserver.Business_layer;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Script.Services;
using System.Web.Services;

namespace Ozserver
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        string _transmissionSource;
        int _searchId;
        string SearchLink = System.Configuration.ConfigurationManager.AppSettings["url2"].ToString();
        public string OrgNameValue { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // If not authenticated, redirect to the login page
                if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Page.Title = "ORGANISATION";
                    // Retrieve the 'source' query parameter from the URL
                    if (Request.QueryString["source"] != null)
                    {
                        _transmissionSource = Request.QueryString["source"].ToUpper();

                        // Retrieve the 'id' query parameter from the URL
                        if (Request.QueryString["id"] != null)
                        {
                            // Parse the 'id' parameter as an integer
                            if (int.TryParse(Request.QueryString["id"], out int searchId))
                            {
                                _searchId = searchId;

                                // Call the API to get user data
                                string apiUrl = SearchLink+"Organisation/GetOrganisationDataById?Id=" + searchId;
                                RestAPICaller apiCaller = new RestAPICaller();
                                string jsonResult = apiCaller.CallRestAPI(apiUrl);

                                // Deserialize the API response
                                List<Branch> data = new List<Branch>();
                                try
                                {
                                    // Deserialize JSON as a list of Branch objects
                                    JsonSerializerSettings settings = new JsonSerializerSettings
                                    {
                                        NullValueHandling = NullValueHandling.Ignore
                                    };
                                    data = JsonConvert.DeserializeObject<List<Branch>>(jsonResult, settings);
                                }
                                catch (JsonSerializationException)
                                {
                                    // If deserialization as a list fails, try deserializing as a single object
                                    try
                                    {
                                        Branch singleBranch = JsonConvert.DeserializeObject<Branch>(jsonResult);
                                        data.Add(singleBranch);
                                    }
                                    catch (JsonSerializationException innerEx)
                                    {
                                        Console.WriteLine("Error deserializing JSON as single object: " + innerEx.Message);
                                    }
                                }

                                if (data != null && data.Count > 0)
                                {
                                    Branch branch = data[0];
                                    OrgNameValue = branch.OrgId; 
                                    OfficeId.Value = branch.OfficeId;
                                    CompanyName.Value = branch.CompanyName;
                                    EmailAddress.Value = branch.Email_Address;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnADD_Click(object sender, EventArgs e)
        {

            string officeId = OfficeId1.Value;
            string companyName = CompanyName.Value;
            string emailAddress = EmailAddress.Value;


            HttpClient client = new HttpClient();


            string url = SearchLink+"Organisation/OrganisationCreate";


            var organisationData = new
            {
                officeId = officeId,
                companyName = companyName,
                email_Address = emailAddress
            };


            string jsonPayload = JsonConvert.SerializeObject(organisationData);


            HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.PostAsync(url, content).Result;


            string responseContent = response.Content.ReadAsStringAsync().Result;


            dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);


            if (response.IsSuccessStatusCode)
            {

                Console.WriteLine("Organization created successfully.");


                if (jsonResponse != null && jsonResponse.message != null)
                {
                    string message = jsonResponse.message;


                    Console.WriteLine($"Message: {jsonResponse.message}");

                }
            }
            else
            {

                if (jsonResponse != null && jsonResponse.success == "0")
                {
                    string message = jsonResponse.message;



                }
            }
            Response.Redirect("DocumentList.aspx?context=ORGANISATION");
        }

        protected void btn_ClickUPDATE(object sender, EventArgs e)
        {

            string newOrgNameValue = OfficeId.Value.Trim();
            string newCompanyName = CompanyName.Value.Trim();
            string newEmailAddress = EmailAddress.Value.Trim();

            if (Request.QueryString["id"] != null)
            {
                
                if (int.TryParse(Request.QueryString["id"], out int searchId1))
                {
                    _searchId = searchId1;
                }
            }
           
            int searchId = _searchId;

           
            string updateUrl = SearchLink+$"Organisation/UpdateOrganisationDataById?Id={searchId}&CompanyName={Uri.EscapeDataString(newCompanyName)}&Email_Address={Uri.EscapeDataString(newEmailAddress)}";

          
            using (HttpClient client = new HttpClient())
            {
               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                
                HttpResponseMessage response = client.GetAsync(updateUrl).Result;

                
                if (response.IsSuccessStatusCode)
                {
                    
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("User data updated successfully.");
                    Console.WriteLine("Response Content: " + responseContent);
                }
                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = $"Failed to update user data. Status Code: {response.StatusCode}";
                    HiddenErrorMessage.Value = errorMessage;
                }

                Response.Redirect("DocumentList.aspx?context=ORGANISATION");
            }
        }
        public bool IsTransmissionFrom(string source)
        {
            return _transmissionSource == source.ToUpper();
        }
        public class Branch
        {
            public string OrgId { get; set; }
            public string OfficeId { get; set; }
            public string CompanyName { get; set; }
            public string Email_Address { get; set; }
           
        }

    }
}