<%@ Page Title="" Language="C#" MasterPageFile="~/Components3Master.Master" AutoEventWireup="true" CodeBehind="BecomeFan.aspx.cs" Inherits="FVK_Demo.BecomeFan" %>
<%@ Register TagPrefix="fvk" TagName="becomefan" Src="~/FVK/BecomeFan.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <br />
    <h1 style="font-size:12px">Facebook Fan Box</h1>
    <br />
    This control is used to allow the user to become a fan of your application. It can be used in 2 ways. 
    First one just enables the user to become a fan by pressing the link inside the control. The second one 
    can show messages from application wall and list of fans. For more information, look at: 
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-Facebook-controls/become-fan-box" target="_blank">Facebook Become Fan Tutorial</a></b>
    <br /><br />
    <b>Note:</b> this control is obsolete and it is stil located in the component list because of backward compatibility. 
    Facebook recommends to use <a href="LikeBox.aspx?tab2tabIndex=3&tab1tabIndex=1">Like Box</a> instead.
    <br /><br />
    <fvk:becomefan ID="becomefan3" ConnectionsCount="10" ShowStream="true" runat="server" />
    <fvk:becomefan ID="becomefan1" runat="server" />
        
    <br /><br />
</asp:Content>
