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

        string From_mail = System.Configuration.ConfigurationManager.AppSettings["FromMail"].ToString();
        string To_mail = System.Configuration.ConfigurationManager.AppSettings["ToMail"].ToString();
        string Password = System.Configuration.ConfigurationManager.AppSettings["Password"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //  string id = (string)Session["id"];
           
        }

        public void btn_ClickMail(object sender, EventArgs e)
        {
            // Access the messagetext server control and retrieve its value
            string feedback = messagetext.Value.Trim();

            string fromAddress = From_mail;
            string toAddress = To_mail;
            string fromPassword = Password;

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
