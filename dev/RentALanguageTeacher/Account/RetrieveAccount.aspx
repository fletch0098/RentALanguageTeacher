<%@ Page Title="Retrieve Account" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="RetrieveAccount.aspx.cs" Inherits="RentALanguageTeacher.Account.RetrieveAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script>

        function pageLoad() {
            $(function () {

                BindValidation();
                BindRequestForm();

            });

        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage"><a href="/Home"><img src="../Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                     <p> RentaLanguageTeacher.com we take your privacy seriously.  To retrieve your account and password 
                            please type the email address your used to sign up below.  </p>
                </div>

            </div>

        </div>

    </div>


                   <div class="ContentSection">

                    <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Lookup your Account</div></div>

                    <div class="ContentSectionInput">

                        <div class="Content">

                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate> 
            

                            <fieldset class="validationGroup">
                                <legend>RetrieveAccount</legend>
                           

                        <div class="formfield-container long">
                            <asp:Label ID="lblEmail" CssClass="RALT required" runat="server" AssociatedControlID="Email" Text="Email"></asp:Label><br />
                            <asp:TextBox ID="Email" TextMode="Email" cssclass="RALT long validate[required, custom[email]]" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                                CssClass="field-validation-error" Text="*"  ErrorMessage="Email is required." ValidationGroup="RetrieveAccount" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" CssClass="field-validation-error" Text="*"  ErrorMessage="Please enter a Valid Email" 
                                ValidationGroup="RetrieveAccount"></asp:RegularExpressionValidator>
                        </div>
                                                                                
                        <div class="formfield-container long">
                           
                            <asp:Label ID="SearchStatus" runat="server" Text="Enter your email to the left and we will search out record for your account, and send you an email to reset your password"></asp:Label>
                        </div>
                          
                        <div style="float:left; width:100%"> 
                            
                            <div style="width:192px;" class="center">

                                <div style="float:left;">
                        
                                    <asp:Button ID="Send" runat="server" Text="Send Email" CssClass="button causesValidation"  ValidationGroup="RetrieveAccount" OnClick="Send_Click" />
                    
                                </div>
                        
                                <div style="float:left;">
                                    
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                              
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>

                                </div>

                            </div>
                        
                        </div>                                                      
 
                            </fieldset>
    </ContentTemplate></asp:UpdatePanel>  
                            
                        </div>
</div>
                </div>

</asp:Content>
