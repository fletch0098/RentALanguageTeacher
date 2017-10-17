using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using RentALanguageTeacher;
using System.Web.Profile;

namespace RentALanguageTeacher
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            ////BundleConfig.RegisterBundles(BundleTable.Bundles);
            ////RouteConfig.RegisterRoutes(RouteTable.Routes);
            registerroute(RouteTable.Routes);

            //Reister Routes in DB
            App_Code.RoutingService.RegisterRoutes();

            RegisterBundlers();

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        private static void RegisterBundlers() {


           //BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
           //         "~/Scripts/jquery-{version}.js"));

           BundleTable.Bundles.Add(new StyleBundle("~/Styles/css").Include(
                       "~/Styles/RALT.css"));

	}


        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void registerroute(RouteCollection routes)
        {
            routes.MapPageRoute(
                "Home-Route",
                "Home",
                "~/Default.aspx"
                );




            routes.MapPageRoute(
                "SecurityError-Route",
                "SecurityError",
                "~/errorpages/securityerrors.aspx"
                );


            routes.MapPageRoute(
            "HomeMsg-Route",
            "Home/{msg}",
            "~/Default.aspx"
            );
            routes.MapPageRoute(
                "AboutUs-Route",
                "About-Us",
                "~/Pages/AboutUs.aspx"
                );
            routes.MapPageRoute(
            "ContactUs-Route",
            "Contact-Us",
            "~/Pages/ContactUs.aspx"
            );
            routes.MapPageRoute(
            "FAQ-Route",
            "Frequently-Asked-Questions",
            "~/Pages/FAQ.aspx"
            );
            routes.MapPageRoute(
            "FAQQS-Route",
            "Frequently-Asked-Questions/{faq}",
            "~/Pages/FAQ.aspx"
            );

            routes.MapPageRoute(
            "Prices-Route",
            "Prices",
            "~/Payment/Prices.aspx"
            );
            routes.MapPageRoute(
            "PricesMSG-Route",
            "Prices/{msg}",
            "~/Payment/Prices.aspx"
            );

            routes.MapPageRoute(
          "Veryify-Route",
          "Verify/{Verify}",
          "~/Account/Verify.aspx"
          );

            //AccountSetUp
            routes.MapPageRoute(
            "AccountSetUp-Route",
            "AccountSetup",
            "~/Account/AccountSetUp.aspx"
            );

            routes.MapPageRoute(
            "AccountSetUpQS-Route",
            "AccountSetUps/{Account}",
            "~/Account/AccountSetup.aspx"
            );

            //CheckOut
            routes.MapPageRoute(
            "CheckOut-Route",
            "Checkout",
            "~/Payment/Checkout.aspx"
            );

            //Error404
            routes.MapPageRoute(
            "Error404-Route",
            "Error404",
            "~/ErrorPages/error404.aspx"
            );

            //ErrorOther
            routes.MapPageRoute(
            "OtherErrors-Route",
            "OtherError",
            "~/ErrorPages/OtherErrors.aspx"
            );

            routes.MapPageRoute(
        "OtherErrorsQS-Route",
        "OtherErrors/{QS}",
        "~/ErrorPages/OtherErrors.aspx"
        );

            //PasswordReset
            routes.MapPageRoute(
            "PasswordResetQS-Route",
            "PasswordReset/{Password}",
            "~/Account/PasswordReset.aspx"
            );

            //RetrieveAccount
            routes.MapPageRoute(
            "RetrieveAccount-Route",
            "RetrieveAccount",
            "~/Account/RetrieveAccount.aspx"
            );

            //TermsOfService
            routes.MapPageRoute(
            "TOS-Route",
            "Terms-Of-Service",
            "~/Pages/TermsOfService.aspx"
            );

            //PrivacyPolicy
            routes.MapPageRoute(
            "PP-Route",
            "Privacy-Policy",
            "~/Pages/PrivacyPolicy.aspx"
            );

            //AdministerStudent
            routes.MapPageRoute(
            "AdministerStudent-Route",
            "Administration/AdministerStudent/{Student}",
            "~/Pages/Administrator/AdministerStudent.aspx"
            );

            //AdministerStudent
            routes.MapPageRoute(
            "Pop-Route",
            "Play-Pop",
            "~/webwritable/pop/popfull.html"
            );

            //AdministerStudents
            routes.MapPageRoute(
            "AdministerStudents-Route",
            "Administration/ViewStudents",
            "~/Pages/Administrator/ViewStudents.aspx"
            );

            //StudentStatus
            routes.MapPageRoute(
            "StudentStatus-Route",
            "StudentStatus",
            "~/Pages/Account/StudentStatus.aspx"
            );

            //Articles 
            routes.MapPageRoute(
            "Articles-Route",
            "Article/{Name}",
            "~/Pages/Content/Articles.aspx"
            );

            //Articles 
            routes.MapPageRoute(
            "Articles2-Route",
            "Article",
            "~/Pages/Content/Articles.aspx"
            );

            //Content 
            routes.MapPageRoute(
            "Content-Route",
            "Content",
            "~/Pages/Content/Content.aspx"
            );

            //NewsContent 
            routes.MapPageRoute(
            "News-Route",
            "News/{Language}/{Title}",
            "~/Pages/Content/Content.aspx"
            );

            //Links 
            routes.MapPageRoute(
            "Links-Route",
            "Links/{Category}/{Language}",
            "~/Pages/Content/ContentLinks.aspx"
            );

            //SpanishContent 
            routes.MapPageRoute(
            "SpanishContent-Route",
            "SpanishContent/{Language}/{Title}",
            "~/Pages/Content/Content.aspx"
            );

            //ContentQS 
            routes.MapPageRoute(
            "contentQS-Route",
            "Content/{Name}",
            "~/Pages/Content/Content.aspx"
            );

            //Tips 
            routes.MapPageRoute(
            "Tips-Route",
            "Articles/Tips-For-Learning-Spanish-Over-Skype",
            "~/Pages/articles/SkypeTips.aspx"
            );

            //AdministerContent 
            routes.MapPageRoute(
            "AdminContent-Route",
            "Administration/AdministerContent",
            "~/Pages/Content/Administration/AdministerContent.aspx"
            );

            //AdministerMenu
            routes.MapPageRoute(
            "AdminMenu-Route",
            "Administration/AdministratorMenu",
            "~/Pages/Administrator/AdministratorMenu.aspx"
            );


           // routes.MapPageRoute("Route1", "Pages/{page}.aspx", "~/404.aspx");
            //routes.MapPageRoute("Route2", "Pages/{folder}/{page}.aspx", "~/404.aspx");
            //routes.MapPageRoute("Route3", "{page}", "~/404.aspx");

        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsSecureConnection.Equals(false) && HttpContext.Current.Request.IsLocal.Equals(false))
            {
                Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
            + HttpContext.Current.Request.RawUrl);
            }
        }

        void Profile_MigrateAnonymous(object sender, ProfileMigrateEventArgs e)
        {
        //    try
        //    {
        //        App_Code.RALTProfile annProfile = new App_Code.RALTProfile();

        //        annProfile = annProfile.GetRALTProfile(e.AnonymousID);

        //        if (annProfile.CopyFlag == false)
        //        {

        //            App_Code.RALTProfile MyProfile = new App_Code.RALTProfile();

        //            MyProfile = MyProfile.GetRALTProfile();

        //            //CopyData
        //            MyProfile.CopyFlag = true;
        //            MyProfile.Email = annProfile.Email;
        //            MyProfile.FirstName = annProfile.FirstName;
        //            MyProfile.Language = annProfile.Language;
        //            MyProfile.LastName = annProfile.LastName;
        //            MyProfile.LastUpdatedDate = annProfile.LastUpdatedDate;
        //            MyProfile.LastVisitedDate = annProfile.LastVisitedDate;
        //            MyProfile.ProfileType = "Account";
        //            MyProfile.SpanishLevel = annProfile.SpanishLevel;
        //            MyProfile.IsAnonymous = false;

        //            MyProfile.SaveRALTProfile(MyProfile);

        //            annProfile.CopyFlag = true;
        //            annProfile.ProfileType = "Account";
        //            annProfile.SaveRALTProfile(annProfile);

        //            // AnonymousIdentificationModule.ClearAnonymousIdentifier();
        //        }
        //    }
        //    catch { }

       }

    }
}
