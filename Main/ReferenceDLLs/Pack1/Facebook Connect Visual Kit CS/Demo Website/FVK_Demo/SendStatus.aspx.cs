using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Facebook;
using Facebook.Web;
using FVK;

namespace FVK_Demo
{
    public partial class SendStatus : System.Web.UI.Page
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

        protected void OnSendStatus(object sender, EventArgs e)
        {
            SendStatusHandlerLabel.Text = "Send Status Handler Executed";
        }
    }
}
