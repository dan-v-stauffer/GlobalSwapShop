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
    /// Facebook Invite control uses to invite friends on using Facebook application or Facebook Connect web 
    /// site by sending invite request. An implementation of the control is wrapper around FBML tags adapted 
    /// for usage as pure ASP.NET control.
    /// </summary>
    public partial class InviteControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// Show border or not
        /// </summary>
        public bool ShowBorder { set { showBorder = value; } }

        /// <summary>
        /// Display email section
        /// </summary>
        public bool EmailInvite { set { emailInvite = value; } }

        /// <summary>
        /// Display dialog for importing external friends
        /// </summary>
        public bool ImportExternalFriends { set { importExternalFriends = value; } }

        /// <summary>
        /// Number of rows. Allowed values are from 3 to 10. Default value is 5.
        /// </summary>
        public int Rows { set { rows = value; } }

        /// <summary>
        /// Number of columns. Allowed values are from 2,3 and 15. Default value is 5.
        /// </summary>
        public int Colums { set { colums = value; } }

        /// <summary>
        /// Set comma separated string of friend ID which you don't want to be in invite list
        /// </summary>
        public string ExcludeFriends { set { excludeFriends = value; } }

        /// <summary>
        /// IList of friend IDs which you don't want to be in invite list
        /// </summary>
        public IList<long> ExcludeFriendsList
        {
            set
            {
                if (value != null)
                {
                    int i = 0;
                    StringBuilder s = new StringBuilder();
                    foreach (long id in value)
                    {
                        i++;
                        s.Append(id.ToString());
                        if (i < value.Count)
                        {
                            s.Append(",");
                        }
                    }
                    excludeFriends = s.ToString();
                }
            }
        }

        /// <summary>
        /// URL where application should be redirected, after an invitation is sent.
        /// Default is application Canvas URL taken from web.config file.
        /// </summary>
        public string ActionUrl { set { actionUrl = value; } }

        /// <summary>
        /// URL where user will be redirected after the invite request is accepted.
        /// If it's not set, ActionUrl is used.
        /// </summary>
        public string AcceptUrl { set { acceptUrl = value; } }

        /// <summary>
        /// Main description which will apear on invite request
        /// </summary>
        public string Content { set { content = value; } }

        /// <summary>
        /// Application name displayed on send button and invite request title.
        /// Default is name taken from web.config file
        /// </summary>
        public string AppName { set { appName = value; } }

        /// <summary>
        /// Main title of control
        /// </summary>
        public string MainTitle { set { mainTitle = value; } }

        /// <summary>
        /// Refresh display of the control
        /// </summary>
        public void Refresh()
        {
            // check consistency
            if (mainTitle == null)
            {
                throw new Exception("Invite Friends Error:  Main Title is not set.");
            }
            if (content == null)
            {
                throw new Exception("Invite Friends Error:  Content is not set.");
            }
            if (confirmButtonTitle == null)
            {
                throw new Exception("Invite Friends Error:  Confirm Button Title is not set.");
            }

            // set defaults
            if (actionUrl == null)
            {
               actionUrl = FVKConfig.AppUrl;
            }
            if (acceptUrl == null)
            {
                acceptUrl = FVKConfig.AppUrl;
            }
             if (appName == null)
            {
                appName = FVKConfig.AppName;
            }

            StringBuilder html = new StringBuilder();
            html.Append("<fb:serverfbml ");
            html.Append("width='" + width.ToString() + "'>");
            html.Append("<script type='text/fbml'>");
            html.Append("<div style='" + cssStyle + "' class='" + cssClass +  "'>");
            html.Append("<fb:fbml>");
            html.Append("<fb:request-form  method=\"GET\" target=\"_top\" action=\"");
            html.Append(actionUrl);
            html.Append("\" content=\"");
            html.Append(content);
            html.Append("<fb:req-choice url='");
            html.Append(acceptUrl);
            html.Append("' label='");
            html.Append(confirmButtonTitle);
            html.Append("' />\" type=\"");
            html.Append(appName);
            html.Append("\" invite=\"true\">");
            html.Append("<fb:multi-friend-selector target=\"_top\" condensed=\"false\" exclude_ids=\"");
            html.Append(excludeFriends);
            html.Append("\"  actiontext=\"");
            html.Append(mainTitle);
            html.Append("\" showborder=\"");
            html.Append(showBorder);
            html.Append("\" rows=\"");
            html.Append(rows);
            if (colums < 5) // fixing bug in FBML (if columns == 5 it renders as it as 4)
            {
                html.Append("\" cols=\"");
                html.Append(colums);
            }
            html.Append("\" import_external_friends=\"");
            html.Append(importExternalFriends);
            html.Append("\" email_invite=\"");
            html.Append(emailInvite);
            html.Append("\" />");
            html.Append("</fb:request-form> ");
            html.Append("</fb:fbml>");
            html.Append("</div>");
            html.Append("</script>");
            html.Append("</fb:serverfbml>");

            invitespan.InnerHtml = html.ToString();
        }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
            }
        }


        /// <summary>
        /// Private members
        /// </summary>
        private string excludeFriends = "";
        private string actionUrl = null;
        private string acceptUrl = null;
        private string content = null;
        private string confirmButtonTitle = "Accept";
        private string appName = null;
        private string mainTitle = null;
        private bool showBorder = true;
        private bool emailInvite = true;
        private bool importExternalFriends = true;
        private int rows = 5;
        private int colums = 5;
        private string cssStyle = "";
        private string cssClass = "";
        private int width = 760;


        /// <summary>
        /// Obsolete members/methods
        /// </summary>
        
        [Obsolete("You shouldn't use this property anymore. Use AppName instead")]
        public string SendButtonTitle { set { appName = value; } }

        [Obsolete("Does not have effect anymore. Title is set depending on lanquage")]
        public string ConfirmButtonTitle { set { confirmButtonTitle = value; } }
        
    }
}