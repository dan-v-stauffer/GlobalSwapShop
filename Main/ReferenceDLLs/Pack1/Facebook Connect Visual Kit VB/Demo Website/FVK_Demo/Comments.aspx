<%@ Page Title="" Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.vb" Inherits="FVK_Demo.Comments" %>
<%@ Register TagPrefix="fvk" TagName="comments" Src="~/FVK/Comments.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Comments for ASP.NET</title>
    <meta name="description" content="ASP.NET Comments Box control for Facebook Connect web sites in C# and VB.NET" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Comments</h1>
    <br />
    This control is used to allow a user of your web site to write comments and share them with their friends 
    by posting them on their profiles. Posting a comment on user's wall will result in more visitors from the 
    Facebook to your site. For more information, look at:
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-facebook-controls/comment-box" target="_blank">Facebook Comments Box</a></b>
    <br /><br />
    <fvk:comments ID="comments1" runat="server" Xid="commentbox1" />
    <br /><br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
