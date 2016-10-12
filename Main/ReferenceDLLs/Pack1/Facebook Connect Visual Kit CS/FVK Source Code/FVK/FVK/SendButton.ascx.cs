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
    /// Like button allows users to share some content from the website with their friends. Pressing on 
    /// the Like button will result in publishing of a story on user's profile, with link to the website.
    /// </summary>
    public partial class SendButton : System.Web.UI.UserControl
    {
        /// <summary>
        /// URL of the like button. If it's not set, current page URL is used.
        /// </summary>
        public string Url { set { url = value; } }

        /// <summary>
        /// Font inside the like button. Available values are 'arial', 'lucida grande',
        /// 'segoe ui', 'tahoma', 'trebuchet ms' and 'verdana'.
        /// </summary>
        public string Font
        {
            set
            {
                if (value != null)
                {
                    switch (font)
                    {
                        case "arial":
                        case "lucida grande":
                        case "segoe ui":
                        case "tahoma":
                        case "trebuchet ms":
                        case "verdana":
                            font = value;
                            break;
                        default:
                            throw new Exception("Like Button Error:  Unsupported font: " + value);
                    }
                }
            }
        }

        /// <summary>
        /// Color scheme. Available values are 'light' and 'dark'. Deault value is 'light'.
        /// </summary>
        public string ColorScheme
        {
            set
            {
                if (value == "dark")
                {
                    colorScheme = value;
                }
                else if (value != "light")
                {
                    throw new Exception("LikeButton Error:  Unsupported Color Scheme: " + value);
                }
            }
        }

        /// <summary>
        /// The reference string for tracking referals.
        /// </summary>
        public string Reference { set { reference = value; } }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Prerender(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            StringBuilder html = new StringBuilder();
            html.Append("<fb:send ");
            if (url != null)
            {
                html.Append("href='" + url + "' ");
            }
            
            if (font != null)
            {
                html.Append("font='" + font + "' ");
            }
            if (colorScheme != null)
            {
                html.Append("colorscheme='" + colorScheme + "' ");
            }
            if (reference != null)
            {
                html.Append("ref='" + reference + "' ");
            }
            html.Append("></fb:send>\n");
            sendSpan.InnerHtml = html.ToString();
        }

        // Private members
        private string url = null;
        private string font = null;
        private string colorScheme = null;
        private string reference = null;
    }
}