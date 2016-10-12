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
    /// ImageData class uses to store data about image media for stream publishing
    /// </summary>
    public class ImageData: IJSONSerialize
    {
        /// <summary>
        /// Create new undefined ImageData object
        /// </summary>
        public ImageData() { }

        /// <summary>
        /// Create and define new ImageData object
        /// </summary>
        /// <param name="imageUrl">URL of image</param>
        /// <param name="destUrl">URL of destionation when image is clicked</param>
        public ImageData(string imageUrl, string destUrl)
        {
            this.imageUrl = imageUrl;
            this.destUrl = destUrl;
        }

        /// <summary>
        /// URL of image
        /// </summary>
        public string ImageUrl { get { return imageUrl; } set { imageUrl = value; } }

        /// <summary>
        /// URL of destionation when image is clicked
        /// </summary>
        public string DestUrl { get { return destUrl; } set { destUrl = value; } }

        /// <summary>
        /// Serialize Image data in JSON format
        /// </summary>
        /// <returns>JSON formated string</returns>
        public string JSONSerialize()
        {
            return "{\"type\":\"image\",\"src\":\"" + imageUrl + "\",\"href\":\"" + DestUrl + "\"}";
        }


        /// <summary>
        /// Private members
        /// </summary>
        private string imageUrl;
        private string destUrl;
    }
}
