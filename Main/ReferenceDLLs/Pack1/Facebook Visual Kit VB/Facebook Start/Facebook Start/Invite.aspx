﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Invite.aspx.vb" Inherits="FacebookStart.Invite" %>
<%@ Register TagPrefix="fb" TagName="invite" Src="~/FVK/InviteControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <fb:invite ID="invite1" runat="server"
        Content = "Invite your friends on this app"
        MainTitle = "Invite your friends to use this app."
     />
</asp:Content>