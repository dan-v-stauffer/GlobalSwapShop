// WARNING: 
// The source code of this class can be used and modified to your particular needs. 
// Sharing the class with unregistered users or using it with unregistered websites 
// or Facebook applications is not allowed and violates the rights of intellectual 
// property. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace FVK
{
    public partial class InitFVK : System.Web.UI.UserControl
    {
        /// <summary>
        /// Set Language code of all XFBML based controls. Default value is 'en_US'.
        /// You can find all language codes at: http://www.facebook.com/translations/FacebookLocales.xml
        /// </summary>
        public string Language { set { language = value; } }

        /// <summary>
        /// Check login status. Default is true
        /// </summary>
        public bool CheckLoginStatus { set { checkLoginStatus = value; } }

        /// <summary>
        /// Use Cookie. Default is true
        /// </summary>
        public bool UseCookie { set { useCookie = value; } }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<div id='fb-root'></div>\n");
            html.Append("<script>\n");
            html.Append("var graphApiInitialized = false;\n");
            html.Append("  window.fbAsyncInit = function() {\n");
            html.Append("    FB.init({\n");
            html.Append("      appId  : '" + FVKConfig.AppId + "',\n");
            html.Append("      status : " + checkLoginStatus.ToString().ToLower() + ",\n");
            html.Append("      cookie : " + useCookie.ToString().ToLower() + ",\n");
            html.Append("      xfbml  : true\n");
            html.Append("    });\n");
            html.Append("    graphApiInitialized = true;\n");
            html.Append("  };\n");
            html.Append("  (function() {\n");
            html.Append("    var e = document.createElement('script');\n");
            html.Append( "    e.src = document.location.protocol + '//connect.facebook.net/" + language + "/all.js';\n");
            html.Append("    e.async = true;\n");
            html.Append("    document.getElementById('fb-root').appendChild(e);\n");
            html.Append("  }());\n");
            
            html.Append("</script>\n");

            contentSpan.InnerHtml = html.ToString();
        }

        private string language = "en_US";
        private bool checkLoginStatus = true;
        private bool useCookie = true;
    }
}