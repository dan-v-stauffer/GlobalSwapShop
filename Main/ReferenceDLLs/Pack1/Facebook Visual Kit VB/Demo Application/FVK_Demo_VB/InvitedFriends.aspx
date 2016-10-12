<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="InvitedFriends.aspx.vb" Inherits="FVK_Demo.InvitedFriends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1 style="font-size:12px">Invited Friends</h1>
    <br />
    This page shows a list of IDs of friends that are invited with facebook invite control. If list is not empty
    FQL query is called using Graph API to get friends' names.
    <br /><br />
    <h2 style="font-size:12px">Friends' IDs:</h2>
    <asp:Label ID="FriendIdsLabel" runat="server" Text="Label"></asp:Label>
    <br /><br />
    
    <h2 style="font-size:12px">Friends' names:</h2>
    <asp:Label ID="FriendsNamesLabel" runat="server" Text=""></asp:Label>
    <br /><br />
</asp:Content>
