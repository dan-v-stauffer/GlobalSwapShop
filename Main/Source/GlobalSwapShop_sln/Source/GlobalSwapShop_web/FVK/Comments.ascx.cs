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
    /// Comment box control uses to enable user of Facebook Connect web site to put comments about a web site 
    /// or some article on the web site.
    /// </summary>
    public partial class Comments : System.Web.UI.UserControl
    {
        /// <summary>
        /// unique id. Should be set if there are more comment box for the same web site
        /// </summary>
        public string Xid { set { xid = value; } }

        /// <summary>
        /// The max number of posts to display. Default is 10.
        /// </summary>
        public int PostsNum { set { postsNum = value; } }

        /// <summary>
        /// Width of the control. Default is 550.
        /// </summary>
        public int Width { set { width = value; } }

        /// <summary>
        /// URL of custom CSS style of the control
        /// </summary>
        public string CssUrl { set { cssUrl = value; } }

        /// <summary>
        /// title of feed story published when comment is made. Default is title of page.
        /// </summary>
        public string Title { set { title = value; } }

        /// <summary>
        /// The URL of page where comment is made.
        /// </summary>
        public string Url { set { url = value; } }

        /// <summary>
        /// a rounded box does not appear around each post on a site. Default is false.
        /// </summary>
        public bool IsSimple { set { isSimple = value; } }

        /// <summary>
        /// if true comments are shown in reverse order. Dafault is false.
        /// </summary>
        public bool IsReverse { set { isReverse = value; } }

        /// <summary>
        /// if true posting comments will not any notifications. Default is false.
        /// </summary>
        public bool IsQuiet { set { isQuiet = value; } }


        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                StringBuilder s = new StringBuilder();
                s.Append("<fb:comments ");
                if (xid != null)
                {
                    s.Append("xid='");
                    s.Append(xid);
                    s.Append("' ");
                }
                s.Append("numposts='");
                s.Append(postsNum.ToString());
                s.Append("' ");

                s.Append("width='");
                s.Append(width.ToString());
                s.Append("' ");

                if (cssUrl != null)
                {
                    s.Append("css='");
                    s.Append(cssUrl);
                    s.Append("' ");
                }

                if (title != null)
                {
                    s.Append("title='");
                    s.Append(title);
                    s.Append("' ");
                }

                if (url != null)
                {
                    s.Append("url='");
                    s.Append(url);
                    s.Append("' ");
                }

                if (isSimple)
                {
                    s.Append("simple='1' "); 
                }

                if (isReverse)
                {
                    s.Append("reverse='1' ");
                }

                if (isQuiet)
                {
                    s.Append("quiet='1' ");
                }

                s.Append("></fb:comments>");

                commentsSpan.InnerHtml = s.ToString();
            }
        }




        /// <summary>
        /// Private members
        /// </summary>
    
        private string xid = null;
        private int postsNum = 10;
        private int width = 550;
        private string cssUrl = null;
        private string title = null;
        private string url = null;
        private bool isSimple = false;
        private bool isReverse = false;
        private bool isQuiet = false;
    }
}