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
          //  string id = (string)Session["id"];
        }
        public void PerformLogin()
        {
            string fromAddress = "ayushdel15@gmail.com";
            string toAddress = "ayushstarc@gmail.com";
            string fromPassword = "xmro mldw wfgg qhne";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromAddress);
            message.To.Add(new MailAddress(toAddress));
            message.Body = "<html><body>Test Body from popup</body></html>";
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
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }
        [System.Web.Services.WebMethod]
        public static string SendEmail(string feedback)
        {
            try
            {
                // Configure the email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("ayushdel15@gmail.com");
                mail.To.Add("ayushdel15@gmail.com");
                mail.Subject = "Feedback Received";
                mail.Body = "Feedback: " + feedback;

                // Send the email using SMTP
                SmtpClient smtp = new SmtpClient("smtp.example.com");
                smtp.Port = 587; // Specify your SMTP port
                smtp.Credentials = new System.Net.NetworkCredential("ayushdel15@gmail.com", "xmro mldw wfgg qhne");
                smtp.EnableSsl = true; // Enable SSL/TLS

                smtp.Send(mail);

                return "Email sent successfully.";
            }
            catch (Exception ex)
            {
                return "Error sending email: " + ex.Message;
            }
        }
    }

}
