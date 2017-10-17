<%@ Page Title="An Error Occured" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="OtherErrors.aspx.cs" Inherits="RentALanguageTeacher.ErrorPages.OtherErrors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage"><a href="../Home"><img src="../Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                       <p>Please check out the 
    <a id="A2" href="~/Home" runat="server">Homepage</a> 
    or choose a different page from the menu.</p>
    <p>Rentalanguageteacher.com</p>


                </div>

            </div>

        </div>

    </div>
</asp:Content>
