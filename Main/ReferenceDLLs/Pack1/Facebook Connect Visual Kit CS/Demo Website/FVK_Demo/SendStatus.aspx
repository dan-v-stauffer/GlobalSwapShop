<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SendStatus.aspx.cs" Inherits="FVK_Demo.SendStatus" Title="Untitled Page" %>
<%@ Register TagPrefix="fvk" TagName="sendstatus" Src="~/FVK/SendUserStatus.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Connect Send User Status control for ASP.NET</title>
    <meta name="description" content="ASP.NET User Status control for developing Facebook Connect web sites in C# and VB.NET." />
    <script type="text/javascript" src="FVK/JavaScript/SendStatus.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Send Status</h1>
    
    <p style="text-align:justify">Send User Status control is used to send a user status from your Facebook application or your Facebook connect 
    web site in the same way as from the Facebook itself. Before sending a status, you have to allow the sending of 
    user status by pressing the link "Allow updating status from the app!". Pressing on the 'Post' button will result 
    in sending of a status and execution of the event handler method inside your page which can execute additional 
    commands. For more information, look at:
    
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/send-user-status"  target="_blank">Facebook Send Status Tutorial</a></b>.
    </p>

    <fvk:sendstatus id="sendstatus1" runat="server" OnSendStatusCalled="OnSendStatus" />
    <br />
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
            <asp:Label ID="SendStatusHandlerLabel" runat="server" Text="" Font-Bold="true"></asp:Label>
       </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />   
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
