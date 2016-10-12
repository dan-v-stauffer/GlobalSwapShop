<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="DataAccess.aspx.vb" Inherits="FVK_Demo.DataAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
    <h1 style="font-size:12px">Graph API Data Access</h1>
    <br />
    This page shows how to access data using Facebook C# SDK. The first example shows how<br />
    to access user information and the second one shows how to get a list of 5 user's friends.
    <br /><br />
    <h2 style="font-size:11px">User data:</h2>
    <br />
    User Id: <asp:Label ID="UserIdLabel" runat="server" Text="Label"></asp:Label>
    <br />
    User Name: <asp:Label ID="UserNameLabel" runat="server" Text="Label"></asp:Label>
    <br />
    User Email: <asp:Label ID="UserEmailLabel" runat="server" Text="Label"></asp:Label>
    <br />
    
    <br /><br />
    <h2 style="font-size:11px">Friend list:</h2>
    <br />
    <asp:Label ID="FriendsLabel" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Connection with Facebook is not yet established" ForeColor="Red" EnableViewState="false" Visible="false"></asp:Label>    
    <br />
    <br />
    <br />
    <br />
</asp:Content>
