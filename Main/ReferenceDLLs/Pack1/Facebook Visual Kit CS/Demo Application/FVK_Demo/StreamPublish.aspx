<%@ Page Title="" Language="C#" MasterPageFile="~/Components1Master.Master" AutoEventWireup="true" CodeBehind="StreamPublish.aspx.cs" Inherits="FVK_Demo.StreamPublish" %>
<%@ Register TagPrefix="fvk" TagName="streampublishpopup" Src="~/FVK/StreamPublishPopup.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
    <script type="text/javascript" src="FVK/JavaScript/JSON.js"></script>
    <script type="text/javascript" src="FVK/JavaScript/StreamPublishPopup.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Stream Publish Popup</h1>
    <br />
    This control is used to publish stories on user profile, friends' profiles or the Facebook page. The example shows how 
    easily you can publish a story on a user profile with different media types. All you have to do is to choose a type 
    of media you want to publish, and then press the publish button. The control has 3 command types: link, button and 
    auto open on page load. For more information, look at:
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/stream-publish-popup" target="_blank">Facebook Stream Publish Tutorial</a></b>
    <br /><br />
    <table>
        <tr>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="MediaDropDown" runat="server" AutoPostBack="true"
                            onselectedindexchanged="MediaDropDown_SelectedIndexChanged" Width="100px">
                            <asp:ListItem Value="Image" Text="Image" />
                            <asp:ListItem Value="Video" Text="Video" />
                            <asp:ListItem Value="Flash" Text="Flash" />
                            <asp:ListItem Value="Mp3" Text="Mp3" />
                        </asp:DropDownList>
                    </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="width:10px"></td>
            <td valign="top">
                <fvk:streampublishpopup ID="streampublish1" runat="server" OnPublishCalled="OnPublishStory" OnConfirmCalled="OnConfirmStory" />
                
            </td>
        </tr>
    </table>
    <br />
    <asp:UpdatePanel ID="PublishLabelUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:Label ID="PublishLabel" runat="server" ForeColor="Red"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    
   <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
   <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br />
</asp:Content>
