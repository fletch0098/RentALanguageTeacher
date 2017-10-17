using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using log4net;
using Stripe;

namespace RentALanguageTeacher
{
    /// <summary>
    /// Summary description for StripeHandler
    /// </summary>
    public class StripeHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var json = new StreamReader(context.Request.InputStream).ReadToEnd();

            var stripeEvent = StripeEventUtility.ParseEvent(json);

            switch (stripeEvent.Type)
            {
                case "charge.refunded":  // take a look at all the types here: https://stripe.com/docs/api#event_types
                    var stripeCharge = Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                    break;

                case "charge.succeeded":  // take a look at all the types here: https://stripe.com/docs/api#event_types
                    try
                    {

                        var myCharge = new StripeCharge();

                        myCharge = Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());

                        string Username = myCharge.Metadata["RALTUserName"];
                        string UserID = myCharge.Metadata["RALTUserID"];

                        //RentALanguageTeacher.user Paypal = UserService.GetUserById(74);
                        //DateTime TransDate = App_Code.RALTService.ConvertFromPayPalDate(myCharge.);

                        //DateTime UTCTransDate = DateTime.UtcNow;

                        payment MyPayment = new payment();
                        
                        MyPayment.hours = Convert.ToInt32(myCharge.Description.Substring(0, 2));
                        MyPayment.transaction_date = myCharge.Created;
                        MyPayment.username = Username;
                        MyPayment.update_user = "Stripe";
                        MyPayment.user_id = Convert.ToInt32(UserID);
                        MyPayment.item_name = myCharge.Description;
                        //MyPayment.payer_email = ;
                        MyPayment.transaction_id = myCharge.Id;
                        MyPayment.transaction_status = stripeEvent.Type;


                        App_Code.PaymentService.SaveObject(MyPayment);

                        UserService.AccountStatusPaid(Convert.ToInt32(UserID));
                    
                    }

                    catch (Exception ex)
                    {

                        Send_download_link("administrator@rentalanguageteacher.com","info@rentalanguageteacher.com","StripeHandlerError", ex.Message);
                    
                    }


                    

                    break;
            }
        }

        void Send_download_link(string from, string to, string subject, string body)
        {
            try
            {  // Construct a new e-mail message 
                SmtpClient client = new SmtpClient();
                client.Send(from, to, subject, body);
            }
            catch (SmtpException ex)
            {
                //log.Error("IPN - Email Error: " + ex.Message.ToString());

            }
        } // --- end of Send_download_link --
    }
}