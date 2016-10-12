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
    /// Facebook Stream publish popup uses to publish stories on user wall, friends' wall or on page wall if user 
    /// is admin.This ASP.NET control is wrapper around JavaScript method FB.Connect.streamPublish which hide all 
    /// underlaying stuff as conversion to JSON format and packaging media attachments.
    /// </summary>
    public partial class StreamPublishPopup : System.Web.UI.UserControl
    {
        public delegate void PublishCalledHandler(object sender, EventArgs e);
        public delegate void ConfirmCalledHandler(object sender, EventArgs e);

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
        /// Inform client when  popup is displayed
        /// </summary>
        public event PublishCalledHandler PublishCalled;

        /// <summary>
        /// Inform client when story is published or popup is closed
        /// </summary>
        public event ConfirmCalledHandler ConfirmCalled;

        /// <summary>
        /// If true, publish button does not work, default = false
        /// </summary>
        public bool Enabled { set { PublishButton.Enabled = value; } }

        /// <summary>
        /// Name of story
        /// </summary>
        public string Name { set { NameHiddenField.Value = value; } }

        /// <summary>
        /// Destination URL linked on name
        /// </summary>
        public string Href { set { HrefHiddenField.Value = value; } }

        /// <summary>
        /// Caption of the story
        /// </summary>
        public string Caption { set { CaptionHiddenField.Value = value; } }

        /// <summary>
        /// Description of story
        /// </summary>
        public string Description { set { DescriptionHiddenField.Value = value; } }

        /// <summary>
        /// Message Prompt of story
        /// </summary>
        public string MessagePrompt { set { MessagePromptHiddenField.Value = value; } }

        /// <summary>
        /// Predefined user message
        /// </summary>
        public string UserMessage { set { UserMessageHiddenField.Value = value; } }

        /// <summary>
        /// If publishing is enabled for an app, story is publish without displaying popup
        /// </summary>
        public string TargetId { set { TargetIdHiddenField.Value = value; } }

        /// <summary>
        /// Page Id if user is admin of the page, story is published as it is published by the page
        /// </summary>
        public string ActorId { set { ActorIdHiddenField.Value = value; } }

        /// <summary>
        /// Set properties of story (PropertyData and LinkedProperyData objects)
        /// </summary>
        public IList<IJSONSerialize> Properties { set { PropertiesHiddenField.Value = "{"+ Conversions.JSONListToJSONString(value) + "}"; } }

        /// <summary>
        /// Set media object (ImageData, VideoData, MP3Data, FlashData)
        /// </summary>
        public IJSONSerialize Media { set { MediaHiddenField.Value = "[" + value.JSONSerialize() + "]"; } }

        /// <summary>
        /// Set list of media objects. Currenty there are just images (ImageData) supported.
        /// </summary>
        public IList<IJSONSerialize> MediaList { set { MediaHiddenField.Value = "[" + Conversions.JSONListToJSONString(value) + "]"; } }

        /// <summary>
        /// Set list of action links
        /// </summary>
        public IList<LinkData> ActionLinkList { set { ActionLinksHiddenField.Value = "[" + Conversions.LinkListToJSONString(value) + "]"; } }

        /// <summary>
        /// Set action link
        /// </summary>
        public LinkData ActionLink { set { ActionLinksHiddenField.Value = "[" + value.JSONSerialize() + "]"; } }

        /// <summary>
        /// Get retuned post id. If it is not set publishing is canceled by user
        /// </summary>
        public string ReturnedPostId { 
            get {
                string postId = ReturnedPostIdHiddenField.Value;
                if (postId == "null") return null;
                return postId;
            } 
        }


        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Prerender(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            switch (commandType)
            {
                case CommandTypeEnum.Link:
                    html.Append("<a style=\"cursor:pointer;\" onclick=\"StreamPublish(this)\" id=\"");
                    html.Append(PublishButton.ClientID);
                    html.Append("Control");
                    html.Append("\" >");
                    html.Append(commandTitle);
                    html.Append("</a>");
                    break;
                case CommandTypeEnum.Button:
                    html.Append("<input type=\"button\" style=\"cursor:pointer\" class=\"button\" onclick=\"StreamPublish(this)\" id=\"");
                    html.Append(PublishButton.ClientID);
                    html.Append("Control");
                    html.Append("\" value=\"");
                    html.Append(commandTitle);
                    html.Append("\" />");
                    break;
                case CommandTypeEnum.AutoOpen:
                    html.Append("<script type=\"text/javascript\">");
                    html.Append("btn = document.getElementById('");
                    html.Append(PublishButton.ClientID);
                    html.Append("');");
                    html.Append("btn.click();</script>");
                    break;
            }
            streamPublishSpan.InnerHtml = html.ToString();
        }

        /// <summary>
        /// Inform cliend when popup is open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PublishButton_Click(object sender, EventArgs e)
        {
            if (PublishCalled != null)
            {
                PublishCalled(this, e);
            }
        }

        /// <summary>
        /// Inform client when story is published of popup is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ConfirmedSendButton_Click(object sender, EventArgs e)
        {
            if (ConfirmCalled != null)
            {
                ConfirmCalled(this, e);
            }
        }

        private CommandTypeEnum commandType = CommandTypeEnum.Button;
        private string commandTitle = "Publish";
    }
}