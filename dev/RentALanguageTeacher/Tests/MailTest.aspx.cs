using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.IO;

namespace RentALanguageTeacher
{
    public partial class MailTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                //string fileName = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/MeetTeacher/Meet Miriam.html");
                //string mailBody = File.ReadAllText(fileName);

                //mailBody = mailBody.Replace("##Name##", "fletch");
                ////mailBody = mailBody.Replace("##Email##", Email);
                ////mailBody = mailBody.Replace("##Country##", Country);
                //mailBody = mailBody.Replace("##Message##", TextBox1.Text.ToString());

                //MailMessage myMessage = new MailMessage();
                //myMessage.Subject = "A New Question";
                //myMessage.Body = mailBody;
                //myMessage.From = new MailAddress("fletch0098@aol.com", "fletcher");
                //myMessage.To.Add(new MailAddress("brian.m.fletcher@gmail.com", "BF"));
                //SmtpClient mySmtpClient = new SmtpClient();
                //mySmtpClient.Send(myMessage);



                string body = this.PopulateBody(TextBox1.Text.ToString());
                this.SendHtmlFormattedEmail("brian.m.fletcher@gmail.com", "New article published!", body);

            }
            catch
            {
                throw;
            }
        }

        private string PopulateBody(string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/App_Data/MeetTeacher/Meet Miriam.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("##Name##", "Brian");
            body = body.Replace("##Message##", description);
            return body;
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("brian.m.fletcher@gmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient mySmtpClient = new SmtpClient();
                mySmtpClient.Send(mailMessage);
            }
        }
    }
}