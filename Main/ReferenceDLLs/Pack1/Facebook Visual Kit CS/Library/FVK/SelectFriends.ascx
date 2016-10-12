<%@ Control AutoEventWireup="true" Inherits="FVK.SelectFriends" %>
<div id="selectfriendsdiv" runat="server" class="selectfriendsdiv" style="height:250px; width:360px">
    <asp:UpdatePanel ID="SelectFriendsUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="TempList" runat="server" />
            <asp:Button ID="InitButton" runat="server" Text="Button" OnClick="SelfInitialize" CssClass="hidden" />
            <asp:Repeater ID="FriendsRepeater" runat="server">
                <ItemTemplate>
                    <div style="width:170px; height:25px; float:left;">
                        <asp:CheckBox ID="FriendCheckBox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>' Checked='<%# DataBinder.Eval(Container.DataItem, "selected") %>' AutoPostBack="true"
                            oncheckedchanged="FriendCheckBox_CheckedChanged" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
             <span id="scriptSpan" runat="server"></span>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
   
