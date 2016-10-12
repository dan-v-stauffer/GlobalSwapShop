using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.Web;
using FVK;
using GlobalSwapShop;

public partial class InviteFriends : GlobalPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //InviteFriends1.MainTitle = "Global Swap Shop Invitation";
        //InviteFriends1.Content = "Come join us at the Global Swap Shop";
        InviteFriends1.ActionUrl = FVKConfig.AppUrl + "InvitationThankYou.aspx";
        InviteFriends1.AcceptUrl = FVKConfig.AppUrl + "InvitationAccept.aspx";
    }
}