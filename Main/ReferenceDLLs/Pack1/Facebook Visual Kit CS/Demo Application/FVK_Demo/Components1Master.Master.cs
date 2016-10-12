using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FVK_Demo
{
    public partial class Components1Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tab2.AddTab("Request Dialog", "RequestDialog.aspx", 100);
                tab2.AddTab("Stream Publish", "StreamPublish.aspx", 120);
                tab2.AddTab("Permissions", "Permissions.aspx", 100);
                tab2.AddTab("Like Box", "LikeBox.aspx", 100);
                tab2.AddTab("Like Button", "LikeButton.aspx", 100);
                tab2.AddTab("Send Button", "SendButton.aspx", 100);

                tab2.Distance = 5;
                tab2.BorderWidth = 10;
            }
        }
    }
}
