﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Services;
using RentALanguageTeacher.App_Code;
using System.Net.Mail;

namespace RentALanguageTeacher.Account
{
    public partial class AccountSetup : System.Web.UI.Page
    {
        protected const string PasswordMask = "*********************************************************************************************************************************";

        protected void Page_Load(object sender, EventArgs e)
        {

            string pg = Page.RouteData.Values["AccountSetup"] as string;

            if (!Page.IsPostBack)
            {
                //Bind DDLs
                BindCountry();
                BindNationality();

                //Get Querystring Values
                if (string.IsNullOrEmpty(Request.QueryString["Level"])
                    || string.IsNullOrEmpty(Request.QueryString["Frequency"])
                    || string.IsNullOrEmpty(Request.QueryString["Period"])
                     || string.IsNullOrEmpty(Request.QueryString["Duration"])
                    || string.IsNullOrEmpty(Request.QueryString["StartDate"]))
                {
                    //QueryString null
                    //Get the logged in User if any
                    MembershipUser LoggedInMembershipUser;
                    LoggedInMembershipUser = Membership.GetUser();

                    //Check if there is a logged in User
                    if (LoggedInMembershipUser == null)
                    {
                        //App_Code.NotificationService.SendNotification("NoUser","You have been returned to out Homepage because of an error.","alert");
                        Response.Redirect("~/Home/AccountError");

                    }

                }

                else
                {
                    //Parss QS items to Hidden field controls
                    SpanishLevel.Value = Request.QueryString["Level"];
                    FrequencyOfClasses.Value = Request.QueryString["Frequency"];
                    PeriodOfClasses.Value = Request.QueryString["Period"];
                    StartDate.Value = Request.QueryString["StartDate"];
                    Duration.Value = Request.QueryString["Duration"];


                }


                //Load Data
                try
                {

                    //Get the logged in User if any
                    MembershipUser LoggedInMembershipUser;
                    LoggedInMembershipUser = Membership.GetUser();

                    //Check if there is a logged in User
                    if (LoggedInMembershipUser != null)
                    {

                        //Membership Data
                        UserName.Text = LoggedInMembershipUser.UserName.ToString();
                        Email.Text = LoggedInMembershipUser.Email.ToString();


                        //Disable controls
                        UserName.Enabled = false;
                        Email.Enabled = false;
                        Password.Enabled = false;
                        Confirm.Enabled = false;
                        Password.Visible = false;
                        lblPassword.Visible = false;
                        Confirm.Visible = false;
                        lblConfirm.Visible = false;

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "AccountSetUpLogginIn", "GreyAccountInfo("+'1'+");", true);

                        //$(".first").addClass("second");

                        //RALT Data

                        // ToInt32 can throw FormatException or OverflowException. 
                        int UserId = -1;

                        try
                        {
                            //Get the RALT data from membership accountID
                            UserId = Convert.ToInt32(LoggedInMembershipUser.ProviderUserKey.ToString());
                            user UserData = UserService.GetUserByMemberId(UserId);

                            //Bind data
                            if (!object.ReferenceEquals(UserData, null))
                            {
                                FirstName.Text = UserData.first_name;
                                Age.SelectedIndex = (int)UserData.age;
                                LastName.Text = UserData.last_name;
                                Nationality.SelectedValue = UserData.nationality;
                                SkypeID.Text = UserData.skype_id;

                                if (UserData.account_status == "Request Made")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '0' + ");", true);
                                }
                                else if (UserData.account_status == "Verified")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '1' + ");", true);
                                }
                                else if (UserData.account_status == "Email Sent")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '2' + ");", true);
                                }
                                else if (UserData.account_status == "Paid")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '3' + ");", true);
                                }
                                else if (UserData.account_status == "First Class")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '4' + ");", true);
                                }

                                //Check for location data
                                location MyLocation = LocationService.GetUserById(UserData.user_id);

                                if (!object.ReferenceEquals(MyLocation, null))
                                {
                                    //Address1.Text = MyLocation.line_1;
                                    //Address2.Text = MyLocation.line_2;
                                    //City.Text = MyLocation.city;
                                    //State.Text = MyLocation.state;
                                    //PostalCode.Text = MyLocation.postal_code;
                                    Country.SelectedValue = MyLocation.country_code_iso2;

                                    BindTimeZone(Country.SelectedValue);

                                    string ZoneId = Convert.ToString(MyLocation.zone_id);

                                    TimeZone.SelectedValue = ZoneId;

                                }

                                //Check for location data
                                quickregistration MyReg = QuickRegService.GetObjectByUserId(UserData.user_id);

                                if (!object.ReferenceEquals(MyReg, null))
                                {
                                    SpecialRequests.Text = MyReg.specialrequests;

                                }
                            }
                        }

                        catch (FormatException)
                        {
                            //Console.WriteLine("Input string is not a sequence of digits.");
                            throw;
                        }
                        catch (OverflowException)
                        {
                            //Console.WriteLine("The number cannot fit in an Int32.");
                            throw;
                        }

                    }

                }

                catch (Exception)
                {

                    App_Code.NotificationService.SendNotification("AccountSetupLoadError", "There was an error loading your account", "error", "4000");

                }

            }
            
            else 
            {
                //detect if password was changed. if filled and not equal to mask, it is new
                if (Password.Text.Trim().Length > 0 && Password.Text != PasswordMask)
                {
                    TypedPassword = Password.Text;
                    Password.Attributes.Add("value", PasswordMask);
                }
                Password.Attributes.Add("onFocus", "Clear_Password('" + Password.ClientID + "')");

                //detect if Confirm was changed. if filled and not equal to mask, it is new
                if (Confirm.Text.Trim().Length > 0 && Confirm.Text != PasswordMask)
                {
                    TypedPassword = Confirm.Text;
                    Confirm.Attributes.Add("value", PasswordMask);
                }
                Confirm.Attributes.Add("onFocus", "Clear_Password('" + Confirm.ClientID + "')");

            }

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Country.SelectedValue == "Default")
            {
                args.IsValid = false;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "DDLInvalid", "DDLRequired("+"Country"+");", true);
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (HTOS.Value == "false")
            {
                args.IsValid = false;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "DDLInvalid", "DDLRequired("+"Country"+");", true);
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TimeZone.SelectedValue == "0")
            {
                args.IsValid = false;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "DDLInvalid", "DDLRequired("+"Country"+");", true);
            }

            else
            {
                args.IsValid = true;
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

            //Disable TimeZone
            TimeZone.Enabled = false;

        }

        protected void BindNationality()
        {

            //Create blank list
            List<RentALanguageTeacher.App_Code.Time.CountryDDL> list = new List<RentALanguageTeacher.App_Code.Time.CountryDDL>();

            //Fill list
            list = TimeService.FillCountryDDL();

            //Create Default Value
            RentALanguageTeacher.App_Code.Time.CountryDDL DefaultCountry = new RentALanguageTeacher.App_Code.Time.CountryDDL();

            DefaultCountry.CountryCode = "Default";
            DefaultCountry.CountryName = "Select your Nationality";

            list.Add(DefaultCountry);

            //Bind DDL
            Nationality.DataSource = list;
            Nationality.DataValueField = "CountryCode";
            Nationality.DataTextField = "CountryName";
            Nationality.DataBind();
            Nationality.SelectedValue = "Default";

        }

        protected void BindTimeZone(string MyCountry)
        {

            //Create blank list
            List<RentALanguageTeacher.App_Code.Time.TimeZoneDDL> list = new List<RentALanguageTeacher.App_Code.Time.TimeZoneDDL>();

            //Populate List from country
            list = TimeService.FillTimeZoneDDL(MyCountry);

            //Create Default
            RentALanguageTeacher.App_Code.Time.TimeZoneDDL DefaultCountry = new RentALanguageTeacher.App_Code.Time.TimeZoneDDL();

            DefaultCountry.ZoneId = 0;
            DefaultCountry.ZoneName = "Select your TimeZone";

            list.Add(DefaultCountry);

            //Bind DDL
            TimeZone.DataSource = list;
            TimeZone.DataValueField = "ZoneId";
            TimeZone.DataTextField = "ZoneName";
            TimeZone.DataBind();

            //Select Default Value
            TimeZone.SelectedValue = "0";

            //Enable
            TimeZone.Enabled = true;

        }

        protected void Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Country.SelectedValue.ToString() == "Default")
            {
                TimeZone.Enabled = false;
            }
            else
            {
                BindTimeZone(Country.SelectedValue.ToString());
            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            //Validate Page
            Page.Validate("NewAccount");

            if (Page.IsValid)
            {
                //valid Page
                try
                {
                    int MemberId = -1;

                    //Get Loggedin User
                    MembershipUser LoggedInMembershipUser;
                    MembershipUser MyMemberShipUser;
                    LoggedInMembershipUser = Membership.GetUser();

                    //Check if loggedin
                    if (LoggedInMembershipUser == null)
                    {
                        //No loggin in User

                        Page.Validate("NewMemberShip");

                        if (Page.IsValid)
                        {
                            string MyPassword;
                            if (TypedPassword != "")
                            {
                                MyPassword = TypedPassword;
                            }
                            else
                            {
                                MyPassword = Password.Text.ToString();
                            }

                            //Create User
                            MemberId = App_Code.MemberShipService.CreateUser(UserName.Text.ToString(), MyPassword, Email.Text.ToString());

                            //Approve User and notify
                            App_Code.MemberShipService.ApproveUserById(MemberId.ToString());

                            ////Set the HasLogInCookie
                            //HttpCookie MyCookie = new HttpCookie("RALTHasLogin");
                            //MyCookie.Value = "True";
                            //Response.Cookies.Add(MyCookie);

                            //Set the pageUser to the new user
                            MyMemberShipUser = App_Code.MemberShipService.GetUserById(MemberId.ToString());
                            App_Code.MemberShipService.NewUserEmail(MyMemberShipUser);
                            //App_Code.NotificationService.SendNotification("NewUserSuccess", "Your Account was created successfully, but you are not done yet. We ask that you confirm your email before we process your request. Please monitor your email for further instructions.", "success");

                        }

                        else
                        {
                            //Invalid Page, notify User
                            App_Code.NotificationService.SendNotification("NewAccountValidation", "Please complete the required fields", "error", "4000");
                            return;
                        }
                    }

                    else
                    {
                        //UserLogged in set page user to logged in user
                        MyMemberShipUser = LoggedInMembershipUser;

                        //Set MemberId
                        try
                        {
                            MemberId = Convert.ToInt32(MyMemberShipUser.ProviderUserKey.ToString());
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    //Check for exsisting RALTUser
                    user RaltUser = UserService.GetUserByMemberId(MemberId);
                    user MyUser = new user();
                    bool NewUser = false;

                    //If there is an RALT USER link set UserID
                    if (!object.ReferenceEquals(RaltUser, null))
                    {
                        MyUser.user_id = RaltUser.user_id;

                    }

                    else
                    {
                        MyUser.account_status = "Request Made";
                        NewUser = true;
                    }

                    


                    MyUser.first_name = FirstName.Text.ToString();
                    MyUser.member_id = MemberId;
                    MyUser.age = Age.SelectedIndex;
                    MyUser.email = MyMemberShipUser.Email;
                    MyUser.last_name = LastName.Text.ToString();
                    MyUser.nationality = Nationality.SelectedValue;
                    MyUser.skype_id = SkypeID.Text;
                   

                    //Save MyUser
                    int MyUserId = UserService.SaveNewUser(MyUser);



                    location RALTLocation = LocationService.GetUserById(MyUserId);
                    location MyLocation = new location();

                    if (!object.ReferenceEquals(RALTLocation, null))
                    {
                        MyLocation.location_id = RALTLocation.location_id;
                    }
                    else
                    {
                        RALTLocation = new location();
                    }


                    //MyLocation.city = City.Text;
                    MyLocation.country_code_iso2 = Country.SelectedValue;
                    //MyLocation.line_1 = Address1.Text;
                    //MyLocation.line_2 = Address2.Text;
                    //MyLocation.postal_code = PostalCode.Text;
                    //MyLocation.state = State.Text;
                    MyLocation.user_id = MyUserId;


                    int ZoneID = -1;
                    try
                    {
                        ZoneID = Convert.ToInt32(TimeZone.SelectedValue);
                    }
                    catch (FormatException)
                    {
                        //Console.WriteLine("Input string is not a sequence of digits.");
                    }
                    catch (OverflowException)
                    {
                        //Console.WriteLine("The number cannot fit in an Int32.");
                    }

                    MyLocation.zone_id = ZoneID;

                    LocationService.SaveObject(MyLocation);


                    quickregistration RALTQuickReg = QuickRegService.GetObjectByUserId(MyUserId);
                    quickregistration MyReg = new quickregistration();

                    if (!object.ReferenceEquals(RALTQuickReg, null))
                    {
                        MyReg.quick_registration_id = RALTQuickReg.quick_registration_id;
                    }
                    else
                    {
                        RALTQuickReg = new quickregistration();
                    }

                    if (!(SpanishLevel.Value == "") || !(FrequencyOfClasses.Value == "")
                        || !(PeriodOfClasses.Value == "") || !(StartDate.Value == ""))
                    {
                        MyReg.languagel_evel = Convert.ToInt32(SpanishLevel.Value);
                        MyReg.classes = Convert.ToInt32(FrequencyOfClasses.Value);
                        MyReg.period = PeriodOfClasses.Value;
                        // MyReg.start_date = Convert.ToDateTime(StartDate.Value);

                        MyReg.class_duration = Convert.ToInt32(Duration.Value);

                        DateTime LocalDate = Convert.ToDateTime(StartDate.Value);
                        MyReg.start_date = App_Code.TimeService.ConvertToUTC(LocalDate, MyUser);
                    }


                    MyReg.user_id = MyUserId;
                    MyReg.specialrequests = SpecialRequests.Text;




                    QuickRegService.SaveObject(MyReg);

                    if (LoggedInMembershipUser == null)
                    {

                        if (NewUser == true)
                        {

                            UserService.AccountStatusVerified(MyUserId);

                           App_Code.EmailService.NewUserNotification(MemberId.ToString());

                        }

                        try
                        {

                            //Save current URL(needed to set cookie)
                            string Currenturl = HttpContext.Current.Request.Url.AbsoluteUri;
                            string Currentpath = HttpContext.Current.Request.Url.AbsolutePath;

                            string MyPassword;
                            if (TypedPassword != "")
                            {
                                MyPassword = TypedPassword;
                            }
                            else
                            {
                                MyPassword = Password.Text.ToString();
                            }

                            //Validate Login
                            bool Authenticated = App_Code.MemberShipService.LogInUser(UserName.Text.ToString(), MyPassword, false, "");

                            //If Valid Login, set cookie
                            if (Authenticated == true)
                            {
                                //Set Cookie
                                // Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
                                //FormsAuthentication.SetAuthCookie(UserName.Text.ToString(), IsPersistant.Checked);

                                App_Code.CookieService.Authenticate(UserName.Text.ToString(), Password.Text.ToString(), false);

                                App_Code.CookieService.SetAccountCookie("User");



                            }

                            else
                            {
                                //UserNot validdated
                                App_Code.NotificationService.SendNotification("LogInAuthenticationInvalid", "There was an error logging in.  Please try again", "alert", "4000");

                            }

                        }

                        catch (Exception ex)
                        {
                            //There was an error in validating login
                            App_Code.NotificationService.SendNotification("LogInAuthenticationError", ex.Message, "error", "4000");
                        }

                        //Clear Form
                        UserName.Text = "";
                        Email.Text = "";
                        Password.Text = "";
                        Confirm.Text = "";

                        FirstName.Text = "";
                        LastName.Text = "";
                        SpecialRequests.Text = "";
                        Age.SelectedValue = "0";
                        Nationality.SelectedValue = "Default";
                        Country.SelectedValue = "Default";
                        TimeZone.SelectedValue = "0";
                        TimeZone.Enabled = false;


                   //     App_Code.NotificationService.SendCBNotification("NewAccountSuccess", "Thank you for creating an accoutn with Rent A Language Teacher.", "success", "window.location.href = '/RALT/EN/Rent';");

                        Response.Redirect("/RALT/EN/Rent");



                    }


                    App_Code.NotificationService.SendNotification("AccountUpdateSuccess", "Your account was updated successfully", "success", "3000");

                }

                


                catch (NewUserException NUex)
                {
                    App_Code.NotificationService.SendNotification("NewUserExceptionError", NUex.Message, "alert", "4000");

                }

                catch (Exception ex)
                {
                    //CreateUser Error, Notify User
                    App_Code.NotificationService.SendNotification("NewUserError", ex.Message, "error", "4000");
                }
            }

            else
            {
                //Invalid Page, notify User
                App_Code.NotificationService.SendNotification("NewAccountValidation", "Please complete the required fields", "error", "4000");
            }

        }

        protected string TypedPassword
        {
            get
            {
                if (ViewState["TypedPassword"] != null)
                {
                    return Convert.ToString(ViewState["TypedPassword"]);
                }
                return null;
            }
            set
            {
                ViewState["TypedPassword"] = value;
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)

        {
   
            if (Password.Text.Trim().Length < 6 && TypedPassword.Length < 6 )
            {
                args.IsValid=false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}