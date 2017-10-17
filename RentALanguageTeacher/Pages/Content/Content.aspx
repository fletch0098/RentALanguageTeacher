﻿<%@ Page Title="Content" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Content.aspx.cs" Inherits="RentALanguageTeacher.Pages.Content.Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script src="/ckeditor/ckeditor.js"></script>
    <script src="/ckeditor/adapters/jquery.js"></script>
    <script>

        //Page variable for the editor instance
        var editor;

        window.onload = function () {

            // Listen to the double click event.
            if (window.addEventListener)
                document.body.addEventListener('dblclick', onDoubleClick, false);
            else if (window.attachEvent)
                document.body.attachEvent('ondblclick', onDoubleClick);
        };

        function onDoubleClick(ev) {

            // Get the element which fired the event. This is not necessarily the
            // element to which the event has been attached.
            var element = ev.target || ev.srcElement;

            // Find out the div that holds this element.
            var name;

            do {
                element = element.parentNode;
            }
            while (element && (name = element.nodeName.toLowerCase()) &&
                (name != 'div' || element.className.indexOf('editable') == -1) && name != 'body');

            if (name == 'div' && element.className.indexOf('editable') != -1)
                replaceDiv(element);
        }

        function replaceDiv(div) {

            //Destroy existing editor if any
            if (editor)
                editor.destroy();

            //Create new Editor
            editor = CKEDITOR.replace(div);

            //Set CSS inside editor
            editor.config.contentsCss = '/Styles/RALT.css';

            //Extra Plugins
            editor.config.extraPlugins = 'timestamp,closeeditor,abbr';

            //FileManager
            editor.config.filebrowserBrowseUrl = '/FileManager/Explorer.aspx';

            // Toolbar configuration generated automatically by the editor based on config.toolbarGroups.
            editor.config.toolbar = [
                { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
                { name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
                { name: 'editing', groups: ['find', 'selection', 'spellchecker'], items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
                { name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'] },
                '/',
                { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
                { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] },
                { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
                { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
                '/',
                { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
                { name: 'colors', items: ['TextColor', 'BGColor'] },
                { name: 'tools', items: ['Maximize', 'ShowBlocks'] },
                { name: 'extras', items: ['Timestamp', 'closeeditor', 'Abbr'] },
                { name: 'others', items: ['-'] },
                { name: 'about', items: ['About'] }
            ];

            // Toolbar groups configuration.
            editor.config.toolbarGroups = [
                { name: 'document', groups: ['mode', 'document', 'doctools'] },
                { name: 'clipboard', groups: ['clipboard', 'undo'] },
                { name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
                { name: 'forms' },
                '/',
                { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
                { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
                { name: 'links' },
                { name: 'insert' },
                '/',
                { name: 'styles' },
                { name: 'colors' },
                { name: 'tools' },
                { name: 'extras' },
                { name: 'others' },
                { name: 'about' }
            ];

        }

        $(document).ready(function () {
            LoadPage();

            $(function () {
                $("#sortable").sortable();
                $("#sortable").disableSelection();
            });

            var Version = $('#<%=ddlContentVersion.ClientID %>').val();
            $('#<%=HFVersionControl.ClientID %>').val(Version);

          //  $(".editable").wrap("<li></li>");

        });

        function Cancel() {
            var Content = $('#<%=HFContentControl.ClientID %>').val();
            $("#<%=ContentPlaceHolder.ClientID %>").html("<ul id=\"sortable\">" + Content + "<div id=\"final\"></div></ul>");
            $(function () {
                $("#sortable").sortable();
                $("#sortable").disableSelection();
            });

            LoadPage();
        };

        //Save the page HTML
        function SavePage() {

            //Destroy existing editor if any
            if (editor)
                editor.destroy();

           $(".editable").unwrap("<li></li>");
            $("#final").remove();

            var Content = $('#<%=ContentPlaceHolder.ClientID %>').html();
            $('#<%=HFContentReturn.ClientID %>').val(Content)

            Save = true;

        };

        //Load the page HTML
        function LoadPage() {

            //Destroy existing editor if any
            if (editor)
                editor.destroy();

            //Save Content
            // SetContent();

            

            var Title = $('#<%=HFTitle.ClientID %>').val();
            var Author = $('#<%=HFAuthor.ClientID %>').val();
            var PublishDate = $('#<%=HFPublishDate.ClientID %>').val();
            var NavLink = $('#<%=HFNavLink.ClientID %>').val();
            var ImageURL = $('#<%=HFImageURL.ClientID %>').val();
            var AuthorEmail = $('#<%=HFAuthorEmail.ClientID %>').val();

            var Language = $('#<%=HFLanguage.ClientID %>').val();
            var Category = $('#<%=HFCategory.ClientID %>').val();

            $("#MyNewContentTitle").html(Title);
            $("#MyNewContentAuthor").html(Author);
            $("#MyNewContentPublishDate").html(PublishDate);
            $("#MyNewContentLink").attr("href", NavLink);
            $("#MyNewContentImage").attr('src', ImageURL);
            $("#MyNewContentAuthor").attr("href", AuthorEmail);
            $("#MyNewContentBackLink").attr("href", "/Links/" + Category + "/" + Language);
            $("#MyNewContentBackLink").html("<< View All " + Category + " Articles");

        };

        function IsDirty() {

            $(".editable").unwrap("<li></li>");
            $("#final").remove();

            var ContentControl = $('#<%=HFContentControl.ClientID %>').val();
            var Content = $("#<%=ContentPlaceHolder.ClientID %>").html();

            //var Publish = $('#input:<%=chkPublished.ClientID %>:checked').val();
            var PublishControl = $('#<%=HFPublishedControl.ClientID %>').val();

            var Description = $('#<%=txtContentDescription.ClientID %>').val();
            var DescriptionControl = $("#<%=HFDescription.ClientID %>").val();

            if ($('#<%=chkPublished.ClientID %>').is(":checked"))
            {
                Publish = "True";
            }
            else
            {
                Publish = "False"
            };

            if (ContentControl.trim() != Content.trim() || (Description != DescriptionControl) || (Publish != PublishControl))
            {
                var Content = $("#<%=ContentPlaceHolder.ClientID %>").html();
                $("#<%=ContentPlaceHolder.ClientID %>").html("<ul id=\"sortable\">" + Content + "<div id=\"final\"></div></ul>");
                $(function () {
                    $("#sortable").sortable();
                    $("#sortable").disableSelection();
                });
                return true;
            }
            else
            {
                var Content = $("#<%=ContentPlaceHolder.ClientID %>").html();
                $("#<%=ContentPlaceHolder.ClientID %>").html("<ul id=\"sortable\">" + Content + "<div id=\"final\"></div></ul>");
                $(function () {
                    $("#sortable").sortable();
                    $("#sortable").disableSelection();
                });
                return false;
            };

        };

        var Save = false;

        $(window).bind('beforeunload', function () {

            var IsEditable = $('#<%=HFEditor.ClientID %>').val();
            
            if (IsDirty() && (!Save) && (IsEditable == "true") ){

                return "Are you sure you want to leave without saving?";
            }
        });

        function ToggleEditorTools() {

            var MyDiv = $("#EditorTools");

            MyDiv.removeClass("Hidden");

        };

        function LanguageChange(obj) {

            //Get Variables
            var Id = $('#<%=HFContentId.ClientID %>').val();
            var Language = obj.val();

            //Call WebMethod
            $.ajax({
                type: "POST",
                url: "/Default.aspx/CheckLanguage",
                data: "{'ContentId': '" + Id + "', 'Language': '" + Language + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //Success Function
                success: function (ReturnValue) {
                    if (ReturnValue.d == 'False') {
                        //No Languages, Prompt User
                        if (!confirm('This does not exsist for this page, Would you like to create one in this language?'))
                        {
                            var PreviousLanguage = $('#<%=HFLanguage.ClientID %>').val();
                            $('#<%=ddlContentLanguage.ClientID %>').val(PreviousLanguage);
                            return false;
                        }
                        else
                        {
                            if (__doPostBack(obj.id, '')) {

                            }
                            else {
                                var PreviousLanguage = $('#<%=HFLanguage.ClientID %>').val();
                                $('#<%=ddlContentLanguage.ClientID %>').val(PreviousLanguage);
                            };
                    };

                    } else {
                        if (__doPostBack(obj.id, '')) {

                        }
                        else {
                            var PreviousLanguage = $('#<%=HFLanguage.ClientID %>').val();
                           $('#<%=ddlContentLanguage.ClientID %>').val(PreviousLanguage);
                       };
                    }

                },
                //Error
                error: function (request, status, error) {
                    var n = noty({ text: "There was an error, Please Try again", type: error });
                },
            });
        };

        function VersionChange(obj) {

            //Get Variables
            var Version = obj.val();

            //var IsEditable = $('#<%=HFEditor.ClientID %>').val();

            //if (IsDirty() && (!Save) && (IsEditable == "true")) {

            //    var value = confirm("Are you sure you want to leave without saving?");
            //    if (value == true)
            //        __doPostBack(obj.id, '');
            //    else
            //        return false;
            //}
            //else

            if (__doPostBack(obj.id, '')) {
                
            }
            else {
                var Version = $('#<%=HFVersionControl.ClientID %>').val();
                $('#<%=ddlContentVersion.ClientID %>').val(Version);
            }

           
        };




        //Add Content Bubble
        function AddContentBubble() {

            $("<div class=\"ContentSection editable\"><div class=\"ContentSectionHeader\"><div class=\"ContentSectionHeaderText\">TitleHere</div></div><div class=\"ContentSectionContent\"><div class=\"Content\"><p>Type here...</p></div></div></div>").insertBefore('#final');

           // $("#<%=ContentPlaceHolder.ClientID %>").append("<div class=\"ContentSection editable\"><div class=\"ContentSectionHeader\"><div class=\"ContentSectionHeaderText\">TitleHere</div></div><div class=\"ContentSectionContent\"><div class=\"Content\"><p>Type here...</p></div></div></div>");
        };

    </script>

    <style>
        #sortable { list-style-type: none; margin: 0; padding: 0; }
    </style>

    <script type="text/javascript">var switchTo5x = true;</script>
    <script type="text/javascript" src="https://ws.sharethis.com/button/buttons.js"></script>
    <script type="text/javascript">stLight.options({ publisher: "e706f11c-b0e1-455e-88a8-42b453cb4051", doNotHash: true, doNotCopy: true, hashAddressBar: false });</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div id="WholePage">
    <asp:HiddenField ID="HFTitle" runat="server" />
    <asp:HiddenField ID="HFImageURL" runat="server" />
    <asp:HiddenField ID="HFAuthor" runat="server" />
    <asp:HiddenField ID="HFPublishDate" runat="server" />
    <asp:HiddenField ID="HFNavLink" runat="server" />
    <asp:HiddenField ID="HFAuthorEmail" runat="server" />
    <asp:HiddenField ID="HFCategory" runat="server" />
    <asp:HiddenField ID="HFContentId" runat="server" />
    <asp:HiddenField ID="HFLanguage" runat="server" />
    <asp:HiddenField ID="HFEditor" runat="server" />
    <asp:HiddenField ID="HFDescription" runat="server" />
    <asp:HiddenField ID="HFPublishedControl" runat="server" />
    <asp:HiddenField ID="HFContentControl" runat="server" />
    <asp:HiddenField ID="HFVersionControl" runat="server" />
    <asp:HiddenField ID="HFContentReturn" runat="server" />

    <div class="ContentSection">

        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage">
                            
                    <a id="MyNewContentLink" href="/Home"><img id="MyNewContentImage" src="/Images/LogoBlack.png" class="center" /></a>

                </div>

                <div class="ContentTitleText" id="MyNewContentTitle">

                </div>
                <br />
                <a id="MyNewContentBackLink"></a>
                <div style="float:left;">

                    <div class="ContentSocialMedia">

                        <span class='st_facebook_large' displayText='Facebook' title="Share on Facebook"></span>
                        <span class='st_twitter_large' displayText='Tweet' title="Share on Twitter"></span>
                        <span class='st_linkedin_large' displayText='LinkedIn' title="Share on LinkedIn"></span>
                        <span class='st_googleplus_large' displayText='Google +' title="Share on Google +"></span>

                    </div>
                            
                    <div class="ContentAuthor">
                        
                        <span>Author: </span><a style="font-weight:400;color:#1ee0e3;" id="MyNewContentAuthor"></a><br />
                        <span>Published On: </span><span  style="font-weight:400;" id="MyNewContentPublishDate"></span><br />
                        

                    </div>
                           
                </div >
                       
            </div>

        </div>

    </div>
    
    <div id="PartPage">

    <div id="ContentPlaceHolder" runat="server">


      
    </div>

</div>
        </div>
    <div class="ContentSection Hidden" id="EditorTools">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Administrator Controls</div></div>
        
        <div class="ContentSectionInput">

            <div class="Content">

                <div  class="formfield-container" style="width:100%;">
                    <asp:Label ID="lblContentDescription" CssClass="RALT " runat="server" AssociatedControlID="txtContentDescription" Text="Content description"></asp:Label><br />
                    <asp:TextBox ID="txtContentDescription" cssclass="RALT Shadow txtContentDescription Corners" style="width:95%;height:100px;resize:none;" TextMode="MultiLine"   runat="server"></asp:TextBox>
                </div>

                <asp:Button ID="btnSavePage" runat="server" CssClass="button" Text="Save Page" OnClientClick="SavePage()" OnClick="btnSavePage_Click" />
                <asp:Button ID="btnNewBubble" runat="server" Text="New Bubble" CssClass="button" OnClientClick="return AddContentBubble()" UseSubmitBehavior="false"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel Edit" CssClass="button" OnClientClick="return Cancel()" UseSubmitBehavior="false"/>

                <div class="formfield-container long">
                    <asp:Label ID="lblContentVersion" CssClass="RALT long" runat="server" AssociatedControlID="ddlContentVersion" Text="Version Control"></asp:Label><br />
                    <asp:DropDownList ID="ddlContentVersion" CssClass="DDLlong ui-spinner ui-widget ui-widget-content ui-corner-all" runat="server" onChange="return VersionChange($(this))" AutoPostBack="true" OnSelectedIndexChanged="ddlContentVersion_SelectedIndexChanged"></asp:DropDownList>                                 
                </div>

                <div class="formfield-container short">
                    <asp:Label ID="lblContentLanguage" CssClass="RALT short" runat="server" AssociatedControlID="ddlContentLanguage" Text="Language"></asp:Label><br />
                    <asp:DropDownList ID="ddlContentLanguage" CssClass="DDLshort ui-spinner ui-widget ui-widget-content ui-corner-all" runat="server" onChange="return LanguageChange($(this))" AutoPostBack="true" OnSelectedIndexChanged="ddlContentLanguage_SelectedIndexChanged"></asp:DropDownList>                                 
                </div>

                <div class="formfield-container short">
                    <asp:Label ID="lblPublished" CssClass="RALT short" runat="server" AssociatedControlID="chkPublished" Text="Published"></asp:Label><br />
                    <asp:CheckBox ID="chkPublished"  runat="server" />
                
                </div>

            </div>

        </div>

    </div>

</asp:Content>
