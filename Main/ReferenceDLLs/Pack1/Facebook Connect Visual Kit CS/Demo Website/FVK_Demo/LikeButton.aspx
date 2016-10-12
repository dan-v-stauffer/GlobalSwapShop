<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LikeButton.aspx.cs" Inherits="FVK_Demo.LikeButton" %>
<%@ Register TagPrefix="fvk" TagName="likebutton" Src="~/FVK/LikeButton.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Like Button</h1>
    
    <p style="text-align:justify">Like Button is used that user of website can share interested content with their friends. After user clicks on like 
    button inside you page a story in the user's friends' News Feed appears with link back to your site which increases 
    number of visitors to your site. For more information, look at:
    
    <b><a href="http://vatlab.com/asp-net-facebook-controls/facebook-like-button" target="_blank">Facebook Like Button Tutorial</a></b>
    </p>
    
    Following example shows 3 types of layout of like button: 'standard', 'button_count' and 'box_count'. Last button is box_count type with 'send' option enabled.
    <br /><br />
    <fvk:likebutton ID="Like1" runat="server" Url="http://vatlab.com" />
    <br /><br />
    <fvk:likebutton ID="Like2" runat="server" Layout="button_count" Url="http://vatlab.com" />
    <br /><br />
    <fvk:likebutton ID="Like3" runat="server" Layout="box_count" Url="http://vatlab.com" />
    <br /><br />
    <fvk:likebutton ID="Like4" runat="server" Layout="button_count" Url="http://vatlab.com" Send="true" />
    <br /><br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
