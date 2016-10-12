using System;
using SpeechLib;
using GlobalSwapShop;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupportControls
{

    public partial class _support_Captcha_CaptchaControl : System.Web.UI.UserControl
    {
        #region field initialisation

        public Captcha cc;
        private int captchaLength;
        private double fontSize;
        private string fontFamily;
        private string backgroundImagePath;
        private string textColor;
        private string successMessage;
        private string errorMessage;
        private string characterSet;
        private string validationGroup;
        private bool validated = false;
        #endregion

        protected string captchaValue
        {
            get { return (ViewState["captcha"] != null) ? (string)ViewState["captcha"] : null; }
            set { ViewState["captcha"] = value; }
        }


        /// <summary>
        /// Set Captcha class properties
        /// </summary>
        private Captcha GetCaptchaClass()
        {
            if (Session["CaptchaClass"] != null)
                cc = (Captcha)Session["CaptchaClass"];
            else
                cc = new Captcha();

            cc.FontSize = this.FontSize;
            cc.FontFamily = this.FontFamily;
            cc.BackgroundImagePath = this.BackgroundImagePath;
            cc.TextColor = this.TextColor;
            return cc;
        }
        protected void Page_Prerender(object sender, EventArgs e)
        {
            int i = 10;
            i = i + 1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //B1.Text = TestButtonText;
            //B2.Text = ReLoadButtonText;
            //BSpeak.Text = SpeakButtonText;
            Label lbl = (Label)Utilities.FindControl(this.Controls, "captchaLenAlert");
            lbl.Text = String.Format(this.GetGlobalResourceObject("GlobalSwapShop", "CAPTCHA_LEN_INSTRUCTIONS").ToString(), CaptchaLength);

            SetValues();

            cc = GetCaptchaClass();

            if (!IsPostBack)
            {
                LoadCaptcha();
            }


        }

        /// <summary>
        /// Generates random text based on CharacterSet
        /// </summary>
        private string GetRandomText()
        {
            char[] letters = CharacterSet.ToCharArray();
            string text = string.Empty;
            Random r = new Random();
            int num = -1;

            for (int i = 0; i < this.CaptchaLength; i++)
            {
                num = (int)(r.NextDouble() * (letters.Length - 1));
                text += letters[num].ToString();
            }
            return text;
        }


        protected void ValidateCaptcha(object sender, EventArgs e)
        {
            string text = T1.Text;
            if (text.ToUpper() == ((string)Session["captcha"]).ToUpper())// (string)ViewState["captcha"])
                LStatus.Text = SuccessMessage;
            else
                LStatus.Text = ErrorMessage;
        }

        protected void LoadAnother(object sender, EventArgs e)
        {
            LoadCaptcha();
        }

        /// <summary>
        /// Set captcha
        /// </summary>
        private void LoadCaptcha()
        {
            string text = GetRandomText();

            //ViewState.Add("captcha", text);
            captchaValue = text;
            Session.Add("CaptchaClass", cc);//add captcha object to Session
            Session.Add("captcha", text);//add captcha text to session
            Im1.ImageUrl = "CaptchaHandler.ashx?fake=" + DateTime.Now.Ticks.ToString();
        }

        #region GetterSetter

        public bool isValid
        {
            get { return validated; }
        }

        public string TestButtonText
        {
            get { return B1.ToolTip; }
            set { B1.ToolTip = value; }
        }

        public string SpeakButtonText
        {
            get { return BSpeak.ToolTip; }
            set { BSpeak.ToolTip = value; }
        }

        public string ReLoadButtonText
        {
            get { return B2.ToolTip; }
            set { B2.ToolTip = value; }
        }

        public string SuccessMessage
        {
            get { return successMessage; }
            set { successMessage = value; }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        public int CaptchaLength
        {
            get { return captchaLength; }
            set
            {
                try
                {
                    int k = Convert.ToInt32(value);
                    if (k < 5 || k > 10)
                        captchaLength = 6;
                    else
                        captchaLength = k;
                }
                catch (Exception ex)
                {
                    captchaLength = 6;
                }
            }
        }

        public string FontFamily
        {
            get { return fontFamily; }
            set
            {
                if (value != string.Empty && value != null)
                    fontFamily = value;
                else
                    fontFamily = "Arial";
            }
        }

        public double FontSize
        {
            get { return fontSize; }
            set
            {
                try
                {
                    fontSize = Convert.ToInt32(value);
                    if (fontSize <= 10 && fontSize >= 24)
                        fontSize = 16;
                }
                catch (Exception ex)
                {
                    fontSize = 16;
                }
            }
        }

        public string BackgroundImagePath
        {
            get { return backgroundImagePath; }
            set
            {
                if (System.IO.File.Exists(Server.MapPath(value)))
                    backgroundImagePath = value;
                else
                    backgroundImagePath = System.Configuration.ConfigurationManager.AppSettings["defaultCaptchaImagePath"];
            }
        }

        public string TextColor
        {
            get { return textColor; }
            set
            {
                if (value == string.Empty || value == null)
                    textColor = "Black";
                else
                    textColor = value;
            }
        }

        public string CharacterSet
        {
            get { return characterSet; }
            set
            {
                if (value == "" || value == null)
                    characterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
                else
                    characterSet = value;
            }
        }

        #endregion

        /// <summary>
        /// Set default values of fields
        /// </summary>
        private void SetValues()
        {
            if (CharacterSet == null)
                CharacterSet = "";
            if (CaptchaLength == 0)
                CaptchaLength = 6;

            if (BackgroundImagePath == null)
                BackgroundImagePath = "";

            if (FontFamily == null)
                FontFamily = "";

            if (FontSize == 0)
                FontSize = 0.0;

            if (TextColor == null)
                TextColor = "";
        }

        /// <summary>
        /// Reads the captcha characters.
        /// </summary>
        protected void ReadCaptcha(object sender, EventArgs e)
        {
            SpVoice voice = new SpVoice();

            char[] text = ((string)Session["captcha"]).ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                voice.Speak(text[i].ToString(), SpeechVoiceSpeakFlags.SVSFDefault);
            }

        }
        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            Im1.ImageUrl = "CaptchaHandler.ashx?fake=" + DateTime.Now.Ticks.ToString();

        }

        protected void CaptchaCheck(Object sender, ServerValidateEventArgs args)
        {
            string captchaEntered = (string)args.Value;
            args.IsValid = (captchaEntered.ToUpper() == ((string)Session["captcha"]).ToUpper());
            validated = args.IsValid;
        }
}

}