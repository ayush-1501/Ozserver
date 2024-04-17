using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Ozserver.Business_layer;
using System.Web.Services;
using System.Threading.Tasks;
using System.Web.Script.Services;

namespace Ozserver
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        string _transmissionSource;
        int _searchId;
        public string OrgNameValue { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the page is being loaded for the first time (not a postback)
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
                                string apiUrl = "https://localhost:7209/api/User/GetUserDataById?Id=" + searchId;
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
                                    OrgNameValue = branch.OrgId; // Set OrgNameValue from branch.OrgId

                                    // Iterate through the options of the OrgName dropdown
                                    foreach (ListItem option in OrgName.Items)
                                    {
                                        // If the value of the option matches the OrgNameValue, mark it as selected
                                        if (option.Value == OrgNameValue)
                                        {
                                            option.Selected = true;
                                            break; // Exit the loop once the matching option is found
                                        }
                                    }

                                    // Update other fields as needed
                                    UserId.Value = branch.UserId;
                                    Password.Value = branch.Password;
                                }
                            }
                        }
                    }
                }
            }
        }

        [WebMethod]
        public static string CallBtnClickAdd(string orgName, string userId, string password)
        {
            string url = "https://localhost:7209/api/User/UserCreate";

            var UserData = new
            {
                OrgId = orgName,
                UserId = userId,
                Password = password
            };

            HttpClient client = new HttpClient();

            string jsonPayload = JsonConvert.SerializeObject(UserData);
            HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;

            dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

            if (response.IsSuccessStatusCode)
            {
                if (jsonResponse != null && jsonResponse.message != null)
                {
                    return $"Organization created successfully. Message: {jsonResponse.message}";
                }
            }
            else
            {
                if (jsonResponse != null && jsonResponse.success == "0")
                {
                    return $"Error: {jsonResponse.message}";
                }
            }
            return "Error occurred";
        }




        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static async Task<string> UpdateUserDataById(string newOrgNameValue, string newUserId,  string newPassword)
        {
            // Get the searchId from query string
            int searchId = 0;
            if (HttpContext.Current.Request.QueryString["id"] != null)
            {
                // Parse the 'id' parameter as an integer
                if (int.TryParse(HttpContext.Current.Request.QueryString["id"], out int searchId1))
                {
                    searchId = searchId1;
                }
            }

            // Construct the URL for updating user data with new values
            string updateUrl = $"https://localhost:7209/api/User/UpdateUserDataById?Id={searchId}&password={Uri.EscapeDataString(newPassword)}&UserId={Uri.EscapeDataString(newUserId)}&OrgName={Uri.EscapeDataString(newOrgNameValue)}";

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
                    // If the request was successful, return the response content
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return $"User data updated successfully. Response Content: {responseContent}";
                }
                else
                {
                    // Handle unsuccessful response, e.g., return an error message
                    return $"Failed to update user data. Status Code: {response.StatusCode}";
                }
            }
        }

        public bool IsTransmissionFrom(string source)
        {
            return _transmissionSource == source.ToUpper();
        }

        public class Branch
        {
            public string OrgId { get; set; }
            public string UserId { get; set; }
            public string Password { get; set; }
            public int Id { get; set; }
        }


    }
}







