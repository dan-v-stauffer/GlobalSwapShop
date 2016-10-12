using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FVK_Demo
{
    public partial class Components3Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tab4.AddTab("Bookmark Button", "BookmarkButton.aspx", 120);
                tab4.AddTab("Fan Box", "BecomeFan.aspx", 120);
                tab4.AddTab("Share Button", "ShareButton.aspx", 120);
                tab4.AddTab("Facebook Tabs", "Tabs.aspx", 120);
                tab4.AddTab("Stream Publish to Friends", "StreamPublishFriendList.aspx", 160);
            }
        }
    }
}
