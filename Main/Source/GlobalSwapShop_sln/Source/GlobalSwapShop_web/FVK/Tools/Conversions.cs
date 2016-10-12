// WARNING: 
// The source code of this class can be used and modified to your particular needs. 
// Sharing the class with unregistered users or using it with unregistered websites 
// or Facebook applications is not allowed and violates the rights of intellectual 
// property. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FVK;
using System.Text;

namespace FVK
{
    /// <summary>
    /// Conversions class provide several static methods to converts among several types,
    /// mostly conversions among familiar lists of different types
    /// </summary>
    public static class Conversions
    {
        /// <summary>
        /// Make conversion from list of FriendData class to list of friends Ids
        /// </summary>
        /// <param name="friends">IList of FriendData</param>
        /// <returns>IList of friend Ids</returns>
        public static IList<long> FriendDataListToIdList(IList<FriendData> friends)
        {
            IList<long> ids = new List<long>();
            foreach (FriendData f in friends)
            {
                ids.Add(f.Id);
            }
            return ids;
        }

        /// <summary>
        /// Make conversion from list of FriendData to list of friends names
        /// </summary>
        /// <param name="friends">IList of FriendData</param>
        /// <returns>Ilist of friends names</returns>
        public static IList<string> FriendDataListToNameList(IList<FriendData> friends)
        {
            IList<string> ids = new List<string>();
            foreach (FriendData f in friends)
            {
                ids.Add(f.Name);
            }
            return ids;
        }

        /// <summary>
        /// Make conversion from list of FriendData to string contained of comma separated list of friends Ids
        /// </summary>
        /// <param name="friends">IList of FriendData</param>
        /// <returns>String contained of comma separated list of friends Ids</returns>
        public static string FriendsDataListToStringIds(IList<FriendData> friends)
        {
            StringBuilder s = new StringBuilder();
            int i = 0;
            int count = friends.Count;
            foreach (FriendData f in friends)
            {
                i++;
                s.Append(f.Id);
                if (i < count)
                {
                    s.Append(",");
                }
            }
            return s.ToString();
        }

        /// <summary>
        /// Make conversion from list of FriendData to string contained of comma separated list of friends names
        /// </summary>
        /// <param name="friends">IList of FriendData</param>
        /// <returns>String contained of comma separated list of friends names</returns>
        public static string FriendsDataListToNamesString(IList<FriendData> friends)
        {
            StringBuilder s = new StringBuilder();
            int i = 0;
            int count = friends.Count;
            foreach (FriendData f in friends)
            {
                i++;
                s.Append(f.Name);
                if (i < count)
                {
                    s.Append(",");
                }
            }
            return s.ToString();
        }

        /// <summary>
        /// Make conversion from list of JSON serializable objects to string which represents list in JSON format
        /// </summary>
        /// <param name="list">IList of JSON serializable objects</param>
        /// <returns>String which represents list in JSON format</returns>
        public static string JSONListToJSONString(IList<IJSONSerialize> list)
        {
            StringBuilder str = new StringBuilder();
            if (list.Count > 0)
            {
                int i = 0;
                foreach (IJSONSerialize v in list)
                {
                    str.Append(v.JSONSerialize());
                    i++;
                    if (i < list.Count)
                    {
                        str.Append(",");
                    }
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// Make conversion from list of LinkData objects to string which represents list in JSON format
        /// </summary>
        /// <param name="list">IList of LinkDat objects</param>
        /// <returns>string which represents list in JSON format</returns>
        public static string LinkListToJSONString(IList<LinkData> list)
        {
            IList<IJSONSerialize> list2 = new List<IJSONSerialize>();
            foreach (LinkData ld in list) list2.Add(ld);
            return JSONListToJSONString(list2);
        }
    }
}

