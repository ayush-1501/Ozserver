using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    namespace Ozserver
    {
        public partial class WebUserControl1 : System.Web.UI.UserControl
        {
                protected bool EDN = false;
                protected bool AQIS = false;
                protected bool PRA = false;
                protected bool MASTER = false;

                 protected void Page_Load(object sender, EventArgs e)
                {
                    // Retrieve values of EDN, AQIS, PRA,MASTER from session state
                    if (Session["EDN"] != null)
                        EDN = (bool)Session["EDN"];

                    if (Session["AQIS"] != null)
                        AQIS = (bool)Session["AQIS"];

                    if (Session["PRA"] != null)
                        PRA = (bool)Session["PRA"];

                    if (Session["MASTER"] != null)
                        MASTER = (bool)Session["MASTER"];

                }
        }
    }