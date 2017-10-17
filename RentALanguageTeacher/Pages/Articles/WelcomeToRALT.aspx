<%@ Page Title="Welcome-to-Rent-A-Language-Teacher" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="WelcomeToRALT.aspx.cs" Inherits="RentALanguageTeacher.Pages.Articles.WelcomeToRALT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage"><a href="/Home"><img src="/Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                    <p>Welcome to RentaLanguageTeacher.com. We are your</p>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
