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
using System.Configuration;
using System.Text;

namespace FVK
{
    /// <summary>
    /// This control uses to enable user to became fan of the Facebook application, 
    /// Facebook Connect web site or Facebook Page. 
    /// </summary>

    [Obsolete("You should use Facebook Like Box control instead")]
    public partial class BecomeFan : System.Web.UI.UserControl
    {
        /// <summary>
        /// Width of control
        /// </summary>
        public int Width { set { width = value; } }

        /// <summary>
        /// Show stories published on wall of application or Facebook page
        /// </summary>
        public bool ShowStream { set { showStream = value; } }

        /// <summary>
        /// Number of fans to display
        /// </summary>
        public int ConnectionsCount { set { connectionsCount = value; } }

        /// <summary>
        /// Url of custom defined CSS file
        /// </summary>
        public string CssUrl { set { cssUrl = value; } }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string appId = FVKConfig.AppId;
                StringBuilder s = new StringBuilder();
                s.Append("<fb:fan profile_id='");
                s.Append(appId.ToString());
                s.Append("' stream='");
                if (showStream) s.Append("1");
                else s.Append("0");
                s.Append("' connections='");
                s.Append(connectionsCount);
                s.Append("' width='");
                s.Append(width);
                s.Append("'");
                if (cssUrl != null)
                {
                    s.Append(" css='");
                    s.Append(cssUrl);
                    s.Append("'");
                }
                s.Append("></fb:fan>");

                fanspan.InnerHtml = s.ToString();
            }
        }


        /// <summary>
        /// Private members
        /// </summary>
        private int width = 300;
        private bool showStream = false;
        private int connectionsCount = 0;
        private string cssUrl = null;
    }
}
