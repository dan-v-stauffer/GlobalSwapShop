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
    /// Facebook Share Button uses to share some interesting links or link of your Facebook application, 
    /// your Facebook Connect web site or Facebook Page with user friends. Using a share button a new 
    /// story is published on user wall with link defined with share button.
    /// </summary>

    [Obsolete("You should use Facebook Like Button control instead")]
    public partial class ShareButton : System.Web.UI.UserControl
    {
        /// <summary>
        /// Type of share button (icon, icon_link, button, button_count, box_count), default = icon_link
        /// </summary>
        public string Type
        {
            set 
            {
                if (value != "icon" && value != "icon_link" && value != "button" && value != "button_count" && value != "box_count")
                {
                    throw new Exception("Share Button type is invalid. Valid values are icon, icon_link, button, button_count and box_count");
                }
                type = value; 
            }
        }

        /// <summary>
        /// Set title of Share button
        /// </summary>
        public string Title
        {
            set { title = value; }
        }

        /// <summary>
        /// Set Url
        /// </summary>
        public string Url
        {
            set { url = value; }
        }

        /// <summary>
        /// Refresh dispay of the control
        /// </summary>
        public void Refresh()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<a name=\"fb_share\" ");
            str.Append("type=\"");
            str.Append(type);
            str.Append("\" href=\"http://www.facebook.com/sharer.php\"");
            if (url != null)
            {
                str.Append(" share_url=\"");
                str.Append(url);
                str.Append("\">");
            }
            str.Append(title);
            str.Append("</a><script src=\"http://static.ak.fbcdn.net/connect.php/js/FB.Share\" type=\"text/javascript\"></script>");
            sharebuttonspan.InnerHtml = str.ToString();
        }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
            }
        }


        /// <summary>
        /// Private members
        /// </summary>
        private string url = null;
        private string type = "icon_link";
        private string title = "Share";
    }
}