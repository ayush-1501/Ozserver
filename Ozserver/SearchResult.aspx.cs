using Newtonsoft.Json;
using Ozserver.Business_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozserver
{
    public partial class WebForm1 : Page
    {
        private List<Branch> branches = new List<Branch>();
        private List<Branch> data = new List<Branch>();
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize = 15;

        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // If not authenticated, redirect to the login page
                Response.Redirect("Login.aspx");
            }
            else
            {
                string fromDate, toDate, refId;
                if (Session["SDate"] != null)
                    fromDate = (string)Session["SDate"];

                if (Session["AQIS"] != null)
                    toDate = (string)Session["RDate"];

                if (Session["refId"] != null)
                    refId = (string)Session["refId"];

                FetchAndStoreData();
                DateTime sDateTime = DateTime.ParseExact("2024-02-10", "yyyy-MM-dd", CultureInfo.InvariantCulture);

                data = SearchByCriteria(null, null, sDateTime, null);

                if (Page.IsPostBack) return;
                BindDataIntoRepeater();

            }

        }

        private void FetchAndStoreData()
        {

            var apiUrl = "http://crm2.omnix.com.au/OzdocsServerWebAPI/api/AQISDocument/GetAQISData";


            RestAPICaller apiCaller = new RestAPICaller();
            string jsonResult = apiCaller.CallRestAPI(apiUrl);

            branches = JsonConvert.DeserializeObject<List<Branch>>(jsonResult);

        }

        private List<Branch> SearchByCriteria(string officeId, int? id, DateTime? sDateTime, DateTime? rDateTime)
        {
            // Ensure that at least one criterion has a value
            if (officeId == null && !id.HasValue && !sDateTime.HasValue && !rDateTime.HasValue)
            {
                throw new ArgumentException("At least one search criterion must have a value.");
            }

            // Filter the branches list based on the provided criteria
            List<Branch> searchResult = branches.FindAll(branch =>
             (officeId == null || branch.OfficeId == officeId) &&
             (!id.HasValue || branch.Id == id.Value) &&
             (!sDateTime.HasValue || branch.SDateTime.Date == sDateTime.Value.Date) &&
             (!rDateTime.HasValue || branch.RDateTime.Date == rDateTime.Value.Date));


            return searchResult;

        }
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

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        public DataTable GetDataFromDb()
        {
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
            public string AQISId { get; set; }
            public int Version { get; set; }
            public string Status { get; set; }
            public DateTime RequestDate { get; set; }
            public TimeSpan RequestTime { get; set; }
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
            public string ECN { get; set; }
            public string Spare { get; set; }
        }
    }
}
