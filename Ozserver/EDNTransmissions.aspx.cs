using System;
using System.Collections.Generic;
using System.Net;
using System.Web.UI;
using System.Web.Script.Serialization;
using Ozserver.Business_layer;
using Newtonsoft.Json;
using System.Web.UI.WebControls;

namespace Ozserver
{
    public partial class EDNtransmissions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is authenticated
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Console.WriteLine("page loaded");
                GetBranchList("ANZCO");
            }
        }

        public void GetBranchList(string orgid)
        {
            //shttp://crm2.omnix.com.au/OzdocsServerWebAPI/api/DPIDocument/GetDPIDataByOfficeId?officeId=ANZCO

            
            string apiUrl = "http://crm2.omnix.com.au/OzdocsServerWebAPI/api/";
            //apiUrl = apiUrl + "Branch/getAllBranchbyOrgId?orgId=" + orgid;
            apiUrl = apiUrl + "DPIDocument/GetDPIDataByOfficeId?officeId=" + orgid;

            // Call the CallRestAPI function from BusinessAccessLayer
            RestAPICaller apiCaller = new RestAPICaller();
            string jsonResult = apiCaller.CallRestAPI(apiUrl);

            Console.WriteLine(jsonResult);
            if (!jsonResult.Contains("404") || !jsonResult.Contains("Not Found"))
            {
                var branches = JsonConvert.DeserializeObject<List<Branch>>(jsonResult);

                Repeater1.DataSource = branches; 
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
            }
        }



        public class Branch
        {
            public int Id { get; set; }
            public string DpiId { get; set; }
            public int Version { get; set; }
            public string Status { get; set; }
            public DateTime RequestDate { get; set; }
            public string RequestTime { get; set; }
            public string OfficeId { get; set; }
            public DateTime SDateTime { get; set; }
            public DateTime RDateTime { get; set; }
            public string StatusDesc { get; set; }
            public string Noin { get; set; }
            public string Permit { get; set; }
            public string FileInName { get; set; }
            public string FileOutName { get; set; }
            public string Error1 { get; set; }
            public string Error2 { get; set; }
            public string Error3 { get; set; }
            public string Error4 { get; set; }
            public string Error5 { get; set; }
            public string Error6 { get; set; }
            public string Error7 { get; set; }
            public string Error8 { get; set; }
            public string Error9 { get; set; }
            public string Error10 { get; set; }
            public string Error11 { get; set; }
            public string Error12 { get; set; }
            public string Error13 { get; set; }
            public string Error14 { get; set; }
            public string Error15 { get; set; }
            public string Error16 { get; set; }
            public string Error17 { get; set; }
            public string Error18 { get; set; }
            public string Error19 { get; set; }
            public string Error20 { get; set; }
            public string Error21 { get; set; }
            public string Error22 { get; set; }
            public string Error23 { get; set; }
            public string Error24 { get; set; }
            public string Error25 { get; set; }
            public string Error26 { get; set; }
            public string Error27 { get; set; }
            public string Error28 { get; set; }
            public string Error29 { get; set; }
            public string Error30 { get; set; }
            public string Error31 { get; set; }
            public string Error32 { get; set; }
            public string Error33 { get; set; }
            public string Error34 { get; set; }
            public string Error35 { get; set; }
            public string Error36 { get; set; }
            public string Error37 { get; set; }
            public string Error38 { get; set; }
            public string Error39 { get; set; }
            public string Error40 { get; set; }
            public string Test { get; set; }
            public string ContPage { get; set; }
            public string Ecn { get; set; }
            public string Spare { get; set; }
        }

    }
}


