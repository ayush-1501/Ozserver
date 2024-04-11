using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ozserver.Business_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozserver
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string _transmissionSource;
        int _searchId;
        string Link = System.Configuration.ConfigurationManager.AppSettings["url1"].ToString();
        protected List<string> StringArray { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {

                Response.Redirect("Login.aspx");
            }
            else
            {
                Page.Title = "User Info";

                if (Request.QueryString["source"] != null)
                {
                    _transmissionSource = Request.QueryString["source"].ToUpper();
                }

                if (Request.QueryString["id"] != null)
                {

                    if (int.TryParse(Request.QueryString["id"], out int searchId))
                    {
                        _searchId = searchId;
                    }
                }
                string apiUrl = Link;

                if (_transmissionSource=="EDN" || _transmissionSource== "EDNSEARCH")
                {
                    apiUrl += "EDNDocument/GetEDNDataById?Id=";
                }
                else if (_transmissionSource == "AQIS" || _transmissionSource == "AQISSEARCH")
                {
                    apiUrl += "AQISDocument/GetAQISDataById?Id=";
                }
                else if (_transmissionSource == "PRA" || _transmissionSource == "PRASEARCH")
                {
                    apiUrl += "PRADocument/GetPRADataById?Id=";
                }
                else if (_transmissionSource == "MASTER" || _transmissionSource == "MASTERSEARCH")
                {
                    apiUrl += "MasterDocument/GetMasterDataById?Id=";
                }

                apiUrl += _searchId;


                if (!string.IsNullOrEmpty(apiUrl))
                {
                    RestAPICaller apiCaller = new RestAPICaller();
                    string jsonResult = apiCaller.CallRestAPI(apiUrl);

                    if (!string.IsNullOrEmpty(jsonResult) && jsonResult != "[]")
                    {
                        JsonSerializerSettings settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        };
                        List<Branch> data = JsonConvert.DeserializeObject<List<Branch>>(jsonResult, settings);

                        // Create an empty list to store label-value pairs
                        List<string> stringArray = new List<string>();

                        foreach (Branch item in data)
                        {
                            PropertyInfo[] properties = typeof(Branch).GetProperties();
                            foreach (PropertyInfo property in properties)
                            {
                                object value = property.GetValue(item);

                                if (value == null || string.IsNullOrEmpty(value.ToString()))
                                {
                                    continue;
                                }
                                string label = property.Name;
                                string valueString;
                                if (value is DateTime)
                                {
                                    valueString = ((DateTime)value).ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    valueString = value?.ToString();
                                }

                              
                                string labelValuePair = $"{label}: {valueString}";

                               
                                stringArray.Add(labelValuePair);
                            }
                        }

                        StringArray = stringArray;
                    }
                }
                repeaterData.DataSource = StringArray;
                repeaterData.DataBind();

            }

        }

        private void ConvertToAllStrings(dynamic obj)
        {
            if (obj is JArray)
            {
                foreach (var item in obj)
                {
                    ConvertToAllStrings(item);
                }
            }
            else if (obj is JObject)
            {
                foreach (var property in obj.Properties())
                {
                    property.Value = property.Value?.ToString();
                    ConvertToAllStrings(property.Value);
                }
            }
        }
        public bool IsTransmissionFrom(string source)
        {
            return _transmissionSource == source.ToUpper();
        }

     
        public class Branch
        {
            public int Id { get; set; }
            public string DocumentId { get; set; }
            public string ReferenceId { get; set; }
            public string Exporter { get; set; }
            public string Consignee { get; set; }
            public string Buyer { get; set; }
            public decimal InvoiceValue { get; set; }
            public string Currency { get; set; }
            public string InvoiceNo { get; set; }
            public DateTime InvoiceDate { get; set; }
            public string DocumentStatus { get; set; }
            public string EdnStatus { get; set; }
            public string Details { get; set; }
            public string ExporterRef { get; set; }
            public string BuyerRef { get; set; }
            public string MUserId { get; set; }
            public DateTime CreationDate { get; set; }
            public DateTime RevisionDate { get; set; }
            public string OfficeId { get; set; }
            public string AqisId { get; set; }
            public string RfpNo { get; set; }
            public int Version { get; set; }
            public string Status { get; set; }
            public string PermitNo { get; set; }
            public string PradocsId { get; set; }
            public string ShippersRef { get; set; }
            public string StatusDesc { get; set; }
            public string OneStopRef { get; set; }
            public string LastVersion { get; set; }
            public string ContainerNo { get; set; }
            public string EdnDocsId { get; set; }
            public string SenderRef { get; set; }
            public string Edn { get; set; }
            public DateTime SDateTime { get; set; }
            public DateTime RDateTime { get; set; }
            public int ControlRef { get; set; }
            public string Acknowledge { get; set; }
            public string ReasonDesc { get; set; }
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
            public string File_In_Name { get; set; }
            public string File_In_Content { get; set; }
            public string File_Out_Name { get; set; }
            public string File_Out_Content { get; set; }
            public int IsNew { get; set; }
        }
    }
}