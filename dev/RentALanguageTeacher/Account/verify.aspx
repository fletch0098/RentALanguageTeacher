<%@ Page Title="Verify Account" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="verify.aspx.cs" Inherits="RentALanguageTeacher.verify" %>
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

                <div class="ContentTitleImage"><img src="../Images/Step1.png" class="center" /></div>
                
                <div class="ContentTitletext">

                    <p>Thank you for your interest in connecting with our Spanish teachers from Guatemala. We have received your request and are currently looking for one that meets your requirements. You will receive an email from us within the next 48 hours with details of your Spanish teacher and lessons. You are one step away from connecting with a Spanish teacher!</p>
                    <p>While you wait you can take a look at our <a href="../Prices">Prices</a></p>
                
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




</asp:Content>
