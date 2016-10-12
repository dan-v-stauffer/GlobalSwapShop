<%@ Page Title="" Language="C#" MasterPageFile="~/Components2Master.Master" AutoEventWireup="true" CodeBehind="InviteSmall.aspx.cs" Inherits="FVK_Demo.InviteSmall" %>
<%@ Register TagPrefix="fvk" TagName="invitesmall" Src="~/FVK/InviteSmallControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Invite Friends Condensed</h1>
    <br />
    <br />
    Small (Condensed) Invite control has the same purpose as the Invite control. The only differences 
    between them are in the design and the properties they have. To test the component, select couple 
    of your friends and press 'Send Fvk Invitation' button. After invitations are sent the application 
    will be redirected on page where you can see IDs and names of friends which are invited. For more 
    information, look at:
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/invite-friends-condensed" target="_blank">Facebook Invite Condensed Tutorial</a></b>
    <br /><br />
    <div>
    <fvk:invitesmall ID="invite2" runat="server" 
        Content = "Facebook Visual Kit is a set of ASP.NET user controls that facilitate the use of common and popular Facebook features by wrapping and hiding the complexity of underlying implementation from the user. This set of controls makes development of Facebook iFrame applications, both in C# and VB.NET programing languages, significantly easier, faster and more organized." 
    />
    </div>
</asp:Content>
