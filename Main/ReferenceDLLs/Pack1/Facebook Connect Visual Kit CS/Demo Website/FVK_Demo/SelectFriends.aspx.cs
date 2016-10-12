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
    public partial class SelectFriends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                selectfriends1.Rows = 4;
                selectfriends1.Columns = 3;
                selectfriends1.Visible = true;
            }

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

        protected void OnSelectedFriends(object sender, EventArgs e)
        {
            SelectedFriendsLabel.Text = "Selected Friends: " +
            Conversions.FriendsDataListToNamesString(selectfriends1.GetSelectedFriends());
        }

        protected void FilterIfStartsWithButton_Click(object sender, EventArgs e)
        {
            selectfriends1.FilterByNameStartsWith(FilterTextBox.Text);
        }

        protected void FilterIfContainsButton_Click(object sender, EventArgs e)
        {
            selectfriends1.FilterByNameContains(FilterTextBox.Text);
        }

        protected void SelectAllButton_Click(object sender, EventArgs e)
        {
            selectfriends1.SelectAll();
        }

        protected void UnselectAllButton_Click(object sender, EventArgs e)
        {
            selectfriends1.UnselectAll();
        }

        
    }
}
