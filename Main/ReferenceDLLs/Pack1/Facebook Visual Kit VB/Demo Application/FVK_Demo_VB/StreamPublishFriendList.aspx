<%@ Page Title="" Language="C#" MasterPageFile="~/Components3Master.Master" AutoEventWireup="true" CodeBehind="StreamPublishFriendList.aspx.cs" Inherits="FVK_Demo.StreamPublishFriendList" %>
<%@ Register TagPrefix="fvk" TagName="streampublishfriendlist" Src="~/FVK/StreamPublishFriendList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
    <script type="text/javascript" src="FVK/JavaScript/JSON.js"></script>
    <script type="text/javascript" src="FVK/JavaScript/StreamPublishPopup.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Stream Publish to Friends</h1>
    <br />
    This control is used to publish stories on a friend profile from the previously defined friend list. 
    The example demonstrates publishing of the image media type on a friend's profile from the list of 4 
    friends. To publish a story, choose a friend from the list and then press the publish button. For more 
    information, look at:  
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/stream-publish-friends" target="_blank">Facebook Stream Publish to Friends Tutorial</a></b>
    <br /><br />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
    <fvk:streampublishfriendlist ID="streampublish1" runat="server" OnPublishCalled="OnPublishStory" OnConfirmCalled="OnConfirmStory" />
    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="PublishLabelUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:Label ID="PublishLabel" runat="server" ForeColor="Red"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
     <br />
    <br />
    
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
