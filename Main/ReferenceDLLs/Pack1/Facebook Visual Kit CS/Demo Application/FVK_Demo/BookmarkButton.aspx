<%@ Page Title="" Language="C#" MasterPageFile="~/Components3Master.Master" AutoEventWireup="true" CodeBehind="BookmarkButton.aspx.cs" Inherits="FVK_Demo.BookmarkButton" %>
<%@ Register TagPrefix="fvk" TagName="bookmark" Src="~/FVK/BookmarkButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Bookmark Button</h1>
    <br />
    With Bookmark button users can easily bookmark your website inside the Facebook environment. If you don't see Bookmark button, 
    you should log in to Facebook first by using the Login Button. For more information, look at:   
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-facebook-controls/bookmark-button" target="_blank">Facebook Bookmark Button Tutorial</a></b>
    <br /><br />
    <fvk:bookmark ID="bookmark1" runat="server" OnAddedBookmark="BookmarkAdded" />
    <br /><br />
    <asp:UpdatePanel ID="BookmarkLabelUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:Label ID="BookmarkedLabel" runat="server" Text="Application is now bookmarked" Visible="false" EnableViewState="false"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br /><br /><br />
</asp:Content>
