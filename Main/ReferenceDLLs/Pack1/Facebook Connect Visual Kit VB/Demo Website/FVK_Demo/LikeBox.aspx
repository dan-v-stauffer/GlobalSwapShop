<%@ Page Title="" Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LikeBox.aspx.vb" Inherits="FVK_Demo.LikeBox" %>
<%@ Register TagPrefix="fvk" TagName="likebox" Src="~/FVK/LikeBox.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Like Box</h1>
    
    <p style="text-align:justify">This control is used to allow users of the web site to become fan of the Facebook page, see messages from 
    the page wall and people who are fans of the page. The example show creating 3 like boxes. The fist one is 
    default with 10 fans, show stream and show header. The second one is without fan list and the third one is 
    without fans and stream.
                    
    For all details about the control with description of all optional properties please visit
    <b><a href="http://vatlab.com/asp-net-facebook-controls/facebook-like-box" target="_blank">Facebook Like Box Tutorial</a></b>.
    </p>
    
    <fvk:likebox ID="Likebox1" runat="server" PageId="224341998463" />
    <fvk:likebox ID="Likebox2" runat="server" PageId="224341998463" FansCount="0" />
    <fvk:likebox ID="Likebox3" runat="server" PageId="224341998463" FansCount="0" ShowStream="false" Width="160" />
    <br /><br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
