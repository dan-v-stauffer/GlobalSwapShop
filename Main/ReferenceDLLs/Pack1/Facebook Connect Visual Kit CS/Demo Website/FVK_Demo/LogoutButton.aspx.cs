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
    public partial class LogoutButton : System.Web.UI.Page
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
            }
            
        }

        protected void Logout(object sender, EventArgs e)
        {
            LogoutLabel.Visible = true;
        }
    }
}
