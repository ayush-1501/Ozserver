using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Ozserver
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected bool EDN = false;
        protected bool AQIS = false;
        protected bool PRA = false;


        string _transmissionSource;
        protected void Page_Load(object sender, EventArgs e)
        {

            // Check if the user is authenticated
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // If not authenticated, redirect to the login page
                Response.Redirect("Login.aspx");
            }
            else
            {

                // Continue loading the dashboard page


                if (Session["EDN"] != null)
                    EDN = (bool)Session["EDN"];

                if (Session["AQIS"] != null)
                    AQIS = (bool)Session["AQIS"];

                if (Session["PRA"] != null)
                    PRA = (bool)Session["PRA"];

                if (Request.QueryString["context"] != null)
                {
                    _transmissionSource = Request.QueryString["context"].ToUpper();
                    Session["Source"] = _transmissionSource;
                }
            }

        }
        // Method to check the transmission source for conditional rendering
        public bool IsTransmissionFrom(string source)
        {
            return _transmissionSource == source.ToUpper();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
          server control at run time. */
        }

        protected void btnLogin_ClickPRA(object sender, EventArgs e)
        {
            string fromDate = FromDateTextBoxPRA.Value;
            string toDate = ToDateTextBoxPRA.Value;
            string stopRef = StopRefTextBox.Value;
            string shipperRef = ShipperRefTextBox.Value;

            // Store values in session state
            Session["FromDate"] = fromDate;
            Session["ToDate"] = toDate;
            Session["StopRef"] = stopRef;
            Session["ShipperRef"] = shipperRef;
            Response.Redirect("DocumentList.aspx?context=PRASEARCH");
        }


        protected void btnLogin_ClickAQIS(object sender, EventArgs e)
        {
            string fromDate = FromDateTextBoxAQIS.Value;
            string toDate = ToDateTextBoxAQIS.Value;
            string AQISId = AQISIdTextBox.Value;
            string rfpNo = RfpNoTextBox.Value;

            // Store values in session state
            Session["FromDate"] = fromDate;
            Session["ToDate"] = toDate;
            Session["AQISId"] = AQISId;
            Session["RfpNo"] = rfpNo;
            Response.Redirect("DocumentList.aspx?context=AQISSEARCH");
        }


        protected void btnLogin_ClickEDN(object sender, EventArgs e)
        {

            string fromDate = FromDateTextBoxEDN.Value;
            string toDate = ToDateTextBoxEDN.Value;
            string senderRef = SenderRefTextBox.Value;
            string edn = EDNTextBox.Value;

            // Store values in session state
            Session["FromDate"] = fromDate;
            Session["ToDate"] = toDate;
            Session["SenderRef"] = senderRef;
            Session["EDN1"] = edn;

            Response.Redirect("DocumentList.aspx?context=EDNSEARCH");

        }
    }
}


