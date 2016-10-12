<%@ Page Title="" Language="C#" MasterPageFile="~/Components3Master.Master" AutoEventWireup="true" CodeBehind="ShareButton.aspx.cs" Inherits="FVK_Demo.ShareButton" %>
<%@ Register TagPrefix="fvk" TagName="sharebutton" Src="~/FVK/ShareButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <h1 style="font-size:12px">Facebook Share Button</h1>
    <br />
    If you want to enable the use to share something with their friends, like some information about your application, 
    Facebook connect web site or any other interesting internet resource, use this control. There are 5 shapes of share 
    buttons displayed bellow. For more information, look at: 
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-facebook-controls/facebook-share-button" target="_blank">Facebook Connect Share Button</a></b>
    <br /><br />
    <b>Note:</b> this control is obsolete and it is stil located in the component list because of backward compatibility. 
    Facebook recommends to use <a href="LikeButton.aspx?tab2tabIndex=4&tab1tabIndex=1">Like Button</a> instead.
    <br /><br />
    <table>
        <tr>
            <td style="width:130px">Icon</td>
            <td style="width:130px">Icon Link</td>
            <td style="width:130px">Button</td>
            <td style="width:130px">Button Count</td>
            <td style="width:130px">Box Count</td>
        </tr>
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td valign="top">
                <fvk:sharebutton id="sharebutton1" Type="icon" runat="server" Url="http://vatlab.com" />
            </td>
            <td valign="top">
                <fvk:sharebutton id="sharebutton2" Type="icon_link" runat="server" Url="http://vatlab.com" />
            </td>
            <td valign="top">
                <fvk:sharebutton id="sharebutton3" Type="button" runat="server" Url="http://vatlab.com" />
            </td>
            <td valign="top">
                <fvk:sharebutton id="sharebutton4" Type="button_count" runat="server" Url="http://vatlab.com" />
            </td>
            <td valign="top">
                <fvk:sharebutton id="sharebutton5" Type="box_count" runat="server" Url="http://vatlab.com" />
            </td>
        </tr>
        
    </table>
</asp:Content>
