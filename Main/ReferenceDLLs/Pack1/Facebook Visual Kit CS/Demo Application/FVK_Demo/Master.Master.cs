using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FVK_Demo
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // enable third party cookies on IE
                Response.AppendHeader("P3P", "CP=\"CAO PSA OUR\"");

                // define tabs
                tab1.AddTab("Home", "Default.aspx", 70);
                tab1.AddTab("1st Component Set", "RequestDialog.aspx", 140);
                tab1.AddTab("2nd Component Set", "Invite.aspx", 140);
                tab1.AddTab("3rd Component Set", "BookmarkButton.aspx", 140);
                tab1.AddTab("Data Access", "DataAccess.aspx", 100);
                tab1.NumOfRightTabs = 1;
                tab1.Distance = 5;
            }
        }
    }
}
