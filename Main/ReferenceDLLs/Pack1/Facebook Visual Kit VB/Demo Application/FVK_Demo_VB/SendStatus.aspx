<%@ Page Title="" Language="C#" MasterPageFile="~/Components2Master.Master" AutoEventWireup="true" CodeBehind="SendStatus.aspx.cs" Inherits="FVK_Demo.SendStatus" %>
<%@ Register TagPrefix="fvk" TagName="sendstatus" Src="~/FVK/SendUserStatus.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
    <script type="text/javascript" src="FVK/JavaScript/SendStatus.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<br />
    <h1 style="font-size:12px">Facebook Send Status</h1>
    <br />
    Facebook Send Status control is used to send a user status from your Facebook application or your Facebook 
    connect web site in the same way as from the Facebook itself. Before sending a status, you have to allow 
    the sending of user status by pressing the link "Allow updating status from the app!". Pressing on the 'Post' 
    button will result in sending of a status and execution of the event handler method inside your page which 
    can execute additional commands. For more information, look at:
    <br />
    <br />
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/send-user-status"  target="_blank">Facebook Send Status Tutorial</a></b>
    <br />
    <br />

    <fvk:sendstatus id="sendstatus1" runat="server" OnSendStatusCalled="OnSendStatus" />
    <br />
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
            <asp:Label ID="SendStatusHandlerLabel" runat="server" Text="" ForeColor="Green"></asp:Label>
       </ContentTemplate>
    </asp:UpdatePanel>
    
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
