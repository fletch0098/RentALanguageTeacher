using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Services;
using RentALanguageTeacher.App_Code;

namespace RentALanguageTeacher.Pages.Administrator
{
    public partial class AdministerStudent : System.Web.UI.Page
    {
        MembershipUser MembershipUser;
        user UserData = new user();

        protected void Page_Load(object sender, EventArgs e)
        {
            string StudentUN = Page.RouteData.Values["Student"] as string;

            if (!Page.IsPostBack)
            {
                //Bind DDLs
                BindCountry();
                BindNationality();
                BindStatus();
                

                //Load Data
                try
                {

                    //Get the logged in User if any
                   
                    MembershipUser = Membership.GetUser(StudentUN);
                    Session["MembershipUser"] = MembershipUser;


                    //Check if there is a logged in User
                    if (MembershipUser != null)
                    {

                        //Membership Data
                        UserName.Text = MembershipUser.UserName.ToString();
                        Email.Text = MembershipUser.Email.ToString();


                        ////Disable controls
                        //UserName.Enabled = false;
                        //Email.Enabled = false;
                        //Password.Enabled = false;
                        //Confirm.Enabled = false;
                        //Password.Visible = false;
                        //lblPassword.Visible = false;
                        //Confirm.Visible = false;
                        //lblConfirm.Visible = false;

                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "AccountSetUpLogginIn", "GreyAccountInfo(" + '1' + ");", true);

                        //$(".first").addClass("second");

                        //RALT Data

                        // ToInt32 can throw FormatException or OverflowException. 
                        int UserId = -1;

                        try
                        {
                            //Get the RALT data from membership accountID
                            UserId = Convert.ToInt32(MembershipUser.ProviderUserKey.ToString());
                            UserData = (user)UserService.GetUserByMemberId(UserId);


                            Session["UserData"] = (user)UserData;

                            //Bind data
                            if (!object.ReferenceEquals(UserData, null))
                            {
                                FirstName.Text = UserData.first_name;
                                Age.SelectedIndex = (int)UserData.age;
                                LastName.Text = UserData.last_name;
                                Nationality.SelectedValue = UserData.nationality;
                                ddlStatus.SelectedValue = UserData.account_status;
                                SkypeID.Text = UserData.skype_id;

                                BindPayments();


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
                                    txtFrequency.Text = MyReg.classes.ToString();
                                    txtLevel.Text = MyReg.languagel_evel.ToString();
                                    txtPeriod.Text = MyReg.period;

                                    DateTime StartDate = (DateTime)MyReg.start_date;

                                    RentALanguageTeacher.user Admin = UserService.GetUserById(Convert.ToInt32(AppConfiguration.AdminID));

                                    DateTime LocalStartDate = App_Code.TimeService.ConvertToMyTime(StartDate, Admin);


                                    txtStartDate.Text = LocalStartDate.Date.ToString("d");
                                    TimeSpan span = new TimeSpan(0, 3, 0, 0, 0);
                                    txtBlockTime.Text = LocalStartDate.TimeOfDay.ToString() + " - " + LocalStartDate.TimeOfDay.Add(span).ToString();

                                    Duration.Text = MyReg.class_duration.ToString();

                                    Teacher.Text = MyReg.teacher;
                                    TeacherSkype.Text = MyReg.teacher_skypeid;
                                    FirstClass.Value = MyReg.first_class.ToString();
                                    txtAdminComments.Text = MyReg.admin_comments;
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "SetFirstClass", "SetFirstClass();", true);
                          

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

                catch (Exception ex)
                {

                    App_Code.NotificationService.SendNotification("AccountSetupLoadError", ex.Message, "error", "4000");

                }

                LockControls();

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

        protected void BindStatus()
        {

            //Create blank list
            List<accountstatu> list = new List<accountstatu>();

            //Fill list
            list = App_Code.AccountStatusService.GetObjects();

            ////Create Default Value
            //RentALanguageTeacher.App_Code.Time.CountryDDL DefaultCountry = new RentALanguageTeacher.App_Code.Time.CountryDDL();

            //DefaultCountry.CountryCode = "Default";
            //DefaultCountry.CountryName = "Select your Country";

            //list.Add(DefaultCountry);
            
            //Bind DDL
            ddlStatus.DataSource = list;
            ddlStatus.DataValueField = "account_status";
            ddlStatus.DataTextField = "account_status";
            ddlStatus.DataBind();
            //Country.SelectedValue = "Default";


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

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // .PageIndex = e.NewPageIndex;
            //BindStudents();
        }

        protected void Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
           // BindStudents();
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

        protected void valDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("1000/12/28");
            DateTime maxDate = DateTime.Parse("9999/12/28");
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }

        protected void LockControls()
        {

            UserName.Enabled = false;
            Email.Enabled = false;
            FirstName.Enabled = false;
            LastName.Enabled = false;
            Nationality.Enabled = false;
            Age.Enabled = false;
            Country.Enabled = false;
            TimeZone.Enabled = false;
            txtLevel.Enabled = false;
            txtFrequency.Enabled = false;
            txtPeriod.Enabled = false;
            Duration.Enabled = false;
            txtStartDate.Enabled = false;
            txtBlockTime.Enabled = false;
            SpecialRequests.Enabled = false;
            SkypeID.Enabled = false;

        }

        protected void btnNewPayment_Click(object sender, EventArgs e)
        {
             //Validate Page
            Page.Validate("NewPayment");

            if (Page.IsValid)
            {
                try
                {
                    MembershipUser = (MembershipUser)Session["MembershipUser"];
                    UserData = (user)Session["UserData"];

                    payment MyPayment = new payment();

                    user UpdateUser = UserService.GetUserByMemberId(Convert.ToInt32(Membership.GetUser().ProviderUserKey.ToString()));

                   // MyPayment.hours = Convert.ToInt32(item_name.Substring(0, 2));
                    //MyPayment.transaction_date = UTCTransDate;
                   // MyPayment.username = option_selection1;
                    MyPayment.update_user = Membership.GetUser().UserName;
                   // MyPayment.user_id = Convert.ToInt32(option_selection2);
                    MyPayment.item_name = txtHours.Text + "Hours";
                    MyPayment.payer_email = PaypalEmail.Text;
                    MyPayment.transaction_id = TxnId.Text;
                    MyPayment.transaction_status = "Completed";

                    //payment MyPayment = new payment();

                    MyPayment.hours = Convert.ToInt32(txtHours.Text);
                    MyPayment.transaction_date = App_Code.TimeService.ConvertToUTC(Convert.ToDateTime(TransDate.Value),UserData);
                    MyPayment.username = MembershipUser.UserName;
                    MyPayment.user_id = UserData.user_id;

                    App_Code.PaymentService.SaveObject(MyPayment);

                    BindPayments();

                    App_Code.NotificationService.SendNotification("PaymentSuccess","Payment Sucessfully Added","success","4000");

                    txtHours.Text = "";
                    TransDate.Value = "";
                    TxnId.Text = "";
                    PaypalEmail.Text = "";

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "SetTransdate", "SetFirstClass();", true);
                    
                }
                catch (Exception ex)
                {

                    App_Code.NotificationService.SendNotification("NewPaymentError", ex.Message, "error", "4000");

                }
            }
            else
                App_Code.NotificationService.SendNotification("NewAccountValidation", "Please complete the required fields", "error", "4000");
        }

        protected void BindPayments()
        {
            UserData = (user)Session["UserData"];

            List<payment> Payments;

            Payments = App_Code.PaymentService.GetObjectsByUserId(UserData.user_id);

            GridPayments.DataSource = Payments;
            GridPayments.DataBind();
        }

        protected void UpDateStudent_Click(object sender, EventArgs e)
        {

            //Validate Page
            Page.Validate("AdministerStudent");

            if (Page.IsValid)
            {
                try
                {
                    MembershipUser = (MembershipUser)Session["MembershipUser"];
                    UserData = (user)Session["UserData"];

                    //user MyUser = UserService.GetUserById(UserData.user_id);

                    quickregistration MyReg = QuickRegService.GetObjectByUserId(UserData.user_id);

                    if (!object.ReferenceEquals(MyReg, null))
                    {
                        MyReg.admin_comments = txtAdminComments.Text;

                        if (!object.ReferenceEquals(FirstClass.Value,""))
                        {
                            MyReg.first_class = App_Code.TimeService.ConvertToUTC(Convert.ToDateTime(FirstClass.Value), UserData);
                        }

                        
                        MyReg.teacher = Teacher.Text;
                        MyReg.teacher_skypeid = TeacherSkype.Text;

                        QuickRegService.SaveObject(MyReg);

                        UserData.account_status = ddlStatus.SelectedItem.ToString();
                        UserService.SaveNewUser(UserData);
                        
                        App_Code.NotificationService.SendNotification("AdministerStudentSuccess", "Sucessfully Updated", "success", "4000");
                    }

                   

                    
                }
                catch (Exception ex)
                {

                    App_Code.NotificationService.SendNotification("AdministerStudentError", ex.Message, "error", "4000");

                }
            }
            else
                App_Code.NotificationService.SendNotification("AdministerStudentValidation", "Please complete the required fields", "error", "4000");

        }


    }
}