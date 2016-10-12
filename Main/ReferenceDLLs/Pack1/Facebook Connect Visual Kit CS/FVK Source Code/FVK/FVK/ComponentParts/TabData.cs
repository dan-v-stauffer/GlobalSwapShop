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
    public class TabData
    {
        private string name;
        private string url;
        private int width;
       
        public TabData(string name, string url, int width)
        {
            this.name = name;
            this.url = url;
            this.width = width;
        }

        public string Name { get { return name; } }
        public string Url { get { return url; } }
        public int Width { get { return width; } }
    }
}
