<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InviteFriends.aspx.cs" Inherits="InviteFriends" %>
<%@ Register TagPrefix="fvk" TagName="inviteFriends" Src="~/FVK/InviteControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<fvk:inviteFriends ID="InviteFriends1" MainTitle = "<%$ Resources:GlobalSwapShop, INVITE_FRIENDS_MAIN_TITLE %>" Content="<%$ Resources:GlobalSwapShop, INVITE_FRIENDS_CONTENT %>" runat="server" />
</asp:Content>

