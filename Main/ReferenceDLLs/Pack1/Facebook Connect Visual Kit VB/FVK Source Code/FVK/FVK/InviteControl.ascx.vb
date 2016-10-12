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
    ''' Facebook Invite control uses to invite friends on using Facebook application or Facebook Connect web 
    ''' site by sending invite request. An implementation of the control is wrapper around FBML tags adapted 
    ''' for usage as pure ASP.NET control.
    ''' </summary>
    Partial Public Class InviteControl
        Inherits System.Web.UI.UserControl
        ''' <summary>
        ''' Show border or not
        ''' </summary>
        Public WriteOnly Property ShowBorder() As Boolean
            Set(ByVal value As Boolean)
                m_showBorder = value
            End Set
        End Property

        ''' <summary>
        ''' Display email section
        ''' </summary>
        Public WriteOnly Property EmailInvite() As Boolean
            Set(ByVal value As Boolean)
                m_emailInvite = value
            End Set
        End Property

        ''' <summary>
        ''' Display dialog for importing external friends
        ''' </summary>
        Public WriteOnly Property ImportExternalFriends() As Boolean
            Set(ByVal value As Boolean)
                m_importExternalFriends = value
            End Set
        End Property

        ''' <summary>
        ''' Number of rows. Allowed values are from 3 to 10. Default value is 5.
        ''' </summary>
        Public WriteOnly Property Rows() As Integer
            Set(ByVal value As Integer)
                m_rows = value
            End Set
        End Property

        ''' <summary>
        ''' Number of columns. Allowed values are from 2,3 and 15. Default value is 5.
        ''' </summary>
        Public WriteOnly Property Colums() As Integer
            Set(ByVal value As Integer)
                m_colums = value
            End Set
        End Property

        ''' <summary>
        ''' Set comma separated string of friend ID which you don't want to be in invite list
        ''' </summary>
        Public WriteOnly Property ExcludeFriends() As String
            Set(ByVal value As String)
                m_excludeFriends = value
            End Set
        End Property

        ''' <summary>
        ''' IList of friend IDs which you don't want to be in invite list
        ''' </summary>
        Public WriteOnly Property ExcludeFriendsList() As IList(Of Long)
            Set(ByVal value As IList(Of Long))
                If value IsNot Nothing Then
                    Dim i As Integer = 0
                    Dim s As New StringBuilder()
                    For Each id As Long In value
                        i += 1
                        s.Append(id.ToString())
                        If i < value.Count Then
                            s.Append(",")
                        End If
                    Next
                    m_excludeFriends = s.ToString()
                End If
            End Set
        End Property

        ''' <summary>
        ''' URL where application should be redirected, after an invitation is sent.
        ''' Default is application Canvas URL taken from web.config file.
        ''' </summary>
        Public WriteOnly Property ActionUrl() As String
            Set(ByVal value As String)
                m_actionUrl = value
            End Set
        End Property

        ''' <summary>
        ''' URL where user will be redirected after the invite request is accepted.
        ''' If it's not set, ActionUrl is used.
        ''' </summary>
        Public WriteOnly Property AcceptUrl() As String
            Set(ByVal value As String)
                m_acceptUrl = value
            End Set
        End Property

        ''' <summary>
        ''' Main description which will apear on invite request
        ''' </summary>
        Public WriteOnly Property Content() As String
            Set(ByVal value As String)
                m_content = value
            End Set
        End Property

        ''' <summary>
        ''' Application name displayed on send button and invite request title.
        ''' Default is name taken from web.config file
        ''' </summary>
        Public WriteOnly Property AppName() As String
            Set(ByVal value As String)
                m_appName = value
            End Set
        End Property

        ''' <summary>
        ''' Main title of control
        ''' </summary>
        Public WriteOnly Property MainTitle() As String
            Set(ByVal value As String)
                m_mainTitle = value
            End Set
        End Property

        ''' <summary>
        ''' Refresh display of the control
        ''' </summary>
        Public Sub Refresh()
            ' check consistency
            If m_mainTitle Is Nothing Then
                Throw New Exception("Invite Friends Error:  Main Title is not set.")
            End If
            If m_content Is Nothing Then
                Throw New Exception("Invite Friends Error:  Content is not set.")
            End If
            If m_confirmButtonTitle Is Nothing Then
                Throw New Exception("Invite Friends Error:  Confirm Button Title is not set.")
            End If

            ' set defaults
            If m_actionUrl Is Nothing Then
                m_actionUrl = FVKConfig.AppUrl
            End If
            If m_acceptUrl Is Nothing Then
                m_acceptUrl = FVKConfig.AppUrl
            End If
            If m_appName Is Nothing Then
                m_appName = FVKConfig.AppName
            End If

            Dim html As New StringBuilder()
            html.Append("<fb:serverfbml ")
            html.Append("width='" & width.ToString() & "'>")
            html.Append("<script type='text/fbml'>")
            html.Append("<div style='" & cssStyle & "' class='" & cssClass & "'>")
            html.Append("<fb:fbml>")
            html.Append("<fb:request-form  method=""GET"" target=""_top"" action=""")
            html.Append(m_actionUrl)
            html.Append(""" content=""")
            html.Append(m_content)
            html.Append("<fb:req-choice url='")
            html.Append(m_acceptUrl)
            html.Append("' label='")
            html.Append(m_confirmButtonTitle)
            html.Append("' />"" type=""")
            html.Append(m_appName)
            html.Append(""" invite=""true"">")
            html.Append("<fb:multi-friend-selector target=""_top"" condensed=""false"" exclude_ids=""")
            html.Append(m_excludeFriends)
            html.Append("""  actiontext=""")
            html.Append(m_mainTitle)
            html.Append(""" showborder=""")
            html.Append(m_showBorder)
            html.Append(""" rows=""")
            html.Append(m_rows)
            If m_colums < 5 Then
                ' fixing bug in FBML (if columns == 5 it renders as it as 4)
                html.Append(""" cols=""")
                html.Append(m_colums)
            End If
            html.Append(""" import_external_friends=""")
            html.Append(m_importExternalFriends)
            html.Append(""" email_invite=""")
            html.Append(m_emailInvite)
            html.Append(""" />")
            html.Append("</fb:request-form> ")
            html.Append("</fb:fbml>")
            html.Append("</div>")
            html.Append("</script>")
            html.Append("</fb:serverfbml>")

            invitespan.InnerHtml = html.ToString()
        End Sub

        ''' <summary>
        ''' Page Load
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                Refresh()
            End If
        End Sub


        ''' <summary>
        ''' Private members
        ''' </summary>
        Private m_excludeFriends As String = ""
        Private m_actionUrl As String = Nothing
        Private m_acceptUrl As String = Nothing
        Private m_content As String = Nothing
        Private m_confirmButtonTitle As String = "Accept"
        Private m_appName As String = Nothing
        Private m_mainTitle As String = Nothing
        Private m_showBorder As Boolean = True
        Private m_emailInvite As Boolean = True
        Private m_importExternalFriends As Boolean = True
        Private m_rows As Integer = 5
        Private m_colums As Integer = 5
        Private cssStyle As String = ""
        Private cssClass As String = ""
        Private width As Integer = 760


        ''' <summary>
        ''' Obsolete members/methods
        ''' </summary>

        <Obsolete("You shouldn't use this property anymore. Use AppName instead")> _
        Public WriteOnly Property SendButtonTitle() As String
            Set(ByVal value As String)
                m_appName = value
            End Set
        End Property

        <Obsolete("Does not have effect anymore. Title is set depending on lanquage")> _
        Public WriteOnly Property ConfirmButtonTitle() As String
            Set(ByVal value As String)
                m_confirmButtonTitle = value
            End Set
        End Property

    End Class
End Namespace
