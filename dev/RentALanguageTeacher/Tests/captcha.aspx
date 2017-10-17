<%@ Page Title="Captcha" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="captcha.aspx.cs" Inherits="RentALanguageTeacher.captcha" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

        <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage"><a href="/Home"><img src="/Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                    <p></p>

                    <div>
                         <asp:Label Visible=false ID="lblResult" runat="server" />
    <recaptcha:RecaptchaControl
    ID="recaptcha"
    runat="server"
    PublicKey="6LcQUu0SAAAAAF5RU3hK3Zt5XABzaP8VbIhuhx1J"
    PrivateKey="6LcQUu0SAAAAABlUGn4BH7n_5afURsgO72z-bRgv"
    />

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                    </div>



                </div>

            </div>

        </div>

    </div>




</asp:Content>
