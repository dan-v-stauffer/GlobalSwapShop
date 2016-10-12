<%@ Page Title="" Language="C#" MasterPageFile="~/Components1Master.Master" AutoEventWireup="true" CodeBehind="LikeButton.aspx.cs" Inherits="FVK_Demo.LikeButton" %>
<%@ Register TagPrefix="fvk" TagName="likebutton" Src="~/FVK/LikeButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Like Button</h1>
    <br />
    Like Button is used that user of website can share interested content with their friends. After user clicks on like 
    button inside you page a story in the user's friends' News Feed appears with link back to your site which increases 
    number of visitors to your site. For more information, look at:
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-facebook-controls/facebook-like-button" target="_blank">Facebook Like Button</a></b>
    <br /><br /><br />
    Following example shows 3 types of layout of like button: 'standard', 'button_count' and 'box_count'.
    Last button is box_count type with 'send' option enabled.
    <br /><br />
    <fvk:likebutton ID="like1" runat="server" Url="http://vatlab.com" />
    <br /><br />
    <fvk:likebutton ID="lik2" runat="server" Layout="button_count" Url="http://vatlab.com" />
    <br /><br />
    <fvk:likebutton ID="Likebutton1" runat="server" Layout="box_count" Url="http://vatlab.com" />
    <br /><br />
    <fvk:likebutton ID="Like4" runat="server" Layout="button_count" Url="http://vatlab.com" Send="true" />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
