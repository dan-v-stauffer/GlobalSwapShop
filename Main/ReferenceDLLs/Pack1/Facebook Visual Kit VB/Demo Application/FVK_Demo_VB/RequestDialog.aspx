<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Components1Master.Master" CodeBehind="RequestDialog.aspx.vb" Inherits="FVK_Demo.RequestDialog" %>
<%@ Register TagPrefix="fvk" TagName="request" Src="~/FVK/RequestDialog.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Request Dialog</h1>
    <br />
    Facebook Request Dialog is used to invite friends to start using an application, or to send request for some specific 
    action to application users. It is implemented as button and link on which user has to click to open the request dialog. There is also an option to 
    open it automatically on page load. For more information, look at:
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-facebook-controls/request-dialog" target="_blank">Facebook Request Dialog Tutorial</a></b>
    <br /><br />
     <fvk:request ID="request1" runat="server" 
      Message="Try Facebook Visual Kit - ASP.NET Facebook development library" 
    />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>