<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="SendButton.aspx.vb" Inherits="FVK_Demo.SendButton" %>
<%@ Register TagPrefix="fvk" TagName="sendbutton" Src="~/FVK/SendButton.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1 style="font-size:18px">Facebook Send Button</h1>
    
    <p style="text-align:justify">Facebook Send Button is used by users of website to share interesting content with their friends by selecting them from friends list. 
    This will result in sending the message to friends' inbox. There is also an option to send it to the wall of group that user is fan of, or any email address. 
    For more information, look at:
    <b><a href="http://vatlab.com/asp-net-facebook-controls/send-button" target="_blank">Facebook Send Button Tutorial</a></b>
    </p>
    
    <br />
    <fvk:sendbutton ID="Like1" runat="server" Url="http://vatlab.com" />
    <br /><br />
    
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
