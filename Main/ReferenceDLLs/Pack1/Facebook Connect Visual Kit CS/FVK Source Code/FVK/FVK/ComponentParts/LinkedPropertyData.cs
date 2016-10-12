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
    /// The class contains data of linked property for stream publishing
    /// </summary>
    public class LinkedPropertyData: PropertyData, IJSONSerialize
    {
        /// <summary>
        /// Create new undefined LinkedPropertyData object
        /// </summary>
        public LinkedPropertyData() { }

        /// <summary>
        /// Create and define new LinkedPropertyData object
        /// </summary>
        /// <param name="name">Name of property</param>
        /// <param name="text">Text of the link</param>
        /// <param name="href">Destionation of the link</param>
        public LinkedPropertyData(string name, string text, string href) : base(name, text)
        {
            this.href = href;
        }

        /// <summary>
        /// Destionation of the link
        /// </summary>
        public string Href { get { return href; } set { href = value;} }

        /// <summary>
        /// Serialize object data in JSON format
        /// </summary>
        /// <returns>JSON formated string</returns>
        new public string JSONSerialize()
        {
            return "\"" + name + "\":{\"text\":\"" + text + "\",\"href\":\"" + href + "\"}";
        }


        /// <summary>
        /// Private members
        /// </summary>
        string href;
    }
}
