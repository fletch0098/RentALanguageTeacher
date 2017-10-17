﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPages/NoSideBar.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RentALanguageTeacher.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcontent" runat="server">

    <link href="/Styles/coin-slider-styles.css" rel="stylesheet" />

    <script src="/Scripts/coin-slider.min.js"></script>
    <script src="/Scripts/RALTScripts.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
          
            $("#content-area").load("/RALT/EN/Home" + ("#PartPage" ? " " + "#PartPage" : ""));
        });

        

    </script>

    <style>

    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

     <div id="ImageSlider" class="center">
    <div id='coin-slider'>

    <a href="#" target="_blank">

        <img src="/Images/1.png" />

<%--        <span>

            Description for img01

        </span>--%>

    </a>


    <a href="#" target="_blank">

        <img src="/Images/2.png" />

<%--        <span>

            Description for imgN

        </span>--%>

    </a>

            <a href="#" target="_blank">

        <img src="/Images/3.png" />

<%--        <span>

            Description for imgN

        </span>--%>

    </a>
            <a href="#" target="_blank">

        <img src="/Images/4.png" />

<%--        <span>

            Description for imgN

        </span>--%>

    </a>


</div>
</div>

<%--<div id="LandingPageInfo">
    <div style="float:left;margin:10px;">
        Forget about boring Spanish grammar books or Rosetta Stone. Learn Spanish the effective way - Get your own Spanish teacher for only USD 8-10/ hour! Have 1-1 face time with a native Spanish teacher through Skype. Pick up a great accent, learn fast and speak well, all at your own schedule.
    </div>

        <div style="float:left;">

        <div class="LandingPageSteps" title="Request a teacher today!">

            <a href="#" onclick="OpenSlider()" ><img src="/Images/Step1.png" class="Shadow StepCorners" /></a>
                    

                </div>
        <div class="LandingPageSteps" title="We send you an email with your teacher">

                    <img src="/Images/Step2.png" class="Shadow StepCorners" />

                </div>
        <div class="LandingPageSteps" title="Purchase hours">

                    <a href="/Prices" ><img src="/Images/Step3.png" class="Shadow StepCorners" /></a>

                </div>


    </div>

    <div style="float:left; margin:10px;">
        <a href="#" onclick="OpenSlider()">Get Connected</a> with Spanish teacher today, or
         <a href="/Contact-Us"> Contact Us </a> for more information.
    </div>



</div>--%>

       <div id="content-area" style="float:left;"></div>

            <asp:HyperLink ID="ArticleLink" CssClass="BubbleLink" runat="server"><div class="ContentSection grid_4 alpha BubbleLink" style="min-height:285px;">

        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Article of the Day</div></div>
        <div class="ContentSectionContent">

            <div class=Content>

                <div style="min-height:240px;">
                    <div style="max-height:240px;">
                    <div style="text-align:center;"><div >
                        <asp:HyperLink ID="ArticleImageLink" CssClass="center" runat="server">
                            <asp:Image ID="ArticleImage" runat="server" /></asp:HyperLink></div>
                     
                    </div> 
                    <div style="float:left;"><h5><asp:Label ID="ArticleTitle" runat="server" Text=""></asp:Label></h5>
                        <asp:Label ID="ArticleDescription" runat="server" Text=""></asp:Label> <br /></div>
                        </div><span class="FullStoryLink" style="font-size:1.3em;font-weight:bold;">>>> Full Story...</span>
                   

                </div>

            </div>

        </div>

    </div></asp:HyperLink>

    <div class="grid_4">
 <div id="testimonials" class="center">
        <ul>
			<li>
				<blockquote>After learning Spanish in Guatemala, I found it very easy to go into my old routine and began forgetting everything that I'd learned. Having Skype lessons really helped to keep my Spanish ticking over and provided a nice break in my day-to-day routine.</blockquote>
				<p class="author">Michael Garrett, UK</p>
			</li>
			<li>
				<blockquote>"I love learning Spanish from a native speaker and hearing feedback in real-time!</blockquote>
				<p class="author">Jillian Davis, CA</p>
			</li>
			<li>
				<blockquote>"With Rent a Language Teacher learning spanish was easy in addition to being full of fun! Their teachers are warm, friendly, and put you at ease from the start. </blockquote>
				<p class="author">Janice Lim, SG</p>
			</li>
        </ul>
    </div>
</div>

        <div class="ContentSection grid_4 omega" style="height:285px;">

        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Word of the Day</div></div>
        <div class="ContentSectionContent">

            <div class=Content>
                <div class="WordOTD">
                <h5><asp:Label ID="WordOfDay" runat="server" Text=""></asp:Label> (<asp:Label ID="PartOfSpeach" runat="server" Text=""></asp:Label>)</h5>
                <ul id="list">
                    <li><asp:Label ID="EnglishTranslation" runat="server" Text=""></asp:Label></li>
                    <li><asp:Label ID="SpanishSentence" runat="server" Text=""></asp:Label></li>
                    <li><asp:Label ID="EnglishSentence" runat="server" Text=""></asp:Label></li>
 
               </ul>
</div>
            </div>

        </div>

    </div>


    
<%--    <div class="grid_3 omega">

            <div class="InputSection" style="height:285px;background:#b3b3b3">

        <div class="InputSectionHeader"><div class="InputSectionHeaderText">Word of the day</div></div>
  
                <ul id="list">
                    <li>Aprender (v)</li>
                    <li>to learn (adquirir conocimientos de) ; to memorize (memorizar)</li>
                    <li>aprender a hacer algo -> to learn to do something </li>
                    <li>aprenderse algo de memoria -> to learn something by heart </li>
 
               </ul>


        <div class="InputSectionContent"></div>

    </div>

    </div>--%>
	
</asp:Content>


