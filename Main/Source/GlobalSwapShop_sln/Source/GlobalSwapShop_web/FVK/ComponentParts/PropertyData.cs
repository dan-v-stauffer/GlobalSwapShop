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
    /// The class contains data of Property for stream publishing
    /// </summary>
    public class PropertyData: IJSONSerialize
    {
        /// <summary>
        /// Create new undefined PropertyData object
        /// </summary>
        public PropertyData() { }

        /// <summary>
        /// Create and define new PropertyData object
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="text">Propery text</param>
        public PropertyData(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        /// <summary>
        /// Propery name
        /// </summary>
        public string Name { get { return name; } set { name = value; } }

        /// <summary>
        /// Property text
        /// </summary>
        public string Text { get { return text; } set { text = value; } }

        /// <summary>
        /// Serialize Propery data in JSON format
        /// </summary>
        /// <returns>JSON formated string</returns>
        public string JSONSerialize()
        {
            return "\"" + name + "\":\"" + text + "\"";
        }


        /// <summary>
        /// Protected members
        /// </summary>
        protected string name;
        protected string text;
    }
}
