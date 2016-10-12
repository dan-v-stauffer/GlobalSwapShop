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
    public partial class LikeButton : System.Web.UI.UserControl
    {
        /// <summary>
        /// URL of the like button. If it's not set, current page URL is used.
        /// </summary>
        public string Url { set {url = value;} }

        

        /// <summary>
        /// Layout type. Available values are 'standard', 'button_count', 'box_count'
        /// </summary>
        public string Layout
        { 
            set {
                if (value == "button_count")
                {
                    layout = value;
                }
                else if (value == "box_count")
                {
                    layout = value;
                }
                else if (value != "standard")
                {
                    throw new Exception("LikeButton Error:  Unsupported layout: " + value);
                }
            }
        }

        /// <summary>
        /// If set to true, send button will be shown next to the like button
        /// </summary>
        public bool Send { set { send = value; } }
    

        /// <summary>
        /// Set to true to show profile picture bellow the like button. Default value is true.
        /// </summary>
        public bool ShowFaces { set { showFaces = value; } } 
        

        /// <summary>
        /// Width of the like button in pixels. Default value is 450.
        /// </summary>
        public int Width { set { width = value; } }
        
        /// <summary>
        /// Text of the like button. Available values are 'like' and 'recommend'. 
	    /// Defined text is translated depending on user language settings.
        /// </summary>
        public string Action
        {
            set 
            {
                if (value == "recommend")
                {
                    action = value;
                }
                else if (value != "like")
                {
                    throw new Exception("LikeButton Error:  Unsupported action: " + value);
                }
            }
        }

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
            html.Append("<fb:like ");
            if (url != null)
            {
                html.Append("href='" + url + "' ");
            }
            if (layout != null)
            {
                html.Append("layout='" + layout + "' ");
            }
            if (send)
            {
                html.Append("send='true' ");
            }
            if (showFaces == false)
            {
                html.Append("show_faces='false' ");
            }
            if (width != 450)
            {
                html.Append("width='" + width.ToString() + "' ");
            }
            if (action != null)
            {
                html.Append("action='" + action + "' ");
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
            html.Append("></fb:like>\n");
            likeSpan.InnerHtml = html.ToString();
        }

        // Private members
        private string url = null;
        private string layout = null;
        private bool send = false;
        private bool showFaces = true;
        private int width = 450;
        private string action = null;
        private string font = null;
        private string colorScheme = null;
        private string reference = null;



        // Obsolete members/methods

        [Obsolete("You shouldn't use this property anymore. Use ColorScheme instead")]
        public string SetColorScheme
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
    }
}