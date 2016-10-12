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
    public partial class Invite : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            invite1.ActionUrl = FVKConfig.AppUrl + "InvitedFriends.aspx";
        }
    }
}
