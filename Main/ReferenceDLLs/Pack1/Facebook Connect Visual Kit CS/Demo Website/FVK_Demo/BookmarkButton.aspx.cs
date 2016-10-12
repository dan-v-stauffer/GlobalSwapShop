using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Facebook;
using Facebook.Web;
using FVK;

namespace FVK_Demo
{
    public partial class BookmarkButton : System.Web.UI.Page
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
