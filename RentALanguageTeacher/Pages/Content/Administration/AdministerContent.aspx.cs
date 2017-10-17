using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Routing;

namespace RentALanguageTeacher.Pages.Administrator
{
    public partial class AdministerContent : System.Web.UI.Page
    {

        string Sort_Direction = "Category ASC";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Only on initial Load
            if (!Page.IsPostBack)
            {

                //Bind the DDL's
                BindCategory();
                BindLanguages("EN");

                //Store Content sortexpression
                ViewState["SortExpr"] = Sort_Direction;

                //BindContentGrid
                BindContentGrid();

                //Get the logged in User if any
                MembershipUser LoggedInMembershipUser;
                LoggedInMembershipUser = Membership.GetUser();

                //Check if there is a logged in User
                if (LoggedInMembershipUser != null)
                {
                    //RALT Data

                    // ToInt32 can throw FormatException or OverflowException. 
                    int UserId = -1;

                    //Get the RALT data from membership accountID
                    UserId = Convert.ToInt32(LoggedInMembershipUser.ProviderUserKey.ToString());
                    user UserData = UserService.GetUserByMemberId(UserId);

                    //Update data
                    txtAuthor.Text = UserData.first_name + " " + UserData.last_name;
                    HFAuthorEmail.Value = "mailto:" + UserData.email;

                }

                txtPublishDate.Text = DateTime.Now.ToLongDateString();

                txtContentDescription.Text = "Type your description here...";
                txtContentTitle.Text = "My-Title";
                txtPictureURL.Text = "/Images/LogoBlack.png";

            }
            
        }

        protected void BindLanguages(string Language)
        {
            try
            {
                //Get List From DB
                List<contentlanguage> Languages = App_Code.ContentService.GetContentLanguageList();

                //Create an option to Add Language
                contentlanguage NewLanguage = new contentlanguage();
                NewLanguage.language = "Add Language";
                Languages.Add(NewLanguage);

                //Databind
                ddlContentLanguage.DataSource = Languages;
                ddlContentLanguage.DataTextField = "language";
                ddlContentLanguage.DataValueField = "language";
                ddlContentLanguage.DataBind();

                //Set Default
                ddlContentLanguage.SelectedValue = Language;
            }

            catch (Exception ex)
            {

                //Error
                App_Code.NotificationService.SendNotification("BindLanguageError", ex.Message, "error");

            }
        }

        protected void BindCategory()
        {
            try
            {
                //Create blank list
                List<App_Code.ContentCategory> list = new List<App_Code.ContentCategory>();

                //Fill list
                list = App_Code.ContentService.GetObjects();

                //Create Default Value and option to add new
                App_Code.ContentCategory Default = new App_Code.ContentCategory();
                App_Code.ContentCategory NewCategory = new App_Code.ContentCategory();

                Default.Category = "Select Category";
                NewCategory.Category = "Add Category";

                list.Add(Default);
                list.Add(NewCategory);

                //Bind DDL
                ddlContentCategory.DataSource = list;
                ddlContentCategory.DataTextField = "Category";
                ddlContentCategory.DataValueField = "Category";
                ddlContentCategory.DataBind();

                ddlContentCategory.SelectedValue = "Select Category";
            }

            catch (Exception ex)
            {

                //Error
                App_Code.NotificationService.SendNotification("BindLanguageError", ex.Message, "error");

            }


        }

        protected void btnNewContent_Click(object sender, EventArgs e)
        {
            //Server Validate
            Page.Validate("NewContent");

            //If valid
            if (Page.IsValid)
            {

                try
                {
                    //Define new Content
                    content MyContent = new content();

                    //Retrieve ContentFormData
                    string ContentTitle = txtContentTitle.Text;
                    string ContentCategory = ddlContentCategory.SelectedValue;
                    string contentLanguage = ddlContentLanguage.SelectedValue;
                    string ContentDescription;
                    string ImageURL = txtPictureURL.Text;

                    //Set Description if null
                    if (!string.IsNullOrEmpty(txtContentDescription.Text))
                    { 
                        ContentDescription = txtContentDescription.Text; 
                    }
                    
                    else
                    { 
                        ContentDescription = "Your Description Here"; 
                    }

                    //HTML Content Bubbles
                    //string Header = "<div class=\"ContentSection\"><div class=\"ContentSectionHeader\"><div class=\"ContentSectionHeaderText\">" + ContentTitle + "</div></div><div class=\"ContentSectionContent\"><div class=\"Content\"><div style=\"float:left;\"><div class=\"ContentTitleImage\"><a href=\"/" + ContentCategory + "/"+ contentLanguage +"/" + ContentTitle + "\"><img src=\"/Images/LogoBlack.png\" class=\"center\"></a></div><div class=\"ContentTitletext\"><p>" + ContentDescription + "</p></div></div></div></div></div>";
                    string Content = "<div class=\"ContentSection\"><div class=\"ContentSectionHeader\"><div class=\"ContentSectionHeaderText\">" + "Header" + "</div></div><div class=\"ContentSectionContent\"><div class=\"Content\"><p>Content Here</p></div></div></div>";

                    //Get the logged in User if any
                    MembershipUser LoggedInMembershipUser;
                    LoggedInMembershipUser = Membership.GetUser();

                    //Check if there is a logged in User
                    if (LoggedInMembershipUser != null)
                    {

                        //RALT Data

                        // ToInt32 can throw FormatException or OverflowException. 
                        int UserId = -1;

                        //Get the RALT data from membership accountID
                        UserId = Convert.ToInt32(LoggedInMembershipUser.ProviderUserKey.ToString());
                        user UserData = UserService.GetUserByMemberId(UserId);

                        //Update data
                        MyContent.author_user_id = UserData.user_id;

                    }

                    //Update Data
                    MyContent.title = ContentTitle;
                    MyContent.category = ContentCategory;
    
                  
                    MyContent.image_url = ImageURL;

                    //Save Content
                    int MyContentID = App_Code.ContentService.SaveObject(MyContent);

                    contentmarkup MyMarkup = new contentmarkup();

                    MyMarkup.content_id = MyContentID;
                    MyMarkup.language = contentLanguage;
                    MyMarkup.description = ContentDescription;
                   // MyMarkup.header_markup = Header;
                    MyMarkup.markup = Content;

                    App_Code.ContentService.SaveContent(MyMarkup);

                    Response.Redirect("/" + ContentCategory + "/"+contentLanguage+"/" + ContentTitle);
                }



                catch (Exception ex)
                {

                    //Loading Content Error
                    App_Code.NotificationService.SendNotification("ContentSaveError", ex.Message, "error");

                }
            }
        }

        protected void btnNewCategory_Click(object sender, EventArgs e)
        {

            try
            {

                //Create and Save new Category
                contentcategory NewCategory = new contentcategory();
                NewCategory.category = txtNewCategory.Text.Trim().Replace(" ", "");
                NewCategory.image = txtCategoryImage.Text.Trim();
                NewCategory.description = txtCategoryDescription.Text.Trim();
                App_Code.ContentService.SaveCategory(NewCategory);

                //Clear form
                txtNewCategory.Text = "";
                txtCategoryDescription.Text = "";
                txtCategoryImage.Text = "";

                //Save the new route to the DB
                route_table NewRoute = new route_table();
                NewRoute.rout_name = NewCategory.category;
                NewRoute.rout_url = "" + NewCategory.category + "/{Language}/{Title}";
                NewRoute.physical_file = "~/Pages/Content/Content.aspx";
                App_Code.RoutingService.SaveObject(NewRoute);

                //Register the route for this run
                RouteTable.Routes.MapPageRoute(""+NewCategory.category+"-Route", ""+NewCategory.category+"/{Language}/{Title}", "~/Pages/Content/Content.aspx");

                //Rebind the Category with new route
                BindCategory();

                //Success Notification
                App_Code.NotificationService.SendNotification("NewCategorySuccess", "Category Added Successfully", "success", "4000");

            }

            catch (Exception ex)
            {

                //Error
                App_Code.NotificationService.SendNotification("NewCategory", ex.Message, "error");

            }

        }

        protected void btnNewLanguage_Click(object sender, EventArgs e)
        {
            try
            {

                contentlanguage NewLanguage = new contentlanguage();
                NewLanguage.language = txtNewLanguage.Text.Trim().Replace(" ", "");

                App_Code.ContentService.SaveObject(NewLanguage);

                BindLanguages(NewLanguage.language);

                App_Code.NotificationService.SendNotification("NewLanguageSuccess", "Language Added Successfully", "success", "4000");

                txtNewLanguage.Text = "";

            }

            catch (Exception ex)
            {

                //Error
                App_Code.NotificationService.SendNotification("NewLanguage", ex.Message, "error");

            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlContentCategory.SelectedValue == "Select Category" || ddlContentCategory.SelectedValue == "Add Category")
            {
                args.IsValid = false;
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlContentLanguage.SelectedValue == "Add Language")
            {
                args.IsValid = false;
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void BindContentGrid()
        {


            List<App_Code.ContentView> ContentList = new List<App_Code.ContentView>();

            if (GridContent.DataSource == null)
            {
                ContentList = App_Code.ContentService.ListContent();
            }
            else
            {
                ContentList = (List<App_Code.ContentView>)GridContent.DataSource;
            }



            string[] SortExp = ViewState["SortExpr"].ToString().Split(' ');

            if (SortExp[0] == "Category")
            {

                if (SortExp[1] == "ASC")
                {
                    App_Code.ContentView.SortOnCategoryASC SOC = new App_Code.ContentView.SortOnCategoryASC();
                    ContentList.Sort(SOC);
                }
                else
                {
                    App_Code.ContentView.SortOnCategoryDSC SOC = new App_Code.ContentView.SortOnCategoryDSC();
                    ContentList.Sort(SOC);
                }

            }
            else if (SortExp[0] == "Title")
            {

                if (SortExp[1] == "ASC")
                {
                    App_Code.ContentView.SortOnLanguagesASC SOC = new App_Code.ContentView.SortOnLanguagesASC();
                    ContentList.Sort(SOC);
                }
                else
                {
                    App_Code.ContentView.SortOnTitleDSC SOC = new App_Code.ContentView.SortOnTitleDSC();
                    ContentList.Sort(SOC);
                }

            }
            else if (SortExp[0] == "Author")
            {

                if (SortExp[1] == "ASC")
                {
                    App_Code.ContentView.SortOnAuthorASC SOC = new App_Code.ContentView.SortOnAuthorASC();
                    ContentList.Sort(SOC);
                }
                else
                {
                    App_Code.ContentView.SortOnAuthorDSC SOC = new App_Code.ContentView.SortOnAuthorDSC();
                    ContentList.Sort(SOC);
                }

            }
            else if (SortExp[0] == "ModDate")
            {

                if (SortExp[1] == "ASC")
                {
                    App_Code.ContentView.SortOnDateASC SOC = new App_Code.ContentView.SortOnDateASC();
                    ContentList.Sort(SOC);
                }
                else
                {
                    App_Code.ContentView.SortOnDateDSC SOC = new App_Code.ContentView.SortOnDateDSC();
                    ContentList.Sort(SOC);
                }

            }
            else if (SortExp[0] == "Versions")
            {

                if (SortExp[1] == "ASC")
                {
                    App_Code.ContentView.SortOnVersionASC SOC = new App_Code.ContentView.SortOnVersionASC();
                    ContentList.Sort(SOC);
                }
                else
                {
                    App_Code.ContentView.SortOnVersionsDSC SOC = new App_Code.ContentView.SortOnVersionsDSC();
                    ContentList.Sort(SOC);
                }

            }
            else if (SortExp[0] == "Languages")
            {

                if (SortExp[1] == "ASC")
                {
                    App_Code.ContentView.SortOnLanguagesASC SOC = new App_Code.ContentView.SortOnLanguagesASC();
                    ContentList.Sort(SOC);
                }
                else
                {
                    App_Code.ContentView.SortOnLanguagesDSC SOC = new App_Code.ContentView.SortOnLanguagesDSC();
                    ContentList.Sort(SOC);
                }

            }
            

            GridContent.DataSource = ContentList;
            GridContent.DataBind();

        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridContent.PageIndex = e.NewPageIndex;
            BindContentGrid();
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

            BindContentGrid();
        }

        protected void myGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink myHL = (HyperLink)e.Row.FindControl("EditHyperLink1");
                App_Code.ContentView MyRow = (App_Code.ContentView)e.Row.DataItem;
                myHL.NavigateUrl = "/" + MyRow.Category + "/"+MyRow.InitialLanguage+"/" + MyRow.Title;
                myHL.Text = MyRow.Title;

                string item = MyRow.Title;
                foreach (Image button in e.Row.Cells[4].Controls.OfType<Image>())
                {
                  
                    
                        button.Attributes["onclick"] = "if(!confirm('Are you sure you want to delete " + item + " and all its versions and languages? There could be serious consequences deleting content, including breaking links on this website and external.  Use Cautiously!')){ return false; };";
                    
                }

            }
        }

        protected void GridContent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Row = e.RowIndex;
            string Title = (string)e.Keys[0];

            content MyContent = App_Code.ContentService.DeleteObjectByTitle(Title);

            BindContentGrid();
        }

    }
}