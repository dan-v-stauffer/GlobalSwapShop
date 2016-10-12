<%@ Page Title="" Language="C#" MasterPageFile="~/Components1Master.Master" AutoEventWireup="true" CodeBehind="Permissions.aspx.cs" Inherits="FVK_Demo.Permissions" %>
<%@ Register TagPrefix="fvk" TagName="permissions" Src="~/FVK/Permissions.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Permissions</h1>
    <br />
    Permission control is used to allow the user to add extended permissions, like sending upload images and status updates, 
    to Facebook application. The control also has an event handler which can be called if the permissions are added. This allows 
    a developer to add some extra code for different kinds of permissions. The control has 3 command types: link, button and auto 
    open on page load. For more information, look at:  
    <br />
    <br />
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/Facebook-permissions" target="_blank">Facebook Permissions Tutorial</a></b>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
            <fvk:permissions id="permissions1" runat="server" CommandType="button" PermissionList="publish_stream, video_upload" OnAddedPermission="OnAddPermission" />
            <br /><br />
            <asp:Label ID="PermAddedLabel" runat="server" ForeColor="Green" />
            <asp:Label ID="SendStatusHandlerLabel" runat="server" Text=""></asp:Label>
       </ContentTemplate>
    </asp:UpdatePanel>
    
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
   
</asp:Content>
