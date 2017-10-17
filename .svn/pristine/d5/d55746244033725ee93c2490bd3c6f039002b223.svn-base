using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using RentALanguageTeacher;

namespace RentALanguageTeacher
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)

            {
                //Get Querystring Values
                if (!string.IsNullOrEmpty(Request.QueryString["MSG"]))
                {

                    //Parss QS items to Hidden field controls
                    string MSG = Request.QueryString["MSG"];

                    if (MSG == "PasswordSet")
                    {
                        App_Code.NotificationService.SendNotification("PasswordSet", "Your password has been set.  Please login to continue.", "success", "3000");
                        //OpenSlider
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "LogIn", "OpenSlider('LogIn');", true);

                    }

                    else if (MSG == "PasswordSetError")
                    {
                        App_Code.NotificationService.SendNotification("PasswordSetError", "There was an error validating your account and you were redirected to our home page", "error", "3000");

                    }
                    else if (MSG == "VerifyError")
                    {
                        App_Code.NotificationService.SendNotification("VerifyError", "There was an error validating your account and you were redirected to our home page", "error", "3000");

                    }

                    else if (MSG == "AccountSuccess")
                    {
                        App_Code.NotificationService.SendNotification("AccountSuccess", "Your Account was created successfully, but you are not done yet. We ask that you confirm your email before we process your request. Please monitor your email for further instructions.", "success");

                    }
                    else if (MSG == "CheckOutError")
                    {
                        App_Code.NotificationService.SendNotification("CheckOutError", "There was an error in Checkout are you were sent to our homepage.  Please try again.", "alert");

                    }
                    else
                    {

                        App_Code.NotificationService.SendNotification("GeneralError", "A Proplem occurred and you were redirected to our homepage.  Please try again.", "alert");

                    }

                }

            
            //string MSG =Page.RouteData.Values["msg"] as string;

            //if (MSG != "")
            //{
            //    if (MSG == "PasswordSet")
            //    { 
            //        App_Code.NotificationService.SendNotification("PasswordSet","Your password has been set.  Please login to continue.","success","3000");
            //        //OpenSlider
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "LogIn", "OpenSlider('LogIn');", true);
                    
            //    }

            //    if (MSG == "PasswordSetError")
            //    {
            //        App_Code.NotificationService.SendNotification("PasswordSetError", "There was an error validating your account and you were redirected to our home page", "error", "3000");

            //    }
            //    if (MSG == "VerifyError")
            //    {
            //        App_Code.NotificationService.SendNotification("VerifyError", "There was an error validating your account and you were redirected to our home page", "error", "3000");

            //    }

            //    if (MSG == "AccountSuccess")
            //    {
            //        App_Code.NotificationService.SendNotification("AccountSuccess", "Your Account was created successfully, but you are not done yet. We ask that you confirm your email before we process your request. Please monitor your email for further instructions.", "success");

            //    }
                
            //}

            GetWordOfDay();
            GetArticleOfDay();

            }

        }

        protected void GetWordOfDay()
        {
            wordofday MyWord = new wordofday();

            if (object.Equals(Session["WordOfDay"], null))
            {
                int WODCount = App_Code.WordOfTheDayService.GetCount();

                int WODMax = WODCount + 1;

                int rand = App_Code.RALTService.GetRandomNumber(1, WODMax);

                MyWord = App_Code.WordOfTheDayService.GetObject(rand);

                Session["WordOfDay"] = MyWord;
            }
            else
            {
                MyWord = (wordofday)Session["WordOfDay"];
            }

            WordOfDay.Text = MyWord.spanish_word;
            PartOfSpeach.Text = MyWord.part_of_speech;
            EnglishTranslation.Text = MyWord.english_translation;
            SpanishSentence.Text = MyWord.spanish_sentence;
            EnglishSentence.Text = MyWord.english_sentence;
        }

        protected void GetArticleOfDay()
        {
            content MyArticle = new content();

            if (object.Equals(Session["ArticleOfDay"], null))
            {
                List<int> MyList = App_Code.ContentService.GetContentIDList("EN");

                int AODCount = MyList.Count();

                int AODMax = AODCount;

                int rand = App_Code.RALTService.GetRandomNumber(0, AODMax);

                int MyContentID = MyList[rand];

                MyArticle = App_Code.ContentService.GetRandomContent(MyContentID, "EN");

                Session["ArticleOfDay"] = MyArticle;
            }
            else
            {
                MyArticle = (content)Session["ArticleOfDay"];
            }

            contentmarkup LatestVersion = new contentmarkup();

            LatestVersion = MyArticle.contentmarkups.FirstOrDefault<contentmarkup>();

            ArticleDescription.Text = LatestVersion.description;
            ArticleImage.ImageUrl = MyArticle.image_url;
            ArticleTitle.Text = MyArticle.title.Replace("-", " ");
            ArticleLink.NavigateUrl = "/" + MyArticle.category + "/" + "EN" + "/" + MyArticle.title;
        }



        #region WebMethods

        [WebMethod]
        public static string CheckLanguage(string ContentId, string Language)
        {

            try
            {

                int LanguageCount = App_Code.ContentService.GetMarkupByLanguage(Convert.ToInt32(ContentId), Language).Count();

                if (LanguageCount >= 1)
                { return "True"; }
                else
                { return "False"; }
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        [WebMethod]
        public static string JoinEmailList(string FirstName, string LastName, string Email, int SpanishLevel)
        {

            try
            {
                //user EmailListUser = new user();

                //EmailListUser.account_status = "Email List";
                //EmailListUser.email = Email;
                //EmailListUser.first_name = FirstName;
                //EmailListUser.last_name = LastName;

                //UserService.SaveNewUser(EmailListUser);

                App_Code.RALTProfile MyProfile = new App_Code.RALTProfile();

                MyProfile = MyProfile.GetRALTProfile();

                MyProfile.Email = Email;

                MyProfile.FirstName = FirstName;
                MyProfile.Language = "EN";
                MyProfile.LastName = LastName;
                MyProfile.SpanishLevel = SpanishLevel;
                MyProfile.LastVisitedDate = DateTime.UtcNow;

                Guid UN;

                if (Guid.TryParse(MyProfile.UserName, out UN))
                    MyProfile.ProfileType = "EmailList";
                else
                    MyProfile.ProfileType = "Account";
       

                MyProfile.SaveRALTProfile(MyProfile);

                return "Success";
                
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [WebMethod]
        public static string DismissEmailList()
        {

            try
            {

                App_Code.RALTProfile MyProfile = new App_Code.RALTProfile();

                MyProfile = MyProfile.GetRALTProfile();

                MyProfile.ProfileType = "Dismiss";
                MyProfile.Language = "EN";
                MyProfile.LastVisitedDate = DateTime.UtcNow;

                MyProfile.SaveRALTProfile(MyProfile);

                return "Success";

            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        [WebMethod]
        public static string SelectPackage( string ItemName, string ItemPrice)
        {
            try
            {


            MembershipUser CurrentUser = Membership.GetUser();

            if (CurrentUser == null)
            {
               // App_Code.NotificationService.SendNotification("PricesLogIn", "Please log in to continue", "alert", "3000");

                return "NoUser";
            }

            else
            {

                string UserName = CurrentUser.UserName.ToString();

                user RALTUser = new user();
                RALTUser = UserService.GetUserByMemberId(Convert.ToInt32(CurrentUser.ProviderUserKey.ToString()));

                string QS = "?Item=" + ItemName + "&UserName=" + UserName + "&Price=" + ItemPrice + "&UserID=" + RALTUser.user_id;

                return QS;
            }

                }

            catch (Exception ex) 

            {throw ex;}
            
        }

        [WebMethod]
        public static string CheckUser()
        {

            MembershipUser CurrentUser = Membership.GetUser();

            if (CurrentUser == null)
            {
                return "false";
                
            }

            else
            {

                string UserName = CurrentUser.UserName.ToString();
                return UserName;

            }
            
        }

        

       

        //[WebMethod]
        //public static string Register(string UserName, string Password, string Email)
        //{
        //    string newuseroutput;

        //    try
        //    {
        //       // newuseroutput = App_Code.MemberShipService.CreateUser(UserName, Password, Email);
        //        return "d";
        //    }

        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }


        //}

        #endregion

    }
}