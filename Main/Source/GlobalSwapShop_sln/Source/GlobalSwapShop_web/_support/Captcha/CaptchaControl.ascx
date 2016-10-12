<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CaptchaControl.ascx.cs"
    Inherits="SupportControls._support_Captcha_CaptchaControl" ViewStateMode="Enabled" %>
<asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="true" UpdateMode="Conditional"
    runat="server" OnLoad="UpdatePanel1_Load">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="B1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="B2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="BSpeak" EventName="Click" />
    </Triggers>
    <ContentTemplate>
    <div style="position:relative; left:5px; top:5px">
        <div style="position: relative; top: 0px; left: 0px; width: 150px; padding-top: 5px;
            padding-bottom: 5px; width: 100%">
            <asp:Label ID="captchaLenAlert" Font-Size="8pt"  CssClass="contact" runat="server"></asp:Label>
        </div>
        <div style="width: 100%; float: left; vertical-align: top; margin-bottom: 10px; position: relative">
            <div style="position: absolute; top: 0px; left: 0px">
                <asp:Image ID="Im1" runat="server" />
            </div>
            <div style="position: absolute; top: 0px; left: 150px; width: 20px">
                <asp:ImageButton ID="BSpeak" ImageUrl="~/_images/audio_icon.jpg" OnClick="ReadCaptcha"
                    Height="20" Width="20" runat="server" />
                <asp:ImageButton ID="B2" runat="server" ImageUrl="~/_images/reload_icon.gif" OnClick="LoadAnother" />
            </div>
            <div style="position: absolute; top: 0px; left: 175px">
                <asp:CustomValidator ID="cvCaptchaResult" runat="server" ErrorMessage=""></asp:CustomValidator>
            </div>
            <br />
            <br />
        </div>
        <div style="width: 100%; float: left; padding-top: 10px">
            <div style="position: relative; top: 5px; left: 0px;">
                <asp:TextBox ID="T1" Width="135" CssClass="contact_input" runat="server"></asp:TextBox>
            </div>
            <div style="position: relative; top: -15px; left: 150px; width: 20px;">
                <div style="position:absolute; left:0px; top:20px">
                <asp:ImageButton ID="B1" ImageUrl="~/_images/Checkmark.png" OnClick="ValidateCaptcha"
                    runat="server" /></div>
                <div style="position: absolute; left: 25px;top:0px; width: 150px">
                    <asp:Label CssClass="contact" ID="LStatus" runat="server"></asp:Label>
                </div>
            </div>
            <div style="width: 100%; color: Red; font-style: italic; position: relative; top:10px">
                <asp:CustomValidator ID="valCaptcha" runat="server" ErrorMessage="<%$ Resources:GlobalSwapShop, CAPTCHA_ERROR %>"
                    ControlToValidate="T1" OnServerValidate="CaptchaCheck" ForeColor="Red"></asp:CustomValidator>
            </div>
        </div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
