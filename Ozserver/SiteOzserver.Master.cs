using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Text;

namespace Ozserver
{
    public partial class SiteOzserver : MasterPage
    {
     

        protected void Page_Load(object sender, EventArgs e)
        {
            //  string id = (string)Session["id"];
           
        }

        public void btn_ClickMail(object sender, EventArgs e)
        {
            // Access the messagetext server control and retrieve its value
            string feedback = messagetext.Value.Trim();

            string fromAddress = "ayushdel15@gmail.com";
            string toAddress = "vijaykant@ozdocs.co.in";
            string fromPassword = "xmro mldw wfgg qhne";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromAddress);
            message.To.Add(new MailAddress(toAddress));
            message.Subject = "Feedback";
            message.Body = feedback;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, fromPassword)
            };
            smtpClient.Send(message);

        }


    }

}
