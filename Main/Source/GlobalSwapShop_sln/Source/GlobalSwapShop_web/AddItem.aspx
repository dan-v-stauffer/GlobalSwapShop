<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AddItem.aspx.cs" Inherits="AddItem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="fjx" Namespace="com.flajaxian" Assembly="com.flajaxian.FileUploader" %>
<%@ Register TagPrefix="dmt" Namespace="FlajaxianCustomAdapters" Assembly="FlajaxianCustomAdapters" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="~/Styles/style.css" />
    <script type="text/javascript">
        function imageUploadComplete(uploader, file, httpStatus, isLast) {
            Flajaxian.fileStateChanged(uploader, file, httpStatus, isLast);
            if (file.state > Flajaxian.File_Uploading && isLast) {
                raiseAsyncPostback();
            }
            return false;
        }

        function loadingImages(uploader, file, httpStatus, isLast) {
            document.getElementById(
                'MainContent_imgUserAvatar').src = '_images/loading.gif';
            raiseAsyncPostback();
        }

        function raiseAsyncPostback() {
            __doPostBack('ctl00$MainContent$upAvatarTrigger', "");
        }


    </script>
    <style type="text/css">
        .test
        {
            width: 247px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="border:4px solid blue">
        <tr>
            <td style="text-align:left; vertical-align:top">
                <asp:Label ID="ItemName" runat="server" Text="Name:" CssClas="contact" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="ItemNameText" runat="server" CssClass="item_name"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ItemDescription" runat="server"  Text="Description:" CssClas="contact" AssociatedControlID="ItemDescription"></asp:Label>
            </td>  
            <td> 
                <asp:TextBox ID="ItemDescriptionText" TextMode="multiline" runat="server" CssClass="item_description"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="text-align:left; vertical-align:top">
                <asp:Label ID="ItemLocation" runat="server" Text="Location:" CssClas="contact" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="ItemLocationText" runat="server" CssClass="item_name"></asp:TextBox>
            </td>
        </tr>
        <tr>
        
            <td colspan="2">
                <asp:Label IubmitD="AvatarLabel" runat="server" AssociatedControlID="imgUserAvatar" Width="200"
                    CssClas="contact">Upload Item Image:</asp:Label>
            </td>
             
        </tr>
        
        <tr>
            
            <td>
                <asp:UpdatePanel ID="upAvatar" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="upAvatarTrigger" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:Image ID="imgUserAvatar" runat="server" Height="65" Width="65" BorderColor="Silver"
                            BorderWidth="1" BorderStyle="Solid" ImageUrl="~/_images/no_image_available.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="upAvatarTrigger" runat="server" Style="display: none;"> 
                LinkButton 
                </asp:LinkButton>
            </td>
   
            <td style="vertical-align: top">
                <fjx:FileUploader ID="fjxUploader" runat="server" AppendToUrlFileIndex="False" MaxFileSize="500KB"
                    ProgressBarWidth="186" ImagesPath="~/_images/buttons/" BrowseButtonUrl="browse_button_60x20.png"
                    BrowseButtonOverUrl="browse_button_hover_60x20.png" BrowseButtonPressedUrl="browse_button_pressed_60x20.png"
                    CancelButtonUrl="cancel_button_60x20.png" CancelButtonOverUrl="cancel_button_hover_60x20.png"
                    CancelButtonPressedUrl="cancel_button_pressed_60x20.png" UploadButtonUrl="upload_button_60x20.png"
                    UploadButtonOverUrl="upload_button_hover_60x20.png" UploadButtonPressedUrl="upload_button_pressed_60x20.png"
                    CancelButtonDisabledUrl="xcancel_button_disabled_60x20.png" UploadButtonDisabledUrl="xupload_button_disabled_60x20.png"
                    ProgressBorderColor="#006666" BrowseButtonDisabledUrl="browse_button_disabled_60x20.png"
                    JsFunc_PercentageChanged="loadingImages" MaxNumberFiles="1" UseInsideUpdatePanel="True"
                    JsFunc_FileStateChanged="imageUploadComplete" IsSingleFileMode="true" BrowseButtonX="5"
                    BrowseButtonY="15" BrowseButtonWidth="60" BrowseButtonHeight="20" UploadButtonX="68"
                    UploadButtonY="15" UploadButtonWidth="60" UploadButtonHeight="20" CancelButtonX="131"
                    CancelButtonY="15" CancelButtonWidth="60" CancelButtonHeight="20" ProgressBarX="5"
                    ProgressBarY="1">
                    <Adapters>
                        <dmt:SessionThumbnailAdapter SessionImageTag="addItemImage" ImageHandlerURL="~/_support/imageHandler.ashx" SessionImageBinaryTag="addItemImageBinaryID"/>
                    </Adapters>
                </fjx:FileUploader>
            </td>

            </tr>   
            <tr>
                <td colspan="2">
                    <div style="position:relative;float:right;margin-top:30px">
                         <asp:Button ID="Cancel" runat="server" Text="Cancel"
                                CssClass="register" />
                    </div>
                    <div style="position:relative;float:right; margin-top:30px; margin-right:5px">
                        <asp:Button ID="OK" runat="server" Text="OK"
                                CssClass="register" ValidationGroup="AddItemValidationGroup" />
                    </div>
                </td>
        </tr>     
    </table>
    
</asp:Content>
