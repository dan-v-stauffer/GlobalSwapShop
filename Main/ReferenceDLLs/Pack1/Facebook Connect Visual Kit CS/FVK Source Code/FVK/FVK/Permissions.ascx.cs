// WARNING: 
// The source code of this class can be used and modified to your particular needs. 
// Sharing the class with unregistered users or using it with unregistered websites 
// or Facebook applications is not allowed and violates the rights of intellectual 
// property. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace FVK
{
    /// <summary>
    /// Facebook Permission control uses to enable user to add some permission to used Facebook application 
    /// or Facebook Connect web site like send email, status update ...
    /// </summary>
    public partial class Permissions : System.Web.UI.UserControl
    {
        /// <summary>
        /// Inform client on added permission
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void AddPermissionHandler(object sender, EventArgs e);
        public event AddPermissionHandler AddedPermission;

        /// <summary>
        /// Link Text
        /// </summary>
        public string Text
        {
            set { text = value; }
        }

        /// <summary>
        /// Set type of command control(link, button, auto_open). If auto_open is
        /// set permission popup is open on page load. Default = link.
        /// </summary>
        public string CommandType
        {
            set {
                switch (value)
                {
                    case "link": commandType = CommandTypeEnum.Link; break;
                    case "button": commandType = CommandTypeEnum.Button; break;
                    case "auto_open": commandType = CommandTypeEnum.AutoOpen; break;
                    default:
                        throw new Exception("Invalid command type, supported values are link, button and auto_open");
                }
            }
        }

        /// <summary>
        /// Add permission list in string representation separated by comma.
        /// </summary>
        public string PermissionList
        {
            set
            {
                value.Trim();
                foreach (string perm in value.Split(','))
                {
                    if (perm != "")
                    {
                        string pt = perm.Trim();
                        if (reversePermMap.Keys.Contains<string>(pt))
                        {
                            PermissionEnum p = reversePermMap[pt];
                            if (!requiredPermissions.Contains(p))
                            {
                                requiredPermissions.Add(p);
                            }
                        }
                        else
                        {
                            throw new Exception("Unsupported permission \"" + pt + "\" defined in PermissionList.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Add permission
        /// </summary>
        /// <param name="perm"></param>
        public void AddPermission(PermissionEnum perm)
        {
            requiredPermissions.Add(perm);
        }

        /// <summary>
        /// Get list of added permissions
        /// </summary>
        public IList<PermissionEnum> ConfirmedPermissions
        {
            get { return confirmedPermissions; }
        }

        /// <summary>
        /// Refresh display of the control
        /// </summary>
        public void Refresh()
        {
            if (requiredPermissions.Count > 0)
            {
                string addPermButtonId = PermButton.ClientID;
                string addedPermId = AddedPermissionsHiddenField.ClientID;
                string funcPermsCalled = "PermCalled" + addPermButtonId;
                string funcPermsAdded = "PermsAdded" + addPermButtonId;
                
                StringBuilder html = new StringBuilder();
                html.Append("\n<script type=\"text/javascript\">\n");
                html.Append("  function ");
                html.Append(funcPermsAdded);
                html.Append("(response) {\n");
                html.Append("    var permsHidden = document.getElementById('");
                html.Append(addedPermId);
                html.Append("');\n");
                html.Append("    permsHidden.value = response.perms;\n");
                html.Append("    var btn = document.getElementById('");
                html.Append(addPermButtonId);
                html.Append("');\n");
                html.Append("    if (response.perms != null && response.perms != '') btn.click();\n");
                html.Append("  }\n");
                html.Append("  function " + funcPermsCalled + "() {\n");
                html.Append("   if (graphApiInitialized != true) {\n");
                html.Append("     setTimeout('" + funcPermsCalled + "()', 100);\n");
                html.Append("     return;\n");
                html.Append("   }\n");
                html.Append("   FB.login(");
                html.Append(funcPermsAdded);
                html.Append(", {perms: '");
                int i = 0;
                foreach (PermissionEnum p in requiredPermissions)
                {
                    html.Append(permissionMap[p]);
                    i++;
                    if (i < requiredPermissions.Count)
                    {
                        html.Append(",");
                    }
                }
                html.Append("' });\n");
                html.Append(" }\n");

                if (commandType != CommandTypeEnum.AutoOpen)
                {
                    html.Append("</script>\n");
                    if (commandType == CommandTypeEnum.Link)
                    {
                        html.Append("<a ");
                    }
                    else
                    {
                        html.Append("<input type=\"button\" class=\"button\" ");
                    }

                    html.Append("style=\"cursor:pointer\"");
                    html.Append(" onclick=\"");
                }

                html.Append(funcPermsCalled + "();");
                
                if (commandType != CommandTypeEnum.AutoOpen)
                {
                    if (commandType == CommandTypeEnum.Link)
                    {
                        html.Append("\">");
                        html.Append(text);
                        html.Append("</a>\n");
                    }
                    else
                    {
                        html.Append("\" value=\"");
                        html.Append(text);
                        html.Append("\" />\n");
                    }
                }
                else
                {
                    html.Append("\n</script>\n");
                }
                
                permissionsSpan.InnerHtml = html.ToString();
            }
        }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
            }
        }


        /// <summary>
        /// On added permission
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PermButton_Click(object sender, EventArgs e)
        {
            CreateAddedPermissions();
            if (AddedPermission != null)
            {
                AddedPermission(this, null);
            }
        }

        /// <summary>
        /// Private members
        /// </summary>
        private string text = "Add Permissions";
        private CommandTypeEnum commandType = CommandTypeEnum.Link;
        private IList<PermissionEnum> requiredPermissions = new List<PermissionEnum>();
        private IList<PermissionEnum> confirmedPermissions = new List<PermissionEnum>();
        private static Dictionary<PermissionEnum, string> permissionMap = new Dictionary<PermissionEnum, string>();
        private static Dictionary<string, PermissionEnum> reversePermMap = new Dictionary<string, PermissionEnum>();

        static Permissions()
        {
            permissionMap[PermissionEnum.Email] = "email";
            permissionMap[PermissionEnum.ReadStream] = "read_stream";
            permissionMap[PermissionEnum.PublishStream] = "publish_stream";
            permissionMap[PermissionEnum.OfflineAccess] = "offline_access";
            permissionMap[PermissionEnum.StatusUpdate] = "status_update";
            permissionMap[PermissionEnum.PhotoUpload] = "photo_upload";
            permissionMap[PermissionEnum.CreateEvent] = "create_event";
            permissionMap[PermissionEnum.RsvpEvent] = "rsvp_event";
            permissionMap[PermissionEnum.Sms] = "sms";
            permissionMap[PermissionEnum.VideoUpload] = "video_upload";
            permissionMap[PermissionEnum.CreateNote] = "create_note";
            permissionMap[PermissionEnum.ShareItem] = "share_item";
            permissionMap[PermissionEnum.ReadMailbox] = "read_mailbox";
            permissionMap[PermissionEnum.ReadInsights] = "read_insights";
            permissionMap[PermissionEnum.UserAboutMe] = "user_about_me";
            permissionMap[PermissionEnum.UserActivities] = "user_activities";
            permissionMap[PermissionEnum.UserBirthday] = "user_birthday";
            permissionMap[PermissionEnum.UserEducationHistory] = "user_education_history";
            permissionMap[PermissionEnum.UserEvents] = "user_events";
            permissionMap[PermissionEnum.UserGroups] = "user_groups";
            permissionMap[PermissionEnum.UserHometown] = "user_hometown";
            permissionMap[PermissionEnum.UserInterests] = "user_interests";
            permissionMap[PermissionEnum.UserLikes] = "user_likes";
            permissionMap[PermissionEnum.UserLocation] = "user_location";
            permissionMap[PermissionEnum.UserNotes] = "user_notes";
            permissionMap[PermissionEnum.UserOnlinePresence] = "user_online_presence";
            permissionMap[PermissionEnum.UserPhotoVideoTags] = "user_photo_video_tags";
            permissionMap[PermissionEnum.UserPhotos] = "user_photos";
            permissionMap[PermissionEnum.UserRelationships] = "user_relationships";
            permissionMap[PermissionEnum.UserReligionPolitics] = "user_religion_politics";
            permissionMap[PermissionEnum.UserStatus] = "user_status";
            permissionMap[PermissionEnum.UserVideos] = "user_videos";
            permissionMap[PermissionEnum.UserWebsite] = "user_website";
            permissionMap[PermissionEnum.UserWorkHistory] = "user_work_history";
            permissionMap[PermissionEnum.ReadFriendlists] = "read_friendlists";
            permissionMap[PermissionEnum.ReadRequests] = "read_requests";
            permissionMap[PermissionEnum.FriendsAboutMe] = "friends_about_me";
            permissionMap[PermissionEnum.FriendsActivities] = "friends_activities";
            permissionMap[PermissionEnum.FriendsBirthday] = "friends_birthday";
            permissionMap[PermissionEnum.FriendsEducationHistory] = "friends_education_history";
            permissionMap[PermissionEnum.FriendsEvents] = "friends_events";
            permissionMap[PermissionEnum.FriendsGroups] = "friends_groups";
            permissionMap[PermissionEnum.FriendsInterests] = "friends_interests";
            permissionMap[PermissionEnum.FriendsLikes] = "friends_likes";
            permissionMap[PermissionEnum.FriendsLocation] = "friends_location";
            permissionMap[PermissionEnum.FriendsNotes] = "friends_notes";
            permissionMap[PermissionEnum.FriendsOnlinePresence] = "friends_online_presence";
            permissionMap[PermissionEnum.FriendsPhotoVideoTags] = "friends_photo_video_tags";
            permissionMap[PermissionEnum.FriendsPhotos] = "friends_photos";
            permissionMap[PermissionEnum.FriendsRelationships] = "friends_relationships";
            permissionMap[PermissionEnum.FriendsReligionPolitics] = "friends_religion_politics";
            permissionMap[PermissionEnum.FriendsStatus] = "friends_status";
            permissionMap[PermissionEnum.FriendsVideos] = "friends_videos";
            permissionMap[PermissionEnum.FriendsWebsite] = "friends_website";
            permissionMap[PermissionEnum.FriendsWorkHistory] = "friends_work_history";

            // create reverse map
            foreach (PermissionEnum perm in permissionMap.Keys)
            {
                reversePermMap[permissionMap[perm]] = perm;
            }
        }

        private void CreateAddedPermissions()
        {
            confirmedPermissions.Clear();
            string perms = AddedPermissionsHiddenField.Value;
            foreach (PermissionEnum permKey in permissionMap.Keys)
            {
                if (perms.Contains(permissionMap[permKey]))
                {
                    confirmedPermissions.Add(permKey);
                }
            }
        }
    }
}