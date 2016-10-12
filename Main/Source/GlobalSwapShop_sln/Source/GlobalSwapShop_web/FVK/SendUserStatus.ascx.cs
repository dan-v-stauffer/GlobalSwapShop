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

namespace FVK
{
    /// <summary>
    /// Send user status control uses to publish user messages on user wall directly from Facebook iFrame 
    /// Application. Before publishing user has to enable sending of status by pressing a link on the control.
    /// </summary>
    public partial class SendUserStatus : System.Web.UI.UserControl
    {
        /// <summary>
        /// Inform client about sent status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void SendStatusHandler(object sender, EventArgs e);
        public event SendStatusHandler SendStatusCalled;
        

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = StatusSentButton.ClientID + "Control";
                ButtonSpan.InnerHtml = "<input ID=\"" + id + "\" value=\"Post\" type=\"button\" onclick=\"OnSendStatus(this)\" class=\"button\" style=\"width:60px\" />";
            }
        }

        /// <summary>
        /// Status sent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void StatusSent(object sender, EventArgs e)
        {
            SendStatusText.Text = "Successful Post";
            SendStatusText.ForeColor = System.Drawing.Color.Green;

            // call event on page
            if (SendStatusCalled != null)
            {
                SendStatusCalled(this, null);
            }
        }

        /// <summary>
        /// Status cannot be sent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void StatusCannotBeSent(object sender, EventArgs e)
        {
            SendStatusText.Text = "The same status is already post or send status is not allowed.";
            SendStatusText.ForeColor = System.Drawing.Color.Red;
        }
    }
}