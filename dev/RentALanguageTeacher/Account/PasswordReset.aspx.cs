using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace RentALanguageTeacher.Account
{
    public partial class PasswordReset : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            string Password = Page.RouteData.Values["Password"] as string;

            //Get Querystring Values
           // if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                if (string.IsNullOrEmpty(Password))
            {
                //QueryString ID null, notify user
                //App_Code.NotificationService.SendNotification("NoVerifyQueryString", "There was an error validating your account", "error");
                Response.Redirect("~/Home/?MSG=PasswordSetError");
            }

            else
            {
                //Parss QS into ID and hash
                string QS = Password;
                int length = QS.Length;
                int UserIDLength = length - 32;

                string UserID = QS.Substring(0, UserIDLength);
                string hash = QS.Substring(UserIDLength, QS.Length - UserIDLength);

                try
                {
                    //Verify the UserID and hash
                    bool HashVerified = App_Code.MemberShipService.VerifyHash(UserID, hash);

                    if (HashVerified == true)
                    {
                        //Approve User and notify

                        MembershipUser MyUser = App_Code.MemberShipService.GetUserById(UserID);

                        if (!object.ReferenceEquals(MyUser, null))
                        {
                            UserName.Text = MyUser.UserName;
                            Email.Text = MyUser.Email;
                        }
                        else
                        {
                            throw new Exception("Your account cannot be found");
                        }

                    }

                    else
                    {
                        //Hash didnt match throw error
                        throw new Exception("There was an error validating your account");
                    }
                }

                catch (Exception ex)
                {
                    //Catch ALL verifications errors
                    App_Code.NotificationService.SendNotification("VerificationError", ex.Message, "error");
                }
            }
        }

        protected void ResetPassword_Click(object sender, EventArgs e)
        {

            string PasswordQS = Page.RouteData.Values["Password"] as string;

            //Get Querystring Values
            // if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            if (string.IsNullOrEmpty(PasswordQS))
            {
                //QueryString ID null, notify user
                Response.Redirect("~/Home?MSG=PasswordSetError");
            }

            else
            {
                //Parss QS into ID and hash
                string QS = PasswordQS;
                int length = QS.Length;
                int UserIDLength = length - 32;

                string UserID = QS.Substring(0, UserIDLength);
                string hash = QS.Substring(UserIDLength, QS.Length - UserIDLength);

                try
                {
                    //Verify the UserID and hash
                    bool HashVerified = App_Code.MemberShipService.VerifyHash(UserID, hash);

                    if (HashVerified == true)
                    {
                        //Approve User and notify

                        MembershipUser MyUser = App_Code.MemberShipService.GetUserById(UserID);

                        if (!object.ReferenceEquals(MyUser, null))
                        {
                           App_Code.MemberShipService.SetPAssword(UserID, NewPassword.Text);
                            //App_Code.NotificationService.SendNotification("PasswordReset", "Your password has been changed sucessfully! Please log in to continue", "success", "4000");
                           // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "LogIn", "OpenSlider();", true);
                           Response.Redirect("~/Home?MSG=PasswordSet");
                        }
                        else
                        {
                            throw new Exception("Your account cannot be found");
                        }


                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Alert5", "Notification('" + "You account is confirmed" + "','" + "success" + "');", true);
                        //App_Code.NotificationService.SendNotification("ÜserApproved", "Your account has been confirmed", "success");
                    }

                    else
                    {
                        //Hash didnt match throw error
                        throw new Exception("There was an error validating your account");
                    }
                }

                catch (Exception ex)
                {
                    //Catch ALL verifications errors
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Alert6", "Notification('" + ex.Message + "','" + "error" + "');", true);
                    App_Code.NotificationService.SendNotification("VerificationError", ex.Message, "error");
                }
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (NewPassword.Text.Trim().Length < 6)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

    }
}
