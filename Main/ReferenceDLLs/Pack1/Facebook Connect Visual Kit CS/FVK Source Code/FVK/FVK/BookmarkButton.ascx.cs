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
    /// Bookmark button uses to enable to users an easy way to bookmark a Facebook Connect website inside 
    /// Facebook environement. 
    /// </summary>
    public partial class BookmarkButton : System.Web.UI.UserControl
    {
        /// <summary>
        /// Inform client about bookmarked application/website
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void AddBookmarkHandler(object sender, EventArgs e);
        public event AddBookmarkHandler AddedBookmark;

        /// <summary>
        /// Set to true if bookmark button is used on externan website
        /// </summary>
        public bool OffFacebook { set { offFacebook = value; } }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<fb:bookmark type=\"");
            if (offFacebook)
            {
                html.Append("off-facebook\"");
            }
            else
            {
                html.Append("on-facebook\"");
            }
            if (AddedBookmark != null)
            {
                html.Append(" onadd=\"document.getElementById('");
                html.Append(BookmarkAddedButton.ClientID);
                html.Append("').click()\"");
            }
            html.Append("></fb:bookmark>");
            bookmarkSpan.InnerHtml = html.ToString();
        }

        protected void BookmarkAddedButton_Click(object sender, EventArgs e)
        {
            if (AddedBookmark != null)
            {
                AddedBookmark(sender, e);
            }
        }

        private bool offFacebook = false;
    }
}