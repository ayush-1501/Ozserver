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
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // If not authenticated, redirect to the login page
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Request.QueryString["source"] != null)
                {
                    _transmissionSource = Request.QueryString["source"].ToUpper();

                    if (Request.QueryString["id"] != null)
                    {

                        if (int.TryParse(Request.QueryString["id"], out int searchId))
                        {
                            _searchId = searchId;
                            string apiUrl = "https://localhost:7209/api/User/GetUserDataById?Id=" + searchId;
                            RestAPICaller apiCaller = new RestAPICaller();
                            string jsonResult = apiCaller.CallRestAPI(apiUrl);


                            List<Branch> data = new List<Branch>();

                            try
                            {

                                JsonSerializerSettings settings = new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore
                                };


                                data = JsonConvert.DeserializeObject<List<Branch>>(jsonResult, settings);
                            }
                            catch (JsonSerializationException ex)
                            {
                                Console.WriteLine("Error deserializing JSON as list: " + ex.Message);
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

                               
                                UserId.Value = branch.UserId; 
                                Password.Value = branch.Password;
                                OrgName.Value = branch.OrgId;
                            }
                        }
                    }
                }
               


            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
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







