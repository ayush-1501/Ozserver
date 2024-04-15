using Newtonsoft.Json;
using Ozserver.Business_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize = 15;
        string _transmissionSource;
        string OfficeID;
        public string Role { get; set; }
        string TableLink = System.Configuration.ConfigurationManager.AppSettings["url1"].ToString();
        string SearchLink = System.Configuration.ConfigurationManager.AppSettings["url2"].ToString();
        public int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // If not authenticated, redirect to the login page
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Request.QueryString["context"] != null)
                {
                    _transmissionSource = Request.QueryString["context"].ToUpper();
                }
                if (Session["Role"] != null)
                {
                    Role = (string)Session["Role"];
                    OfficeID = (string)Session["OfficeID"];
                }
                else
                {
                    Role = "Non-Admin";
                    OfficeID = "ANZCO";
                }



                if (_transmissionSource== "EDN")
                {
                    Page.Title = "EDN TRANSISSMION";
                }
                else if(_transmissionSource =="PRA" )
                {
                    Page.Title = "PRA TRANSMISSION";
                }
                else if (_transmissionSource == "AQIS" )
                {
                    Page.Title = "AQIS TRANSMISSION";
                }
                else if (_transmissionSource == "MASTER" )
                {
                    Page.Title = "MASTER DOCUMENT";
                }
                else if(_transmissionSource == "EDNSEARCH" || _transmissionSource == "PRASEARCH" || _transmissionSource == "AQISSEARCH" || _transmissionSource == "MASTERSEARCH")
                {
                    Page.Title = "TRANSISSMION";
                }


                if (Page.IsPostBack) return;
                BindDataIntoRepeater();
            }

           

        }

        protected string GenerateMouseOutScript(int pageIndex)
        {
            // Check if the current page index matches the CurrentPage
            if (pageIndex == CurrentPage)
            {
                // If matches, set color to #00d0f1
                return "changeColor(this, '#00d0f1')";
            }
            else
            {
                // Otherwise, set color to #1b5a90
                return "changeColor(this, '#1b5a90')";
            }
        }
        public bool IsTransmissionFrom(string source)
        {
            return _transmissionSource == source.ToUpper();
        }

        public string GetTransmissionSource()
        {
            
            return _transmissionSource;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }

        public DataTable GetDataFromDb()
        {
         
            string apiUrl = TableLink;
            if (_transmissionSource == "EDN")
            {
                if (Role == "Admin")
                {
                    apiUrl = apiUrl + "EDNDocument/GetEDNData";
                }
                else
                {
                    apiUrl = apiUrl + "EDNDocument/GetEDNDataByOfficeId?officeId=" + OfficeID;
                }
            }
            else if (_transmissionSource =="PRA")
            {
                if (Role == "Admin")
                {
                    apiUrl = apiUrl + "PRADocument/GetPRAData";
                }
                else
                {
                    apiUrl = apiUrl + "PRADocument/GetPRADataByOfficeId?officeId=" + OfficeID;
                }
            }
            else if (_transmissionSource=="AQIS")
            {
                if (Role == "Admin")
                {
                    apiUrl = apiUrl + "AQISDocument/GetAQISData";
                }
                else
                {
                    apiUrl = apiUrl + "AQISDocument/GetAQISDataByOfficeId?officeId=" + OfficeID;
                }
            }
            else if (_transmissionSource == "MASTER")
            {
                if (Role == "Admin")
                {
                    apiUrl = apiUrl + "MasterDocument/GetMasterData";
                }
                else
                {
                    apiUrl = apiUrl + "MasterDocument/GetMasterDataByOfficeId?officeId=" + OfficeID;
                }
            }


            string apiUrl1 = SearchLink;
            if (_transmissionSource == "EDNSEARCH")
            {
                apiUrl1 += "EDNDocument/GetEDNDataByFilter?";
                if (!string.IsNullOrEmpty((string)Session["FromDate"]))
                {
                    string fromDate = Session["FromDate"].ToString();
                    apiUrl1 += $"FromDate={fromDate}&";
                }


                if (!string.IsNullOrEmpty((string)Session["ToDate"]))
                {
                    string toDate = Session["ToDate"].ToString();
                    apiUrl1 += $"ToDate={toDate}&";
                }


                if (!string.IsNullOrEmpty((string)Session["SenderRef"]))
                {
                    string senderRef = Session["SenderRef"].ToString();
                    apiUrl1 += $"SenderRef={senderRef}&";
                }

                if (!string.IsNullOrEmpty((string)Session["EDN1"]))
                {
                    string edn1 = Session["EDN1"].ToString();
                    apiUrl1 += $"EDN={edn1}&";
                }

                if (!string.IsNullOrEmpty(apiUrl1) && apiUrl1.EndsWith("&"))
                {
                    apiUrl1 = apiUrl1.Remove(apiUrl1.Length - 1);
                }



            }
            else if (_transmissionSource == "PRASEARCH")
            {

                apiUrl1 += "PRADocument/GetPRADataByFilter?";
                if (!string.IsNullOrEmpty((string)Session["FromDate"]))
                {
                    string fromDate = Session["FromDate"].ToString();
                    apiUrl1 += $"FromDate={fromDate}&";
                }


                if (!string.IsNullOrEmpty((string)Session["ToDate"]))
                {
                    string toDate = Session["ToDate"].ToString();
                    apiUrl1 += $"ToDate={toDate}&";
                }


                if (!string.IsNullOrEmpty((string)Session["ShipperRef"]))
                {
                    string shipperRef = Session["ShipperRef"].ToString();
                    apiUrl1 += $"ShipperRef={shipperRef}&";
                }

                if (!string.IsNullOrEmpty((string)Session["StopRef"]))
                {
                    string StopRef = Session["StopRef"].ToString();
                    apiUrl1 += $"OneStopRef={StopRef}&";
                }

                if (!string.IsNullOrEmpty(apiUrl1) && apiUrl1.EndsWith("&"))
                {
                    apiUrl1 = apiUrl1.Remove(apiUrl1.Length - 1);
                }

            }
            else if (_transmissionSource == "AQISSEARCH")
            {


                apiUrl1 += "AQISDocument/GetAQISDataByFilter?";
                if (!string.IsNullOrEmpty((string)Session["FromDate"]))
                {
                    string fromDate = Session["FromDate"].ToString();
                    apiUrl1 += $"FromDate={fromDate}&";
                }


                if (!string.IsNullOrEmpty((string)Session["ToDate"]))
                {
                    string toDate = Session["ToDate"].ToString();
                    apiUrl1 += $"ToDate={toDate}&";
                }


                if (!string.IsNullOrEmpty((string)Session["AQISId"]))
                {
                    string AQISId = Session["AQISId"].ToString();
                    apiUrl1 += $"AQISId={AQISId}&";
                }

                if (!string.IsNullOrEmpty((string)Session["RfpNo"]))
                {
                    string RfpNo = Session["RfpNo"].ToString();
                    apiUrl1 += $"RfpNo={RfpNo}&";
                }

                if (!string.IsNullOrEmpty(apiUrl1) && apiUrl1.EndsWith("&"))
                {
                    apiUrl1 = apiUrl1.Remove(apiUrl1.Length - 1);
                }
            }
            else if (_transmissionSource == "MASTERSEARCH")
            {


                apiUrl1 += "MasterDocument/GetMasterDataByFilter?";
                if (!string.IsNullOrEmpty((string)Session["FromDate"]))
                {
                    string fromDate = Session["FromDate"].ToString();
                    apiUrl1 += $"FromDate={fromDate}&";
                }


                if (!string.IsNullOrEmpty((string)Session["ToDate"]))
                {
                    string toDate = Session["ToDate"].ToString();
                    apiUrl1 += $"ToDate={toDate}&";
                }


                if (!string.IsNullOrEmpty((string)Session["DocId"]))
                {
                    string DocumentId = Session["DocId"].ToString();
                    apiUrl1 += $"DocumentId={DocumentId}&";
                }

                if (!string.IsNullOrEmpty((string)Session["invoiceNo"]))
                {
                    string InvoiceNo = Session["invoiceNo"].ToString();
                    apiUrl1 += $"InvoiceNo={InvoiceNo}&";
                }
                if (!string.IsNullOrEmpty((string)Session["toDateInvoice"]))
                {
                    string ToInvoice = Session["toDateInvoice"].ToString();
                    apiUrl1 += $"ToInvoice={ToInvoice}&";
                }
                if (!string.IsNullOrEmpty((string)Session["fromDateInvoice"]))
                {
                    string FromInvoice = Session["fromDateInvoice"].ToString();
                    apiUrl1 += $"FromInvoice={FromInvoice}&";
                }
                if (!string.IsNullOrEmpty((string)Session["exporter"]))
                {
                    string Exporter = Session["exporter"].ToString();
                    apiUrl1 += $"InvoiceNo={Exporter}&";
                }
                if (!string.IsNullOrEmpty((string)Session["EDN1"]))
                {
                    string Edn = Session["EDN1"].ToString();
                    apiUrl1 += $"Edn={Edn}&";
                }
                if (!string.IsNullOrEmpty(apiUrl1) && apiUrl1.EndsWith("&"))
                {
                    apiUrl1 = apiUrl1.Remove(apiUrl1.Length - 1);
                }
            }


            string apiUrlUser = SearchLink;

            if(_transmissionSource == "USER")
            {
                apiUrlUser += "User/GetUserData";
            }
            else if(_transmissionSource == "ORGANISATION")
            {
                apiUrlUser += "Organisation/GetOrganisationData";
            }
            if(_transmissionSource == "USER" || _transmissionSource == "ORGANISATION")
            {
                apiUrl=apiUrlUser;
            }

            if (_transmissionSource == "EDNSEARCH" || _transmissionSource == "AQISSEARCH" || _transmissionSource == "PRASEARCH" || _transmissionSource == "MASTERSEARCH")
            {
                apiUrl = apiUrl1;
               
            }

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

            if (data[0].Status == "404" )
            {
                data = null;
            }
            DataTable dt = ToDataTable(data);

            return dt;
        }

     
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (items == null || items.Count == 0)
            {
                return new DataTable(typeof(T).Name);
            }
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        // Bind PagedDataSource into Repeater
        private void BindDataIntoRepeater()
        {
            var dt= GetDataFromDb(); 
           
          
            _pgsource.DataSource = dt.DefaultView;
            _pgsource.AllowPaging = true;
            
            _pgsource.PageSize = _pageSize;
            _pgsource.CurrentPageIndex = CurrentPage;
           
            ViewState["TotalPages"] = _pgsource.PageCount;
         
            lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
         
            lbPrevious.Enabled = !_pgsource.IsFirstPage;
            lbNext.Enabled = !_pgsource.IsLastPage;
            lbFirst.Enabled = !_pgsource.IsFirstPage;
            lbLast.Enabled = !_pgsource.IsLastPage;

            
            rptResult.DataSource = _pgsource;
            rptResult.DataBind();

            
            HandlePaging();
        }

        private void HandlePaging()
        {
            var dt = new DataTable();
            dt.Columns.Add("PageIndex"); 
            dt.Columns.Add("PageText"); 

            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;

           
            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            
            for (var i = _firstIndex; i < _lastIndex; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }

            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }

        protected void lbFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BindDataIntoRepeater();
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BindDataIntoRepeater();
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindDataIntoRepeater();
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindDataIntoRepeater();
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BindDataIntoRepeater();
        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
            lnkPage.BackColor = Color.FromName("#00FF00");
        }

        public class Branch
        {
            public int Id { get; set; }
            public string DocumentId { get; set; }
            public string ReferenceId { get; set; }
            public string OfficeId { get; set; }
            public int Version { get; set; } 
            public string Exporter { get; set; }
            public string Consignee { get; set; }
            public string Buyer { get; set; }
            public decimal InvoiceValue { get; set; }
            public string Currency { get; set; }
            public string InvoiceNo { get; set; }
            public DateTime InvoiceDate { get; set; }
            public string DocumentStatus { get; set; }
            public string EdnStatus { get; set; }
            public string Edn { get; set; } 
            public string Details { get; set; }
            public string ExporterRef { get; set; }
            public string BuyerRef { get; set; }
            public string MUserId { get; set; }
            public DateTime CreationDate { get; set; }
            public DateTime RevisionDate { get; set; }
            public string AqisId { get; set; }
            public string RfpNo { get; set; }
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
            public DateTime SDateTime { get; set; }
            public DateTime RDateTime { get; set; }
            public int ControlRef { get; set; }
            public string Acknowledge { get; set; }
            public string ReasonDesc { get; set; }
            public string File_In_Name { get; set; }
            public string File_In_Content { get; set; }
            public string File_Out_Name { get; set; }
            public string File_Out_Content { get; set; }
            public int IsNew { get; set; }
            public string OrgId { get; set; }
            public string BranchName { get; set; }
            public string Address { get; set; }
            public string UserId { get; set; }
            public string Password { get; set; }
            public string CompanyName { get; set; }
            public string Email_Address { get; set; }
        }


    }
}