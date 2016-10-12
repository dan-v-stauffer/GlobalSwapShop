using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GlobalSwapShop;
using Facebook;

public partial class Account_Login : GlobalPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    protected void OnConnected(object sender, EventArgs e)
    {
        try
        {
            // get user data
            FacebookApp facebook = new FacebookApp();
            JsonObject user = (JsonObject)facebook.Api("me");
            String id = (string)user["id"];
            String name = (string)user["name"];
            String email = (string)user["email"];
        }
        catch (Exception)
        {
            // Session is invalid, handle error
        }
    }
}
