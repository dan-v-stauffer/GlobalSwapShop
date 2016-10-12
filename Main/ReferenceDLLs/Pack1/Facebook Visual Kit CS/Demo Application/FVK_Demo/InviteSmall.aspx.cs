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
    public partial class InviteSmall : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            invite2.ActionUrl = FVKConfig.AppUrl + "InvitedFriends.aspx";
        }
    }
}
