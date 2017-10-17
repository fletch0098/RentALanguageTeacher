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

namespace RentALanguageTeacher.Pages.Payment
{
    public partial class WebForm1 : System.Web.UI.Page


    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("RentALanguageTeacher.PaymentService");

        protected void Page_Load(object sender, EventArgs e)
        {

            log.Info("IPN - Start - **********************************************************************************************************");
            log.Debug("IPN - Sending HTTP Response");

            try
            {
                //Post back to either sandbox or live
                string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                string strLive = "https://www.paypal.com/cgi-bin/webscr";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive);
                //Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
                string strRequest = Encoding.ASCII.GetString(param);
                string strResponse_copy = strRequest;  //Save a copy of the initial info sent by PayPal
                strRequest += "&cmd=_notify-validate";
                req.ContentLength = strRequest.Length;

                //for proxy
                //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
                //req.Proxy = proxy;
                //Send the request to PayPal and get the response
                StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                streamOut.Write(strRequest);
                streamOut.Close();
                StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                string strResponse = streamIn.ReadToEnd();
                streamIn.Close();

                log.Info("IPN - HTTP Response Received");

                if (strResponse == "VERIFIED")
                {
                    //check the payment_status is Completed
                    //check that txn_id has not been previously processed
                    //check that receiver_email is your Primary PayPal email
                    //check that payment_amount/payment_currency are correct
                    //process payment

                    // pull the values passed on the initial message from PayPal

                    NameValueCollection these_argies = HttpUtility.ParseQueryString(strResponse_copy);
                    string user_email = these_argies["payer_email"];
                    string pay_stat = these_argies["payment_status"];
                    string option_name1 = these_argies["option_name1"];
                    string option_selection1 = these_argies["option_selection1"];
                    string item_name = these_argies["item_name"];
                    string payment_date = these_argies["payment_date"];
                    string option_name2 = these_argies["option_name2"];
                    string option_selection2 = these_argies["option_selection2"];
                    string txn_id = these_argies["txn_id"];

                    log.Info("IPN - Verified - Pay_stat: " + pay_stat + ", Payer Email: " + user_email + ", " + option_name1 + ": " + option_selection1 + ": " + option_name2 + ": " + option_selection2 +
                            ", Item Name: " + item_name + " Payment Date: " + payment_date + " Transaction ID: " + txn_id);


                    //.
                    //.  more args as needed look at the list from paypal IPN doc
                    //.


                    if (pay_stat.Equals("Completed"))
                    {
                        log.Info("IPN - Payment Status = Complete");
                        RentALanguageTeacher.user Paypal = UserService.GetUserById(74);
                        DateTime TransDate = App_Code.RALTService.ConvertFromPayPalDate(payment_date);

                        DateTime UTCTransDate = App_Code.TimeService.ConvertToUTC(TransDate, Paypal);

                        Send_download_link("administratory@rentalanguageteacher.com", "info@rentalanguageteacher.com", "Payment Received", "Payer Email: " + user_email + ", " + option_name1 + ": " + option_selection1 + ": " + option_name2 + ": " + option_selection2 +
                            ", Item Name: " + item_name + " Payment Date: " + UTCTransDate.ToString() + " Transaction ID: " + txn_id);

                        log.Info("IPN - Email Sent");

                        payment MyPayment = new payment();

                        MyPayment.hours = Convert.ToInt32(item_name.Substring(0, 2));
                        MyPayment.transaction_date = UTCTransDate;
                        MyPayment.username = option_selection1;
                        MyPayment.update_user = Paypal.my_aspnet_users.name;
                        MyPayment.user_id = Convert.ToInt32(option_selection2);
                        MyPayment.item_name = item_name;
                        MyPayment.payer_email = user_email;
                        MyPayment.transaction_id = txn_id;
                        MyPayment.transaction_status = pay_stat;


                        App_Code.PaymentService.SaveObject(MyPayment);

                        log.Info("IPN - Payment Added To RALT");

                    }


                    // more checks needed here specially your account number and related stuff
                }
                else if (strResponse == "INVALID")
                {
                    log.Error("IPN - Invalid");

                }
                else
                {
                    //log response/ipn data for manual investigation
                    log.Error("IPN - NOT Verified");
                }
            }
            catch (Exception ex)
            {
                log.Error("IPN - ERROR:" + ex.Message.ToString());
            }

            finally
            {
                log.Info("IPN Complete - **********************************************************************************************************");
            }
        }  // --- end of page load --


        void Send_download_link(string from, string to, string subject, string body)
        {
            try
            {  // Construct a new e-mail message 
                SmtpClient client = new SmtpClient();
                client.Send(from, to, subject, body);
            }
            catch (SmtpException ex)
            {
                log.Error("IPN - Email Error: " + ex.Message.ToString());

            }
        } // --- end of Send_download_link --

    }
}