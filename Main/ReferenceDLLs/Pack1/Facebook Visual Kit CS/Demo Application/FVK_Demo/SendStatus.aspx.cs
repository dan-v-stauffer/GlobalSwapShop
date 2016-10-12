using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.Web;

namespace FVK_Demo
{
    public partial class SendStatus : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void OnSendStatus(object sender, EventArgs e)
        {
            SendStatusHandlerLabel.Text = "Send Status Handler Executed";
        }
    }
}
