<%@ Page Title="" Language="C#" MasterPageFile="~/Components2Master.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="FVK_Demo.Comments" %>
<%@ Register TagPrefix="fvk" TagName="comments" Src="~/FVK/Comments.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<br />
    <h1 style="font-size:12px">Facebook Comments</h1>
    <br />
    This control is used to allow a user of your web site to write comments and share them with their friends 
    by posting them on their profiles. Posting a comment on user's wall will result in more visitors from the 
    Facebook to your site. For more information, look at:
    <br /><br />
    <b><a href="http://vatlab.com/asp-net-facebook-controls/comment-box" target="_blank">Facebook Connect Comments Box</a></b>
    <br /><br />
    <fvk:comments ID="comments1" runat="server" Xid="commentbox1" />
    <br />
    <br />
    <br />
</asp:Content>
