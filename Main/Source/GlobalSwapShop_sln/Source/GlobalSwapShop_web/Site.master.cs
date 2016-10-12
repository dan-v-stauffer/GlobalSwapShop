using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // enable third party cookies on IE
            Response.AppendHeader("P3P", "CP=\"CAO PSA OUR\"");
            LanguageSelector.SelectedValue = Thread.CurrentThread.CurrentCulture.Name;

        }
    }
}
