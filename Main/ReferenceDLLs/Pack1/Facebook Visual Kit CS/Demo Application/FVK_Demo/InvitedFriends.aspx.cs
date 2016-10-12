using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using Facebook.Web;

namespace FVK_Demo
{
    public partial class InvitedFriends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string friendIds = Request.QueryString["ids[]"];
                if (friendIds != null)
                {
                    FriendIdsLabel.Text = friendIds;
                    FriendsNamesLabel.Text = "";
                    try
                    {
                        FacebookWebClient facebook = new FacebookWebClient();
                        JsonArray friendsArray = (JsonArray)facebook.Query("select name from user where uid in (" + friendIds + ")");
                        foreach (JsonObject f in friendsArray)
                        {
                            FriendsNamesLabel.Text += (string)f["name"] + ", ";
                        }
                    }
                    catch (Exception)
                    {
                        ErrorLabel.Text = "Error on getting friends' names by calling FQL";
                        ErrorLabel.Visible = true;
                    }
                }
                else
                {
                    ErrorLabel.Text = "No one of friends are invited";
                    ErrorLabel.Visible = true;
                }
            }
        }
    }
}
