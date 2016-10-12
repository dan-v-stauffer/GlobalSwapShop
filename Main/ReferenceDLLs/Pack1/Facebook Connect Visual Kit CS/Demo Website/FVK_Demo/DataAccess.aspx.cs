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
    public partial class DataAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fbWebContext = FacebookWebContext.Current;
            if (! fbWebContext.IsAuthorized())
            {
                ErrorLabel.Text = "Facebook session is not established. Please login by pressing login button:";
                ErrorLabel.Visible = true;
                loginbutton1.Visible = true;
                return;
            }
            ErrorLabel.Visible = false;
            loginbutton1.Visible = false;

            var facebook = new FacebookWebClient(fbWebContext);

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
