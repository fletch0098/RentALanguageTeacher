﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Services;
using RentALanguageTeacher.App_Code;

namespace RentALanguageTeacher
{
    public partial class Prices : System.Web.UI.Page
    {
        MembershipUser CurrentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //Get Querystring Values
                if (!string.IsNullOrEmpty(Request.QueryString["MSG"]))
                {

                    //Parss QS items to Hidden field controls
                    string MSG = Request.QueryString["MSG"];

                    if (MSG == "CheckOutError")
                    {
                        App_Code.NotificationService.SendNotification("CheckOutError", "There was an error and you were redirected here.  Please select a package and continue", "error", "3000");

                    }

                }

                //string MSG = Page.RouteData.Values["msg"] as string;

                //if (MSG != "" && string.IsNullOrEmpty(Request.QueryString["IsLogin"]))
                //{
                //    if (MSG == "CheckOutError")
                //    {
                //        App_Code.NotificationService.SendNotification("CheckOutError", "There was an error and you were redirected here.  Please select a package and continue", "error", "3000");

                //    }


                //}
            }

        }

        protected void ViewCart_Click(object sender, EventArgs e)
        {

            CurrentUser = Membership.GetUser();

            if (CurrentUser == null)
            {
                App_Code.NotificationService.SendNotification("PricesLogIn", "Please log in to continue", "alert", "3000");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "LogIn", "OpenSlider('LogIn');", true);
                
            }

            else
            {

                string UserName = CurrentUser.UserName.ToString();

                user RALTUser = new user();
                RALTUser = UserService.GetUserByMemberId(Convert.ToInt32(CurrentUser.ProviderUserKey.ToString()));

                string ItemName = null;
                string ItemPrice = null;

                if (ItemSelected.Value == "1")
                {
                    ItemName = "10Hours";
                    ItemPrice = "100.00";

                }

                else if (ItemSelected.Value == "2")
                {
                    ItemName = "25Hours";
                    ItemPrice = "225.00";
                }

                else if (ItemSelected.Value == "3")
                {
                    ItemName = "50Hours";
                    ItemPrice = "400.00";
                }
                else
                {
                    ItemName = "10Hours";
                    ItemPrice = "100.00";
                }

                Response.Redirect("~/Checkout?Item=" + ItemName + "&UserName=" + UserName + "&Price=" + ItemPrice + "&UserID=" + RALTUser.user_id);
            }
            
        }
    }
}