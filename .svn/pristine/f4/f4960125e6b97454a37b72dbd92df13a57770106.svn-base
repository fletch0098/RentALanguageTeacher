<%@ Page Title="Account Setup" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="AccountSetup.aspx.cs" Inherits="RentALanguageTeacher.Account.AccountSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

      <script>



          function GreyAccountInfo(i) {
              $("#AccountInfo").addClass("ContentSectionContent");
              $("#AccountInfo").removeClass("ContentSectionInput");
          };

          function Clear_Password(id) { try { document.getElementById(id).value = ''; } catch (ex) {/* do nothing */ } }

          function CompleteStep(i) {
              for (var n = 0; n <= i; n++) {
                  $("ol#Progress li:eq(" + n + ")").removeClass("progtrckr-todo");
                  $("ol#Progress li:eq(" + n + ")").addClass("progtrckr-done");
              }


          };

          function pageLoad() {
              $(function () {

                  BindValidation();
                  BindRequestForm();
                  SetTOSLink();

              });

          }

              jQuery.fn.terms_agree = function (content_area, selector) {
                  var body = $(body);
                  $(this).click(function () {
                      body.css("height", "auto").css("height", body.height()); // Prevent page flicker on slideup
                      //if ($(content_area).html() == "") {
                      //    $(content_area).load($(this).attr("href") + (selector ? " " + selector : ""));
                      //}
                      $(content_area).slideToggle();
                      return false;
                  });
              }
     

          function SetTOSLink() {
              $("#terms").terms_agree("#content-area", "#PartPage");
              $("#content-area").load($("#terms").attr("href") + ("#PartPage" ? " " + "#PartPage" : ""));


          }

          function SetTOS(sender) {
              if (sender.checked) {
                  $("#<%=HTOS.ClientID%>").val('true')
              }
              else {
                  $("#<%=HTOS.ClientID%>").val('false')
              }
          }

  </script>

    <style>

        #content-area {
    display:none;
    height:400px;
    overflow:auto;
    margin-bottom:1.5em;
    padding:10px;
    border:solid 1px #d7d7d7;
    color:#505050;
    background-color:#ffffff;
    font-size:0.5em;
}

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <div class="ContentSection">

        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>

        <div class="ContentSectionContent">

            <div class="Content">

                <div style="float:left;">

                <div class="ContentTitleImage"><img src="../Images/Step1.png" class="center" /></div>
                
                <div class="ContentTitletext">

                    <p>Thank you for your request for a Spanish teacher. To complete this request, please fill up the following account and profile information and click send. We will </p>
                
                </div>

                    </div>

                                <ol id="Progress" class="progtrckr" data-progtrckr-steps="5">
                                    <li class="progtrckr-todo">Request Made</li><!--
                                 --><li class="progtrckr-todo">Email Verified</li><!--
                                 --><li class="progtrckr-todo">Email Sent</li><!--
                                 --><li class="progtrckr-todo">Paid</li><!--
                                 --><li class="progtrckr-todo">First Class</li>
                                </ol>
            
            </div>

        </div>    

    </div>




    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate> 
    <fieldset class="validationGroup">
        <legend>NewMemberShip</legend>


 

    <div class="ContentSection">

        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Account Information</div></div>

        <div class="ContentSectionInput" id="AccountInfo">

            <div class="Content">

                <div class="ui-widget Hidden">
	<div class="ui-state-error ui-corner-all" style="padding: 0 .7em;">
		<p><span class="ui-icon ui-icon-alert" style="float: left; margin-right: .3em;"></span>
		<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="NewMemberShip" /></p>
	</div>
</div>
                

                <div class="ui-widget">
	                                                                <div class="ui-state-highlight ui-corner-all" style="margin-top: 5px; padding: 0 .7em;">
		                                                                <p><span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
		                                                                Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.</p>
	                                                                </div>
                                                                </div>

                <div class="formfield-container long">
                    <asp:Label ID="lblUserName" CssClass="RALT required" runat="server" AssociatedControlID="UserName" Text="UserName"></asp:Label><br />
                    <asp:TextBox ID="UserName"  cssclass="RALT long validate[required]" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                        CssClass="field-validation-error" Text="*"  ErrorMessage="UserName is required." ValidationGroup="NewMemberShip"></asp:RequiredFieldValidator>
                </div>
                

                <div class="formfield-container long">
                    <asp:Label ID="lblEmail" CssClass="RALT required" runat="server" AssociatedControlID="Email" Text="Email"></asp:Label><br />
                    <asp:TextBox ID="Email" TextMode="Email" cssclass="RALT long validate[required, custom[email]]" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                        CssClass="field-validation-error" Text="*"  ErrorMessage="Email is required." ValidationGroup="NewMemberShip" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" CssClass="field-validation-error" Text="*"  ErrorMessage="Please enter a Valid Email" 
                        ValidationGroup="NewMemberShip"></asp:RegularExpressionValidator>
                </div>

                <div class="formfield-container long ">
                    <asp:Label ID="lblPassword" CssClass="RALT required" runat="server" AssociatedControlID="Password" Text="Password"></asp:Label><br />
                    <asp:TextBox ID="Password" MaxLength="128" TextMode="Password" cssclass="RALT long validate[required, minSize[6]]"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password"
                        CssClass="field-validation-error" Text="*"  ErrorMessage="Password is required." ValidationGroup="NewMemberShip" />
                    <asp:CustomValidator ID="CustomValidator3" runat="server"  ControlToValidate="Password"
                        CssClass="field-validation-error" Text="*"  ErrorMessage="Password must be greater then 6" ValidationGroup="NewMemberShip" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
                </div>

                <div class="formfield-container long">
                    <asp:Label ID="lblConfirm" CssClass="RALT required" runat="server" AssociatedControlID="Confirm" Text="Confirm Password"></asp:Label><br />
                    <asp:TextBox ID="Confirm" MaxLength="128" TextMode="Password" cssclass="RALT long validate[required, equals[cpMainContent_Password]]" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Confirm"
                        CssClass="field-validation-error" Text="*"  ErrorMessage="Confirm Password is required." ValidationGroup="NewMemberShip" />
                    <asp:CompareValidator ID="CompareValidator1" CssClass="field-validation-error" ValidationGroup="NewMemberShip" 
                        ControlToValidate="Confirm" ControlToCompare="Password" Text="*" runat="server" ErrorMessage="CompareValidator">
                    </asp:CompareValidator>
                </div>

            </div>

        </div>    

    </div>

    <div class="ContentSection">

        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Profile Information</div></div>

        <div class="ContentSectionInput">

            <div class="Content">

                <div class="formfield-container long">
                            <asp:Label ID="lblFirstName" CssClass="RALT required" runat="server" AssociatedControlID="FirstName" Text="First Name"></asp:Label><br />
                            <asp:TextBox ID="FirstName" cssclass="RALT long validate[required]" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FirstName"
                                CssClass="field-validation-error" Text="*"  ErrorMessage="First Name is required." ValidationGroup="NewAccount" />
                        </div>
                                                                                
                        <div class="formfield-container long">
                            <asp:Label ID="lblLastName" CssClass="RALT required" runat="server" AssociatedControlID="LastName" Text="Last Name"></asp:Label><br />
                            <asp:TextBox ID="LastName" cssclass="RALT long validate[required]"  runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="LastName"
                                CssClass="field-validation-error" Text="*" ErrorMessage="Email is required." ValidationGroup="NewAccount"/>                                                    
                        </div>
                                                                                
                        <div class="formfield-container long">
                            <asp:Label ID="lblNationality" CssClass="RALT" runat="server" AssociatedControlID="Nationality" Text="Nationality"></asp:Label><br />
                            <asp:DropDownList ID="Nationality" CssClass="DDLlong ui-spinner ui-widget ui-widget-content ui-corner-all Shadow" runat="server"></asp:DropDownList>
                        </div>

                           <div class="formfield-container short">
                            <asp:Label ID="lblSkype" CssClass="RALT required" runat="server" AssociatedControlID="SkypeID" Text="SkypeID"></asp:Label><br />
                            <asp:TextBox ID="SkypeID" cssclass="RALT short validate[required]" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="SkypeID"
                                CssClass="field-validation-error" Text="*"  ErrorMessage="Skype ID is required." ValidationGroup="NewAccount" />
                        </div>       
                                                                  
                        <div class="formfield-container short">
                                <asp:Label ID="lblAge" CssClass="RALT" runat="server" AssociatedControlID="Age" Text="Age"></asp:Label><br />
                                <asp:DropDownList ID="Age" CssClass="DDLshort ui-spinner ui-widget ui-widget-content ui-corner-all" runat="server">
                                    <asp:ListItem Value="0">Select Age</asp:ListItem>
                                    <asp:ListItem Value="1">7-12</asp:ListItem>
                                    <asp:ListItem Value="2">13-18</asp:ListItem>
                                    <asp:ListItem Value="3">19-25</asp:ListItem>
                                    <asp:ListItem Value="4">26-35</asp:ListItem>
                                    <asp:ListItem Value="5">36-46</asp:ListItem>
                                    <asp:ListItem Value="6">47-57</asp:ListItem>
                                    <asp:ListItem Value="7">58+</asp:ListItem>
                                </asp:DropDownList>
                        </div>

                

                        <div class="formfield-container long">
                            <asp:Label ID="lblCountry" CssClass="RALT long required" runat="server" AssociatedControlID="Country" Text="Country"></asp:Label><br />
                            <asp:DropDownList ID="Country" CssClass="DDLlong ui-spinner ui-widget ui-widget-content ui-corner-all validate[funcCall[CheckDefault]]" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Country_SelectedIndexChanged" ></asp:DropDownList>
                             <asp:CustomValidator ID="CustomValidator1" ControlToValidate="Country" CssClass="field-validation-error" 
                                    Text="*" runat="server" ErrorMessage="Country is required." ValidationGroup="NewAccount" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>                                            
                        </div>

                        <div class="formfield-container long">
                            <asp:Label ID="lblTimeZone" CssClass="RALT long required" runat="server" AssociatedControlID="TimeZone" Text="Time Zone"></asp:Label><br />
                            <asp:DropDownList ID="TimeZone" CssClass="DDLlong ui-spinner ui-widget ui-widget-content ui-corner-all validate[funcCall[CheckTimeZone]]" runat="server"></asp:DropDownList>
                             <asp:CustomValidator ID="CustomValidator2" ControlToValidate="TimeZone" CssClass="field-validation-error" 
                                    Text="*" runat="server" ErrorMessage="Time Zone is required." ValidationGroup="NewAccount" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>                                  
                        
                        
                        </div>

             
                    <div  class="formfield-container" style="width:100%;">
                     <asp:Label ID="Label1" CssClass="RALT" runat="server" AssociatedControlID="SpecialRequests" Text="Specific Requests"></asp:Label><br />
                        <asp:Label ID="Label2" CssClass="RALT" runat="server" Text="e.g. A specific start time, alternating times and days, or specific requests in a teacher"></asp:Label>
                            <asp:TextBox ID="SpecialRequests" cssclass="RALT Shadow Corners" style="width:95%;height:100px;resize:none;" TextMode="MultiLine"   runat="server"></asp:TextBox>
                
                    
                    </div>

                   <div class="formfield-container" style="width:100%;">

                   
                        
                            <asp:Label ID="lblTOS" CssClass="RALT required" runat="server" Text=""><input type="checkbox" id="tos" name="tos" class="validate[required]" data-prompt-position="topRight:130" onchange="SetTOS(this)" data-errormessage="Please read and agree to our Terms and Conditions " />I agree to the </asp:Label><a href="/News/EN/Terms-Of-Service" id="terms">terms &amp; conditions</a>
                       <asp:HiddenField ID="HTOS" runat="server" />
                       <asp:CustomValidator ID="CustomValidator4" CssClass="field-validation-error" 
                                    Text="*" runat="server" ErrorMessage="You must agree to our Terms of Service" ValidationGroup="NewAccount" OnServerValidate="CustomValidator4_ServerValidate"></asp:CustomValidator>                                

                       
                        <div id="content-area"></div>
                 
   

                   </div>

                

                                        <div style="float:left; width:100%"> 
                            
                            <div style="width:192px;" class="center">

                                <div style="float:left;">
                        
                                    <asp:Button ID="Register" runat="server" Text="Save" CssClass="button causesValidation"  ValidationGroup="NewAccount" OnClick="Register_Click" />
                    
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
             

            </div>

        </div>    

    </div>




 


</fieldset>


            </ContentTemplate>
        </asp:UpdatePanel>

      <asp:HiddenField ID="SpanishLevel" runat="server" />
        <asp:HiddenField ID="FrequencyOfClasses" runat="server" />
        <asp:HiddenField ID="PeriodOfClasses" runat="server" />
        <asp:HiddenField ID="StartDate" runat="server" />
    <asp:HiddenField ID="Duration" runat="server" />


</asp:Content>
