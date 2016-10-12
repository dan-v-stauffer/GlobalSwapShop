using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using Facebook.Web;
using FVK;
using GlobalSwapShop;


public partial class InvitationThankYou : GlobalPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Page.IsPostBack)
            return;

        string friendIds = Request.QueryString["ids[]"];
        if (friendIds != null)
        {
            InvitedFriendsLabel.Text = friendIds;
            InvitedFriendsNames.Text = "";
            try
            {
                FacebookWebClient facebook = new FacebookWebClient();
                JsonArray friendsArray = (JsonArray)facebook.Query("select name from user where uid in (" + friendIds + ")");
                foreach (JsonObject f in friendsArray)
                {
                    InvitedFriendsNames.Text += (string)f["name"] + ", ";
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
            ErrorLabel.Text = "No friends were invited";
            ErrorLabel.Visible = true;
        }
    }
}