// WARNING: 
// The source code of this class can be used and modified to your particular needs. 
// Sharing the class with unregistered users or using it with unregistered websites 
// or Facebook applications is not allowed and violates the rights of intellectual 
// property. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FVK
{
    /// <summary>
    /// This class uses to store data about Facebook user for SelectFriends control
    /// </summary>
    [Serializable]
    public class SelectedFriend : FriendData, IComparable<SelectedFriend>
    {
        /// <summary>
        /// Create and define new SelectedFriend object
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="name">User Name</param>
        /// <param name="selected">Is user selected</param>
        /// <param name="isAppUser">Is user application user</param>
        /// <param name="isInList">Is user currently in the filtered list</param>
        public SelectedFriend(long id, string name, bool selected, bool isAppUser, bool isInList)
            : base(id, name)
        {
            this.selected = selected;
            this.isAppUser = isAppUser;
            this.isInList = isInList;
        }

        /// <summary>
        /// Is user selected
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// Is user application user
        /// </summary>
        public bool IsAppUser
        {
            get { return isAppUser; }
        }

        /// <summary>
        /// Is user currently in the list
        /// </summary>
        public bool IsInList
        {
            get { return isInList; }
            set { isInList = value; }
        }

        /// <summary>
        /// Compare SelectedFriend objects
        /// </summary>
        /// <param name="other">other SelectedFriend object</param>
        /// <returns>Look at CompareTo .NET documetation</returns>
        public int CompareTo(SelectedFriend other)
        {
            return Name.CompareTo(other.Name);
        }


        /// <summary>
        /// Private members
        /// </summary>
        private bool selected;
        private bool isAppUser;
        private bool isInList;

    }
}
