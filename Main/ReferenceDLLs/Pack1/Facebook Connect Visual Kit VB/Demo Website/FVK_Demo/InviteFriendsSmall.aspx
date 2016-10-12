<%@ Page Title="" Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InviteFriendsSmall.aspx.vb" Inherits="FVK_Demo.InviteFriendsSmall" %>
<%@ Register TagPrefix="fvk" TagName="invitesmall" Src="~/FVK/InviteSmallControl.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Connect Invite Friends Condensed control for .NET</title>
    <meta name="description" content="Invite Friends Condensed Facebook Connect Control for ASP.NET web sites." />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Invite Friends Condensed</h1>
    <p style="text-align:justify">Small (Condensed) Invite control has the same purpose as the Invite control. The only differences 
    between them are in the design and the properties they have. To test the component, select couple
    of your friends and press 'Send Fvk Invitation' button. For more information, look at:
    <b><a href="http://vatlab.com/asp-net-facebook-controls/invite-friends-condensed" target="_blank">Facebook Invite Condensed Tutorial</a></b>
    </p>
    
    <div>
    <fvk:invitesmall ID="invite2" runat="server" ImportExternalFriends="false" 
        Content = "Facebook Visual Kit is a set of ASP.NET user controls that facilitate the use of common and popular Facebook features by wrapping and hiding the complexity of underlying implementation from the user. This set of controls makes development of Facebook iFrame applications, both in C# and VB.NET programing languages, significantly easier, faster and more organized." 
    />
    </div>
    <br /><br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
    <br /><br /><br /><br />    
    <br /><br /><br /><br />
    <br /><br /><br /><br />
</asp:Content>
