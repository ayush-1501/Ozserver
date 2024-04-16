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

namespace Ozserver
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // If not authenticated, redirect to the login page
                Response.Redirect("Login.aspx");
            }
            else
            {

              

               
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



    }
}