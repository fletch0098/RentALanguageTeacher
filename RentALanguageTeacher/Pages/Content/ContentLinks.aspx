<%@ Page Title="Content Links" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="ContentLinks.aspx.cs" Inherits="RentALanguageTeacher.Pages.Content.ContentLinks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style>





    </style>

    <script>
        //$(".BubbleLink").hover(
        //  function () {
        //      $(".FullStory").removeClass("FullStoryLink");
        //      $(".FullStory").addClass("FullStoryHover");
        //  }, function () {
        //      $(".FullStory").removeClass("FullStoryHover");
        //      $(".FullStory").addClass("FullStoryLink");
        //  }
        //);

</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

        <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage"><a href="/Home"><asp:Image ID="CategoryImage" runat="server" CssClass="center" /></a></div>
                
                <div class="ContentTitletext">

                    <p>                    <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label></p>

                </div>

            </div>

        </div>

    </div>
    <div id="small-print">
    <div id="Links" runat="server"></div>
        </div>
</asp:Content>
