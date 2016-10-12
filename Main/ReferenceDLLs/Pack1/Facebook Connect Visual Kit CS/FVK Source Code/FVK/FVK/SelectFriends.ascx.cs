// WARNING: 
// The source code of this class can be used and modified to your particular needs. 
// Sharing the class with unregistered users or using it with unregistered websites 
// or Facebook applications is not allowed and violates the rights of intellectual 
// property. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace FVK
{
    /// <summary>
    /// This control uses to include possibility to select Facebook frends as easy as possible. The control 
    /// has 2 types of filter methods and 3 types of selection methods. There are also possibility to change 
    /// number of rows and columns.
    /// </summary>
    public partial class SelectFriends : System.Web.UI.UserControl
    {
        /// <summary>
        /// Inform client about changes in selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void SelectionChangedHandler(object sender, EventArgs e);
        public event SelectionChangedHandler SelectionChanged;

        /// <summary>
        /// Set num of rows
        /// </summary>
        public int Rows
        {
            set
            {
                selectfriendsdiv.Style.Add("height", (value * 25).ToString() + "px");
            }
        }

        /// <summary>
        /// set num of columns
        /// </summary>
        public int Columns
        {
            set
            {
                if (value > 4)
                {
                    throw new Exception("Number of columns exceed limit (4)");
                }
                selectfriendsdiv.Style.Add("width", (value * 170 + 20).ToString() + "px");
            }
        }

        /// <summary>
        /// Get selected friend list
        /// </summary>
        /// <returns></returns>
        public IList<FriendData> GetSelectedFriends()
        {
            IList<FriendData> selectedFriends = new List<FriendData>();
            foreach (SelectedFriend f in Friends)
            {
                if (f.Selected)
                {
                    selectedFriends.Add(f);
                }
            }
            return selectedFriends;
        }

        /// <summary>
        /// Filter list by name which starts with parameter
        /// </summary>
        /// <param name="namePart"></param>
        public void FilterByNameStartsWith(string namePart)
        {
            foreach (SelectedFriend f in Friends)
            {
                if (f.Name.ToLower().StartsWith(namePart.ToLower()))
                {
                    f.IsInList = true;
                }
                else
                {
                    f.IsInList = false;
                }
                f.Selected = false;
            }
            OnSelectionChangedCall();
        }

        /// <summary>
        /// Filter list by name which contains parameter
        /// </summary>
        /// <param name="namePart"></param>
        public void FilterByNameContains(string namePart)
        {
            foreach (SelectedFriend f in Friends)
            {
                if (f.Name.ToLower().Contains(namePart.ToLower()))
                {
                    f.IsInList = true;
                }
                else
                {
                    f.IsInList = false;
                }
                f.Selected = false;
            }
            OnSelectionChangedCall();
        }

        /// <summary>
        /// Select all in filtered list
        /// </summary>
        public void SelectAll()
        {
            foreach (SelectedFriend f in Friends)
            {
                if (f.IsInList)
                {
                    f.Selected = true;
                }
            }
            OnSelectionChangedCall();
        }

        /// <summary>
        /// Unselect All
        /// </summary>
        public void UnselectAll()
        {
            foreach (SelectedFriend f in Friends)
            {
                f.Selected = false;
            }
            OnSelectionChangedCall();
        }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                StringBuilder script = new StringBuilder();
                script.Append("<script>\n");
                script.Append("function InitFriends() {\n");
                script.Append("if (graphApiInitialized != true) {\n");
                script.Append("  setTimeout('" + "InitFriends" + "()', 100);\n");
                script.Append("  return;\n");
                script.Append("}\n");
                script.Append("var friends = FB.api('/me/friends?fields=id, name', function(response) {\n");
                script.Append("  if (!response || response.error) {\n");
                script.Append("  } else {\n");
                script.Append("    var friends = response.data;\n");
                script.Append("    var stringList = \"\";\n");
                script.Append("    for (var i = 0; i < friends.length; i++) {\n");
                script.Append("       stringList += friends[i].id;\n");
                script.Append("       stringList += \",\";\n");
                script.Append("       stringList += friends[i].name;\n");
                script.Append("       stringList += \",\";\n");
                script.Append("    }\n");
                script.Append("    var tempList = document.getElementById(\"" + TempList.ClientID + "\");\n");
                script.Append("    tempList.value = stringList;\n");
                script.Append("    var initButton = document.getElementById(\"" + InitButton.ClientID + "\");\n");
                script.Append("    initButton.click();\n");
                script.Append("  }\n");
                script.Append("});\n");
                script.Append("};");
                script.Append("InitFriends();\n");
                script.Append("</script>\n");
                scriptSpan.InnerHtml = script.ToString();
            }
        }

        /// <summary>
        /// Initialize friends list from hidden field created with Java Script SDK. Do not call it directly.
        /// </summary>
        protected void SelfInitialize(object sender, EventArgs e)
        {
            string friendsString = TempList.Value;
            IList<SelectedFriend> friends = new List<SelectedFriend>();
            int index1 = 0;
            int index2 = 0;
            while (index1 < friendsString.Length - 1)
            {
                index2 = friendsString.IndexOf(",", index1);
                string id = friendsString.Substring(index1, index2 - index1);
                index1 = index2 + 1;
                index2 = friendsString.IndexOf(",", index1);
                string name = friendsString.Substring(index1, index2 - index1);
                index1 = index2 + 1;
                SelectedFriend friend = new SelectedFriend(Int64.Parse(id), name, false, false, true);
                friends.Add(friend);
            }
            TempList.Value = null;
            Friends = friends;
            FriendsRepeater.DataSource = friends;
            FriendsRepeater.DataBind();
        }

        /// <summary>
        /// One of friend in check box list is selected or unselected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FriendCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IList<SelectedFriend> friends = FilteredList;
            int friendIndex = 0;
            foreach (RepeaterItem item in FriendsRepeater.Items)
            {
                // read value from checkbox and store it to friend list
                CheckBox checkBox = (CheckBox)item.FindControl("FriendCheckBox");
                SelectedFriend friend = friends[friendIndex];
                friend.Selected = checkBox.Checked;
                friendIndex++;
            }
            OnSelectionChangedCall();
        }


        /// <summary>
        /// Get friends from viewstate
        /// </summary>
        private IList<SelectedFriend> Friends
        {
            get {return (List<SelectedFriend>)ViewState["SelectedFriends"]; }
            set {ViewState["SelectedFriends"] = value; }
        }

        /// <summary>
        /// Get filtered list of friends
        /// </summary>
        private IList<SelectedFriend> FilteredList
        {
            get
            {
                IList<SelectedFriend> filteredList = new List<SelectedFriend>();
                foreach (SelectedFriend f in Friends)
                {
                    if (f.IsInList)
                    {
                        filteredList.Add(f);
                    }
                }
                return filteredList;
            }
        }

        /// <summary>
        /// Inform client about changes in selecting
        /// </summary>
        private void OnSelectionChangedCall()
        {
            FriendsRepeater.DataSource = FilteredList;
            FriendsRepeater.DataBind();
            if (SelectionChanged != null)
            {
                SelectionChanged(this, null);
            }
        }        
    }
}