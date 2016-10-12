<%@ Page Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="BookmarkButton.aspx.vb" Inherits="FVK_Demo.BookmarkButton" %>
<%@ Register TagPrefix="fvk" TagName="bookmark" Src="~/FVK/BookmarkButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Connect Bookmark Button control for ASP.NET</title>
    <meta name="description" content="ASP.NET Bookmark Button control for Facebook Connect web sites in .NET framework" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 style="font-size:18px">Facebook Boomark Button</h1>
    <p style="text-align:justify">With Bookmark button users can easily bookmark your website inside the Facebook environment. If you don't see Bookmark button, 
    you should log in to Facebook first by using the Login Button. For more information, look at:   
    
    <b><a href="http://vatlab.com/asp-net-facebook-controls/bookmark-button" target="_blank">Facebook Bookmark Button Tutorial</a></b>
    </p>
    
    <fvk:bookmark ID="bookmark1" runat="server" OnAddedBookmark="BookmarkAdded" />
    <br />
    <asp:UpdatePanel ID="BookmarkButtonUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:Label ID="BookmarkedLabel" runat="server" Text="The website is now bookmarked" Visible="false" EnableViewState="false" Font-Bold="true"></asp:Label>
       </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    
    <br /><br /><br />
</asp:Content>
