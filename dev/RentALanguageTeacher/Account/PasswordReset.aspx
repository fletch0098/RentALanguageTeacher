<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="RentALanguageTeacher.Account.PasswordReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage"><a href="/Home"><img src="../Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                    <p>Thank you for taking the time to verify your identity.  Please set your new password below</p>

                </div>

            </div>

        </div>

    </div>    
    
    <div class="ContentSection">

        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Account Information</div></div>

        <div class="ContentSectionContent">

            <div class="Content">

                <div class="formfield-container long">
                    <asp:Label ID="lblUserName" CssClass="RALT" runat="server" AssociatedControlID="UserName" Text="UserName"></asp:Label><br />
                    <asp:TextBox ID="UserName" ToolTip="Your RALT USERNAME" cssclass="RALT long ui-state-disabled" Enabled="false" runat="server"></asp:TextBox>
                </div>
                                                                                
                <div class="formfield-container long">
                    <asp:Label ID="lblEmail" CssClass="RALT" runat="server" AssociatedControlID="Email" Text="Email"></asp:Label><br />
                    <asp:TextBox ID="Email" cssclass="RALT long ui-state-disabled" Enabled="false" runat="server"></asp:TextBox>                                                  
                </div>

            </div>

        </div>

    </div>

    <div class="ContentSection">

        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">New Password</div></div>

        <div class="ContentSectionInput">
                        
            <div class="Content">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate> 

                        <fieldset class="validationGroup">
                            <legend>NewPassword</legend>
                                
                                <div class="formfield-container long ">
                                    <asp:Label ID="lblPassword" CssClass="RALT required" runat="server" AssociatedControlID="NewPassword" Text="Password"></asp:Label><br />
                                    <asp:TextBox ID="NewPassword" ClientIDMode="Inherit" MaxLength="128" TextMode="Password" cssclass="RALT long validate[required, minSize[6]]"  runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="NewPassword"
                                        CssClass="field-validation-error" Text="*"  ErrorMessage="Password is required." ValidationGroup="NewPassword" />
                                    <asp:CustomValidator ID="CustomValidator3" runat="server"  ControlToValidate="NewPassword"
                                        CssClass="field-validation-error" Text="*"  ErrorMessage="Password must be greater then 6" ValidationGroup="NewPassword" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
                                </div>

                                <div class="formfield-container long">
                                    <asp:Label ID="lblConfirm" CssClass="RALT required" runat="server" AssociatedControlID="Confirm" Text="Confirm Password"></asp:Label><br />
                                    <asp:TextBox ID="Confirm"  MaxLength="128" TextMode="Password" cssclass="RALT long validate[required, equals[cpMainContent_NewPassword]]" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Confirm"
                                        CssClass="field-validation-error" Text="*"  ErrorMessage="Confirm Password is required." ValidationGroup="NewPassword" />
                                    <asp:CompareValidator ID="CompareValidator1" CssClass="field-validation-error" ValidationGroup="NewPassword" 
                                        ControlToValidate="Confirm" ControlToCompare="NewPassword" Text="*" runat="server" ErrorMessage="CompareValidator">
                                    </asp:CompareValidator>
                                </div>

                        <div style="float:left; width:100%"> 
                            
                            <div style="width:192px;" class="center">

                                <div style="float:left;">
                        
                                    <asp:Button ID="ResetPassword" runat="server" Text="Set Password" CssClass="button causesValidation"  ValidationGroup="NewPassword" OnClick="ResetPassword_Click" />
                    
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
                
                    </ContentTemplate>

                </asp:UpdatePanel>                                                   
        
            </div>
                    
        </div>
    
    </div>

</asp:Content>
