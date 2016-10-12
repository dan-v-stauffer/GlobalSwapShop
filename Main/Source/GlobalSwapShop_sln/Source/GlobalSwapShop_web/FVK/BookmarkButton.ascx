<%@ Control AutoEventWireup="true" Inherits="FVK.BookmarkButton" %>
<span id="bookmarkSpan" runat="server"></span>
<asp:UpdatePanel ID="BookmarkButtonUpdatePanel" runat="server">
    <ContentTemplate>
        <asp:Button ID="BookmarkAddedButton" runat="server" CssClass="hidden" onclick="BookmarkAddedButton_Click" />
    </ContentTemplate>
</asp:UpdatePanel>
