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
        string SearchLink = System.Configuration.ConfigurationManager.AppSettings["url2"].ToString();
        public string OrgNameValue { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
          
           
            if (!IsPostBack)
            {
                
                if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Page.Title = "USER";
                    if (Request.QueryString["source"] != null)
                    {
                        _transmissionSource = Request.QueryString["source"].ToUpper();

                       
                        if (Request.QueryString["id"] != null)
                        {
                           
                            if (int.TryParse(Request.QueryString["id"], out int searchId))
                            {
                                _searchId = searchId;

                               
                                string apiUrl = SearchLink+"User/GetUserDataById?Id=" + searchId;
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
                                catch (JsonSerializationException)
                                {
                                   
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

                                   
                                    foreach (ListItem option in OrgName.Items)
                                    {
                                       
                                        if (option.Value == OrgNameValue)
                                        {
                                            option.Selected = true;
                                            break; 
                                        }
                                    }

                                    
                                    UserId.Value = branch.UserId;
                                    Password.Value = branch.Password;
                                }
                            }
                        }
                    }
                }
            }
        }

     

        protected void btn_ClickADD(object sender, EventArgs e)
        {

            string orgName = Select1.Value;
            string userId = UserId.Value;
            string password = Password.Value;

            HttpClient client = new HttpClient();


            string url =SearchLink+"User/UserCreate";



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

                Console.WriteLine("User created successfully.");


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
            Response.Redirect("DocumentList.aspx?context=USER");
        }


        protected void btn_ClickUPDATE(object sender, EventArgs e)
        {
            
            string newUserId = UserId.Value; 
            string newPassword = Password.Value; 
            string newOrgNameValue = OrgName.Value;
            if (Request.QueryString["id"] != null)
            {
                
                if (int.TryParse(Request.QueryString["id"], out int searchId1))
                {
                    _searchId = searchId1;
                }
            }
           
            int searchId = _searchId;

          
            string updateUrl = SearchLink+$"User/UpdateUserDataById?Id={searchId}&password={Uri.EscapeDataString(newPassword)}&UserId={Uri.EscapeDataString(newUserId)}&OrgName={Uri.EscapeDataString(newOrgNameValue)}";

            
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
                else
                {
                    
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







