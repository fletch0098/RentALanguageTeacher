<%@ Page Title="Prices" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="Prices.aspx.cs" Inherits="RentALanguageTeacher.Prices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


    <script src="../Scripts/jquery.myplugin.js"></script>
    <script src="../Scripts/PricesRadio.js"></script>
      <script>


          function UpdateDescription() {
              if ($('#radio :radio:checked').val() == 1) {
                  $("#<%=ItemSelected.ClientID%>").val('1')
                  $("#<%=Savings.ClientID%>").html('$100.00')
                  $("#<%=SavingsTitle.ClientID%>").html('Low Price!')
                  $("#<%=SavingsTitle.ClientID%>").addClass("Hidden")
                  $("#SavingsBox").addClass("Hidden")
                  $('#ItemDescription').val('10 hours: Get an introduction to Spanish or refresh your Spanish for only USD 100!')

    }
    if ($('#radio :radio:checked').val() == 2) {
        $("#<%=ItemSelected.ClientID%>").val('2')
        $("#<%=Savings.ClientID%>").html('$25.00')
        $("#<%=SavingsTitle.ClientID%>").removeClass("Hidden")
        $("#SavingsBox").removeClass("Hidden")
        $("#<%=SavingsTitle.ClientID%>").html('Savings!')
        $('#ItemDescription').val('25 hours: Start speaking conversational Spanish or use this package to move from a beginner to intermediate level, or intermediate to advanced level. At USD 9/hour, you save USD 25!')
    }
    if ($('#radio :radio:checked').val() == 3) {
        $("#<%=ItemSelected.ClientID%>").val('3')
        $("#<%=Savings.ClientID%>").html('$100.00')
        $("#<%=SavingsTitle.ClientID%>").html('Savings!')
        $("#<%=SavingsTitle.ClientID%>").removeClass("Hidden")
        $("#SavingsBox").removeClass("Hidden")
        $('#ItemDescription').val('50 hours: Enroll in an intensive Spanish course for USD 8/hour. Improve your Spanish by leaps and bounds and save USD 100!')
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

                <div class="ContentTitleImage"><a href="/Home"><img src="../Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                    <p>At only USD 8-10 an hour, it is now affordable to 
                        have your own private Spanish teacher. Start with one of the courses we offer. 
                        Please select one of the following packages (10 hours, 25 hours, and 50 hours) 
                        and you will be brought to our payment page. *Please note that you have to be 
                        logged in to proceed to payment.  </p>
                       
                
                </div>

                    </div>

            
            </div>

        </div>    

    </div>


       
        
        


        <div class="ContentSection">

        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Choose your package</div></div>

        <div class="ContentSectionInput">
            <div class="Content">

                

            <fieldset class="validationGroup">

                                                                    <legend></legend>


                <div style="width:499px;" class="center">
            <img src="../Images/Prices.png" />
        </div>

            <div class="formfield-container" style="width:125px;">

                <div id="radio">
                    <input type="radio" id="radio1" name="radio" value="1" checked="checked" onchange="UpdateDescription()" class="validate[groupRequired[payments]]"/><label title="Low Price - $100.00" for="radio1">10 Hours</label>
                    <input type="radio" id="radio2" name="radio" value="2" onchange="UpdateDescription()" class="validate[groupRequired[payments]]"/><label for="radio2" title="Savings - $25.00">25 Hours</label>
                    <input type="radio" id="radio3" name="radio" value="3" onchange="UpdateDescription()" class="validate[groupRequired[payments]]"/><label for="radio3" title="Savings - $100.00">50 Hours</label>
                </div>

            </div>

                <div class="formfield-container" style="width:100px;margin-right:20px;">
                   
                     <asp:Label ID="SavingsTitle" CssClass="highlight Hidden" runat="server" Text="Low Price!"></asp:Label>
                    <div id="SavingsBox" class="ui-state-highlight ui-corner-all Hidden" style="margin-top: 5px; padding: 0 .3em;">
		                                                                <p><span class="ui-icon ui-icon-info" style="float: left; margin-right: .2em;"></span>
                                                                            <asp:Label ID="Savings" runat="server" Text="$100.00"></asp:Label></p>
	                                                                </div>

                </div>

<%--                <div class="formfield-container short">
                    

                </div>--%>
               

            <div class="formfield-container">

                <asp:HiddenField ID="ItemSelected"  runat="server" />
               

                <textarea id="ItemDescription" class="ui-state-disabled RALT" readonly="readonly"  cols="40" rows="4" style="width: 370px; height: 90px; resize:none; ">10 hours: Get an introduction to Spanish or refresh your Spanish for only USD 100!</textarea>

            </div>
                <asp:UpdatePanel ID="UpdatePanel1"  runat="server" UpdateMode="Conditional">
                    <ContentTemplate> 
                                        <div style="float:left; width:100%"> 
                            
                            <div style="width:192px;" class="center">

                                <div style="float:left;">
                        
                                   <asp:Button ID="Button2" runat="server" Text="Select" CssClass="button causesValidation"  OnClick="ViewCart_Click" />
                    
                                </div>
                        
                                <div style="float:left;">
                                    
<%--                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                          
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>--%>

                                </div>

                            </div>
                        
                        </div>  

                 </ContentTemplate>
                    </asp:UpdatePanel>

                <%--<div>
<div style="width:150px;" class="center"><asp:Button ID="Button2" runat="server" Text="Select" CssClass="button causesValidation"  OnClick="ViewCart_Click" /></div>
        </div> --%> </fieldset> 
                         </div>
            </div>
    </div>


    
    <%--<div class="InputSection">

        <div class="InputSectionHeader"><div class="InputSectionHeaderText">Our Prices</div></div>

        <div class="InputSectionContent">

            <fieldset class="validationGroup">

                                                                    <legend></legend>

            <div class="formfield-container long">

                <div id="radio">
                    <input type="radio" id="radio1" name="radio" value="1" onchange="UpdateDescription()"/><label for="radio1">10 Hours</label>
                    <input type="radio" id="radio2" name="radio" value="2" onchange="UpdateDescription()"/><label for="radio2">25 Hours</label>
                    <input type="radio" id="radio3" name="radio" value="3" onchange="UpdateDescription()"/><label for="radio3">50 Hours</label>
                </div>

            </div>
                    
            <div class="formfield-container long">

                <asp:HiddenField ID="ItemSelected"  runat="server" />
                <asp:TextBox ID="TextBox1" runat="server" CssClass="validate[required]"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ValidationGroup="Prices" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>

                <textarea id="ItemDescription" class="ui-state-disabled RALT" readonly="readonly"  cols="40" rows="3" style="width: 326px; height: 65px; resize:none; ">Our 10 Hour package is great to get you started, and at $10.00 USD an hour who can complain?</textarea>

            </div>

            <div><div style="width:150px;" class="center">
                        <asp:Button ID="ViewCart" runat="server" Text="Select" CssClass="button causesValidation" ValidationGroup="Prices" OnClick="ViewCart_Click" CausesValidation="False" />
                    </div></div>

                </fieldset>

            <fieldset class="validationGroup">
                <legend></legend>
                <asp:Button ID="Button1" runat="server" Text="Select" CssClass="button causesValidation"  OnClick="ViewCart_Click" />
                </fieldset>

            </div>

        </div>--%>

</asp:Content>

<%--                        <script src="../Scripts/paypal-button.min.js?merchant=J9T4RVL3P6SRE" 
    data-button="buynow" 
    data-name="Basic Package - 10 Hours" 
    data-quantity="1" 
    data-amount="100.00" 
    data-currency="USD" 
    data-shipping="0.00" 
    data-tax="0.00" 
    data-callback="http://www.Rentalanguageteacher.com/payment/confirmation.aspx"
></script>--%>

<%--                        <script src="../Scripts/paypal-button.min.js?merchant=payment@rentalanguageteacher.com" 
    data-button="buynow"
    data-custom="123"
    data-id="69"
    data-invoice="TestInvoice1"
    data-on0="UserId"                        
    data-os0="brian"                          
    data-name="TestHours" 
    data-quantity="1" 
    data-amount="100" 
    data-currency="USD" 
    data-shipping="0" 
    data-tax="0" 
    data-callback="http://www.rentalanguageteacher.com" 
    data-env="sandbox"
></script>--%>