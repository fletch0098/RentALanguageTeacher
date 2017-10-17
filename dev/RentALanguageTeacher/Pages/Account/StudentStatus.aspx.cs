using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Services;
using RentALanguageTeacher.App_Code;


namespace RentALanguageTeacher.Pages.Account
{
    public partial class StudentStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //Bind DDLs
               // BindStatus();

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

                                if (UserData.account_status == "Request Made")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '0' + ");", true);
                                    PleasePayPanel.Visible = true;
                                    lblStatus.Visible = false;
                                }
                                else if (UserData.account_status == "Verified")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '1' + ");", true);
                                    PleasePayPanel.Visible = true;
                                    lblStatus.Visible = false;
                                }
                                else if (UserData.account_status == "Email Sent")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '2' + ");", true);
                                    PleasePayPanel.Visible = true;
                                    lblStatus.Visible = false;
                                 
                                }
                                else if (UserData.account_status == "Paid")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '3' + ");", true);
                                    PleasePayPanel.Visible = false;
                                }
                                else if (UserData.account_status == "First Class")
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "CompleteVerify", "CompleteStep(" + '4' + ");", true);
                                    PleasePayPanel.Visible = false;
                                    lblStatus.Visible = true;
                                    lblStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#edac1c");
                                    lblStatus.Text = "Rent a Language Teacher appreciates your business! Please purchase another package on our <a href='/Prices' Title='Prices'>Prices</a> page.";

                                    //
                                }

                                BindPayments();

                                //Check for location data
                                location MyLocation = LocationService.GetUserById(UserData.user_id);

                                if (!object.ReferenceEquals(MyLocation, null))
                                {


                                }

                                //Check for location data
                                quickregistration MyReg = QuickRegService.GetObjectByUserId(UserData.user_id);

                                if (!object.ReferenceEquals(MyReg, null))
                                {
                                    Teacher.Text = MyReg.teacher;
                                    TeacherSkype.Text = MyReg.teacher_skypeid;
                                    txtFirstClass.Text = App_Code.TimeService.ConvertToMyTime(Convert.ToDateTime(MyReg.first_class), UserData).ToString();
                                    RentALanguageTeacher.user Admin = UserService.GetUserById(Convert.ToInt32(AppConfiguration.AdminID));

                                    txtTeacherTime.Text = App_Code.TimeService.ConvertToMyTime(Convert.ToDateTime(MyReg.first_class), Admin).ToString();
                                    //ddlStatus.SelectedValue = UserData.account_status;
                                    UserComments.Text = MyReg.student_comments;


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

                    App_Code.NotificationService.SendNotification("StudentstatusErrorLoadError", "There was an error loading your account", "error", "4000");

                }
LockControls();
            }

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

        //protected void BindStatus()
        //{

        //    //Create blank list
        //    List<accountstatu> list = new List<accountstatu>();

        //    //Fill list
        //    list = App_Code.AccountStatusService.GetObjects();

        //    //Bind DDL
        //    ddlStatus.DataSource = list;
        //    ddlStatus.DataValueField = "account_status";
        //    ddlStatus.DataTextField = "account_status";
        //    ddlStatus.DataBind();
        //    //Country.SelectedValue = "Default";


        //}

        protected void BindPayments()
        {
                    //Get the logged in User if any
                    MembershipUser LoggedInMembershipUser;
                    LoggedInMembershipUser = Membership.GetUser();

                    //Check if there is a logged in User
                    if (LoggedInMembershipUser != null)
                    {
                        // ToInt32 can throw FormatException or OverflowException. 
                        int UserId = -1;

                        try
                        {
                            //Get the RALT data from membership accountID
                            UserId = Convert.ToInt32(LoggedInMembershipUser.ProviderUserKey.ToString());
                            user UserData = UserService.GetUserByMemberId(UserId);
                            List<payment> Payments;

                            Payments = App_Code.PaymentService.GetObjectsByUserId(UserData.user_id);

                            GridPayments.DataSource = Payments;
                            GridPayments.DataBind();
                        }
                        catch { }
                    }

            
        }

        protected void LockControls()
        {
            Teacher.Enabled = false;
            TeacherSkype.Enabled = false;
            txtFirstClass.Enabled = false;
            txtTeacherTime.Enabled = false;
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (UserComments.Text != "")
            {
                try
                {
                                        //Get the logged in User if any
                    MembershipUser LoggedInMembershipUser;
                    LoggedInMembershipUser = Membership.GetUser();

                    //Check if there is a logged in User
                    if (LoggedInMembershipUser != null)
                    {

                        // ToInt32 can throw FormatException or OverflowException. 
                        int UserId = -1;

                        //Get the RALT data from membership accountID
                        UserId = Convert.ToInt32(LoggedInMembershipUser.ProviderUserKey.ToString());
                        user UserData = UserService.GetUserByMemberId(UserId);

                        //Bind data
                        if (!object.ReferenceEquals(UserData, null))
                        {

                            quickregistration MyReg = QuickRegService.GetObjectByUserId(UserData.user_id);

                            if (!object.ReferenceEquals(MyReg, null))
                            {
                                MyReg.student_comments = UserComments.Text;

                                QuickRegService.SaveObject(MyReg);

                                App_Code.NotificationService.SendNotification("AdministerStudentSuccess", "Sucessfully Updated", "success", "4000");
                            }

                        }

                    }
                }
                catch (Exception ex)
                {

                    App_Code.NotificationService.SendNotification("AdministerStudentError", ex.Message, "error", "4000");

                }
            }
        }

    }
}