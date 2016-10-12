<%@ Page Title="" Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="FVK_Demo.Default" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<%@ Register TagPrefix="fvk" TagName="likebox" Src="~/FVK/LikeBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ASP.NET Facebook Connect controls in C# and VB.NET</title>
    <meta name="description" content="How to make Facebook Connect site with ASP.NET. This site examples of usage of Facebook Connect Visual Kit library along as integration with Facebook Developer Toolkit" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 style="font-size:18px">Facebook Connect Visual Kit for ASP.NET</h1>
    
        <p style="text-align:justify">This website is used as an example on how to use Facebook Connect Visual Kit components. The components will make Facebook 
        applications development much faster and easier to maintain. Component list contains 14 of the most used ASP.NET controls 
        for Facebook Connect websites. Each component is supplemented with a demo page. All details about components and the 
        source code of this demo application are available for download at following web site:
     
        <b><a href="http://vatlab.com/facebook-asp-net-libs/facebook-connect-asp-net" target="_blank">Facebook Connect for ASP.NET</a></b>
        </p>
        <fvk:likebox ID="like1" runat="server" FansCount="0" ShowStream="false" PageId="224341998463" />
        <br /><br />
        <asp:Label ID="Label1" runat="server" Font-Bold="true" 
            Text="Facebook session is not established. Please login by pressing login button:" 
            Visible = "false"
        />&nbsp;
        <fvk:loginbutton id ="loginbutton1" runat="server" OnConnectCalled="OnConnected" Permissions="email" Size="small" />
</asp:Content>
