using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace RentALanguageTeacher.App_Code
{
    public class CookieService
    {

        public static void SetAccountCookie(string AccountType)
        {

             var http = System.Web.HttpContext.Current;
             if ((http != null))
             {
                 var page = http.CurrentHandler as System.Web.UI.Page;
                 if (page != null)
                 {


                     //Check for exsisting cookie
                     HttpCookie AccountCookie = http.Request.Cookies["RentALanguageTeacherAccount"];

                     if (AccountCookie == null)
                     {

                         AccountCookie = new HttpCookie("RentALanguageTeacherAccount");

                         AccountCookie.Value = AccountType;

                         AccountCookie.Expires = DateTime.Now.AddDays(735);

                         http.Response.Cookies.Add(AccountCookie);

                     }

                     else
                     {

                         AccountCookie.Value = AccountType;

                         http.Response.Cookies.Set(AccountCookie);

                     }
                 }
             }

        }

        public static string ReadAccountCookie()
        {

            var http = System.Web.HttpContext.Current;
            if ((http != null))
            {
                var page = http.CurrentHandler as System.Web.UI.Page;
                if (page != null)
                {

                    //Check for exsisting cookie
                    HttpCookie AccountCookie = http.Request.Cookies["RentALanguageTeacherAccount"];

                    if (AccountCookie != null)
                    {

                        return AccountCookie.Value;

                    }

                    else
                    {

                        return "false";

                    }
                }
                else
                {

                    return "false";

                }

            }
            else
            {

                return "false";

            }

        }

        public static void Authenticate(string username, string password, Boolean isPersistent)
        {
            var http = System.Web.HttpContext.Current;
            if ((http != null))
            {
                var page = http.CurrentHandler as System.Web.UI.Page;
                if (page != null)
                {


                    if (Membership.ValidateUser(username, password))
                    {
                        // sometimes used to persist user roles
                        //string userData = string.Join("|", GetCustomUserRoles());

                        string userData = "";

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                          1,                                     // ticket version
                          username,                              // authenticated username
                          DateTime.Now,                          // issueDate
                          DateTime.Now.AddMinutes(120),           // expiryDate
                          isPersistent,                          // true to persist across browser sessions
                          userData,                              // can be used to store additional user data
                          FormsAuthentication.FormsCookiePath);  // the path for the cookie

                        // Encrypt the ticket using the machine key
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                        // Add the cookie to the request to save it
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        cookie.HttpOnly = true;
                        http.Response.Cookies.Add(cookie);

                        // Your redirect logic
                        // Response.Redirect(FormsAuthentication.GetRedirectUrl(username, isPersistent));
                    }
                }
            }

        }

    }
}