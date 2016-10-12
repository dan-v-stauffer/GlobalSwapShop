<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FVK_Demo.Default" %>
<%@ Register TagPrefix="fvk" TagName="likebox" Src="~/FVK/LikeBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
        <br />
        <h1 style="font-size:14px">Facebook Visual Kit for ASP.NET Demo</h1>
        <br />
        This application is used as an example on how to use Facebook Visual Kit components. The components will make 
        Facebook applications development much faster and easier to maintain. Component list contains 14 of the most 
        used ASP.NET controls for Facebook IFrame applications. Each component is supplemented with a demo page. All 
        details about components and the source code of this demo application are available for download at following web site:
        <br /><br />
        <b><a href="http://vatlab.com/Facebook-asp-net-libs/Facebook-asp-net-user-controls" target="_blank">ASP.NET Facebook Controls for iFrame Apps</a></b>
        
        <br /><br />
        <asp:Label ID="WelcomeLabel" runat="server" Font-Bold="true"></asp:Label>
        <br /><br />
        <fvk:likebox id="like1" runat="server" PageId="224341998463" FansCount="0" ShowStream="false" />
</asp:Content>

