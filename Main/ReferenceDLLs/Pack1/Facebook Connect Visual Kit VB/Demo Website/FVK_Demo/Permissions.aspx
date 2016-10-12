<%@ Page Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Permissions.aspx.vb" Inherits="FVK_Demo.Permissions" %>
<%@ Register TagPrefix="fvk" TagName="permissions" Src="~/FVK/Permissions.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Permissions</h1>
    
    <p style="text-align:justify">Facebook Permission control is used to allow the user to add extended permissions, like sending upload images and status updates, 
    to Facebook application. The control also has an event handler which can be called if the permissions are added. This 
    allows a developer to add some extra code for different kinds of permissions. The control has 3 command types: link, 
    button and auto open on page load. For more information, look at:
    
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/Facebook-permissions" target="_blank">Facebook Permissions Tutorial</a></b>
    </p>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
            <fvk:permissions id="permissions1" runat="server" 
                CommandType="button" 
                Text="Add Permissions" 
                PermissionList="publish_stream, video_upload" 
                OnAddedPermission="OnAddPermission" 
             />
            <br /><br />
            <asp:Label ID="PermAddedLabel" runat="server" ForeColor="Green" />
       </ContentTemplate>
    </asp:UpdatePanel>
    
    <br />
    <asp:Label ID="ErrorLabel" runat="server" 
        Text="Facebook session is not established. Please login by pressing login button:" 
        Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;    
    <fvk:loginbutton ID="loginbutton1" runat="server" Visible ="false" Size="small" />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
