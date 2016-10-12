<%@ Page Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SelectFriends.aspx.vb" Inherits="FVK_Demo.SelectFriends" %>
<%@ Register TagPrefix="fvk" TagName="selectfriends" Src="~/FVK/SelectFriends.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Connect Select Friends control for ASP.NET</title>
    <meta name="description" content="ASP.NET Select Friends control for developing of Facebook Connect web sites in C# and VB.NET." />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Select Facebook Friends</h1>
    
    <p style="text-align:justify">This control is used for easy selection of your Facebook friends. The control is customizable and supports 2 types 
    of filters and 2 types of selection. Number of rows and columns is also customizable. Click on one or more of your 
    friends, or use one of buttons, to see how the label is changed depending on your selection. For more information, 
    look at:
    
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/select-friends-box" target="_blank">Facebook Select Friends Tutorial</a></b>
    </p>
     
    <fvk:selectfriends id="selectfriends1" runat="server" 
        Rows = "4"
        Columns = "3"
        OnSelectionChanged="OnSelectedFriends" 
    />
    
    <br />
    <asp:UpdatePanel ID="SelectedFriendsLabelUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:Label ID="SelectedFriendsLabel" runat="server" Text="Selected Friends:" ForeColor="Blue"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <b>Filter Features:</b> (type something and press one of the buttons)
    <asp:UpdatePanel ID="FiltersUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="FilterTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="FilterIfStartsWithButton" runat="server" Text="Filter if Starts With" 
                CssClass="button" onclick="FilterIfStartsWithButton_Click" />
            <asp:Button ID="FilterIfContainsButton" runat="server" Text="Filter if Contains" 
                CssClass="button" onclick="FilterIfContainsButton_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <br />
    <br />
    <b>Selection Features:</b> (press one of the buttons to see the change in selection)
    <asp:UpdatePanel ID="SelectorsUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:Button ID="SelectAllButton" runat="server" Text="Select All" 
                CssClass="button" onclick="SelectAllButton_Click" />
            <asp:Button ID="UnselectAllButton" runat="server" Text="Unselect All" 
                CssClass="button" onclick="UnselectAllButton_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />    
    <br />
</asp:Content>
