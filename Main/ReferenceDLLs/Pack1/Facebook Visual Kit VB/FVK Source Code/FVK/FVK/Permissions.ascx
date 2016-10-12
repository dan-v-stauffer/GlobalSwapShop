<%@ Control AutoEventWireup="true" Inherits="FVK.Permissions" %>
<asp:HiddenField ID="AddedPermissionsHiddenField" runat="server" />
<asp:Button ID="PermButton" runat="server" Text="Button" CssClass="hidden" 
    onclick="PermButton_Click" />
<span id="permissionsSpan" runat="server">
</span>

    