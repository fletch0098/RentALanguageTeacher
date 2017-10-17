<%@ Page Title="Contact-Us" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="RentALanguageTeacher.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script>

       // Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(BindValidation())

        function pageLoad() {
            $(function () {

                BindValidation();
                BindRequestForm();

            });

        }

        //function endRequest(sender, args) {
        //    //Do all what you want to do in jQuery ready function
        //    BindValidation();
        //}

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage"><a href="/Home"><img src="/Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                    <p>¿Quisiera contactarnos? Have a query or a specific request? 
                    Use the following form to contact us. We will get back to you as soon as we can.</p>
                    <div style="float:right; margin-top:20px;">Email: <a href="mailto:info@rentalanguageteacher.com">info@rentalanguageteacher.com</a> </div>

                </div>

            </div>

        </div>

    </div>

    <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Contact Us Form</div></div>
        
        <div class="ContentSectionInput">

            <div class="Content">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate> 

                        <fieldset class="validationGroup">
                            <legend>ContactUs</legend>
                            
                            <div class="formfield-container long">
                                <asp:Label ID="lblName" CssClass="RALT required" runat="server" AssociatedControlID="Name" Text="Name"></asp:Label><br />
                                <asp:TextBox ID="Name" cssclass="RALT long validate[required]"  runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Name"
                                    CssClass="field-validation-error" Text="*" ErrorMessage="Name is required." ValidationGroup="ContactUs"/>                                                    
                            </div>

                            <div class="formfield-container long">
                                <asp:Label ID="lblEmail" CssClass="RALT required" runat="server" AssociatedControlID="Email" Text="Email"></asp:Label><br />
                                <asp:TextBox ID="Email" TextMode="Email" cssclass="RALT long validate[required, custom[email]]" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" Text="*"  ErrorMessage="Email is required." ValidationGroup="ContactUs" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" CssClass="field-validation-error" Text="*"  ErrorMessage="Please enter a Valid Email" 
                                    ValidationGroup="ContactUs"></asp:RegularExpressionValidator>
                            </div>

                            <div class="formfield-container long">
                                <asp:Label ID="lblCountry" CssClass="RALT required" runat="server" AssociatedControlID="Country" Text="Country"></asp:Label><br />
                                 <asp:dropdownlist ID="Country" cssclass="DDLlong ui-spinner ui-widget ui-widget-content ui-corner-all validate[funcCall[CheckDefault]]" 
                                     runat="server" autopostback="false"></asp:dropdownlist>
                                <asp:CustomValidator ID="CustomValidator1" ControlToValidate="Country" CssClass="field-validation-error" 
                                    Text="*" runat="server" ErrorMessage="Country is required." ValidationGroup="ContactUs" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>                                  
                            </div>

                            <div class="formfield-container long blank">

                            </div>

                            <div class="formfield-container" style="width:100%;">
                                <asp:Label ID="lblMessage" CssClass="RALT required" runat="server" AssociatedControlID="Message" Text="Message"></asp:Label><br />
                                <asp:TextBox ID="Message" cssclass="RALT Shadow Corners validate[required]" style="width:95%;height:100px;resize:none;" 
                                    TextMode="MultiLine"   runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Message"
                                    CssClass="field-validation-error" Text="*" ErrorMessage="Message is required." ValidationGroup="ContactUs"/>                                                    
                            </div>

                            <div style="float:left; width:100%"> 
                            
                                    <div style="width:192px;" class="center">

                                        <div style="float:left;">
                        
                                            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="button causesValidation"  ValidationGroup="ContactUs" OnClick="btnSend_Click" />
                    
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
