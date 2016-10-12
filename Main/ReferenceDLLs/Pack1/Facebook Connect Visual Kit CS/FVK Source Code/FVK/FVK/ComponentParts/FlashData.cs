// WARNING: 
// The source code of this class can be used and modified to your particular needs. 
// Sharing the class with unregistered users or using it with unregistered websites 
// or Facebook applications is not allowed and violates the rights of intellectual 
// property. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace FVK
{
    /// <summary>
    /// FlashData class uses to store data about flash media for stream publishing
    /// </summary>
    public class FlashData: IJSONSerialize
    {
        /// <summary>
        /// Create new undefined Flash data object
        /// </summary>
        public FlashData() { }

        /// <summary>
        /// Create amd define new Flash data object
        /// </summary>
        /// <param name="swfSrc">URL of SWF file</param>
        /// <param name="imgSrc">URL of Image file</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="expandedWidth">Extended width</param>
        /// <param name="expandedHeight">Extended height</param>
        public FlashData(string swfSrc, string imgSrc, int width, int height, int expandedWidth, int expandedHeight)
        {
            this.swfSrc = swfSrc;
            this.imgSrc = imgSrc;
            this.width = width;
            this.height = height;
            this.expandedWidth = expandedWidth;
            this.expandedHeight = expandedHeight;
        }

        /// <summary>
        /// URL of SWF file
        /// </summary>
        public string SwfSrc { get { return swfSrc; } set { swfSrc = value; } }

        /// <summary>
        /// URL of Image file
        /// </summary>
        public string ImgSrc { get { return imgSrc; } set { imgSrc = value; } }

        /// <summary>
        /// Widht
        /// </summary>
        public int Width { get { return width; } set { width = value; } }

        /// <summary>
        /// Height
        /// </summary>
        public int Height { get { return height; } set { height = value; } }

        /// <summary>
        /// Expanded Widht
        /// </summary>
        public int ExpandedWidth { get { return expandedWidth; } set { expandedWidth = value; } }

        /// <summary>
        /// Expanded Height
        /// </summary>
        public int ExpandedHeight { get { return expandedHeight; } set { expandedHeight = value; } }

        /// <summary>
        /// Serialize Flash data in JSON formated string
        /// </summary>
        /// <returns>JSON formated string</returns>
        public string JSONSerialize()
        {
            return "{\"type\":\"flash\",\"swfsrc\":\"" + swfSrc + "\",\"imgsrc\":\"" + imgSrc + "\"," +
                   "\"width\":\"" + width + "\", \"height\":\"" + height +
                   "\",\"expanded_width\":\"" + expandedWidth + "\", \"expanded_height\":\"" + expandedHeight + "\"}";
        }


        /// <summary>
        /// Private members
        /// </summary>
        private string swfSrc;
        private string imgSrc;
        private int width;
        private int height;
        private int expandedWidth;
        private int expandedHeight;
    }
}
