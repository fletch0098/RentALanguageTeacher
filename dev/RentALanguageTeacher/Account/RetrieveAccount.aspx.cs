using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentALanguageTeacher.Account
{
    public partial class RetrieveAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Send_Click(object sender, EventArgs e)
        {
            Page.Validate("RetrieveAccount");
            if (Page.IsValid)
            {

                try
                {
      
                    App_Code.MemberShipService.RetrievePassword(Email.Text);
                    SearchStatus.Text = "Thank you, an email has been sent with further instructions";
                    Email.Text = "";
                    App_Code.NotificationService.SendNotification("RetrieveAccountSuccess", "Thank you, an email has been sent with further instructions", "success", "4000");
                }

                catch (System.ArgumentNullException exN)
                {
                    App_Code.NotificationService.SendNotification("RetrieveAccountError", "A UserName was not found for that email", "alert", "4000");
                }

                catch (Exception ex)
                {
                    //App_Code.NotificationService.SendNotification("UserNotLoggedIn", "Please log in to continue", "information", "4000");
                    // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Alert1", "Notification('" + "You suck" + "','" + "error" + "');", true);
                    App_Code.NotificationService.SendNotification("RetrieveAccountError", ex.Message.ToString(), "error", "4000");
                    //  App_Code.NotificationService.SendNotification("error", "WTF", "information", "4000");
                }
            }

            else 
            {
                App_Code.NotificationService.SendNotification("RetrieveAccountValidation", "Please complete the required fields", "alert", "4000");
            }


        }
    }
}