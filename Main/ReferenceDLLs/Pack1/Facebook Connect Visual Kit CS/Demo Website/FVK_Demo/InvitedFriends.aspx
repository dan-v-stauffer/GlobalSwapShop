<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InvitedFriends.aspx.cs" Inherits="FVK_Demo.InvitedFriends" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook get invited friends</title>
    <meta name="description" content="How to get list of invited friends' ids with facebook invite control" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Invited Friends</h1>
    
    <p style="text-align:justify">This page shows a list of IDs of friends that are invited with facebook invite control. If list is not empty
    FQL query is called using Graph API to get friends' names.</p>
    <br />
    <h2 style="font-size:12px">Friends' IDs:</h2>
    <asp:Label ID="FriendIdsLabel" runat="server" Text="Label"></asp:Label>
    <br /><br />
    
    <h2 style="font-size:12px">Friends' names:</h2>
    <asp:Label ID="FriendsNamesLabel" runat="server" Text=""></asp:Label>
    <br /><br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
</asp:Content>
