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
                    System.Diagnostics.Debug.WriteLine(_transmissionSource);
                    Console.WriteLine(_transmissionSource);
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

            protected void btnLogin_Click1(object sender, EventArgs e)
            {

            string fromDate = FromDateTextBox.Value;
            string toDate = ToDateTextBox.Value;
            string refId = RefIdTextBox.Value;
            string containerNo = ContainerNoTextBox.Value;

            Session["SDate"] = fromDate;
            Session["RDate"] = toDate;
            Session["refId"] = refId;
            Session["containerNo"] = containerNo;
            Response.Redirect("SearchResult1.aspx");

        }
       }
    }


