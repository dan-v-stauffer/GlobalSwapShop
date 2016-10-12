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
    /// MP3Data class uses to store data about MP3 media for stream publishing
    /// </summary>
    public class MP3Data: IJSONSerialize
    {
        /// <summary>
        /// Create new undefined MP3Data object
        /// </summary>
        public MP3Data() { }

        /// <summary>
        /// Create and define new MP3Data object
        /// </summary>
        /// <param name="src">URL of MP3 file</param>
        /// <param name="title">Title</param>
        /// <param name="artist">Artist name</param>
        /// <param name="album">Album name</param>
        public MP3Data(string src, string title, string artist, string album)
        {
            this.src = src;
            this.title = title;
            this.artist = artist;
            this.album = album;
        }

        /// <summary>
        /// URL of mp3 file
        /// </summary>
        public string Src { get { return src; } set { src = value; } }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get { return title; } set { title = value; } }

        /// <summary>
        /// Artist name
        /// </summary>
        public string Artist { get { return artist; } set { artist = value; } }

        /// <summary>
        /// Album name
        /// </summary>
        public string Album { get { return album; } set { album = value; } }

        /// <summary>
        /// Serialize MP3 data in JSON format
        /// </summary>
        /// <returns>JSON formated string</returns>
        public string JSONSerialize()
        {
            return "{\"type\":\"mp3\",\"src\":\"" + src + "\",\"title\":\"" + title + "\"," +
                   "\"artist\":\"" + artist + "\", \"album\":\"" + album + "\"}";
        }


        /// <summary>
        /// Private members
        /// </summary>
        private string src;
        private string title;
        private string artist;
        private string album;
    }
}
