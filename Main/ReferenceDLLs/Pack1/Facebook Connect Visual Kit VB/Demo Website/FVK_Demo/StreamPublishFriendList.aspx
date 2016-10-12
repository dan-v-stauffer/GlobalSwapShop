<%@ Page Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="StreamPublishFriendList.aspx.vb" Inherits="FVK_Demo.StreamPublishFriendList" %>
<%@ Register TagPrefix="fvk" TagName="streampublishfriendlist" Src="~/FVK/StreamPublishFriendList.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Connect Stream Publish to Friends control for ASP.NET</title>
    <meta name="description" content="ASP.NET Stream Publish to Friends control for developing of Facebook Connect web sites in C# in VB.NET" />
    <script type="text/javascript" src="FVK/JavaScript/JSON.js"></script>
    <script type="text/javascript" src="FVK/JavaScript/StreamPublishPopup.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Stream Publish to Friends</h1>
    
    <p style="text-align:justify">This control is used to publish stories on a friend profile from the previously defined friend list. 
    The example demonstrates publishing of the image media type on a friend's profile from the list of 4 
    friends. To publish a story, choose a friend from the list and then press the publish button. 
    For more information, look at:
    
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/stream-publish-friends" target="_blank">Facebook Stream Publish to Friends Tutorial</a></b>
     </p>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
    <fvk:streampublishfriendlist ID="streampublish1" runat="server" OnPublishCalled="OnPublishStory" OnConfirmCalled="OnConfirmStory" />
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="PublishLabelUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:Label ID="PublishLabel" runat="server" Font-Bold="true"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
