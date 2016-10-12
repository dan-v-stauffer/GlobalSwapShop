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
    /// VideoData class uses to store data about Video media for stream publishing
    /// </summary>
    public class VideoData: IJSONSerialize
    {
        /// <summary>
        /// Create new undefined VideoData object
        /// </summary>
        public VideoData() { }

        /// <summary>
        /// Create and define new VideaData object
        /// </summary>
        /// <param name="videoSrc">URL of video file</param>
        /// <param name="previewImg">URL of preview image</param>
        /// <param name="videoLink">Destination URL when video is clicked</param>
        /// <param name="videoTitle">Video Title</param>
        public VideoData(string videoSrc, string previewImg, string videoLink, string videoTitle)
        {
            this.videoSrc = videoSrc;
            this.previewImg = previewImg;
            this.videoLink = videoLink;
            this.videoTitle = videoTitle;
        }

        /// <summary>
        /// URL of video file
        /// </summary>
        public string VideoSrc { get { return videoSrc; } set { videoSrc = value; } }

        /// <summary>
        /// URL of preview image
        /// </summary>
        public string PreviewImg { get { return previewImg; } set { previewImg = value; } }

        /// <summary>
        /// Destination URL when video is clicked
        /// </summary>
        public string VideoLink { get { return videoLink; } set { videoLink = value; } }

        /// <summary>
        /// Video Title
        /// </summary>
        public string VideoTitle { get { return videoTitle; } set { videoTitle = value; } }

        /// <summary>
        /// Serialize Video data in JSON format
        /// </summary>
        /// <returns>JSON formated string</returns>
        public string JSONSerialize()
        {
            return "{\"type\":\"video\",\"video_src\":\"" + videoSrc + "\",\"preview_img\":\"" + previewImg + "\"," +
                   "\"video_link\":\"" + videoLink + "\", \"video_title\":\"" + videoTitle + "\"}";
        }


        /// <summary>
        /// Private members
        /// </summary>
        private string videoSrc;
        private string previewImg;
        private string videoLink;
        private string videoTitle;
    }
}
