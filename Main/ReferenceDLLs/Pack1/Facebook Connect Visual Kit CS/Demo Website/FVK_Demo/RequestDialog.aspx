<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RequestDialog.aspx.cs" Inherits="FVK_Demo.RequestDialog" %>
<%@ Register TagPrefix="fvk" TagName="request" Src="~/FVK/RequestDialog.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Request Dialog</h1>
    
    <p style="text-align:justify">Facebook Request Dialog is used to invite friends to start using an application, or to send request for some specific 
    action to application users. It is implemented as button and link on which user has to click to open the request dialog. There is also an option to 
    open it automatically on page load. For more information, look at:
    
    <b><a href="http://vatlab.com/asp-net-facebook-controls/request-dialog" target="_blank">Facebook Request Dialog Tutorial</a></b>
    </p>
    
    <fvk:request ID="request1" runat="server" 
      Message="Try Facebook Visual Kit - ASP.NET Facebook development library" 
    />
    <br /><br />
    
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
