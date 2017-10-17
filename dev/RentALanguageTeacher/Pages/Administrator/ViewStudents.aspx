<%@ Page Title="View-Students" Language="C#" MasterPageFile="~/MasterPages/RentALanguageTeacher.Master" AutoEventWireup="true" CodeBehind="ViewStudents.aspx.cs" Inherits="RentALanguageTeacher.Pages.Administrator.ViewStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

    <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText"><%: Page.Title %></div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">

                <div class="ContentTitleImage"><a href="/Home"><img src="/Images/LogoBlack.png" class="center" /></a></div>
                
                <div class="ContentTitletext">

                    <p>view Students</p>

                </div>

            </div>

        </div>

    </div>
    
        <div class="ContentSection">
        
        <div class="ContentSectionHeader"><div class="ContentSectionHeaderText">Students</div></div>
        
        <div class="ContentSectionContent">

            <div class="Content">


                <asp:GridView ID="GridStudents" runat="server" AutoGenerateColumns="False" AllowSorting="true" 
                    AllowPaging="True" PageSize="20" CssClass="mGrid" AlternatingRowStyle-CssClass="alt"
                     OnSorting="Sorting" OnPageIndexChanging="PageIndexChanging" >
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="UserName" 
                DataNavigateUrlFormatString="/Administration/AdministerStudent/{0}" 
                DataTextField="UserName" HeaderText="User Name" Text="User Name"   SortExpression="UserName" />
                         <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                         <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"/>

                         <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                     </Columns>
                </asp:GridView>

                            

            </div>

        </div>

    </div>        

</asp:Content>
