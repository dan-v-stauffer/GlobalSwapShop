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
    /// FriendData class contains Id and Name of facebook user and support for comparing
    /// </summary>
    [Serializable]
    public class FriendData: IComparable<FriendData>
    {
        /// <summary>
        /// Create undefined FriendData object
        /// </summary>
        public FriendData() { }

        /// <summary>
        /// Create and define FriendData object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public FriendData(long id, string name)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// Id
        /// </summary>
        public long Id { get { return id; } set { id = value; } }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get { return name; } set { name = value; } }

        /// <summary>
        /// Compare FriendData objects
        /// </summary>
        /// <param name="other">other FriendData object</param>
        /// <returns>Look at CompareTo .NET documetation</returns>
        public int CompareTo(FriendData other)
        {
            return this.Name.CompareTo(other.Name);
        }


        /// <summary>
        /// Private members
        /// </summary>
        /// 
        private long id;
        private string name;
    }
}
