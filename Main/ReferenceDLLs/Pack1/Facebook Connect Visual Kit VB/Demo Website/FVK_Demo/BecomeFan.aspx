<%@ Page Title="" Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="BecomeFan.aspx.vb" Inherits="FVK_Demo.BecomeFan" %>
<%@ Register TagPrefix="fvk" TagName="becomefan" Src="~/FVK/BecomeFan.ascx" %>
<%@ Register TagPrefix="fvk" TagName="loginbutton" Src="~/FVK/LoginButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Connect Become Fan control for ASP.NET</title>
    <meta name="description" content="ASP.NET Become Fan control for programming of Facebook Connect web sites in C# and VB.NET" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Fan Box</h1>
    
    <p style="text-align:justify">This control is used to allow the user to become a fan of your application. It can be used in 2 ways. 
    First one just enables the user to become a fan by pressing the link inside the control. The second one 
    can show messages from application wall and list of fans. For more information, look at: 
    
    <b><a href="http://vatlab.com/asp-net-facebook-controls/become-fan-box" target="_blank">Facebook Connect Become Fan</a></b>
    </p>
    
    <b>Note:</b> this control is obsolete and it is stil located in the component list because of backward compatibility. 
    Facebook recommends to use <a href="LikeBox.aspx">Facebook Like Box</a> instead.
    <br /><br />
    <fvk:becomefan ID="becomefan3" ConnectionsCount="10" ShowStream="true" runat="server" />
    <fvk:becomefan ID="becomefan1" runat="server" />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Facebook session is not established. Please login by pressing login button:" 
    Font-Bold="true" EnableViewState="false" Visible="false" />&nbsp;
    <fvk:loginbutton ID="loginbutton1" runat="server" Size="small" />
    <br /><br />
    
</asp:Content>
