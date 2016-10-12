<%@ Page Title="" Language="C#" MasterPageFile="~/Components2Master.Master" AutoEventWireup="true" CodeBehind="Invite.aspx.cs" Inherits="FVK_Demo.Invite" %>
<%@ Register TagPrefix="fvk" TagName="invite" Src="~/FVK/InviteControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Invite Friends</h1>
    <br />
    <br />
    Invite Friends control is used for sending the invite requests to the user's friends. To test the component, 
    select couple of your friends and press the 'Send Fvk Invitation' button. After invitations are sent the 
    application will be redirected on page where you can see IDs and names of friends which are invited. For 
    more information, look at:
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/invite-friends" target="_blank">Facebook Invite Friends Tutorial</a></b>
    <br /><br />
    <fvk:invite ID="invite1" runat="server"
        MainTitle = "Facebook Visual Kit"
        Content = "Facebook Visual Kit is a set of ASP.NET user controls that facilitate the use of common and popular Facebook features by wrapping and hiding the complexity of underlying implementation from the user. This set of controls makes development of Facebook iFrame applications, both in C# and VB.NET programing languages, significantly easier, faster and more organized."
     />
</asp:Content>
