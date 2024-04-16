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

namespace Ozserver
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        string _transmissionSource;
        int _searchId;
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

                                // If data is available, populate form fields with the first branch data
                                if (data != null && data.Count > 0)
                                {
                                    Branch branch = data[0];
                                    UserId.Value = branch.UserId;
                                    Password.Value = branch.Password;
                                    OrgName.Value = branch.OrgId;
                                }
                            }
                        }
                    }
                }
            }
        }


        protected void btn_ClickADD(object sender, EventArgs e)
        {

            string orgName = OrgName.Value;
            string userId = UserId.Value;
            string password = Password.Value;

            HttpClient client = new HttpClient();


            string url = "https://localhost:7209/api/User/UserCreate";


           
            var UserData = new
            {
                OrgId = orgName,
                UserId = userId,
                Password = password
            };



            string jsonPayload = JsonConvert.SerializeObject(UserData);


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
        }

        protected void btn_ClickUPDATE(object sender, EventArgs e)
        {
            // Retrieve new values from input fields directly
            string newUserId = UserId.Value; // New UserId from form field
            string newPassword = Password.Value; // New Password from form field
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
            string updateUrl = $"https://localhost:7209/api/User/UpdateUserDataById?Id={searchId}&password={Uri.EscapeDataString(newPassword)}&UserId={Uri.EscapeDataString(newUserId)}";

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

                Response.Redirect("DocumentList.aspx?context=USER");
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







