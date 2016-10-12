<%@ Page Title="" Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LoginButton.aspx.vb" Inherits="FVK_Demo.LoginButton" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Connect Login Button for ASP.NET</title>
    <meta name="description" content="ASP.NET login button control for Facebook Connect web sites." />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Login Button</h1>
    
    <p style="text-align:justify">Login Button control is used to connect a web site to the Facebook and allow it to use the Facebook API. 
    It also enables the user that once he is logged, all controls from this list will work without additional 
    logging. The control also has an event handler to execute additional code when the user is logged in. 
    Without logging some of the controls from the list would not be displayed correctly. Log in now, if you 
    haven't done it already, to enable the correct functioning of all components. For more information, look at:</p>
    
    <b><a href="http://vatlab.com/asp-net-facebook-controls/facebook-connect-login-button" target="_blank">Facebook Login Button Tutorial</a></b>
    <br /><br /><br />
     Default login button with email extended permissions:
    <br /><br />
    <fvk:loginbutton ID="logginButton1" runat="server" OnConnectCalled="OnConnected" Permissions="email" />
    <br /><br /><br />
    Small size and default title:
    <br /><br />
    <fvk:loginbutton id ="logginButton2" runat="server" Size="small" OnConnectCalled="OnConnected"  />
    <br /><br /><br />
    Default (medium) size and user defined title:
    <br /><br />
    <fvk:loginbutton id ="Loginbutton3" Title="Connect with Facebook" runat="server" OnConnectCalled="OnConnected" />
    <br /><br /><br />
    Large size and user defined title:
    <br /><br />
    <fvk:loginbutton id ="Loginbutton1" Title="Login with Facebook" Size="large" runat="server" OnConnectCalled="OnConnected" />
    <br /><br />
    <asp:Label ID="ConnectLabel" runat="server" Text="Connect Button is successfully triggered !!" Visible="false" Font-Bold="true"></asp:Label>
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button." 
        Font-Bold="true" EnableViewState="false" Visible="false" />    
</asp:Content>
