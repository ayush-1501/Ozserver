using Newtonsoft.Json;
using Ozserver.Business_layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        private int CurrentPage
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
                // Continue loading the dashboard page
                if (Page.IsPostBack) return;
                BindDataIntoRepeater();
            }
           
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
          server control at run time. */
        }

        public DataTable GetDataFromDb()
        {
            string apiUrl = "http://crm2.omnix.com.au/OzdocsServerWebAPI/api/";

            apiUrl = apiUrl + "EDNDocument/GetEDNData";

            // Call the CallRestAPI function from BusinessAccessLayer
            RestAPICaller apiCaller = new RestAPICaller();
            string jsonResult = apiCaller.CallRestAPI(apiUrl);

            // Deserialize JSON string to a suitable object
            List<Branch> data = new List<Branch>();

            try
            {
                // Attempt to deserialize JSON as a list
                data = JsonConvert.DeserializeObject<List<Branch>>(jsonResult);
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine("Error deserializing JSON as list: " + ex.Message);
                try
                {
                    // If deserialization as list fails, try deserializing as a single object
                    Branch singleBranch = JsonConvert.DeserializeObject<Branch>(jsonResult);
                    data.Add(singleBranch); // Add the single object to the list
                }
                catch (JsonSerializationException innerEx)
                {
                    Console.WriteLine("Error deserializing JSON as single object: " + innerEx.Message);
                    // Handle the exception accordingly, possibly log it or throw it further
                }
            }

            // Convert the object to a DataTable
            DataTable dt = ToDataTable(data);

            return dt;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
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
            var dt = GetDataFromDb();
            _pgsource.DataSource = dt.DefaultView;
            _pgsource.AllowPaging = true;
            // Number of items to be displayed in the Repeater
            _pgsource.PageSize = _pageSize;
            _pgsource.CurrentPageIndex = CurrentPage;
            // Keep the Total pages in View State
            ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
            // Enable First, Last, Previous, Next buttons
            lbPrevious.Enabled = !_pgsource.IsFirstPage;
            lbNext.Enabled = !_pgsource.IsLastPage;
            lbFirst.Enabled = !_pgsource.IsFirstPage;
            lbLast.Enabled = !_pgsource.IsLastPage;

            // Bind data into repeater
            rptResult.DataSource = _pgsource;
            rptResult.DataBind();

            // Call the function to do paging
            HandlePaging();
        }

        private void HandlePaging()
        {
            var dt = new DataTable();
            dt.Columns.Add("PageIndex"); //Start from 0
            dt.Columns.Add("PageText"); //Start from 1

            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;

            // Check last page is greater than total page then reduced it 
            // to total no. of page is last index
            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            // Now creating page number based on above first and last page index
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
            public string OfficeId { get; set; }
            public string EdnDocsId { get; set; }
            public string SenderRef { get; set; }
            public int Version { get; set; }
            public string Edn { get; set; }
            public string Status { get; set; }
            public DateTime SDateTime { get; set; }
            public DateTime RDateTime { get; set; }
            public int ControlRef { get; set; }
            public string Acknowledge { get; set; }
            public string StatusDesc { get; set; }
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
            public string File_In_Name { get; set; }
            public string File_In_Content { get; set; }
            public string File_Out_Name { get; set; }
            public string File_Out_Content { get; set; }
            public int IsNew { get; set; }
        }
    }
}