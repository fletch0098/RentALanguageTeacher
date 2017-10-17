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
using System.Web.Routing;
using System.Web.Mail;

namespace RentALanguageTeacher
{
    public partial class verify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Verify = Page.RouteData.Values["Verify"] as string;

            //Get Querystring Values
            //if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            if (string.IsNullOrEmpty(Verify))
            {
                //QueryString ID null, notify user
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Alert7", "Notification('" + "There was an error confirming your account" + "','" + "error" + "');", true);
                Response.Redirect("~/Home/?MSG=VerifyError");
            }

            else
            {
                //Parss QS into ID and hash
                string QS = Verify;
                int length = QS.Length;
                int UserIDLength = length - 32;

                string UserID = QS.Substring(0,UserIDLength);
                string hash = QS.Substring(UserIDLength, QS.Length-UserIDLength);

                try
                {
                    //Verify the UserID and hash
                    bool HashVerified = App_Code.MemberShipService.VerifyHash(UserID, hash);

                    if (HashVerified == true)
                    {
                        //Approve User and notify
                        App_Code.MemberShipService.ApproveUserById(UserID);

                        user RALTUser = new user();
                        RALTUser = UserService.GetUserByMemberId(Convert.ToInt32(UserID));

                        UserService.AccountStatusVerified(Convert.ToInt32(RALTUser.user_id));
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '1' + ");", true);
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Alert5", "Notification('" + "You account is confirmed" + "','" + "success" + "');", true);
                        App_Code.NotificationService.SendNotification("ÜserApproved", "Your account has been confirmed and we are working on your request.", "success","5000");
                       // System.Threading.Thread.Sleep(10000);
                        

                        App_Code.EmailService.NewUserNotification(UserID);


Response.Redirect("/Prices");


                    }

                    else
                    {
                        //Hash didnt match throw error
                        throw new Exception("Your account cannot be confirmed");
                    }
                }



                catch (Exception ex)
                {
                    //Catch ALL verifications errors
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Alert6", "Notification('" + ex.Message + "','" + "error" + "');", true);
                   // App_Code.NotificationService.SendNotification("VerificationError", ex.Message, "error");
                }
            }

        }
     
    }
}