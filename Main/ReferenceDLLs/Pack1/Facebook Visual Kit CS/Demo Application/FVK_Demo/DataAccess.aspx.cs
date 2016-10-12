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
    public partial class DataAccess : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var auth = new CanvasAuthorizer { Permissions = new[] { "email" } };

                if (! auth.Authorize())
                {
                    ErrorLabel.Visible = true;
                    return;
                }

                var facebook = new FacebookWebClient();

                // get user object
                try
                {
                    JsonObject user = (JsonObject)facebook.Get("me");
                    UserIdLabel.Text = (string)user["id"];
                    UserNameLabel.Text = (string)user["name"];
                    UserEmailLabel.Text = (string)user["email"];
                }
                catch (Exception)
                {
                    ErrorLabel.Text = "Error accessing user object";
                    ErrorLabel.Visible = true;
                    return;
                }

                // get friend list
                try
                {
                    JsonObject friends = (JsonObject)facebook.Get("me/friends");
                    JsonArray friendsList = (JsonArray)friends["data"];

                    // print max 5 friends
                    FriendsLabel.Text = "";
                    int counter = 0;
                    foreach (JsonObject f in friendsList)
                    {
                        FriendsLabel.Text += (string)f["name"] + ", ";
                        counter++;
                        if (counter == 5) break;
                    }
                }
                catch (Exception)
                {
                    ErrorLabel.Text = "Error accession friends list";
                    ErrorLabel.Visible = true;
                }
            }
        }
    }
}
