using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookStart
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
                tab1.AddTab("Home Page", "Default.aspx", 100);
                tab1.AddTab("Second Page", "SecondPage.aspx", 100);
                tab1.AddTab("Invite Friends", "Invite.aspx", 100);

                tab1.NumOfRightTabs = 1;
                tab1.Distance = 5;
            }
        }
    }
}
