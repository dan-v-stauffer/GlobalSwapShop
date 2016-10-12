<%@ Page Language="C#" MasterPageFile="~/Components1Master.Master" AutoEventWireup="true" CodeBehind="SendButton.aspx.cs" Inherits="FVK_Demo.SendButton" %>
<%@ Register TagPrefix="fvk" TagName="sendbutton" Src="~/FVK/SendButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Send Button</h1>
    <br />
    Facebook Send Button is used by users of website to share interesting content with their friends by selecting them from friends list. 
    This will result in sending the message to friends' inbox. There is also an option to send it to the wall of group that user is fan of, or any email address. 
    For more information, look at:
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-facebook-controls/send-button" target="_blank">Facebook Send Button Tutorial</a></b>
    <br /><br />
    <fvk:sendbutton ID="Send1" runat="server" Url="http://vatlab.com" />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>