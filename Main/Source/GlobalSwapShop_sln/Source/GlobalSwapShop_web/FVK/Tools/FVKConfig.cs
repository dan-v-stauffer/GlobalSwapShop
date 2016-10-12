// WARNING: 
// The source code of this class can be used and modified to your particular needs. 
// Sharing the class with unregistered users or using it with unregistered websites 
// or Facebook applications is not allowed and violates the rights of intellectual 
// property. 

using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace FVK
{
    public static class FVKConfig
    {
        public static string AppId { get { return appId; } set { appId = value; } }
        public static string AppSecret { get { return appSecret; } set { appSecret = value; } }
        public static string AppName { get { return appName; } set { appName = value; } }
        public static string AppUrl { get { return appUrl; } set { appUrl = value; } }

        static FVKConfig()
        {
            // Initialization
            appId = ConfigurationManager.AppSettings["appId"];
            appSecret = ConfigurationManager.AppSettings["appSecret"];
            appName = ConfigurationManager.AppSettings["appName"];
            appUrl = ConfigurationManager.AppSettings["appUrl"];

            // checking
            if (appId == null || appId == "")
            {
                throw new Exception("AppId is not defined in Web.config");
            }

            if (appSecret == null || appSecret == "")
            {
                throw new Exception("Secret is not defined in Web.config");
            }

            if (appName == null || appName == "")
            {
                throw new Exception("AppName is not defined in Web.config");
            }

            if (appUrl == null || appUrl == "")
            {
                throw new Exception("AppCanvasUrl is not defined in Web.config");
            }
            else
            {
                if (!appUrl.EndsWith("/"))
                {
                    appUrl += "/";
                }
            }
        }

        private static string appId;
        private static string appSecret;
        private static string appName;
        private static string appUrl;
    }
}
