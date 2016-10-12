<%@ Control AutoEventWireup="true" Inherits="FVK.SendUserStatus" %>
<%@ Register TagPrefix="fvk" TagName="permissions" Src="Permissions.ascx" %>
<div id="Div1" class="boxdiv" style="width:450px" runat="server">
    <asp:UpdatePanel ID="SendUserStatusUpdatePanel" runat="server">
        <ContentTemplate>
            <div style="padding:5px">
                <asp:TextBox ID="SendStatusText" runat="server" text="What's on your mind?" Width="365px" Height="20px" ForeColor="Black" onfocus="OnStatusClick(this)" />&nbsp;
                <span id="ButtonSpan" runat="server"></span>
                <asp:Button ID="StatusSentButton" runat="server" OnClick="StatusSent" CssClass="hidden" />
                <asp:Button ID="SendErrorButton" runat="server" OnClick="StatusCannotBeSent" CssClass="hidden" />
                <fvk:permissions id="permissions1" runat="server" CommandType="link" PermissionList="status_update" Text="Allow updating status from the application!" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
 </div>