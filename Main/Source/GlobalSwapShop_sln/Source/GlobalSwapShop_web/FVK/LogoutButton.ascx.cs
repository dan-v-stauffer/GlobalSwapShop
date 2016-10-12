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
    /// <summary>
    /// Logout Button is used to log out from Facebook. If user is already logged on Facebook, pressing 
    /// on the Login Button will result in executing of event handler where additional code can be executed
    /// </summary>
    public partial class LogoutButton : System.Web.UI.UserControl
    {
        /// <summary>
        /// Inform client about logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void LogoutHandler(object sender, EventArgs e);
        public event LogoutHandler LogoutCalled;

        /// <summary>
        /// Button Title
        /// </summary>
        public string Title { set { title = value; } }

        /// <summary>
        /// CSS class of the button
        /// </summary>
        public string CssClass { set { cssClass = value; } }

        /// <summary>
        /// CSS style of the style
        /// </summary>
        public string CssStyle { set { cssStyle = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            string spanId = logoutSpan.ClientID;
            html.Append("<script>\n");
            html.Append("  function DoLogout" + spanId + "() {\n");
            html.Append("    FB.logout(function(response) {\n");
            html.Append("      var button = document.getElementById('" + OnLogoutButton1.ClientID + "');\n");
            html.Append("      button.click();\n");
            html.Append("    });\n");
            html.Append("  }\n");
            html.Append("</script>\n");
            html.Append("<input type=\"button\" class=\"" + cssClass + "\" onclick=\"DoLogout" + spanId + "()\" value=\""+ title +"\" style=\"" + cssStyle +"; cursor:pointer\" />\n");
            logoutSpan.InnerHtml = html.ToString();
        }

        protected void OnLogoutButton1_Click(object sender, EventArgs e)
        {
            if (LogoutCalled != null)
            {
                LogoutCalled(sender, e);
            }
        }

        private string cssClass = "button";
        private string cssStyle = "font-weight:bold";
        private string title = "Logout";
    }
}