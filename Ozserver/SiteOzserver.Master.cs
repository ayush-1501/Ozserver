using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Xml;

namespace Ozserver
{
    public partial class SiteOzserver : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string feedback = Request.Form["feedbackText"];

            string fromAddress = "ayushdel15@gmail.com";
            string toAddress = "ayushstarc@gmail.com";
            string fromPassword = "ezak komq euwh gise";

            MailMessage message=new MailMessage();
            message.From=new MailAddress(fromAddress);
            message.To.Add(new MailAddress(toAddress));
            message.Body = "<html><body>Test Body</body></html>";
            message.IsBodyHtml = true;

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
