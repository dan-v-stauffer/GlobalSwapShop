<%@ Page Title="" Language="C#" MasterPageFile="~/Components1Master.Master" AutoEventWireup="true" CodeBehind="LikeBox.aspx.cs" Inherits="FVK_Demo.LikeBox" %>
<%@ Register TagPrefix="fvk" TagName="likebox" Src="~/FVK/LikeBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Like Box</h1>
    <br />
    This control is used to allow users of the web site to become fan of the Facebook page, see messages from 
    the page wall and people who are fans of the page. The example show creating 3 like boxes. The fist one is 
    default with 10 fans, show stream and show header. The second one is without fan list and the third one is 
    without fans and stream.
    <br /><br />                    
    For all details about the control with description of all optional properties please visit
    <b><a href="http://vatlab.com/asp-net-facebook-controls/facebook-like-box" target="_blank">Facebook Like Box</a></b>
    <br /><br />
    
    <fvk:likebox ID="Likebox1" runat="server" PageId="224341998463" Width="294" />
    <fvk:likebox ID="Likebox2" runat="server" PageId="224341998463" FansCount="0" Width="294" />
    <fvk:likebox ID="Likebox3" runat="server" PageId="224341998463" FansCount="0" ShowStream="false" Width="150" />
</asp:Content>
