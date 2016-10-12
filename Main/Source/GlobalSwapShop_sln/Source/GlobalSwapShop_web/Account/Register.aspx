<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<%@ Register Src="~/_support/Captcha/CaptchaControl.ascx" TagName="CaptchaControl"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="fjx" Namespace="com.flajaxian" Assembly="com.flajaxian.FileUploader" %>
<%@ Register TagPrefix="dmt" Namespace="FlajaxianCustomAdapters" Assembly="FlajaxianCustomAdapters" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
                'MainContent_RegisterUser_CreateUserStepContainer_imgUserAvatar').src = '../_images/loading.gif';
            raiseAsyncPostback();
        }

        function raiseAsyncPostback() {
            __doPostBack('ctl00$MainContent$RegisterUser$CreateUserStepContainer$upAvatarTrigger', "");
        }


    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="true" UpdateMode="Conditional"
        runat="server">
        <ContentTemplate>
            <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                        <ContentTemplate>
                            <h2>
                                <asp:Label ID="lblCreateUserHdr" runat="server" Text="<%$ Resources:GlobalSwapShop, CREATE_USER_HDR %>"></asp:Label>
                            </h2>
                            <p class="details">
                                <asp:Label ID="lblCreateUserDescription" runat="server" Text="<%$ Resources:GlobalSwapShop, CREATE_USER_DESCRIPTION %>"></asp:Label>
                            </p>
                            <p class="details">
                                <asp:Label ID="lblSetPasswordLenErr" runat="server" Text=""></asp:Label>
                            </p>
                            <span class="failureNotification">
                                <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                            </span>
                            <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
                                ValidationGroup="RegisterUserValidationGroup" />
                            <div class="accountInfo">
                                <fieldset class="register">
                                    <legend>
                                        <asp:Literal ID="ltrlRegUserTitle" Text="<%$ Resources:GlobalSwapShop, REGISTER_USER_TITLE %>"
                                            runat="server"></asp:Literal>
                                    </legend>
                                    <p>
                                        <asp:Label ID="UserNameLabel" runat="server" CssClass="contact" AssociatedControlID="UserName">User Name:</asp:Label>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="contact_input"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </p>
                                    <p>
                                        <asp:Label ID="EmailLabel" runat="server" CssClass="contact" AssociatedControlID="Email">E-mail:</asp:Label>
                                        <asp:TextBox ID="Email" runat="server" CssClass="contact_input"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                            CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </p>
                                    <p>
                                        <asp:Label ID="PasswordLabel" runat="server" CssClass="contact" AssociatedControlID="Password">Password:</asp:Label>
                                        <asp:TextBox ID="Password" runat="server" CssClass="contact_input" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </p>
                                    <p>
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword"
                                            CssClass="contact">Confirm Password:</asp:Label>
                                        <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="contact_input" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                                            Display="Dynamic" ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired"
                                            runat="server" ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                            ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                                            ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                                    </p>
                                    <p>
                                        <asp:Label ID="CountryLabel" runat="server" CssClass="contact" AssociatedControlID="Country">Country:</asp:Label>
                                        <asp:DropDownList ID="Country" CssClass="contact_input" Font-Size="Small" ForeColor="#999999"
                                            runat="server" Width="251px" DataSourceID="sqldsCountries" DataValueField="CountryCode"
                                            DataTextField="CountryName">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="sqldsCountries" runat="server" ConnectionString="<%$ ConnectionStrings:gss_backend %>"
                                            SelectCommand="sp_web_util_CountryList" SelectCommandType="StoredProcedure">
                                        </asp:SqlDataSource>
                                    </p>
                                    <p>
                                        <asp:Label ID="PostCodeLabel" CssClass="contact" runat="server" AssociatedControlID="PostCode">Post Code:</asp:Label>
                                        <asp:TextBox ID="PostCode" CssClass="contact_input" runat="server"></asp:TextBox>
                                    </p>
                                    <p style="position: relative; top: 20px">
                                        <asp:Label ID="AvatarLabel" runat="server" AssociatedControlID="imgUserAvatar" Width="200"
                                            CssClass="contact">Avatar Image:</asp:Label>
                                        <table style="position: relative;">
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
                                                        JsFunc_PercentageChanged="loadingImages" MaxNumberFiles="1" UseInsideUpdatePanel="true"
                                                        JsFunc_FileStateChanged="imageUploadComplete" IsSingleFileMode="true" BrowseButtonX="5"
                                                        BrowseButtonY="15" BrowseButtonWidth="60" BrowseButtonHeight="20" UploadButtonX="68"
                                                        UploadButtonY="15" UploadButtonWidth="60" UploadButtonHeight="20" CancelButtonX="131"
                                                        CancelButtonY="15" CancelButtonWidth="60" CancelButtonHeight="20" ProgressBarX="5"
                                                        ProgressBarY="1">
                                                        <Adapters>
                                                            <dmt:SessionThumbnailAdapter SessionImageTag="registrationAvatar" ImageHandlerURL="~/_support/imageHandler.ashx"
                                                                SessionImageBinaryTag="registrationAvatarBinaryID" />
                                                        </Adapters>
                                                    </fjx:FileUploader>
                                                </td>
                                            </tr>
                                        </table>
                                    </p>
                                    <p style="position:relative; top:-30px;">
                                        <asp:Label ID="lblCaptcha" CssClass="contact" runat="server" AssociatedControlID="captchaControlRegistration">User Verification:</asp:Label>
                                        <div style="float: left; position:relative; top:-50px; left:5px">
                                            <uc1:CaptchaControl ID="captchaControlRegistration" runat="server" TestButtonText="Try"
                                                BackgroundImagePath="~/images/captcha/captcha2.png" ErrorMessage="" SuccessMessage=""
                                                CaptchaLength="5" ValidationGroup="RegisterUserValidationGroup" CharacterSet="ABCDEFG123456"
                                                ReLoadButtonText="Reload" FontSize="20" FontFamily="Trebuchet MS" TextColor="Blue" />
                                            <asp:TextBox ID="captchaDummy" CssClass="hidden" Width="1" runat="server"></asp:TextBox>
                                        </div>
                                        <div style="float: left; position:relative; top:-30px">
                                            <asp:CustomValidator ID="valCaptcha" runat="server" CssClass="failureNotification"
                                                ValidationGroup="RegisterUserValidationGroup" Display="Dynamic" ValidateEmptyText="true"
                                                ErrorMessage="<%$ Resources:GlobalSwapShop, CAPTCHA_ERROR_SUMMARY %>" ToolTip="<%$ Resources:GlobalSwapShop, CAPTCHA_ERROR_SUMMARY %>"
                                                ControlToValidate="captchaDummy" OnServerValidate="CaptchaCheck" ForeColor="Red">*</asp:CustomValidator>
                                        </div>
                                    </p>
                                </fieldset>
                                <p>
                                    <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Register!"
                                        CssClass="register" ValidationGroup="RegisterUserValidationGroup" />
                                </p>
                            </div>
                        </ContentTemplate>
                        <CustomNavigationTemplate>
                        </CustomNavigationTemplate>
                    </asp:CreateUserWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
    </p>
</asp:Content>
