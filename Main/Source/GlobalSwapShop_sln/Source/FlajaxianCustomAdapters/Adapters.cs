using System;
using System.Collections;
using System.Text;
using System.Web;
using System.IO;
using com.flajaxian;
using System.Windows.Forms;

namespace FlajaxianCustomAdapters
{
    // This adapter converts uploaded file to byte array, stores it in a Session Variable
    // then passed byte data to referenced image handler.

    public class SessionThumbnailAdapter : FileUploaderAdapter
    {
        private byte[] _data;
        private String _imageHandlerURL;
        private String _sessionImageTag;
        private String _sessionImageBinaryTag;

        public String ImageHandlerURL
        {
            get { return _imageHandlerURL; }
            set { _imageHandlerURL = value; }
        }

          public String SessionImageTag
        {
            get { return _sessionImageTag; }
            set { _sessionImageTag = value; }
        }

          public String SessionImageBinaryTag
          {
              get { return _sessionImageBinaryTag; }
              set { _sessionImageBinaryTag = value; } 
          }

        /// <param name="file">Incoming file</param>
        public override void ProcessFile(HttpPostedFile file)
        {
            System.Web.UI.Page me = this.Parent.Page;

            using (var binaryReader = new BinaryReader(file.InputStream)) 
            {
                _data = binaryReader.ReadBytes(file.ContentLength); 
            }
            MemoryStream ms = new System.IO.MemoryStream(_data);

            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            Guid imageID = Guid.NewGuid();
            me.Session[_sessionImageBinaryTag] = imageID;

            HttpRuntime.Cache.Add(imageID.ToString(), _data, null,
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.Normal,
                null);

            me.Session[_sessionImageTag] = ImageHandlerURL + "?id=" + imageID.ToString() +
                                    "&fake=" + DateTime.Now.Ticks.ToString();
 
        }


    }
}
