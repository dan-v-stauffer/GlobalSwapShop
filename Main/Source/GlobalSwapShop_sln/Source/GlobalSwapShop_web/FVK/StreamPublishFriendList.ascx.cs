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
    /// Stream publish friend list uses to enable publishing stories on friends' wall on easy way by selection 
    /// friend from a list and press publish button.This ASP.NET control is wrapper around Facebook stream 
    /// publish popup control. It provides a box with friend list which can be defined through source code. 
    /// By selecting a friend and pressing a publish button stream publish popup is shown.
    /// </summary>
    public partial class StreamPublishFriendList : System.Web.UI.UserControl
    {
        public delegate void PublishCalledHandler(object sender, EventArgs e);
        public delegate void ConfirmCalledHandler(object sender, EventArgs e);

        /// <summary>
        /// Inform client when  popup is displayed
        /// </summary>
        public event PublishCalledHandler PublishCalled;

        /// <summary>
        /// Inform client when story is published or popup is closed
        /// </summary>
        public event ConfirmCalledHandler ConfirmCalled;

        /// <summary>
        /// Set title of publish button
        /// </summary>
        public string PostBtnTitle { set { streampublishpopup1.CommandTitle = value; } }

        /// <summary>
        /// Set title of hide button
        /// </summary>
        public string HideBtnTitle { set { HideButton.Text = value; } }

        /// <summary>
        /// Set url of image inside the Box
        /// </summary>
        public string MainImageUrl {set { SelectedImage.ImageUrl = value; } }

        /// <summary>
        /// Title of the box
        /// </summary>
        public string Title { set { titleLabel.Text = value; } }

        /// <summary>
        /// Set text inside box the Box
        /// </summary>
        public string BoxText { set { BoxTextLabel.Text = value; } }

        /// <summary>
        /// Name of story
        /// </summary>
        public string Name { set { streampublishpopup1.Name = value; } }

        /// <summary>
        /// Destination URL linked on name
        /// </summary>
        public string Href { set { streampublishpopup1.Href = value; } }

        /// <summary>
        /// Caption of the story
        /// </summary>
        public string Caption { set { streampublishpopup1.Caption = value; } }

        /// <summary>
        /// Description of story
        /// </summary>
        public string Description { set { streampublishpopup1.Description = value; } }

        /// <summary>
        /// Message Prompt of story
        /// </summary>
        public string MessagePrompt { set { streampublishpopup1.MessagePrompt = value; } }

        /// <summary>
        /// Predefined user message
        /// </summary>
        public string UserMessage { set { streampublishpopup1.UserMessage = value; } }

        /// <summary>
        /// Set properties of story
        /// </summary>
        public IList<IJSONSerialize> Properties { set { streampublishpopup1.Properties = value; } }

        /// <summary>
        /// Set media object (ImageData, VideoData, MP3Data, FlashData)
        /// </summary>
        public IJSONSerialize Media { set { streampublishpopup1.Media = value; } }

        /// <summary>
        /// Set list of media objects. Currenty there are just images (ImageData) supported.
        /// </summary>
        public IList<IJSONSerialize> MediaList { set { streampublishpopup1.MediaList = value; } }

        /// <summary>
        /// Set list of action links
        /// </summary>
        public IList<LinkData> ActionLinkList { set { streampublishpopup1.ActionLinkList = value; } }

        /// <summary>
        /// Set action link
        /// </summary>
        public LinkData ActionLink { set { streampublishpopup1.ActionLink = value; } }

        /// <summary>
        /// Get retuned post id. If it is not set publishing is canceled by user
        /// </summary>
        public string ReturnedPostId { get { return streampublishpopup1.ReturnedPostId; } }




        /// <summary>
        /// Set list of friends which have to be displayed in the box
        /// </summary>
        public IList<FriendData> Friends 
        { 
            set 
            {
                if (value.Count > 0)
                {
                    List<FriendData> sortedList = new List<FriendData>(value);
                    sortedList.Sort();

                    StringBuilder html = new StringBuilder();
                    html.Append("<table>\n");
                    
                    int index = 0;
                    string parentId = RadioItemsSpan.ClientID;
                    foreach (FriendData f in value)
                    {
                        html.Append("  <tr>\n");
                        html.Append("    <td>\n");
                        html.Append("      <input type='radio' id='");
                        html.Append(parentId);
                        html.Append("Item");
                        html.Append(index.ToString());
                        html.Append("' value='");
                        html.Append(f.Id.ToString());
                        html.Append("' name='");
                        html.Append(parentId);
                        html.Append("List");
                        html.Append("' onclick='SelectTarget(\"");
                        html.Append(streampublishpopup1.ClientID);
                        html.Append("_TargetIdHiddenField\", this)' />\n");
                        html.Append("      <label for='");
                        html.Append(parentId);
                        html.Append("Item' >");
                        html.Append(f.Name);
                        html.Append("</label>\n");
                        html.Append("    </td>\n");
                        html.Append("  </tr>\n");
                    }
                    html.Append("</table>\n");
                    RadioItemsSpan.InnerHtml = html.ToString();
                }
                else
                {
                    RadioItemsSpan.InnerHtml = "";
                }
            }
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
                streampublishpopup1.Enabled = false;
            }
        }

        /// <summary>
        /// Inform cliend when popup is open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PublishButtonHandler(object sender, EventArgs e)
        {
            streampublishpopup1.TargetId = null;
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
        protected void ConfirmedSendButtonHandler(object sender, EventArgs e)
        {
            streampublishpopup1.TargetId = null;
            if (ConfirmCalled != null)
            {
                ConfirmCalled(this, e);
            }
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HideButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


        /// <summary>
        /// Private members
        /// </summary>
        private string TargetId { set { streampublishpopup1.TargetId = value; } }
    }
}