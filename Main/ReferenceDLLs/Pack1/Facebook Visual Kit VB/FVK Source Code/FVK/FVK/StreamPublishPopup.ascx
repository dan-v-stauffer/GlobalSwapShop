<%@ Control AutoEventWireup="true" Inherits="FVK.StreamPublishPopup" %>
<asp:UpdatePanel ID="StreamPublishUpdatePanel" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="NameHiddenField" runat="server" />
        <asp:HiddenField ID="HrefHiddenField" runat="server" />
        <asp:HiddenField ID="CaptionHiddenField" runat="server" />
        <asp:HiddenField ID="DescriptionHiddenField" runat="server" />
        <asp:HiddenField ID="MessagePromptHiddenField" runat="server" />
        <asp:HiddenField ID="UserMessageHiddenField" runat="server" />
        <asp:HiddenField ID="ActionLinksHiddenField" runat="server" Value="{}" />
        <asp:HiddenField ID="TargetIdHiddenField" runat="server" />
        <asp:HiddenField ID="ActorIdHiddenField" runat="server" />
        <asp:HiddenField ID="MediaHiddenField" runat="server" Value="{}" />
        <asp:HiddenField ID="PropertiesHiddenField" runat="server" Value="{}" />
        <asp:HiddenField ID="ReturnedPostIdHiddenField" runat="server" />
        
        <asp:Button ID="PublishButton" runat="server" Text="Publish" 
            CssClass="hidden" OnClientClick="StreamPublish(this)" onclick="PublishButton_Click" />
        <span id="streamPublishSpan" runat="server"></span>
        <asp:Button ID="ConfirmedSendButton" runat="server" CssClass="hidden" onclick="ConfirmedSendButton_Click" />
    </ContentTemplate>
</asp:UpdatePanel>
