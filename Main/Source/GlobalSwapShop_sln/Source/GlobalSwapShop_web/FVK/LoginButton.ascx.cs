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
    /// Facebook Connect Login Button control uses to connect web site on Facebook and share data using 
    /// Facebook API. It also enable that once user is logged all controls from the library work without 
    /// requiring for logging.
    /// </summary>
    public partial class LoginButton : System.Web.UI.UserControl
    {
        public delegate void OnConnectHandler(object sender, EventArgs e);

        /// <summary>
        /// Inform client that connection on Facebook is established
        /// </summary>
        public event OnConnectHandler ConnectCalled;

        /// <summary>
        /// of the control. Possible values: icon, small, medium, large, xlarge
        /// </summary>
        public string Size { set { size = value; } }

        /// <summary>
        /// text inside login button
        /// </summary>
        public string Title { set { title = value; } }

        /// <summary>
        /// Add permissions as comma separaded values string
        /// </summary>
        public string Permissions { set { permissions = value; } }

       
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
                StringBuilder s = new StringBuilder();
                s.Append("<fb:login-button ");
                s.Append("onlogin=\"");
                s.Append("document.getElementById('");
                s.Append(ConnectButton.ClientID);
                s.Append("').click()\" ");
                if (size != null)
                {
                    s.Append("size=\"");
                    s.Append(size);
                    s.Append("\" ");
                }
                if (permissions != null)
                {
                    s.Append(" perms=\"");
                    s.Append(permissions);
                    s.Append("\"");
                }

                s.Append(" >");
                if (title != null) s.Append(title);
                s.Append("</fb:login-button>");
                ConnectSpan.InnerHtml = s.ToString();
            //}
        }

        /// <summary>
        /// Login button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ConnectCalled != null)
            {
                ConnectCalled(sender, e);
            }
        }

        /// <summary>
        /// Private members
        /// </summary>

        private string size = null;
        private string title = null;
        private string permissions = null;
    }
}