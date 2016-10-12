<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" 
AutoEventWireup="true" CodeFile="PrivacyPolicy.aspx.cs"  UICulture="auto" Inherits="PrivacyPolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <%--  <asp:HyperLink ID="HyperLink1" NavigateUrl="~/TermsOfUse.aspx" runat="server">HyperLink</asp:HyperLink>
--%>
    <asp:Label ID="PrivacyPolicy1" runat="server" 
        Text="<%$ Resources:GlobalSwapShop, PRIVACY_POLICY %>"></asp:Label>
   

</asp:Content>

