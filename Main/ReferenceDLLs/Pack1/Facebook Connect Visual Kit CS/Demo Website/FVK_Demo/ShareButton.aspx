<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShareButton.aspx.cs" Inherits="FVK_Demo.ShareButton" %>
<%@ Register TagPrefix="fvk" TagName="sharebutton" Src="~/FVK/ShareButton.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Facebook Share Button for ASP.NET</title>
    <meta name="description" content="ASP.NET Share button control for Facebook Connect web sites." />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:18px">Facebook Share Button</h1>
    
    <p style="text-align:justify">If you want to enable the use to share something with their friends, like some information about your application, 
    Facebook connect web site or any other interesting internet resource, use this control. There are 5 shapes of share 
    buttons displayed bellow. For more information, look at:
    
    <b><a href="http://vatlab.com/asp-net-facebook-controls/facebook-share-button" target="_blank">Facebook Share Button Tutorial</a></b>
    </p>
    
    <b>Note:</b> this control is obsolete and it is stil located in the component list because of backward compatibility. 
    Facebook recommends to use <a href="LikeButton.aspx">Like Button</a> instead.
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
    
    <br />
    <br /><br />
</asp:Content>
