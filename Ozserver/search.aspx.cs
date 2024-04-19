using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ozserver.Business_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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




                    List<Branch> data = new List<Branch>();
                    if (jsonResult != "[]")
                    {

                        JsonSerializerSettings settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        };


                        data = JsonConvert.DeserializeObject<List<Branch>>(jsonResult, settings);


                    }



                    if (data != null && data.Count > 0)
                    {

                        Branch firstUser = data[0];
                        if (_transmissionSource == "EDN" || _transmissionSource == "EDNSEARCH")
                        {
                            string officeIdEDN = firstUser.OfficeId;
                            OfficeIdEDN.Value = officeIdEDN.ToString();

                            
                            string edndocsId = firstUser.EdndocsId;
                            EdndocsId.Value = edndocsId;

                            
                            string senderRef = firstUser.SenderRef;
                            SenderRef.Value = senderRef;

                           
                            int versionEDN = firstUser.Version;
                            VersionEDN.Value = versionEDN.ToString();

                           
                            string edn1 = firstUser.Edn;
                            EDN1.Value = edn1;

                          
                            string permitNo = firstUser.PermitNo;
                            StatusEDN.Value = permitNo;

                            
                            DateTime sDateTimeEDN = firstUser.SDateTime;
                            SDateTimeEDN.Value = sDateTimeEDN.ToString("yyyy-MM-dd HH:mm:ss");
                            if ((SDateTimeEDN.Value == "0001-01-01"))
                            {
                                SDateTimeEDN.Value = "";
                            }


                            DateTime rDateTimeEDN = firstUser.RDateTime;
                            RDateTimeEDN.Value = rDateTimeEDN.ToString("yyyy-MM-dd HH:mm:ss");
                            if ((RDateTimeEDN.Value == "0001-01-01"))
                            {
                                RDateTimeEDN.Value = "";
                            }


                            string controlRef = firstUser.ControlRef.ToString();
                            ControlRef.Value = controlRef;

                           
                            string acknowledge = firstUser.Acknowledge;
                            Acknowledge.Value = acknowledge;

                           
                            string statusDescEDN = firstUser.StatusDesc;
                            StatusDescEDN.Value = statusDescEDN;

                           
                            string reasonDesc = firstUser.ReasonDesc;
                            ReasonDesc.Value = reasonDesc;

                            
                            string fileInNameEDN = firstUser.File_In_Name;
                            File_In_NameEDN.Value = fileInNameEDN;

                           
                            string fileInContentEDN = firstUser.File_In_Content;
                            File_In_ContentEDN.Value = fileInContentEDN;

                           
                            string fileOutNameEDN = firstUser.File_Out_Name;
                            File_Out_NameEDN.Value = fileOutNameEDN;

                            
                            string fileOutContentEDN = firstUser.File_Out_Content;
                            File_Out_ContentEDN.Value = fileOutContentEDN;

                            
                            string isNewEDN = firstUser.IsNew.ToString();
                            IsNewEDN.Value = isNewEDN;
                        }
                        else if (_transmissionSource == "AQIS" || _transmissionSource == "AQISSEARCH")
                        {
                          
                            string officeIdAQIS = firstUser.OfficeId;
                            OfficeIdAQIS.Value = officeIdAQIS.ToString();

                          
                            string aqisId = firstUser.AqisId;
                            AQISId.Value = aqisId;

                           
                            string rfpNo = firstUser.RfpNo;
                            RFPNo.Value = rfpNo;

                          
                            int versionAQIS = firstUser.Version;
                            VersionAQIS.Value = versionAQIS.ToString();

                          
                            string status = firstUser.Status;
                            Status.Value = status;

                           
                            string permitNo = firstUser.PermitNo;
                            PermitNo.Value = permitNo;

                            
                            string statusDescAQIS = firstUser.StatusDesc;
                            StatusDescAQIS.Value = statusDescAQIS;

                            
                            DateTime sDateTimeAQIS = firstUser.SDateTime;
                            SDateTimeAQIS.Value = sDateTimeAQIS.ToString("yyyy-MM-dd HH:mm:ss");
                            if ((SDateTimeAQIS.Value == "0001-01-01"))
                            {
                                SDateTimeAQIS.Value = "";
                            }

                            DateTime rDateTimeAQIS = firstUser.RDateTime;
                            RDateTimeAQIS.Value = rDateTimeAQIS.ToString("yyyy-MM-dd HH:mm:ss");
                            if ((RDateTimeAQIS.Value == "0001-01-01"))
                            {
                                RDateTimeAQIS.Value = "";
                            }

                            string test = firstUser.Test;
                            Test.Value = test;

                           
                            string contPage = firstUser.ContPage;
                            ContPage.Value = contPage;

                            
                            string ecn = firstUser.ECN;
                            ECN.Value = ecn;

                           
                            string fileInNameAQIS = firstUser.File_In_Name;
                            File_In_NameAQIS.Value = fileInNameAQIS;

                           
                            string fileInContentAQIS = firstUser.File_In_Content;
                            File_In_ContentAQIS.Value = fileInContentAQIS;

                           
                            string fileOutNameAQIS = firstUser.File_Out_Name;
                            File_Out_NameAQIS.Value = fileOutNameAQIS;

                           
                            string fileOutContentAQIS = firstUser.File_Out_Content;
                            File_Out_ContentAQIS.Value = fileOutContentAQIS;

                           
                            string spare = firstUser.Spare;
                            Spare.Value = spare;

                            
                            string isNew = firstUser.IsNew.ToString();
                            IsNew.Value = isNew;

                        }
                        else if (_transmissionSource == "PRA" || _transmissionSource == "PRASEARCH")
                        {
                           
                            string officeIdPRA = firstUser.OfficeId;
                            OfficeIdPRA.Value = officeIdPRA.ToString();

                           
                            string pradocsId = firstUser.PradocsId;
                            PradocsId.Value = pradocsId;

                          
                            string shippersRef = firstUser.ShippersRef;
                            ShippersRef.Value = shippersRef;

                           
                            int versionPRA = firstUser.Version;
                            VersionPRA.Value = versionPRA.ToString();

                            
                            DateTime sDateTime = firstUser.SDateTime;
                            SDateTime.Value = sDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            if (SDateTime.Value == "0001-01-01")
                            {
                                SDateTime.Value = "";
                            }


                            DateTime rDateTime = firstUser.RDateTime;
                            RDateTime.Value = rDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            if (RDateTime.Value == "0001-01-01")
                            {
                                RDateTime.Value = "";
                            }

                            string statusDesc = firstUser.StatusDesc;
                            StatusDesc.Value = statusDesc;

                            
                            string oneStopRef = firstUser.OneStopRef;
                            OneStopRef.Value = oneStopRef;

                           
                            int lastVersion = firstUser.Version;
                            LastVersion.Value = lastVersion.ToString();

                           
                            string containerNo = firstUser.ContainerNo;
                            ContainerNo.Value = containerNo;

                           
                            string sentType = firstUser.SentType;
                            SentType.Value = sentType;

                            
                            string fileInName = firstUser.File_In_Name;
                            File_In_Name.Value = fileInName;

                            
                            string fileInContent = firstUser.File_In_Content;
                            File_In_Content.Value = fileInContent;

                            
                            string fileOutName = firstUser.File_Out_Name;
                            File_Out_Name.Value = fileOutName;

                     
                            string fileOutContent = firstUser.File_Out_Content;
                            File_Out_Content.Value = fileOutContent;

                        }
                        else if (_transmissionSource == "MASTER" || _transmissionSource == "MASTERSEARCH")
                        {
                            string documentId = firstUser.DocumentId;
                            DocumentId.Value = documentId;

                         
                            string referenceId = firstUser.ReferenceId;
                            ReferenceId.Value = referenceId;

                          
                            string officeId = firstUser.OfficeId;
                            OfficeId.Value = officeId.ToString();

                            
                            int version = firstUser.Version;
                            Version.Value = version.ToString();

                           
                            string exporter = firstUser.Exporter;
                            Exporter.Value = exporter;

                           
                            string consignee = firstUser.Consignee;
                            Consignee.Value = consignee;

                           
                            string buyer = firstUser.Buyer;
                            Buyer.Value = buyer;

                            
                            decimal invoiceValue = firstUser.InvoiceValue;
                            InvoiceValue.Value = invoiceValue.ToString("F2"); 

                           
                            string currency = firstUser.Currency;
                            Currency.Value = currency;

                            
                            string invoiceNo = firstUser.InvoiceNo;
                            InvoiceNo.Value = invoiceNo;

                           
                            DateTime invoiceDate = firstUser.InvoiceDate;
                            InvoiceDate.Value = invoiceDate.ToString("yyyy-MM-dd");
                            if (InvoiceDate.Value == "0001-01-01")
                            {
                                InvoiceDate.Value = "";
                            }


                            string documentStatus = firstUser.DocumentStatus;
                            DocumentStatus.Value = documentStatus;

                           
                            string ednStatus = firstUser.EdnStatus;
                            EDNStatus.Value = ednStatus;

                            
                            string edn = firstUser.Edn;
                            EDN.Value = edn;

                            
                            string details = firstUser.Details;
                            Details.Value = details;

                            
                            string exporterRef = firstUser.ExporterRef;
                            ExporterRef.Value = exporterRef;

                            
                            string buyerRef = firstUser.BuyerRef;
                            BuyerRef.Value = buyerRef;

                            
                            string mUserId = firstUser.MUserId;
                            MUserId.Value = mUserId;

                            
                            DateTime creationDate = firstUser.CreationDate;
                            CreationDate.Value = creationDate.ToString("yyyy-MM-dd");
                            if (CreationDate.Value == "0001-01-01")
                            {
                                CreationDate.Value = "";
                            }


                            DateTime revisionDate = firstUser.RevisionDate;
                            RevisionDate.Value = revisionDate.ToString("yyyy-MM-dd");
                            if (revisionDate.ToString("yyyy-MM-dd") == "0001-01-01")
                            {
                                RevisionDate.Value = "";
                            }
                        }
                      


                    }
                 }
                
               

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
            public string SentType { get; set; }
            public string Spare { get; set; }
            public string ECN { get; set; }
            public string Test { get; set; }
            public string ContPage { get; set; }
            public string EdndocsId { get; set; }
         



        }
    }
}