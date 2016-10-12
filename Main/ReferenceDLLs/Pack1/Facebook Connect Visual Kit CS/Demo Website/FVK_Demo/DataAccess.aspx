<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DataAccess.aspx.cs" Inherits="FVK_Demo.DataAccess" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Graph API get user data and friends with .NET</title>
    <meta name="description" content="How to get user and friends data using Facebook C# and VB.NET" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Graph API Data Access</h1>
    <p style="text-align:justify">This page shows how to access data using Facebook C# SDK. The first example shows how<br />
    to access user information and the second one shows how to get a list of 5 user's friends.</p>
    <br />
    <h2 style="font-size:11px">User data:</h2>
    <br />
    User Id: <asp:Label ID="UserIdLabel" runat="server"></asp:Label>
    <br />
    User Name: <asp:Label ID="UserNameLabel" runat="server"></asp:Label>
    <br />
    User Email: <asp:Label ID="UserEmailLabel" runat="server"></asp:Label>
    <br />
    
    <br /><br />
    <h2 style="font-size:11px">Friend list:</h2>
    <br />
    <asp:Label ID="FriendsLabel" runat="server"></asp:Label>
    <br />
    <br />
    
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
     <fvk:loginbutton ID="loginbutton1" runat="server" Permissions="email" />
    
    <br />
    <br />
    <br />
    <br />
</asp:Content>
