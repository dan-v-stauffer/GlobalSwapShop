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
    /// Link data class uses to store data of link
    /// </summary>
    public class LinkData : IJSONSerialize
    {
        /// <summary>
        /// Create new undefined LinkData object
        /// </summary>
        public LinkData() { }

        /// <summary>
        /// Create and define new LinkData object
        /// </summary>
        /// <param name="text">Text of the link</param>
        /// <param name="href">Destination of the link</param>
        public LinkData(string text, string href)
        {
            this.text = text;
            this.href = href;
        }

        /// <summary>
        /// Text of the link
        /// </summary>
        public string Text { get { return text; } set { text = value; } }

        /// <summary>
        /// Destination of the link
        /// </summary>
        public string Href { get { return href; } set { href = value; } }

        /// <summary>
        /// Serialize Link data in JSON format
        /// </summary>
        /// <returns>JSON formated string</returns>
        public string JSONSerialize()
        {
            return "{\"text\":\"" + text + "\",\"href\":\"" + href + "\"}";
        }


        /// <summary>
        /// Private members
        /// </summary>
        string text;
        string href;

    }
}
