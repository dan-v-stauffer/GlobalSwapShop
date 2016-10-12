<%@ Control AutoEventWireup="true" Inherits="FVK.StreamPublishFriendList" %>
<%@ Register TagPrefix="fb" TagName="streampublishpopup" Src="~/FVK/StreamPublishPopup.ascx" %>
<asp:UpdatePanel ID="StreamPublishFriendListUpdatePanel" runat="server">
    <ContentTemplate>
        <div class="boxdiv" style="width:420px;">
           <h2 class="boxtitle" style="font-size:11px"><asp:Label ID="titleLabel" runat="server" text="Send to Friends Wall" /></h2>
            <table>
                <tr>
                    <td colspan="2">
                        <table>
                            <tr>
                                <td valign="top" style="width:100%">
                                    <asp:Label ID="BoxTextLabel" runat="server"  />
                                </td>
                                <td valign="top" >
                                    <table>
                                        <tr>
                                            <td>
                                                <fb:streampublishpopup ID="streampublishpopup1" runat="server" OnPublishCalled="PublishButtonHandler" OnConfirmCalled="ConfirmedSendButtonHandler" />
                                            </td>
                                            <td>
                                                <asp:Button ID="HideButton" runat="server" Text="Hide" CssClass="button" 
                                                    onclick="HideButton_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Image ID="SelectedImage" runat="server" />
                    </td>
                    <td valign="top">
                        <div style="background:white none repeat scroll 0 0;border-style:none; font-size:9px;height:100px;margin-top:-1px;overflow:auto;padding:0px;width:230px;">
                            <span id="RadioItemsSpan" runat="server"></span>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
         </div>
    </ContentTemplate>
</asp:UpdatePanel>

