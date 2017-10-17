using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentALanguageTeacher.App_Code;

namespace RentALanguageTeacher
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindCountry();
            }

        }

        protected void BindCountry()
        {

            //Create blank list
            List<RentALanguageTeacher.App_Code.Time.CountryDDL> list = new List<RentALanguageTeacher.App_Code.Time.CountryDDL>();

            //Fill list
            list = TimeService.FillCountryDDL();

            //Create Default Value
            RentALanguageTeacher.App_Code.Time.CountryDDL DefaultCountry = new RentALanguageTeacher.App_Code.Time.CountryDDL();

            DefaultCountry.CountryCode = "Default";
            DefaultCountry.CountryName = "Select your Country";

            list.Add(DefaultCountry);

            //Bind DDL
            Country.DataSource = list;
            Country.DataValueField = "CountryCode";
            Country.DataTextField = "CountryName";
            Country.DataBind();
            Country.SelectedValue = "Default";

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Country.SelectedValue == "Default")
            {
                args.IsValid = false;
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Page.Validate("ContactUs");

            if (Page.IsValid)
            {
                try
                {
                   App_Code.EmailService.ContactUsEmail(Name.Text.ToString(), Email.Text.ToString(), Country.SelectedValue.ToString(), Message.Text.ToString());

                    Name.Text = "";
                    Email.Text = "";
                    Message.Text = "";
                    Country.SelectedValue = "Default";

                    App_Code.NotificationService.SendNotification("ContactUsSuccess", "Thank you for your qestion.  We will get back to you shortly", "success", "4000");
                }

                catch
                {
                    App_Code.NotificationService.SendNotification("ContactUsError", "I am sorry, there was an error.  This has been logged and we will fix it shortly.", "error", "4000");
                }
            }

            else
            {
                App_Code.NotificationService.SendNotification("ContactUsValidation", "Please complete the required fields", "error", "4000");
            }

        }
    }
}