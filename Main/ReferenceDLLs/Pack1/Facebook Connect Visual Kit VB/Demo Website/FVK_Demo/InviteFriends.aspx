<%@ Page Title="" Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InviteFriends.aspx.vb" Inherits="FVK_Demo.InviteFriends" %>
<%@ Register TagPrefix="fvk" TagName="invite" Src="~/FVK/InviteControl.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Connect Invite Friends Control for ASP.NET</title>
    <meta name="description" content="ASP.NET Invite Friends control for Facebook Connect web sites." />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:16px">Facebook Invite Friends</h1>
    
    <p style="text-align:justify">Facebook Invite Friends control is used for sending the invite requests to the user's friends. To test 
    the component, select couple of your friends and press the 'Send Fvk Demo Invitation' button. After invitations
    are sent the application will be redirected on page where you can see IDs of friends which are invited.
    For more information, look at:
    
    <b><a href="http://vatlab.com/asp-net-facebook-controls/invite-friends" target="_blank">Facebook Invite Friends Tutorial</a></b></p>
    
    <fvk:invite ID="invite1" runat="server"
        MainTitle = "Facebook Visual Kit"
        Content = "Facebook Visual Kit is a set of ASP.NET user controls that facilitate the use of common and popular Facebook features by wrapping and hiding the complexity of underlying implementation from the user. This set of controls makes development of Facebook iFrame applications, both in C# and VB.NET programing languages, significantly easier, faster and more organized."
     />
    <br /><br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
    <br /><br /><br /><br /> 
    <br />
</asp:Content>

