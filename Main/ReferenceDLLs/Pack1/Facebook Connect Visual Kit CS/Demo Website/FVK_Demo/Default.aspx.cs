using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using Facebook.Web;
using System.Configuration;
using FVK;

namespace FVK_Demo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fbWebContext = FacebookWebContext.Current;
            if (! fbWebContext.IsAuthorized())
            {
                Label1.Visible = true;
                loginbutton1.Visible = true;
            }
            else
            {
                Label1.Visible = false;
                loginbutton1.Visible = false;
            }
        }

        protected void OnConnected(object sender, EventArgs e)
        {
            Response.Redirect("DataAccess.aspx");
        }
    }
}
