<%@ Page Title="Status" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="StudentStatus.aspx.cs" Inherits="RentALanguageTeacher.Pages.Account.StudentStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script>

        function CompleteStep(i) {
            for (var n = 0; n <= i; n++) {
                $("ol#Progress li:eq(" + n + ")").removeClass("progtrckr-todo");
                $("ol#Progress li:eq(" + n + ")").addClass("progtrckr-done");
            }


        };

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">



                <div style="float:left;">

                <div class="ContentTitleImage"><a href="/Home"><img src="/Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                    <asp:Panel ID="PleasePayPanel" Visible="false" runat="server">

                        <div id="SavingsBox" class=" ui-state-error ui-corner-all" style="margin-top: 5px; padding: 0 .3em;">
		                    <p><span class="ui-icon ui-icon-info" style="float: left; margin-right: .2em;"></span>
                            <asp:Label ID="Savings"  runat="server" Text="Our records indicate you have not purchased a package yet. Please go to our <a href='/RALT/EN/rent' Style='color:#1ee0e3' Title='Rent'>Rent</a> page and select a package."></asp:Label></p>
	                    </div>

                    </asp:Panel>

                    

                     <p>Here you can find all your information about your teacher, and payments.  Please also review your <a href="/AccountSetup">Account Page</a></p>
                    <p>

                        <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>

                    </p>
                
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

        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Status</div></div>

        <div class="ContentSectionContent">
                        
            <div class="Content">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate> 

                        <fieldset class="validationGroup">
                            <legend>StudentStatus</legend>

                              <div class="formfield-container long">
                                <asp:Label ID="lblTeacher" CssClass="RALT required" runat="server"  Text="Teacher"></asp:Label><br />
                                <asp:TextBox ID="Teacher" cssclass="RALT long"  runat="server"></asp:TextBox>
                            </div>

                            <div class="formfield-container long">
                                <asp:Label ID="lblTeacherSkype" CssClass="RALT required" runat="server"  Text="Teacher SkypeID"></asp:Label><br />
                                <asp:TextBox ID="TeacherSkype" cssclass="RALT long"  runat="server"></asp:TextBox>
                            </div>

                            <div class="formfield-container long">
                                <asp:Label ID="Label3" CssClass="RALT required" runat="server" Text="Date of First Class"></asp:Label><br />
                                 <asp:TextBox ID="txtFirstClass" cssclass="RALT long "  runat="server"></asp:TextBox>
                                <asp:HiddenField ID="FirstClass" runat="server" />
                                     
                            </div>

                            <div class="formfield-container long">
                                <asp:Label ID="lblTeacherTime" CssClass="RALT required" runat="server" Text="First Class in Teacher's Time"></asp:Label><br />
                                 <asp:TextBox ID="txtTeacherTime" cssclass="RALT long validate[required]"  runat="server"></asp:TextBox>                                     
                            </div>

<%--                            <div class="formfield-container short">
                                <asp:Label ID="lblStatus" CssClass="RALT required" runat="server" AssociatedControlID="ddlStatus" Text="RALT Account Status"></asp:Label><br />
                                <asp:DropDownList ID="ddlStatus" CssClass="DDLshort ui-spinner ui-widget ui-widget-content ui-corner-all" runat="server"></asp:DropDownList>                                       
                            </div>--%>

<%--                            <div class="formfield-container">
                                  <asp:Label ID="Label2" CssClass="RALT " runat="server"  Text="Payment History"></asp:Label><br />
                                <asp:GridView ID="GridPayments" runat="server" AutoGenerateColumns="False" AllowSorting="false" 
                                    AllowPaging="True" PageSize="20" CssClass="mGrid" AlternatingRowStyle-CssClass="alt"
                                     OnPageIndexChanging="PageIndexChanging" ShowHeaderWhenEmpty="true" >
                                    <Columns>
                                         <asp:BoundField DataField="payment_id" HeaderText="Transaction ID" SortExpression="PaymentID" HeaderStyle-Width="200px" />
                                         <asp:BoundField DataField="hours" HeaderText="Hours" SortExpression="Hours"  HeaderStyle-Width="200px"/>
                                         <asp:BoundField DataField="transaction_date" HeaderText="Transaction Date (UTC)" SortExpression="TransactionDate"  HeaderStyle-Width="220px" />
                                     </Columns>
                                </asp:GridView>
                            </div>--%>

                            <div class="formfield-container">
                                <asp:GridView ID="GridPayments" runat="server" AutoGenerateColumns="False" AllowSorting="false" 
                                    AllowPaging="True" PageSize="20" CssClass="mGrid" AlternatingRowStyle-CssClass="alt"
                                    OnSorting="Sorting" OnPageIndexChanging="PageIndexChanging" ShowHeaderWhenEmpty="true" >
                                    <Columns>
                                         <asp:BoundField DataField="payment_id" HeaderText="Trans ID" SortExpression="PaymentID" HeaderStyle-Width="100px" />
                                         
                                        <asp:BoundField DataField="item_name" HeaderText="Item" SortExpression="Item"  HeaderStyle-Width="100px"/>
                                        <asp:BoundField DataField="update_user" HeaderText="Update User" SortExpression="UpdateUser"  HeaderStyle-Width="150px"/>
                                        <asp:BoundField DataField="transaction_id" HeaderText="Trans ID" SortExpression="TransID"  HeaderStyle-Width="200px"/>
                                         <asp:BoundField DataField="transaction_date" HeaderText="Transaction Date (UTC)" SortExpression="TransactionDate"  HeaderStyle-Width="220px" />
                                     </Columns>
                                </asp:GridView>
                            </div>

                            <div  class="formfield-container" style="width:100%;">
                                <asp:Label ID="Label1" CssClass="RALT" runat="server" AssociatedControlID="UserComments" Text="Please Leave your comments about your teacher, and experience with Rent A Language Teacher below."></asp:Label><br />
                                <asp:TextBox ID="UserComments" cssclass="RALT Shadow Corners" style="width:95%;height:100px;resize:none;" TextMode="MultiLine"   runat="server"></asp:TextBox>
                            </div>

                            <div style="float:left; width:100%"> 
                            
                                <div style="width:192px;" class="center">

                                    <div style="float:left;">
                        
                                        <asp:Button ID="Save" runat="server" Text="Save" CssClass="button causesValidation"  ValidationGroup="StudentStatus" OnClick="Save_Click" />
                    
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
