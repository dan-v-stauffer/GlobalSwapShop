<%@ Page Title="" Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LogoutButton.aspx.vb" Inherits="FVK_Demo.LogoutButton" %>
<%@ Register TagPrefix="fvk" TagName="logoutbutton" Src="~/FVK/LogoutButton.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Logout Button</h1>
    
    <p style="text-align:justify">Logout Button is used to log out from Facebook. If user is already logged on Facebook, pressing on the Login Button will
    result in executing of event handler where additional code can be executed, for example logout from web application or
    store data in DB. It also has properties for setting of title, CSS style and CSS class. For more information, look at:
    
    <b><a href="http://vatlab.com/asp-net-facebook-controls/facebook-connect-logout-button" target="_blank">Facebook Logout Button Tutorial</a></b>
    </p>

    <fvk:logoutbutton ID="logout1" runat="server" OnLogoutCalled="Logout" />
    <br /><br />
    <asp:Label ID="LogoutLabel" runat="server" Text="Logout event handler executed." Visible="false" EnableViewState="false"></asp:Label>
    <br /><br />
    <asp:Label ID="ErrorLabel" runat="server" 
        Text="Facebook session is not established. Please login by pressing login button:" 
        Font-Bold="true" EnableViewState="false" Visible="false" 
    />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Visible="false" Size="small" Permissions="email" />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
