' WARNING: 
' The source code of this class can be used and modified to your particular needs. 
' Sharing the class with unregistered users or using it with unregistered websites 
' or Facebook applications is not allowed and violates the rights of intellectual 
' property. 

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text

Namespace FVK
    ''' <summary>
    ''' Facebook Permission control uses to enable user to add some permission to used Facebook application 
    ''' or Facebook Connect web site like send email, status update ...
    ''' </summary>
    Partial Public Class Permissions
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Inform client on added permission
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Public Delegate Sub AddPermissionHandler(ByVal sender As Object, ByVal e As EventArgs)
        Public Event AddedPermission As AddPermissionHandler

        ''' <summary>
        ''' Link Text
        ''' </summary>
        Public WriteOnly Property Text() As String
            Set(ByVal value As String)
                m_text = value
            End Set
        End Property

        ''' <summary>
        ''' Set type of command control(link, button, auto_open). If auto_open is
        ''' set permission popup is open on page load. Default = link.
        ''' </summary>
        Public WriteOnly Property CommandType() As String
            Set(ByVal value As String)
                Select Case value
                    Case "link"
                        m_commandType = CommandTypeEnum.Link
                        Exit Select
                    Case "button"
                        m_commandType = CommandTypeEnum.Button
                        Exit Select
                    Case "auto_open"
                        m_commandType = CommandTypeEnum.AutoOpen
                        Exit Select
                    Case Else
                        Throw New Exception("Invalid command type, supported values are link, button and auto_open")
                End Select
            End Set
        End Property

        ''' <summary>
        ''' Add permission list in string representation separated by comma.
        ''' </summary>
        Public WriteOnly Property PermissionList() As String
            Set(ByVal value As String)
                value.Trim()
                For Each perm As String In value.Split(","c)
                    If perm <> "" Then
                        Dim pt As String = perm.Trim()
                        If reversePermMap.Keys.Contains(pt) Then
                            Dim p As PermissionEnum = reversePermMap(pt)
                            If Not requiredPermissions.Contains(p) Then
                                requiredPermissions.Add(p)
                            End If
                        Else
                            Throw New Exception("Unsupported permission """ & pt & """ defined in PermissionList.")
                        End If
                    End If
                Next
            End Set
        End Property

        ''' <summary>
        ''' Add permission
        ''' </summary>
        ''' <param name="perm"></param>
        Public Sub AddPermission(ByVal perm As PermissionEnum)
            requiredPermissions.Add(perm)
        End Sub

        ''' <summary>
        ''' Get list of added permissions
        ''' </summary>
        Public ReadOnly Property ConfirmedPermissions() As IList(Of PermissionEnum)
            Get
                Return m_confirmedPermissions
            End Get
        End Property

        ''' <summary>
        ''' Refresh display of the control
        ''' </summary>
        Public Sub Refresh()
            If requiredPermissions.Count > 0 Then
                Dim addPermButtonId As String = PermButton.ClientID
                Dim addedPermId As String = AddedPermissionsHiddenField.ClientID
                Dim funcPermsCalled As String = "PermCalled" & addPermButtonId
                Dim funcPermsAdded As String = "PermsAdded" & addPermButtonId

                Dim html As New StringBuilder()
                html.Append(vbLf & "<script type=""text/javascript"">" & vbLf)
                html.Append("  function ")
                html.Append(funcPermsAdded)
                html.Append("(response) {" & vbLf)
                html.Append("    var permsHidden = document.getElementById('")
                html.Append(addedPermId)
                html.Append("');" & vbLf)
                html.Append("    permsHidden.value = response.perms;" & vbLf)
                html.Append("    var btn = document.getElementById('")
                html.Append(addPermButtonId)
                html.Append("');" & vbLf)
                html.Append("    if (response.perms != null && response.perms != '') btn.click();" & vbLf)
                html.Append("  }" & vbLf)
                html.Append("  function " & funcPermsCalled & "() {" & vbLf)
                html.Append("   if (graphApiInitialized != true) {" & vbLf)
                html.Append("     setTimeout('" & funcPermsCalled & "()', 100);" & vbLf)
                html.Append("     return;" & vbLf)
                html.Append("   }" & vbLf)
                html.Append("   FB.login(")
                html.Append(funcPermsAdded)
                html.Append(", {perms: '")
                Dim i As Integer = 0
                For Each p As PermissionEnum In requiredPermissions
                    html.Append(permissionMap(p))
                    i += 1
                    If i < requiredPermissions.Count Then
                        html.Append(",")
                    End If
                Next
                html.Append("' });" & vbLf)
                html.Append(" }" & vbLf)

                If m_commandType <> CommandTypeEnum.AutoOpen Then
                    html.Append("</script>" & vbLf)
                    If m_commandType = CommandTypeEnum.Link Then
                        html.Append("<a ")
                    Else
                        html.Append("<input type=""button"" class=""button"" ")
                    End If

                    html.Append("style=""cursor:pointer""")
                    html.Append(" onclick=""")
                End If

                html.Append(funcPermsCalled & "();")

                If m_commandType <> CommandTypeEnum.AutoOpen Then
                    If m_commandType = CommandTypeEnum.Link Then
                        html.Append(""">")
                        html.Append(m_text)
                        html.Append("</a>" & vbLf)
                    Else
                        html.Append(""" value=""")
                        html.Append(m_text)
                        html.Append(""" />" & vbLf)
                    End If
                Else
                    html.Append(vbLf & "</script>" & vbLf)
                End If

                permissionsSpan.InnerHtml = html.ToString()
            End If
        End Sub

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Prerender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
            If Not Page.IsPostBack Then
                Refresh()
            End If
        End Sub


        ''' <summary>
        ''' On added permission
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub PermButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            CreateAddedPermissions()
            RaiseEvent AddedPermission(Me, Nothing)
        End Sub

        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_text As String = "Add Permissions"
        Private m_commandType As CommandTypeEnum = CommandTypeEnum.Link
        Private requiredPermissions As IList(Of PermissionEnum) = New List(Of PermissionEnum)()
        Private m_confirmedPermissions As IList(Of PermissionEnum) = New List(Of PermissionEnum)()
        Private Shared permissionMap As New Dictionary(Of PermissionEnum, String)()
        Private Shared reversePermMap As New Dictionary(Of String, PermissionEnum)()

        Shared Sub New()
            permissionMap(PermissionEnum.Email) = "email"
            permissionMap(PermissionEnum.ReadStream) = "read_stream"
            permissionMap(PermissionEnum.PublishStream) = "publish_stream"
            permissionMap(PermissionEnum.OfflineAccess) = "offline_access"
            permissionMap(PermissionEnum.StatusUpdate) = "status_update"
            permissionMap(PermissionEnum.PhotoUpload) = "photo_upload"
            permissionMap(PermissionEnum.CreateEvent) = "create_event"
            permissionMap(PermissionEnum.RsvpEvent) = "rsvp_event"
            permissionMap(PermissionEnum.Sms) = "sms"
            permissionMap(PermissionEnum.VideoUpload) = "video_upload"
            permissionMap(PermissionEnum.CreateNote) = "create_note"
            permissionMap(PermissionEnum.ShareItem) = "share_item"
            permissionMap(PermissionEnum.ReadMailbox) = "read_mailbox"
            permissionMap(PermissionEnum.ReadInsights) = "read_insights"
            permissionMap(PermissionEnum.UserAboutMe) = "user_about_me"
            permissionMap(PermissionEnum.UserActivities) = "user_activities"
            permissionMap(PermissionEnum.UserBirthday) = "user_birthday"
            permissionMap(PermissionEnum.UserEducationHistory) = "user_education_history"
            permissionMap(PermissionEnum.UserEvents) = "user_events"
            permissionMap(PermissionEnum.UserGroups) = "user_groups"
            permissionMap(PermissionEnum.UserHometown) = "user_hometown"
            permissionMap(PermissionEnum.UserInterests) = "user_interests"
            permissionMap(PermissionEnum.UserLikes) = "user_likes"
            permissionMap(PermissionEnum.UserLocation) = "user_location"
            permissionMap(PermissionEnum.UserNotes) = "user_notes"
            permissionMap(PermissionEnum.UserOnlinePresence) = "user_online_presence"
            permissionMap(PermissionEnum.UserPhotoVideoTags) = "user_photo_video_tags"
            permissionMap(PermissionEnum.UserPhotos) = "user_photos"
            permissionMap(PermissionEnum.UserRelationships) = "user_relationships"
            permissionMap(PermissionEnum.UserReligionPolitics) = "user_religion_politics"
            permissionMap(PermissionEnum.UserStatus) = "user_status"
            permissionMap(PermissionEnum.UserVideos) = "user_videos"
            permissionMap(PermissionEnum.UserWebsite) = "user_website"
            permissionMap(PermissionEnum.UserWorkHistory) = "user_work_history"
            permissionMap(PermissionEnum.ReadFriendlists) = "read_friendlists"
            permissionMap(PermissionEnum.ReadRequests) = "read_requests"
            permissionMap(PermissionEnum.FriendsAboutMe) = "friends_about_me"
            permissionMap(PermissionEnum.FriendsActivities) = "friends_activities"
            permissionMap(PermissionEnum.FriendsBirthday) = "friends_birthday"
            permissionMap(PermissionEnum.FriendsEducationHistory) = "friends_education_history"
            permissionMap(PermissionEnum.FriendsEvents) = "friends_events"
            permissionMap(PermissionEnum.FriendsGroups) = "friends_groups"
            permissionMap(PermissionEnum.FriendsInterests) = "friends_interests"
            permissionMap(PermissionEnum.FriendsLikes) = "friends_likes"
            permissionMap(PermissionEnum.FriendsLocation) = "friends_location"
            permissionMap(PermissionEnum.FriendsNotes) = "friends_notes"
            permissionMap(PermissionEnum.FriendsOnlinePresence) = "friends_online_presence"
            permissionMap(PermissionEnum.FriendsPhotoVideoTags) = "friends_photo_video_tags"
            permissionMap(PermissionEnum.FriendsPhotos) = "friends_photos"
            permissionMap(PermissionEnum.FriendsRelationships) = "friends_relationships"
            permissionMap(PermissionEnum.FriendsReligionPolitics) = "friends_religion_politics"
            permissionMap(PermissionEnum.FriendsStatus) = "friends_status"
            permissionMap(PermissionEnum.FriendsVideos) = "friends_videos"
            permissionMap(PermissionEnum.FriendsWebsite) = "friends_website"
            permissionMap(PermissionEnum.FriendsWorkHistory) = "friends_work_history"

            ' create reverse map
            For Each perm As PermissionEnum In permissionMap.Keys
                reversePermMap(permissionMap(perm)) = perm
            Next
        End Sub

        Private Sub CreateAddedPermissions()
            m_confirmedPermissions.Clear()
            Dim perms As String = AddedPermissionsHiddenField.Value
            For Each permKey As PermissionEnum In permissionMap.Keys
                If perms.Contains(permissionMap(permKey)) Then
                    m_confirmedPermissions.Add(permKey)
                End If
            Next
        End Sub
    End Class
End Namespace
