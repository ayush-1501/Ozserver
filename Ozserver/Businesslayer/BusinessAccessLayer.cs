    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;

 namespace Ozserver.Business_layer
 {
    public class RestAPICaller
    {
        public string CallRestAPI(string apiUrl)
        {

            string result = string.Empty;

            // Create the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET";  // Adjust if needed for POST, PUT, etc.
            request.ContentType = "application/json"; // Adjust based on request body

            try
            {
                // Get the response
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Read the response
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                return result;
            }
            catch (WebException ex)
            {
                // Handle exceptions
                if (ex.Response != null)
                {
                    using (StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string errorResult = streamReader.ReadToEnd();
                        return errorResult;
                    }
                }
                else
                {
                    return ex.Message;
                }
            }
        }
    }
}
