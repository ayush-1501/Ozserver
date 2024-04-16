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

namespace Ozserver
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        string _transmissionSource;
        int _searchId;
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
                                string apiUrl = "https://localhost:7209/api/Organisation/GetOrganisationDataById?Id=" + searchId;
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            string officeId = OfficeId.Value;
            string companyName = CompanyName.Value;
            string emailAddress = EmailAddress.Value;

           
            HttpClient client = new HttpClient();

           
            string url = "https://localhost:7209/api/Organisation/OrganisationCreate";

            
            var organisationData = new
            {
                id = 5,
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
                    string message=jsonResponse.message;
                  
                    if (message.IndexOf("duplicate key value violates unique constraint \"unique_OfficeId\"", StringComparison.Ordinal) >= 0)
                    {
                        // Display error message on the frontend
                        lblError.Text = "OfficeId already exists. Please enter a different OfficeId.";
                        lblError.Visible = true;
                    }
                    else
                    {
                        Console.WriteLine($"Message: {jsonResponse.message}");
                    }
                }
            }
            else
            {
                // Handle unsuccessful response
                if (jsonResponse != null && jsonResponse.success == "0")
                {
                    string message = jsonResponse.message;

                    // Display error message
                    lblError.Text = $"Error: {message}";
                    lblError.Visible = true;
                }
            }
        }

        protected void btn_ClickUPDATE(object sender, EventArgs e)
        {
            // Retrieve new values from input fields directly
            string newOrgNameValue = OfficeId.Value; // New UserId from form field
            string newCompanyName = CompanyName.Value; // New Password from form field
            string newEmailAddress = EmailAddress.Value;

            if (Request.QueryString["id"] != null)
            {
                // Parse the 'id' parameter as an integer
                if (int.TryParse(Request.QueryString["id"], out int searchId1))
                {
                    _searchId = searchId1;
                }
            }
            // Use the _searchId obtained from Page_Load to update the data
            int searchId = _searchId;

            // Construct the URL for updating user data with new values
            string updateUrl = $"https://localhost:7209/api/Organisation/UpdateOrganisationDataById?Id={searchId}&CompanyName={Uri.EscapeDataString(newCompanyName)}&Email_Address=={Uri.EscapeDataString(newEmailAddress)}";

            // Create an instance of HttpClient to make the HTTP request
            using (HttpClient client = new HttpClient())
            {
                // Optionally, set the request headers
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Send a GET request to the constructed URL
                HttpResponseMessage response = client.GetAsync(updateUrl).Result;

                // Check the response status code
                if (response.IsSuccessStatusCode)
                {
                    // If the request was successful, handle the response content as needed
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("User data updated successfully.");
                    Console.WriteLine("Response Content: " + responseContent);
                }
                else
                {
                    // Handle unsuccessful response, e.g., display an error message
                    Console.WriteLine($"Failed to update user data. Status Code: {response.StatusCode}");
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