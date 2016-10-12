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
    /// This control is used to allow users of the web site to become fan of the Facebook page, 
    /// see messages from the page wall and people who are fans of the page.
    /// </summary>
    public partial class LikeBox : System.Web.UI.UserControl
    {
        /// <summary>
        /// Facebook Page ID.
        /// </summary>
        public string PageId{ set {pageId = value; } }

        /// <summary>
        /// Width of the like box in pixels. Default value is 292.
        /// </summary>
        public int Width{ set { width = value; } }

        /// <summary>
        /// Height of the like box in pixels. Default value is 556.
        /// </summary>
        public int Height { set { height = value; } } 

        /// <summary>
        /// Number of fans to display. Default value is 10.
        /// </summary>
        public int FansCount{ set { fansCount = value; } } 

        /// <summary>
        /// Set to true to show the massages from the Page Wall.
        /// </summary>
        public bool ShowStream { set { showStream = value; } }

        /// <summary>
        /// Set to true to show the header.
        /// </summary>
        public bool ShowHeader { set { showHeader = value; } }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        /**
         * string renders component on the web page, depending on defined settings.
         */
        private void Refresh()
        {
            StringBuilder html = new StringBuilder();
            if (pageId == null)
            {
                pageId = FVKConfig.AppId;
            }
            html.Append("<fb:like-box profile_id='" + pageId + "' ");
            if (width != 292)
            {
                html.Append("width='" + width.ToString() + "' ");
            }
            if (height != 556)
            {
                html.Append("height='" + height.ToString() + "' ");
            }
            if (fansCount != 10)
            {
                html.Append("connections='" + fansCount.ToString() + "' ");
            }
            if (showStream == false)
            {
                html.Append("stream='false' ");
            }
            if (showHeader == false)
            {
                html.Append("header='false' ");
            }
            html.Append("></fb:like-box>\n");

            likeSpan.InnerHtml = html.ToString();
        }


        //private members
        private string pageId = null;
        private int width = 292;
        private int height = 556;
        private int fansCount = 10;
        private bool showStream = true;
        private bool showHeader = true;
    }
}