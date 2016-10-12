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
    public partial class SelectFriends : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
