<%@ Page Title="Sortable" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="Sortable.aspx.cs" Inherits="RentALanguageTeacher.Tests.Sortable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

      <style>
#sortable { list-style-type: none; margin: 0; padding: 0; }


  </style>
  <script>
      $(function () {
          $("#sortable").sortable();
          $("#sortable").disableSelection();
      });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <ul id="sortable">

  <a class="BubbleLink" id="MyContentLinkLink" href="/GetShortcuts/EN/Conjugation-Cheatsheet">

                                    <div class="ContentSection BubbleLink">
        
                                    <div class="ContentSectionHeader"><div class="ContentSectionHeaderText" id="MyContentLinkTitle">Conjugation Cheatsheet</div></div>
        
                                    <div class="ContentSectionContent">

                                        <div class="Content">

                                            <div class="ContentTitleImage"><img id="MyContentLinkImage" src="/WebWritable/Images/Get Shortcuts page/conjugationcheatsheet.png" class="center" /></div>
                        
                                            <div style="float:left;width:400px;">
                                            <div class="ContentTitleText">

                                                    <div id="MyContentLinkDescription">In this cheatsheet, we summarize the general rules that govern the conjugations of -ar, -er and -ir verbs for the following tenses:
- Present, Preterit Past, Imperfect Past, Conditional, Future, Present Subjunctive, Past Subjunctive.

This is a great recap of conjugation rules, especially before trying out our conjugation game POP on our Games page.</div>
                           
                                                    <span id="FullStory" class="FullStoryLink" style="font-size:1.3em;font-weight:bold;">>> Full Story...</span>
                                                <br />
                                                <br />
                                            </div>

                                            <div class="LinkContentAuthor">

                                                    <span>Author: </span><span  style="font-weight:400;" id="MyContentLinkAuthor">Rent A  Language Teacher</span><br />
                                                    <span>Published On: </span><span  style="font-weight:400;" id="MyContentLinkPublishDate">Friday, April 04, 2014</span>

                                                </div></div>

                                        </div>

                                    </div>

                                </div>

                                </a>
  <a class="BubbleLink" id="A1" href="/GetShortcuts/EN/The-4-Uses-Of-The-Conditional-Tense">

                                    <div class="ContentSection BubbleLink">
        
                                    <div class="ContentSectionHeader"><div class="ContentSectionHeaderText" id="Div1">The 4 Uses Of The Conditional Tense</div></div>
        
                                    <div class="ContentSectionContent">

                                        <div class="Content">

                                            <div class="ContentTitleImage"><img id="Img1" src="/WebWritable/Images/Get Shortcuts page/conditional.png" class="center" /></div>
                        
                                            <div style="float:left;width:400px;">
                                            <div class="ContentTitleText">

                                                    <div id="Div2">Confused over when to use the Conditional tense? This shortcut gives you a summary of the 4 main uses of the conditional tense with examples. Check it out!</div>
                           
                                                    <span id="Span1" class="FullStoryLink" style="font-size:1.3em;font-weight:bold;">>> Full Story...</span>
                                                <br />
                                                <br />
                                            </div>

                                            <div class="LinkContentAuthor">

                                                    <span>Author: </span><span  style="font-weight:400;" id="Span2">Rent A  Language Teacher</span><br />
                                                    <span>Published On: </span><span  style="font-weight:400;" id="Span3">Thursday, March 27, 2014</span>

                                                </div></div>

                                        </div>

                                    </div>

                                </div>

                                </a>

</ul>

</asp:Content>
