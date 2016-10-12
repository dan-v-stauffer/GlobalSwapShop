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
    public partial class Permissions: Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void OnAddPermission(object sender, EventArgs e)
        {
            PermAddedLabel.Text = "Permissions Added: ";
            foreach (PermissionEnum perm in permissions1.ConfirmedPermissions)
            {
                PermAddedLabel.Text += perm.ToString() + " ";
            }
        }

    }
}
