using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FVK_Demo
{
    public partial class Components2Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tab3.AddTab("Invite Friends", "Invite.aspx", 120);
                tab3.AddTab("Invite F. Small", "InviteSmall.aspx", 120);
                tab3.AddTab("Comments", "Comments.aspx", 120);
                tab3.AddTab("Select Friends", "SelectFriends.aspx", 120);
                tab3.AddTab("Send Status", "SendStatus.aspx", 120);

                tab3.Distance = 5;
                tab3.BorderWidth = 10;
            }
        }
    }
}
