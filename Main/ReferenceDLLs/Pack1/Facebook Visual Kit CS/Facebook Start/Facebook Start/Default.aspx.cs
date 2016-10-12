using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using Facebook.Web;
using FVK;

namespace FacebookStart
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var auth = new CanvasAuthorizer { Permissions = new[] { "email" } };

                if (auth.Authorize())
                {
                    var facebook = new FacebookWebClient();

                    // check if facebook session is valid
                    try
                    {
                        JsonObject basicData = (JsonObject)facebook.Get("me?fields=id,name");
                    }
                    catch (Exception)
                    {
                        Session.Clear();
                        auth.HandleUnauthorizedRequest();
                        return;
                    }
                }
            }
        }
    }
}
