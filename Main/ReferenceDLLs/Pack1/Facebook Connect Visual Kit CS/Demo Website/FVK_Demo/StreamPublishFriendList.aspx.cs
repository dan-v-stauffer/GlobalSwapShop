using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using Facebook;
using Facebook.Web;
using FVK;

namespace FVK_Demo
{
    public partial class StreamPublishFriendList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fbWebContext = FacebookWebContext.Current;
            if (!fbWebContext.IsAuthorized())
            {
                ErrorLabel.Visible = true;
                loginbutton1.Visible = true;
            }
            else
            {
                ErrorLabel.Visible = false;
                loginbutton1.Visible = false;

                // set friend list
                IList<FriendData> friends = new List<FriendData>();
                int count = 0;
                var facebook = new FacebookWebClient(fbWebContext);
                JsonObject friendsData = (JsonObject)facebook.Get("me/friends");
                JsonArray friendsList = (JsonArray)friendsData["data"];
                foreach (JsonObject f in friendsList)
                {
                    long id = Int64.Parse((string)f["id"]);
                    string name = (string)f["name"];
                    friends.Add(new FriendData(id, name));
                    count++;
                    if (count == 4) break;
                }
                streampublish1.Friends = friends;
            }

            if (!Page.IsPostBack)
            {
                streampublish1.Visible = true;
                streampublish1.BoxText = "Want to inform your friends about Facebook Visual Kit. " +
                                            "Make sure they see the info by posting it on their wall.";
                streampublish1.MainImageUrl = "http://images.vatlab.net/logo.png";
                streampublish1.Name = "Facebook Visual Kit for ASP.NET";
                streampublish1.Href = FVKConfig.AppUrl;
                streampublish1.Caption = "{*actor*} is trying Facebook Visual Kit Demo.";
                streampublish1.Description = "Facebook Visual Kit is a set of ASP.NET user controls that facilitate the use of common and popular Facebook features by wrapping and hiding the complexity of underlying implementation from the user. This set of controls makes development of Facebook iFrame applications, both in C# and VB.NET programing languages, significantly easier, faster and more organized.";
                streampublish1.UserMessage = "ASP.NET library for Facebook development";

                List<IJSONSerialize> properties = new List<IJSONSerialize>();
                properties.Add(new PropertyData("Text Property", "This is property description"));
                properties.Add(new LinkedPropertyData("Link Property", "This is property link", FVKConfig.AppUrl));
                streampublish1.Properties = properties;

                streampublish1.Media = new ImageData("http://images.vatlab.net/logo.png", FVKConfig.AppUrl);
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
                PublishLabel.Text = "Story is published";
            }
            else
            {
                PublishLabel.Text = "Publishing Canceled";
            }
        }
    }
}
