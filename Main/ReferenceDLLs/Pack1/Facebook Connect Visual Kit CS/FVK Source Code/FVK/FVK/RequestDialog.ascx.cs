using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace FVK
{
    public partial class RequestDialog : System.Web.UI.UserControl
    {
        /// <summary>
        /// Set type of command control(link, button, auto_open). If auto_open is
        /// set permission popup is open on page load. Default = button.
        /// </summary>
        public string CommandType
        {
            set
            {
                switch (value)
                {
                    case "link": commandType = CommandTypeEnum.Link; break;
                    case "button": commandType = CommandTypeEnum.Button; break;
                    case "auto_open": commandType = CommandTypeEnum.AutoOpen; break;
                    default:
                        throw new Exception("Invalid command type, supported values are link, button and auto_open");
                }
            }
        }

        /// <summary>
        /// Set title of publish button/link
        /// </summary>
        public string CommandTitle { set { commandTitle = value; } }

        /// <summary>
        /// Set message of request dialog
        /// </summary>
        public string Message { set { message = value; } }

        /// <summary>
        /// Set title of request dialog
        /// </summary>
        public string Title { set { title = value; } }
        
        /// <summary>
        /// Set id of friend to which request has to be sent. If omited, friend selector is shown
        /// </summary>
        public string FriedId { set { friendId = value; } }

        /// <summary>
        /// Optional data which is sent with request
        /// </summary>
        public string AdditionalData { set { additionalData = value; }}

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            string functionName = "ShowRequestDialog" + this.ClientID;
            StringBuilder html = new StringBuilder();
            html.Append("<script>\n");
            html.Append("function " + functionName + "() {\n");
            html.Append("  if (graphApiInitialized != true) {\n");
            html.Append("    setTimeout('" + functionName + "()', 100);\n");
            html.Append("    return;\n");
            html.Append("  }\n");
            html.Append("  FB.ui({method: 'apprequests', message: '");
            html.Append(message + "'");
            if (title != null)
            {
                html.Append(", title: '" + title + "'");
            }
            if (friendId != null)
            {
                html.Append(", to: '" + friendId + "'");
            }
            if (additionalData != null)
            {
                html.Append(", data: '" + additionalData + "'");
            }
            html.Append("});\n");
            html.Append("}\n");
            
            html.Append("</script>\n");

            switch (commandType)
            {
                case CommandTypeEnum.Link:
                    html.Append("<a style=\"cursor:pointer;\" onclick=\"" + functionName + "()\" >" );
                    html.Append(commandTitle);
                    html.Append("</a>\n");
                    break;
                case CommandTypeEnum.Button:
                    html.Append("<input type=\"button\" style=\"cursor:pointer\" class=\"button\" onclick=\"" + functionName + "()\"  value=\"");
                    html.Append(commandTitle);
                    html.Append("\" />\n");
                    break;
                case CommandTypeEnum.AutoOpen:
                    html.Append("<script type=\"text/javascript\">");
                    html.Append(functionName + "();\n");
                    html.Append("</script>\n");
                    break;
            }
            requestSpan.InnerHtml = html.ToString();
        }



        // Private members
        private string message;
        private string title;
        private string friendId;
        private string additionalData;
        private CommandTypeEnum commandType = CommandTypeEnum.Button;
        private string commandTitle = "Send Request";
          
    }
}