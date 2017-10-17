using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.IO;

namespace RentALanguageTeacher.App_Code
{
    public class EmailService
    {
        private static string FromAddress = AppConfiguration.FromAddress;
        private static string FromName = AppConfiguration.FromName;
        private static string InfoAddress = "info@rentalanguageteacher.com";
        private static string InfoName = "RALT Info";
        private static string AdminAddress = "administrator@rentalanguageteacher.com";
        private static string AdinName = "RALT Administrator";


        public static void ContactUsEmail(string Name, string Email, string Country, string Message)
        {
            try
            {

                string fileName = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/ContactUs.txt");
                string mailBody = File.ReadAllText(fileName);

                mailBody = mailBody.Replace("##Name##", Name);
                mailBody = mailBody.Replace("##Email##", Email);
                mailBody = mailBody.Replace("##Country##", Country);
                mailBody = mailBody.Replace("##Message##", Message);

                MailMessage myMessage = new MailMessage();
                myMessage.Subject = "A New Question";
                myMessage.Body = mailBody;
                myMessage.From = new MailAddress(Email, Name);
                myMessage.To.Add(new MailAddress(InfoAddress, InfoName));
                SmtpClient mySmtpClient = new SmtpClient();
                mySmtpClient.Send(myMessage);

            }
            catch
            {
                throw;
            }


        }


        public static void NewUserNotification(string MemberId)
        {
            RentALanguageTeacher.user Admin = UserService.GetUserById(Convert.ToInt32(AppConfiguration.AdminID));

            MembershipUser MyUser = MemberShipService.GetUserById(MemberId);

            int MemberIdInt = Convert.ToInt32(MemberId);

            RentALanguageTeacher.user MyRALTUser = UserService.GetUserByMemberId(MemberIdInt);

            DateTime LocalTime = App_Code.TimeService.GetUserLocalTime(MyRALTUser);

            location MyLocation = LocationService.GetUserById(MyRALTUser.user_id);

            quickregistration MyQuickReg = QuickRegService.GetObjectByUserId(MyRALTUser.user_id);

            double TimeDifference = App_Code.TimeService.GetTimeZoneDifference(MyRALTUser,Admin);

            DateTime GTStartDate = TimeService.ConvertToMyTime(Convert.ToDateTime(MyQuickReg.start_date), Admin);

            DateTime UserStartDate = TimeService.ConvertToMyTime(Convert.ToDateTime(MyQuickReg.start_date), MyRALTUser);

            TimeSpan span = new TimeSpan(0, 3, 0, 0, 0);

            string GTBlockTime = GTStartDate.ToString() + " - " + GTStartDate.Add(span).ToString();
            string UserBlockTime = UserStartDate.ToString() + " - " + UserStartDate.Add(span).ToString();

            string fileName = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/NewUserReg.txt");
            string mailBody = File.ReadAllText(fileName);

            mailBody = mailBody.Replace("##FirstName##", MyRALTUser.first_name);
            mailBody = mailBody.Replace("##LastName##", MyRALTUser.last_name);
            mailBody = mailBody.Replace("##Age##", MyRALTUser.age.ToString());
            mailBody = mailBody.Replace("##UserName##", MyUser.UserName);

            mailBody = mailBody.Replace("##Nationality##", MyRALTUser.nationality);
            mailBody = mailBody.Replace("##Email##", MyRALTUser.email);
            mailBody = mailBody.Replace("##Country##", MyLocation.country.short_name);
            mailBody = mailBody.Replace("##LocalTime##", LocalTime.ToString());
            mailBody = mailBody.Replace("##TZDiff##", TimeDifference.ToString());

            mailBody = mailBody.Replace("##Classes##", MyQuickReg.classes.ToString());
            mailBody = mailBody.Replace("##Period##", MyQuickReg.period);
            mailBody = mailBody.Replace("##Duration##", MyQuickReg.class_duration.ToString());
            mailBody = mailBody.Replace("##StartDate##", GTBlockTime);
            mailBody = mailBody.Replace("##StartDateUser##", UserBlockTime);
            mailBody = mailBody.Replace("##Level##", MyQuickReg.languagel_evel.ToString());
            mailBody = mailBody.Replace("##SpecialRequests##", MyQuickReg.specialrequests);

            MailMessage myMessage = new MailMessage();
            myMessage.Subject = "New Registration";
            myMessage.Body = mailBody;
            myMessage.From = new MailAddress(InfoAddress, InfoName);
            myMessage.To.Add(new MailAddress(InfoAddress, InfoName));
            SmtpClient mySmtpClient = new SmtpClient();
            mySmtpClient.Send(myMessage);



        }

    }
}