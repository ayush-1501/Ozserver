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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public async Task<string> btnCREATE_Click(string officeId, string companyName, string emailAddress)
        {
            try
            {
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

                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Parse and return the JSON response
                    return responseContent;
                }
                else
                {
                    // Return an error message for the client to handle
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    return $"Error: {jsonResponse.message}";
                }
            }
            catch (Exception ex)
            {
                // Log and return error message
                Console.WriteLine($"Exception: {ex.Message}");
                return $"Error: {ex.Message}";
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public async Task<string> UpdateOrganisationDataByIdAsync(int searchId, string newCompanyName, string newEmailAddress)
        {
            try
            {
                // Construct the URL for updating user data with new values
                string updateUrl = $"https://localhost:7209/api/Organisation/UpdateOrganisationDataById?Id={searchId}&CompanyName={Uri.EscapeDataString(newCompanyName)}&Email_Address={Uri.EscapeDataString(newEmailAddress)}";

                // Create an instance of HttpClient to make the HTTP request
                using (HttpClient client = new HttpClient())
                {
                    // Optionally, set the request headers
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Send a GET request to the constructed URL
                    HttpResponseMessage response = await client.GetAsync(updateUrl);

                    // Check the response status code
                    if (response.IsSuccessStatusCode)
                    {
                        // If the request was successful, return the response content as a string
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Organisation data updated successfully.");
                        Console.WriteLine("Response Content: " + responseContent);
                        return responseContent; // Return the response content to the client side
                    }
                    else
                    {
                        // Handle unsuccessful response and return error message
                        string errorMessage = $"Failed to update organisation data. Status Code: {response.StatusCode}";
                        Console.WriteLine(errorMessage);
                        return errorMessage; // Return the error message to the client side
                    }
                }
            }
            catch (Exception ex)
            {
                // Log and return error message
                string exceptionMessage = $"Exception occurred: {ex.Message}";
                Console.WriteLine(exceptionMessage);
                return exceptionMessage; // Return the exception message to the client side
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