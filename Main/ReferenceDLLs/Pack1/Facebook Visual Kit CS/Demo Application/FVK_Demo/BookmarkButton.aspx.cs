using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.Web;

namespace FVK_Demo
{
    public partial class BookmarkButton : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BookmarkAdded(object sender, EventArgs e)
        {
            BookmarkedLabel.Visible = true;
        }
    }
}
