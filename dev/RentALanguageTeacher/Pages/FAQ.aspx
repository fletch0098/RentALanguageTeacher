<%@ Page Title="Frequently-Asked-Questions" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="RentALanguageTeacher.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

      <script>
          $(function () {
              $("#accordion").accordion();
          });
  </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <div class="ContentSection">
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        <div class="ContentSectionContent">

            <div class="Content">
                       
                <div class="ContentTitleImage"><a href="/Home"><img src="/Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                    <p>Before taking the leap into learning Spanish over Skype with us, I'm sure you 
have millions of queries. We hope that these FAQs answer some of your questions. 
If not, <a href="/Contact-Us">Contact Us</a> and we will get back to you as 
soon as we can.</p>

                    

                </div>

   

       

</div></div></div>

        <div class="ContentSection">
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Frequently Asked Questions</div></div>
        <div class="ContentSectionContent">

            <div class="Content">

    <div id="accordion">
  <h3>1. What kind of teaching experience do your Spanish teachers have?</h3>
  <div>
    <p>
   The Spanish teachers teaching on this site have been recommended to us by word-of-mouth. As we have been living here for some time, we get to hear about great Spanish teachers from satisfied Spanish students. This is the best reference one can get. Our teachers have been teaching for between 5-20 years. Some teach in Spanish schools while others teach privately.
    </p>
  </div>
  <h3>2. I am a total beginner. Will it be hard to start learning over Skype?</h3>
  <div>
    <p>
    The internet is arguably the next big frontier in education. Today, you can learn all kinds of skills 
(even get a university degree) online, through YouTube videos and online presentations.
Language is primarily communicative, and Skype allows you to have 1-to-1 face and voice contact
with your teacher. In addition, all our teachers have experience teaching beginners. Many students
have tried it out and raved about it. You should too!
    </p>
  </div>
  <h3>3. How much are the teachers earning?</h3>
  <div>
    <p>
    Rent a language teacher.com takes  commission from the teachers for ever new student we bring in. 
After that, the teachers earn 100% of the price of the lessons.
    </p>
  </div>
  <h3>4. I need to change the date/time of my lessons. How do I go about doing it?</h3>
  <div>
    <p>
    You can email/inform your Spanish teacher privately 48 hours in advanced to change the date/time 
of your lessons. If you fail to do so, and not appear for your scheduled lesson, you will be charged
for that lesson.
    </p>
  </div>
          <h3>5. How do you match Spanish teachers with students?</h3>
  <div>
    <p>
    We match the Spanish teachers based on the needs and capability of each student. Every student
is unique in their level of Spanish, availability schedule and preferences and we try out best to 
find the best teacher for them. We are currently building a more in-depth service where we will
match students to teachers based on their interests, learning patterns and personality types. 
    </p>
  </div>
</div>

</div></div></div>

</asp:Content>
