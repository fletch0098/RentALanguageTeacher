<%@ Page Title="Administer-Content" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="AdministerContent.aspx.cs" Inherits="RentALanguageTeacher.Pages.Administrator.AdministerContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script src="/ckeditor/ckeditor.js"></script>
    <script src="/ckeditor/adapters/jquery.js"></script>

    <script>

        function ToggleAddLanguage(DDL) {

            var MyDiv = $("#AddLanguage");
            var Value = DDL.val();

            if (Value == 'Add Language') {

                if (MyDiv.hasClass("Hidden")) {

                    MyDiv.removeClass("Hidden");

                }
                else {

                    MyDiv.addClass("Hidden");

                }
            }

            else {

                MyDiv.addClass("Hidden");

            }

        }

        function ToggleAddCategory(DDL) {

            var MyDiv = $("#AddCategory");
            var Value = DDL.val();

            if (Value == 'Add Category') {

                if (MyDiv.hasClass("Hidden")) {

                    MyDiv.removeClass("Hidden");

                }
                else {

                    MyDiv.addClass("Hidden");

                }
            }

            else {

                MyDiv.addClass("Hidden");

            }

        }

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

        $(function () {
            $("#dialog-confirm").dialog({
                autoOpen: false,
                resizable: true,
                height: 500,
                width: 500,
                modal: true,
                buttons: {
                    "Save": function () {

                        //Destroy existing editor if any
                        if (editor)
                            editor.destroy();

                        var title = $("#MyNewContentTitle").html();
                        var Description = $("#MyContentLinkDescription").html();
                        var ImageURL = $("#MyNewContentImage").attr('src');

                        $(".txtContentTitle").val(title.replace(" ","-"));
                        $(".txtContentDescription").val(Description);
                        $(".txtContentImage").val(ImageURL);              

                        $(this).dialog("close");
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    },
                }
            });
        });

        function PreviewBubble() {

            var title = $(".txtContentTitle").val();

            title = title.replace("-"," ");

            var description = $(".txtContentDescription").val();
            var image = $(".txtContentImage").val();
            var language = $(".ddlContentLanguage").val();
            var category = $(".ddlContentCategory").val();
            var PublishDate = $(".txtPublishDate").val();
            var Author = $(".txtAuthor").val();
            var AuthorEmail = $('#<%=HFAuthorEmail.ClientID %>').val();


            $("#MyNewContentTitle").html(title);
            $("#MyNewContentAuthor").html(Author);
            $("#MyNewContentPublishDate").html(PublishDate);
            $("#MyNewContentDescription").html(description);
            $("#MyNewContentLink").attr("href", '/' + category + '/' + language + '/' + title);
            $("#MyNewContentImage").attr('src', image);

            $("#MyNewContentAuthor").attr("href", AuthorEmail);

            $("#MyContentLinkTitle").html(title);
            $("#MyContentLinkDescription").html(description);
            $("#MyContentLinkLink").attr("href", '/' + category + '/' + language + '/' + title);
            $("#MyContentLinkImage").attr('src', image);
            $("#MyContentLinkAuthor").html(Author);
            $("#MyContentLinkPublishDate").html(PublishDate);


            
            $("#dialog-confirm").dialog("open");

        };

    </script>

    <script type="text/javascript">var switchTo5x = true;</script>
    <script type="text/javascript" src="https://ws.sharethis.com/button/buttons.js"></script>
    <script type="text/javascript">stLight.options({ publisher: "e706f11c-b0e1-455e-88a8-42b453cb4051", doNotHash: true, doNotCopy: true, hashAddressBar: false });</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <asp:HiddenField ID="HFAuthorEmail" runat="server" />

    <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage"><a href="/Home"><img src="/Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                    <p>Administer Content</p>

                </div>

            </div>

        </div>

    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate> 

            <div class="ContentSection">

                <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Content</div></div>

                <div class="ContentSectionContent">

                    <div class="Content">                

                        <asp:GridView ID="GridContent" runat="server" AutoGenerateColumns="False" AllowSorting="true" 
                            AllowPaging="True" PageSize="20" CssClass="mGrid" AlternatingRowStyle-CssClass="alt"
                            OnSorting="Sorting" OnPageIndexChanging="PageIndexChanging" OnRowDataBound="myGV_RowDataBound" DataKeyNames="Title" OnRowDeleting="GridContent_RowDeleting" >
                            <Columns>
                                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                                   <ItemTemplate>
                                     <asp:HyperLink ID="EditHyperLink1" runat="server" >
                                     </asp:HyperLink>
                                   </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                                 <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author"/>
                                 
                                 <asp:BoundField DataField="ModDate" HeaderText="Create Date" dataformatstring="{0:MMMM d, yyyy}" htmlencode="false" SortExpression="ModDate" />
                                <asp:CommandField DeleteText="" ShowDeleteButton="True" ButtonType="Image"
                                    DeleteImageUrl="/Images/RedX.png" />
                            </Columns>
                            
                        </asp:GridView>

                    </div>

                </div>    

            </div>

            <div class="ContentSection">

                <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Create Page</div></div>

                <div class="ContentSectionContent">

                    <div class="Content">                

                        <fieldset class="validationGroup">

                            <legend>NewContent</legend>

                            <div class="formfield-container long">
                                <asp:Label ID="lblContentTitme" CssClass="RALT required" runat="server" AssociatedControlID="txtContentTitle" Text="Content Title"></asp:Label><br />
                                <asp:TextBox ID="txtContentTitle" MaxLength="255"  cssclass="RALT long txtContentTitle validate[required,custom[NumbersAndLetters],maxSize[255]]" data-prompt-position="bottomRight:-60" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContentTitle"
                                    CssClass="field-validation-error" Text="*"  ErrorMessage="ContentTitle is required." ValidationGroup="NewContent"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtContentTitle" CssClass="field-validation-error"
                                    ValidationGroup="NewContent" Text="*" ValidationExpression="^[A-Za-z0-9_-]+$" ErrorMessage="Only Numbers and Letters"></asp:RegularExpressionValidator>
                            </div>

                            <div class="formfield-container long">
                                <asp:Label ID="lblContentCategory" CssClass="RALT  long required" runat="server" AssociatedControlID="ddlContentCategory" Text="Category"></asp:Label><br />
                                <asp:DropDownList ID="ddlContentCategory" CssClass="DDLlong ddlContentCategory ui-spinner ui-widget ui-widget-content ui-corner-all validate[funcCall[ValidateContentCategory]]" 
                                    onChange="ToggleAddCategory($(this))" data-prompt-position="bottomRight" runat="server"></asp:DropDownList>
                                <asp:CustomValidator ID="CustomValidator1" ControlToValidate="ddlContentCategory" CssClass="field-validation-error" 
                                    Text="*" runat="server" ErrorMessage="Category is required." ValidationGroup="NewContent" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>                                                                             
                            </div>

                            <div class="formfield-container long">
                                <asp:Label ID="lblContentLanguage" CssClass="RALT short required" runat="server" AssociatedControlID="ddlContentLanguage" Text="Language"></asp:Label><br />
                                <asp:DropDownList ID="ddlContentLanguage" CssClass="DDLlong ddlContentLanguage ui-spinner ui-widget ui-widget-content ui-corner-all" onChange="ToggleAddLanguage($(this))" runat="server"></asp:DropDownList>                                 
                                <asp:CustomValidator ID="CustomValidator2" ControlToValidate="ddlContentLanguage" CssClass="field-validation-error" 
                                    Text="*" runat="server" ErrorMessage="Language is required." ValidationGroup="NewContent" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>                                                                             
                            </div>

                            <div class="formfield-container long">
                                <asp:Label ID="lblPictureURL" CssClass="RALT" runat="server" AssociatedControlID="txtPictureURL" Text="Picture URL"></asp:Label><br />
                                <asp:TextBox ID="txtPictureURL" MaxLength="255"  cssclass="RALT txtContentImage long validate[required]" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPictureURL"
                                    CssClass="field-validation-error" Text="*"  ErrorMessage="ContentTitle is required." ValidationGroup="NewContent"></asp:RequiredFieldValidator>
                            </div>
                            <div class="formfield-container long">
                                <asp:Label ID="lblAuthor" CssClass="RALT" runat="server" AssociatedControlID="txtAuthor" Text="Author"></asp:Label><br />
                                <asp:TextBox ID="txtAuthor" MaxLength="255"  cssclass="RALT txtAuthor long" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="formfield-container long">
                                <asp:Label ID="lblPublishDate" CssClass="RALT" runat="server" AssociatedControlID="txtPublishDate" Text="Publish Date(example)"></asp:Label><br />
                                <asp:TextBox ID="txtPublishDate" Enabled="false" MaxLength="255"  cssclass="RALT txtPublishDate long" runat="server"></asp:TextBox>
                            </div>

                            <div  class="formfield-container" style="width:100%;">
                                <asp:Label ID="lblContentDescription" CssClass="RALT " runat="server" AssociatedControlID="txtContentDescription" Text="Content description"></asp:Label><br />
                                <asp:TextBox ID="txtContentDescription" cssclass="RALT Shadow txtContentDescription Corners" style="width:95%;height:100px;resize:none;" TextMode="MultiLine"   runat="server"></asp:TextBox>
                            </div>

                            <div style="float:left; width:100%"> 
                            
                                <div style="width:350px;" class="center">

                                    <div class="formfield-container short">

                                        <asp:Button ID="btnPreview" runat="server" Text="Interactive Preview" CssClass="button" OnClientClick="return PreviewBubble()" UseSubmitBehavior="false" />
                    
                                    </div>

                                    <div class="formfield-container short">

                                        <asp:Button ID="btnNewContent" runat="server" Text="Creae Page" CssClass="button causesValidation" UseSubmitBehavior="true" OnClick="btnNewContent_Click" ValidationGroup="NewContent" />

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

                    </div>

                </div>    

            </div>

            <div class="ContentSection Hidden" id="AddCategory">

                <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Add Category</div></div>

                <div class="ContentSectionInput">

                    <div class="Content" style="min-height:85px;">                

                        <fieldset class="validationGroup">

                            <legend>NewCategory</legend>

                            <div class="formfield-container long">
                                <asp:Label ID="lblNewCategory" CssClass="RALT required" runat="server" AssociatedControlID="txtNewCategory" Text="Category Name"></asp:Label><br />
                                <asp:TextBox ID="txtNewCategory" MaxLength="255"  cssclass="RALT long validate[required,custom[NumbersAndLetters],maxSize[255]]" data-prompt-position="bottomRight" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewCategory"
                                    CssClass="field-validation-error" Text="*"  ErrorMessage="New Category is required." ValidationGroup="NewCategory"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNewCategory" CssClass="field-validation-error"
                                    ValidationGroup="NewCategory" Text="*" ValidationExpression="^[a-zA-Z0-9]+$" ErrorMessage="Only Numbers and Letters"></asp:RegularExpressionValidator>
                            </div>

                            <div class="formfield-container long">
                                <asp:Label ID="lblCategoryDescription" CssClass="RALT" runat="server" AssociatedControlID="txtCategoryDescription" Text="Category Description"></asp:Label><br />
                                <asp:TextBox ID="txtCategoryDescription"  cssclass="RALT long" data-prompt-position="bottomRight" runat="server"></asp:TextBox>
                             </div>

                            <div class="formfield-container long">
                                <asp:Label ID="lblCategoryImage" CssClass="RALT " runat="server" AssociatedControlID="txtCategoryImage" Text="Category Image"></asp:Label><br />
                                <asp:TextBox ID="txtCategoryImage" MaxLength="255"  cssclass="RALT long validate[maxSize[255]]" data-prompt-position="bottomRight" runat="server"></asp:TextBox>
                            </div>

                            <div class="formfield-container long" style="padding-top:10px;">

                                <asp:Button ID="btnNewCategory" runat="server" Text="Create" CssClass="button causesValidation" OnClick="btnNewCategory_Click" ValidationGroup="NewCategory" />

                            </div>
                            
                        </fieldset>

                    </div>

                </div>    

            </div>

            <div class="ContentSection Hidden" id="AddLanguage">

                <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Add Language</div></div>

                <div class="ContentSectionInput">

                    <div class="Content" style="min-height:85px;">                

                        <fieldset class="validationGroup">

                            <legend>NewLanguage</legend>

                            <div class="formfield-container long">
                                <asp:Label ID="lblNewLanguage" CssClass="RALT required" runat="server" AssociatedControlID="txtNewLanguage" Text="Language Name"></asp:Label><br />
                                <asp:TextBox ID="txtNewLanguage" MaxLength="2"  cssclass="RALT long validate[required,custom[NumbersAndLetters],maxSize[2]]" data-prompt-position="bottomRight" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewLanguage"
                                    CssClass="field-validation-error" Text="*" ErrorMessage="New Language is required." ValidationGroup="NewLanguage"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNewLanguage" CssClass="field-validation-error"
                                    ValidationGroup="NewLanguage" Text="*" ValidationExpression="^[a-zA-Z0-9]+$" ErrorMessage="Only Numbers and Letters"></asp:RegularExpressionValidator>
                            </div>

                            <div class="formfield-container long" style="padding-top:10px;">

                                <asp:Button ID="btnNewLanguage" runat="server" Text="Create" CssClass="button causesValidation" OnClick="btnNewLanguage_Click" ValidationGroup="NewLanguage" />

                            </div>
                            
                        </fieldset>

                    </div>

                </div>    

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="dialog-confirm" title="New Content Bubble">

        <div id="MyNewContentHeader">

            <div class="ContentSection editable">

                <div class="ContentSectionContent">

                    <div class="Content">

                        <div class="ContentTitleImage">
                            
                            <a id="MyNewContentLink" href="/Home"><img id="MyNewContentImage" src="/Images/LogoBlack.png" class="center" /></a>

                        </div>

                        <div class="ContentTitleText" id="MyNewContentTitle">

                        </div>

                        <div style="float:left;">

                            <div class="ContentSocialMedia">

                                <span class='st_facebook_large' displayText='Facebook'></span>
                                <span class='st_twitter_large' displayText='Tweet'></span>
                                <span class='st_linkedin_large' displayText='LinkedIn'></span>
                                <span class='st_googleplus_large' displayText='Google +'></span>

                            </div>
                            
                            <div class="ContentAuthor">

                                <span>Author: </span><a style="font-weight:400;color:#1ee0e3;" id="MyNewContentAuthor"></a><br />
                                <span>Published On: </span><span  style="font-weight:400;" id="MyNewContentPublishDate"></span>

                            </div>
                           
                        </div >
                       
                    </div>

                </div>

            </div>

        </div>

        <br />

         <div id="MyContentLink">

             <a id="MyContentLinkLink" href="/Home">

                <div class="ContentSection">
        
                <div class="ContentSectionHeader"><div class="ContentSectionHeaderText" id="MyContentLinkTitle">Type-Your-Header-Here</div></div>
        
                <div class="ContentSectionContent">

                    <div class="Content">

                        <div class="ContentTitleImage"><img id="MyContentLinkImage" src="/Images/LogoBlack.png" class="center" /></div>
                        
                        <div style="float:left;width:400px;">
                        <div class="ContentTitleText">

                                <div id="MyContentLinkDescription">Type a description, or intro here...</div>
                           
                                <span style="font-size:1.3em;font-weight:bold;color:#1ee0e3;">>> Full Story...</span>
                            <br />
                            <br />
                        </div>

                        <div class="LinkContentAuthor">

                                <span>Author: </span><span  style="font-weight:400;" id="MyContentLinkAuthor"></span><br />
                                <span>Published On: </span><span  style="font-weight:400;" id="MyContentLinkPublishDate"></span>

                            </div></div>

                    </div>

                </div>

            </div>

            </a>

        </div>
  
    </div>

</asp:Content>
