using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.Web;
using FVK;

namespace FVK_Demo
{
    public partial class StreamPublish : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                streampublish1.Name = "Facebook Visual Kit for ASP.NET";
                streampublish1.Href = FVKConfig.AppUrl;
                streampublish1.Caption = "{*actor*} is trying Facebook Visual Kit Demo.";
                streampublish1.Description = "Facebook Visual Kit is a set of ASP.NET user controls that facilitate the use of common and popular Facebook features by wrapping and hiding the complexity of underlying implementation from the user. This set of controls makes development of Facebook iFrame applications, both in C# and VB.NET programing languages, significantly easier, faster and more organized.";
                streampublish1.UserMessage = "ASP.NET library for Facebook development";
                streampublish1.TargetId = null;  //  set to user id to publish on friends' wall (ActorId should be null)
                streampublish1.ActorId = null; // page id if user is admin of the page (TargetId should be null)

                List<IJSONSerialize> properties = new List<IJSONSerialize>();
                properties.Add(new PropertyData("Text Property", "This is property description"));
                properties.Add(new LinkedPropertyData("Link Property", "This is property link", FVKConfig.AppUrl));
                streampublish1.Properties = properties;

                streampublish1.Media = new ImageData("http://images.vatlab.net/logo.png", FVKConfig.AppUrl);

                List<LinkData> linkList = new List<LinkData>();
                linkList.Add(new LinkData("action link", FVKConfig.AppUrl));
                linkList.Add(new LinkData("action link2", FVKConfig.AppUrl));
                streampublish1.ActionLinkList = linkList;
            }
        }

        protected void OnPublishStory(object sender, EventArgs e)
        {
            // stream publish popup is open
        }

        protected void OnConfirmStory(object sender, EventArgs e)
        {
            string postId = streampublish1.ReturnedPostId;
            if (postId != null)
            {
                PublishLabel.Text = "Story Published";
            }
            else
            {
                PublishLabel.Text = "Publishing Canceled";
            }
        }

        protected void MediaDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MediaDropDown.SelectedValue)
            {
                case "Image": streampublish1.Media = new ImageData("http://images.vatlab.net/jeweler/big/diamond1.png", "http://vatlab.com");
                    break;
                case "Video": streampublish1.Media = new VideoData("http://www.youtube.com/v/fzzjgBAaWZw&hl=en&fs=1",
                                                                   "http://icanhascheezburger.files.wordpress.com/2009/04/funny-pictures-hairless-cat-phones-home.jpg",
                                                                   "http://icanhascheezburger.com",
                                                                   "kitty");
                    break;
                case "Flash": streampublish1.Media = new FlashData("http://images.vatlab.net/flashiness_fz.swf",
                                                                   "http://images.vatlab.net/flashimage.png",
                                                                   250, 250, 750, 550);
                    break;

                case "Mp3": streampublish1.Media = new MP3Data("http://www.looptvandfilm.com/blog/Radiohead%20-%20In%20Rainbows/01%20-%20Radiohead%20-%2015%20Step.MP3",
                                                               "20 Step","Radiohead","In Rainbows");
                    break;
            }
        }
    }
}
